using Microsoft.AspNetCore.Mvc;
using ShopClock.Data.Interfaces;
using ShopClock.ViewModels;

namespace ShopClock.Controllers
{
	public class HomeController : Controller
	{
		private IAllClocks _clockRep;

		public HomeController(IAllClocks clockRep)
		{
			_clockRep = clockRep;
		}
		public ViewResult Index()
		{
			var homeClocks = new HomeViewModel
			{
				favClocks = _clockRep.getFavClocks
			};
			return View(homeClocks);
		}
	}
}
