
using BackToFiorello.Models;
using Microsoft.EntityFrameworkCore;
using static System.Net.Mime.MediaTypeNames;

namespace BackToFiorello.ViewModels {

    public class HomeVM {

        public IEnumerable<Slider> Sliders { get; set; }

        public SliderInfo? SliderInfos { get; set; }
        public IEnumerable<Category> Categories { get; set; }
        public IEnumerable<Product> Products { get; set; }
        public IEnumerable<ProductImage> ProductImages { get; set; }
        public List<About> About { get; set; }
        public IEnumerable<Expert> Expert { get; set; }
        public List<Blog> Blogs { get; set; }
        public List<Instagram> Instagram { get; set; }
        


    }
}
