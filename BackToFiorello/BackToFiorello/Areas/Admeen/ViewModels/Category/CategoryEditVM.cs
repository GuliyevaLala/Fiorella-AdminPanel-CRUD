using System.ComponentModel.DataAnnotations;

namespace BackToFiorello.Areas.Admeen.ViewModels.Category {

    public class CategoryEditVM {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
