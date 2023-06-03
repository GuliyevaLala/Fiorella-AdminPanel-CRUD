using BackToFiorello.Data;
using BackToFiorello.Models;
using BackToFiorello.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Reflection.Metadata;
using System.Xml.Linq;

namespace BackToFiorello.Controllers {
    public class HomeController : Controller {
        private readonly AppDbContext _context;

        public HomeController(AppDbContext context)
        {
            _context = context;
        }


        public async Task<IActionResult> Index()
        {
            

            List<Blog> blogs = await _context.Blogs.Where(b => !b.SoftDelete).ToListAsync();

            //IEnumerable<Product> products = await _context.Products.Include(p=>p.ProductImages).Take(8).Where(pi => !pi.SoftDelete).ToListAsync();
            IEnumerable<Product> products = await _context.Products.Where(pi => !pi.SoftDelete).Include(p=>p.ProductImages).Take(8).ToListAsync();

            IEnumerable<Category> categories = await _context.Categories.Where(c => !c.SoftDelete).ToListAsync();

            List<About> about = await _context.About.Where(a => !a.SoftDelete).ToListAsync();

            IEnumerable<Expert> experts = await _context.Expert.Where(e => !e.SoftDelete).ToListAsync();

            List<Instagram> instagram = await _context.Instagram.Where(i => !i.SoftDelete).ToListAsync();

            HomeVM model = new()
            {
            
                Blogs = blogs,
                Categories = categories,
                Products  = products,
                About = about,
                Expert = experts,
                Instagram = instagram
            };

            return View(model);
        }


    }
}