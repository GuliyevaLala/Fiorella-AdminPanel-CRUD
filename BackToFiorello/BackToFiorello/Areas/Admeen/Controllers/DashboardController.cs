using Microsoft.AspNetCore.Mvc;

namespace BackToFiorello.Areas.Admeen.Controllers {

    public class DashboardController : Controller {

        [Area("Admeen")]

        public IActionResult Index()
        {
            return View();
        }
    }
}
