using BackToFiorello.Areas.Admeen.ViewModels.Category;
using BackToFiorello.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BackToFiorello.Areas.Admeen.Controllers {

    [Area("Admeen")]
    public class ArchiveController : Controller {
        private readonly AppDbContext _context;

        public ArchiveController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Categories()
        {
            var datas = await _context.Categories.IgnoreQueryFilters().Where(m => m.SoftDelete).ToListAsync();   
            List<CategoryVM> list = new();

            foreach (var item in datas)
            {
                list.Add(new CategoryVM
                {
                    Id = item.Id,
                    Name = item.Name,
                });
            }

            return View(list);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ExractCategory(int id)
        {
            var existCategory = await _context.Categories.IgnoreQueryFilters().FirstOrDefaultAsync(m => m.Id == id);

            existCategory.SoftDelete = false;

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Categories));
        }
    }
}