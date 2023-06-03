using BackToFiorello.Data;
using BackToFiorello.Models;
using BackToFiorello.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BackToFiorello.Services
{
    public class ProductService : IProductService
    {
        private readonly AppDbContext _context;

        public ProductService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await _context.Products.Include(m => m.ProductImages).ToListAsync();
        }
    }
}
