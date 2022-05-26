namespace Pustok.DAL.Models
{
    public class Promotion
    {
        public int Id { get; set; }
        public string RedirectUrl { get; set; }
        public bool IsDeleted { get; set; }
        public string ImgUrl { get; set; }
    }
}