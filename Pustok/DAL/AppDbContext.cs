using System;
using Microsoft.EntityFrameworkCore;
using Pustok.DAL.Models;

namespace Pustok.DAL
{
	public class AppDbContext: DbContext
	{
		public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
		{
		}

		public DbSet<Slider> Sliders { get; set; }
		public DbSet<Feature> Features { get; set; }
		public DbSet<Promotion> Promotions { get; set; }
		public DbSet<PromotionTwo> PromotionTwos { get; set; }
	}
}

