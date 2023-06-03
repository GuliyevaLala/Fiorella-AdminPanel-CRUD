using BackToFiorello.Data;
using BackToFiorello.Models;
using BackToFiorello.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BackToFiorello.Controllers
{
    public class ProductController : Controller
    {
        private readonly AppDbContext _context;

        public ProductController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(int? id)
        {
            if (id is null) return BadRequest();

            Product product = await _context.Products.Include(m=>m.Discount).Include(m=>m.ProductImages).Include(m=>m.Categories).Where(m=>!m.SoftDelete).FirstOrDefaultAsync(x => x.Id == id);

            if(product is null) return NotFound();

            ProductDetailVM model = new()
            {
                Id = product.Id,
                Name = product.Name,
                CategoryName = product.Categories.Name,
                ActualPrice = product.Price,
                DiscountPrice = product.Price - (product.Price * product.Discount.Percent)/100,
                Percent = product.Discount.Percent,
                Description = product.Description,
                ProductImages = product.ProductImages.ToList()
            };

            return View(model);
        }
    }
}
