using System.ComponentModel.DataAnnotations;

namespace BackToFiorello.Areas.Admeen.ViewModels.Category {

    public class CategoryCreateVM {
        [Required(ErrorMessage = "Please fill the blank")]
        public string Name { get; set; }
    }
}
