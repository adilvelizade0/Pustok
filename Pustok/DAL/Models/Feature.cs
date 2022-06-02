namespace Pustok.DAL.Models
{
    public class Feature
    {
        public int Id { get; set; }
        public string IconUrl { get; set; }
        public string  Title { get; set; }
        public string SubTitle { get; set; }
        public bool IsDeleted { get; set; }
    }
}