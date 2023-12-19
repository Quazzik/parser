using Microsoft.EntityFrameworkCore;
using parser.Models.Entities;
using System.Text.RegularExpressions;

namespace parser.Services.Parsers
{
    public partial class CersanitParserService : IParserService
    {
        private Regex regex = CersanitRegex();
        private readonly DBService _context;
        private readonly HTTPService _http;
        public CersanitParserService(DBService context)
        {
            _context = context;
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

        public async Task<bool> UpdatePrices()
        {
            try
            {
                var cersanitProducts = await _context.Products.Where(x => x.Shop.ID == 1).ToListAsync();
                foreach (var product in cersanitProducts)
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
        [GeneratedRegex(@"")]
        private static partial Regex CersanitRegex();
    }
}
