using BackToFiorello.Areas.Admeen.ViewModels;
using BackToFiorello.Models;
using Microsoft.AspNetCore.Mvc;
using BackToFiorello.Data;
using Microsoft.EntityFrameworkCore;

namespace BackToFiorello.Areas.Admeen.Controllers 
{
    [Area("Admeen")]
    public class SliderController : Controller {
        private readonly AppDbContext _context;

        public SliderController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            List<SliderVM> sliderList = new();

            IEnumerable<Slider> sliders = await _context.Sliders.ToListAsync(); 

            foreach (Slider slider in sliders)
            {
                SliderVM model = new()
                {
                    Id = slider.Id,
                    Image = slider.Image,
                    CreateDate = slider.CreatedDate.ToString("dd-MM-yyyy")
                };

                sliderList.Add(model);
            }

            return View(sliderList);
        }


        [HttpGet]
        public async Task<IActionResult> Detail(int? id)
        {
            if (id is null) return BadRequest();

            Slider dbSlider = await _context.Sliders.FirstOrDefaultAsync(m => m.Id == id);

            if (dbSlider is null) return NotFound();

            SliderDetailVM model = new()
            {
                Image = dbSlider.Image,
                CreateDate = dbSlider.CreatedDate.ToString("dd-MM-yyyy"),
            };

            return View(model);


        }

    }
}