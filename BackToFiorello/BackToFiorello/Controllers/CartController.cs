
using BackToFiorello.Data;
using BackToFiorello.Models;
using BackToFiorello.Services.Interfaces;
using BackToFiorello.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace BackToFiorello.Controllers
{
    public class CartController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IHttpContextAccessor _accessor;
        private readonly IBasketService _basketService;

        public CartController(AppDbContext context,
                              IHttpContextAccessor accessor,
                              IBasketService basketService)
        {
            _context = context;
            _accessor = accessor;
            _basketService = basketService;
        }

        public async Task<IActionResult> Index()
        {
            List<BasketDetailVM> basketList = new();

            if (_accessor.HttpContext.Request.Cookies["basket"] != null)
            {
                List<BasketVM> basketDatas = JsonConvert.DeserializeObject<List<BasketVM>>(_accessor.HttpContext.Request.Cookies["basket"]);

                foreach (var item in basketDatas)
                {
                    var dbProduct = await _context.Products.Include(m => m.ProductImages).FirstOrDefaultAsync(m => m.Id == item.Id);

                    if(dbProduct != null)
                    {
                        BasketDetailVM basketDetail = new()
                        {
                            Id = dbProduct.Id,
                            Name = dbProduct.Name,
                            Image = dbProduct.ProductImages.Where(m => m.IsMain).FirstOrDefault().Image,
                            Count = item.Count,
                            Price = dbProduct.Price,
                            TotalPrice = item.Count * dbProduct.Price
                        };

                        basketList.Add(basketDetail);
                    }

                }
            }

            return View(basketList);
        }


        [HttpPost]
        public async Task<IActionResult> AddBasket(int? id)
        {
            if (id is null) return BadRequest();

            Product product = await _context.Products.FindAsync(id);

            if (product is null) return NotFound();

            List<BasketVM> basket = _basketService.GetAll();

            _basketService.AddProduct(basket, product);

            return Ok(basket.Sum(m=>m.Count));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public IActionResult DeleteProductFromBasket(int? id)
        {
            _basketService.DeleteProduct(id);
            return RedirectToAction(nameof(Index));

        }
    }
}
