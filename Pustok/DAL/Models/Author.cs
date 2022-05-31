using System.Collections.Generic;

namespace Pustok.DAL.Models
{
    public class Author
    {
        public int Id { get; set; }
        public string Fullname { get; set; }
        public bool IsDeleted { get; set; }
        public List<Product> Products { get; set; }
    }
}