namespace BackToFiorello.Models {
    public class Product : BaseEntity {

        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }
        public Category Categories { get; set; }
        public int? DiscountId { get; set; }
        public Discount Discount { get; set; }
        public ICollection<ProductImage> ProductImages { get; set; }



    }
}
