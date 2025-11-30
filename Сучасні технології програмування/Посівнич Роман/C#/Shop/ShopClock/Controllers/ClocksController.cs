using Microsoft.AspNetCore.Mvc;
using ShopClock.Data.Interfaces;
using ShopClock.Data.Models;
using ShopClock.ViewModels;

namespace ShopClock.Controllers
{
	public class ClocksController : Controller
	{
		private readonly IAllClocks _allClocks;
		private readonly IClockCategory _allCategories;

		public ClocksController(IAllClocks IAllClocks, IClockCategory IClockCat)
		{
			_allClocks = IAllClocks;
			_allCategories = IClockCat;
		}


		[Route("Clocks/List")]
		[Route("Clocks/List/{category}")]
		public ViewResult List(string category)
		{
			string _category = category;
			IEnumerable<Clock> clocks = null;
			string currCategory = "";
			if (string.IsNullOrEmpty(category))
			{
				clocks = _allClocks.clocks.OrderBy(i => i.Id);
			}
			else
			{
				if (string.Equals("classic", category, StringComparison.OrdinalIgnoreCase))
				{
					clocks = _allClocks.clocks.Where(i => i.Category.CategoryName.Equals("Класичні годинники")).OrderBy(i => i.Id);
					currCategory = "Класичні годинники";
				}
				else if (string.Equals("sport", category, StringComparison.OrdinalIgnoreCase))
				{
					clocks = _allClocks.clocks.Where(i => i.Category.CategoryName.Equals("Спортивні годинники")).OrderBy(i => i.Id);
					currCategory = "Спортивні годинники";
				}
				else if (string.Equals("smart", category, StringComparison.OrdinalIgnoreCase))
				{
					clocks = _allClocks.clocks.Where(i => i.Category.CategoryName.Equals("Смарт-годинники")).OrderBy(i => i.Id);
					currCategory = "Смарт-годинники";
				}
			}


			var clockObj = new ClocksListViewModel
			{
				allClocks = clocks,
				ClockCategory = currCategory,
			};

			ViewBag.Title = "Сторінка з годинниками";
			return View(clockObj);
		}

	}

}
