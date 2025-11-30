using Microsoft.AspNetCore.Mvc;
using ShopClock.Data.Interfaces;
using ShopClock.Data.Models;

namespace ShopClock.Controllers
{
	public class OrderController : Controller
	{
		private readonly IAllOrders allOrders;
		private readonly ShopCart shopCart;

		public OrderController(IAllOrders allOrders, ShopCart shopCart)
		{
			this.allOrders = allOrders;
			this.shopCart = shopCart;
		}

		public IActionResult Checkout()
		{
			return View();
		}
		[HttpPost]
		public IActionResult Checkout(Order order)
		{
			shopCart.listShopItems = shopCart.getShopItems();

			if(shopCart.listShopItems.Count == 0) 
			{
				ModelState.AddModelError("", "У вас повинні бути товари!");
				
				return RedirectToAction("Error", "Order");
			}

            if (!ModelState.IsValid)
			{
				allOrders.createOrder(order);
				return RedirectToAction("Complete","Order");
			}
			return View(order);
		}

		public IActionResult Complete()
		{
			return View(new ReturnMessage { Message = "Замовлення успішно оброблене! Чекайте повідомлення!" });
		}

		public IActionResult Error()
		{
			ViewBag.Error = "Спочатку виберіть товар!";
			return View();
		}
	}
}
