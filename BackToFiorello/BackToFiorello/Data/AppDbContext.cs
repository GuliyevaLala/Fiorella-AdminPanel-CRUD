
using BackToFiorello.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;

namespace BackToFiorello.Data {


    public class AppDbContext :DbContext {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Slider> Sliders { get; set; }
        public DbSet<SliderInfo> SliderInfos { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }
        public DbSet<About> About { get; set; }
        public DbSet<Expert> Expert { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Instagram> Instagram { get; set; }
        public DbSet<Discount> Discounts { get; set; }
        public DbSet<Setting> Settings { get; set; }
        public object Experts { get; internal set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasQueryFilter(m => !m.SoftDelete);
            modelBuilder.Entity<Slider>().HasQueryFilter(m => !m.SoftDelete);
            modelBuilder.Entity<Category>().HasQueryFilter(m => !m.SoftDelete);

            modelBuilder.Entity<Setting>().HasData(
            new Setting
            {
                Id = 1,
                Key = "HeaderLogo",
                Value = "logo.png",
            },
            new Setting
            {
                Id = 2,
                Key = "Phone",
                Value = "7456834857634",
            },
            new Setting
            {
                Id = 3,
                Key = "Email",
                Value = "fiorello@gmail.com",
            });

        }


    }
}
