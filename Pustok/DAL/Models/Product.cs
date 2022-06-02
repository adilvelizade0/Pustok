namespace Pustok.DAL.Models
{
    public class Product
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public int AuthorId { get; set; }
        public string Name { get; set; }
        public double SalePrice { get; set; }
        public double CostPrice { get; set; }
        public double DiscountPrice { get; set; }
        public string InfoText { get; set; }
        public string Desc{ get; set; }
        public bool IsNew { get; set; }
        public bool IsDeleted { get; set; }
        public bool 
            IsFeatured { get; set; }
        public Category Category { get; set; }
        public Author Author { get; set; }
    }
}