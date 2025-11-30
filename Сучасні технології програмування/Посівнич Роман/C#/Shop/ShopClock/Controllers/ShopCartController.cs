using Microsoft.AspNetCore.Mvc;
using ShopClock.Data.Interfaces;
using ShopClock.Data.Models;
using ShopClock.Data.Repository;
using ShopClock.ViewModels;

namespace ShopClock.Controllers
{
	public class ShopCartController : Controller
	{
		private  IAllClocks _clockRep;
		private readonly ShopCart _shopCart;

		public ShopCartController(IAllClocks clockRep, ShopCart shopCart)
		{
			_clockRep = clockRep;
			_shopCart = shopCart;
		}

		public ViewResult Index()
		{
			var items = _shopCart.getShopItems();
			_shopCart.listShopItems = items;

			var obj = new ShopCartViewModel
			{
				shopCart = _shopCart,
			};
			return View(obj);
		}

		public RedirectToActionResult addToCart(int id )
		{
			var item = _clockRep.clocks.FirstOrDefault(i=> i.Id == id);
            if (item != null)
            {
				_shopCart.AddToCart(item);
            }
			return RedirectToAction("Index");
        }
        public RedirectToActionResult RemoveFromCart(int clockId)
        {
            var item = _clockRep.clocks.FirstOrDefault(i => i.Id == clockId);
            if (item != null)
            {			
                _shopCart.RemoveFromCart(item);
            }
            return RedirectToAction("Index");
        }

    }
}
