using System.Collections.Generic;

namespace Pustok.DAL.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsDeleted { get; set; }
        public List<Product> Products { get; set; }
    }
}