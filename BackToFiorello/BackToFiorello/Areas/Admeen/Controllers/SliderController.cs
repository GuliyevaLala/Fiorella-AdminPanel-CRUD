using BackToFiorello.Areas.Admeen.ViewModels;
using BackToFiorello.Models;
using Microsoft.AspNetCore.Mvc;
using BackToFiorello.Data;
using Microsoft.EntityFrameworkCore;
using BackToFiorello.Helpers;

namespace BackToFiorello.Areas.Admeen.Controllers 
{
    [Area("Admeen")]
    public class SliderController : Controller {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;


        public SliderController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;

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

        [HttpGet]
        public IActionResult Create() {

            return View();  
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SliderCreateVM request)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            if (!request.Image.CheckFileType("image/"))
            {
                ModelState.AddModelError("Image", "This file must be in image format");
                return View();
            }

            if (request.Image.CheckFileSize(200))
            {
                ModelState.AddModelError("Image", "Image size cannot be more than 200 KB");
                return View();
            }

            string fileName = Guid.NewGuid().ToString() + "_" + request.Image.FileName;

            await request.Image.SaveFileAsync(fileName, _env.WebRootPath, "img");

            Slider slider = new()
            {
                Image = fileName
            };

            await _context.Sliders.AddAsync(slider);

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}