using System.ComponentModel.DataAnnotations;

namespace BackToFiorello.Areas.Admeen.ViewModels {

    public class SliderCreateVM {
        [Required]
        public IFormFile Image { get; set; }
    }
}
