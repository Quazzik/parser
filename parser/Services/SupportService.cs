using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using parser.Models.Entities;
using parser.Services;

namespace UI.Server.Services
{
    public class SupportService
    {
        private readonly DBService _context;

        public SupportService(DBService context)
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
    }
}
