using Microsoft.EntityFrameworkCore;
using ShopClock.Data.Models;

namespace ShopClock.Data
{
	public class AppDbContent : DbContext
	{
		public AppDbContent(DbContextOptions<AppDbContent> options) : base(options) { }

		public DbSet<Clock> Clocks { get; set; }
		public DbSet<Category> Category { get; set; }
		public DbSet<ShopCartItem> ShopCartItems { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<OrderDetail> OrderDetail { get; set; }

    }
}
