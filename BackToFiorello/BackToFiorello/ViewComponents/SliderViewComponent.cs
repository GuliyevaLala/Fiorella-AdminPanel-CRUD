using BackToFiorello.Data;
using BackToFiorello.Models;
using BackToFiorello.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BackToFiorello.ViewComponents {
public class SliderViewComponent : ViewComponent {
    private readonly AppDbContext _context;

    public SliderViewComponent(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IViewComponentResult> InvokeAsync()
    {

            IEnumerable<Slider> sliders = await _context.Sliders.Where(m => !m.SoftDelete).ToListAsync();

            SliderInfo sliderInfo = await _context.SliderInfos.Where(si => !si.SoftDelete).FirstOrDefaultAsync();

            SliderVM model = new()
            {
                Sliders = sliders,
                SliderInfo = sliderInfo,
            };

            return await Task.FromResult(View(model));
        }
    }
}
