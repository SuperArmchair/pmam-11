using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace ShopClock.Data.Models
{
	public class ShopCart
	{
		private readonly AppDbContent appDbContent;

		public ShopCart(AppDbContent appDbContent)
		{
			this.appDbContent = appDbContent;
		}
		public string ShopCartId { get; set; }
		public List<ShopCartItem> listShopItems { get; set; }

		public static ShopCart GetCart(IServiceProvider services)
		{
			ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
			var context = services.GetService<AppDbContent>();
			string shopCartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();

			session.SetString("CartId", shopCartId);

			return new ShopCart(context) { ShopCartId = shopCartId };
		}

		public void AddToCart(Clock clock)
		{
			appDbContent.ShopCartItems.Add(new ShopCartItem
			{
				ShopCartId = ShopCartId,
				clock = clock,
				price = clock.price
			});
			appDbContent.SaveChanges();
		}

		public List<ShopCartItem> getShopItems()
		{
			return appDbContent.ShopCartItems.Where(c => c.ShopCartId ==ShopCartId).Include(s=>s.clock).ToList(); 
		}
		public void RemoveFromCart(Clock clock)
		{
			var cartItem = appDbContent.ShopCartItems.FirstOrDefault(c => c.ShopCartId == ShopCartId && c.clock.Id == clock.Id);

			if (cartItem != null)
			{
                appDbContent.ShopCartItems.Remove(cartItem);
				appDbContent.SaveChanges();
			}
		}


	}
}
