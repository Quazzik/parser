using Microsoft.EntityFrameworkCore;
using parser.Models.Entities;
using System.Security.Cryptography.Xml;
using System.Text.RegularExpressions;

namespace parser.Services.Parsers
{
    public partial class NeptunParserService : IParserService
    {
        private Regex regex = CersanitRegex();
        private readonly MyApplicationContext _context;
        private readonly HTTPService _http;

        public NeptunParserService(MyApplicationContext context, HTTPService http)
        {
            _context = context;
            _http = http;
        }

        public async Task<uint> GetPriceAsync(string url)
        {
            string html = await _http.GetHTMLAsync(url);
            return Parse(html);
        }

        public async Task<List<Product>> GetProductAsync()
        {
            return await _context.Products.Where(x => x.Shop.ID == 2).Include(x=>x.Shop).Include(x=> x.Category).ToListAsync();
        }

        public async Task<bool> UpdatePrices()
        {
            try
            {
                var neptunProducts = await _context.Products.Where(x => x.Shop.ID == 2).ToListAsync();
                foreach (var product in neptunProducts)
                {
                    var newPrice = await GetPriceAsync(product.Url);
                    product.Price = newPrice;
                    _context.Products.Update(product);
                }
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        private uint Parse(string url)
        {
            var price = regex.Match(url).Groups[1].Value.Replace(" ", "");
            return uint.TryParse(price, out var priceinteger) ? priceinteger : 0;
        }

        [GeneratedRegex(@"<div class=""[a-zA-Z\-]*product-price[a-zA-Z\-]*"">\s*(\d*\s*\d*\s*\d+)")]
        private static partial Regex CersanitRegex();
    }
}
