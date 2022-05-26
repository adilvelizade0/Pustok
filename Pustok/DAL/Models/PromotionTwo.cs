namespace Pustok.DAL.Models
{
    public class PromotionTwo
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string RedirectUrl { get; set; }
        public string RedirectText { get; set; }
        public bool IsDeleted { get; set; }
        public string ImgUrl { get; set; }
        public  string Title2 { get; set; }
        public bool isSmall { get; set; }
    }
}