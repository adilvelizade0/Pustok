using System;
namespace Pustok.DAL.Models
{
	public class Slider
	{
		public int Id { get; set; }
		public string Title1 { get; set; }
		public string Title2 { get; set; }
		public string Description { get; set; }
		public string ImageUrl { get; set; }
		public string RedirectUrl { get; set; }
		public string RedirectText { get; set; }
		public bool IsDeleted { get; set; }
		public string position { get; set; }
	}
}

