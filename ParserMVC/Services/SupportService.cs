using Microsoft.EntityFrameworkCore;
using parser.Models.Entities;
using parser.Services;
using ParserMVC.DataModels;

namespace UI.Server.Services
{
    public class SupportService
    {
        private readonly MyApplicationContext _context;

        public SupportService(MyApplicationContext context)
        {
            _context = context;
        }

        public async Task<List<Category>> GetCategoriesAsync()
        {
            return await _context.Categories.ToListAsync();
        }

        public async Task<List<Shop>> GetShopsAsync()
        {
            return await _context.Shops.ToListAsync();
        }

        public async Task<List<TransferDataModel>> GetDataModelsAsync()
        {

            List<TransferDataModel> transferDataModels = _context.Products
        .Join(
            _context.Shops,
            product => product.ShopID,
            shop => shop.ID,
            (product, shop) => new { Product = product, ShopName = shop.ShopName }
        )
        .Join(
            _context.Categories,
            data => data.Product.CategoryID,
            category => category.ID,
            (data, category) => new TransferDataModel
            {
                RowProduct = data.Product,
                ShopName = data.ShopName,
                CategoryName = category.Name
            }
        )
        .ToList();
            return (transferDataModels);
        }
    }
}
