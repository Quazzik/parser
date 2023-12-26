using Microsoft.EntityFrameworkCore;
using parser.Models.Entities;
using parser.Services.Parsers;
using System.Text.RegularExpressions;

namespace parser.Services.Parsers
{
    public partial class FixenParserService : IParserService
    {
        private Regex regex = FixenRegex();
        private readonly MyApplicationContext _context;
        private readonly HTTPService _http;

        public FixenParserService(MyApplicationContext context, HTTPService http)
        {
            _context = context;
            _http = http;
        }

        public async Task<bool> UpdatePrices()
        {
            try
            {
                var fixenProducts = await _context.Products.Where(x => x.Shop.ID == 1).ToListAsync();
                foreach (var product in fixenProducts)
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
            var price = regex.Match(url).Groups[1].Value;
            return uint.TryParse(price, out var priceinteger) ? priceinteger : 0;
        }

        public async Task<uint> GetPriceAsync(string url)
        {
            string html = await _http.GetHTMLAsync(url);
            return Parse(html);
        }

        public async Task<List<Product>> GetProductAsync()
        {
            return await _context.Products.Where(x => x.Shop.ID == 1).ToListAsync();
        }

        [GeneratedRegex(@"<p class=""[a-zA-Z\s]*price[a-zA-Z\s]*"">[<a-zA-Z>\\]*<span class=""[a-zA-Z\s]*woocommerce-Price-amount amount[a-zA-Z\s]*""><bdi>(\d+)")]
        private static partial Regex FixenRegex();
    }
}
