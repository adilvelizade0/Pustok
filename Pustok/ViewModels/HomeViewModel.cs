using System.Collections.Generic;
using Pustok.DAL.Models;

namespace Pustok.ViewModels
{
    public class HomeViewModel
    {
        public List<Slider> Sliders { get; set; }
        public List<Feature> Features { get; set; }
        public List<Promotion> Promotions { get; set; }
        public List<PromotionTwo> PromotionTwos { get; set; }
        public List<Product> FeaturedProducts { get; set; }
        public List<Product> NewProduct { get; set; }
        public List<Product> DiscountProduct { get; set; }
        public List<Category> Categories { get; set; }
    }
}