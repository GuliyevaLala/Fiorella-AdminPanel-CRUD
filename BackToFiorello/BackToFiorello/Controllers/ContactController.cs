
using BackToFiorello.Data;
using BackToFiorello.Models;
using BackToFiorello.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Fiorello.Controllers
{
    public class ContactController : Controller
    {
        private readonly AppDbContext _context;

        public ContactController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()

        {

            IEnumerable<Expert> experts = await _context.Expert.Where(m => !m.SoftDelete).ToListAsync();

            ContactVM model = new()
            {
                Experts = experts
            };

            return View(model);
        }
    }
}
