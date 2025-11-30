using ShopClock.Data.Models;

namespace ShopClock.ViewModels
{
	public class ClocksListViewModel
	{
		public IEnumerable<Clock> allClocks { get; set; }

		public string ClockCategory { get; set; }
	}
}
