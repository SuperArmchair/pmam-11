using Microsoft.EntityFrameworkCore;
using ShopClock.Data.Interfaces;
using ShopClock.Data.Models;

namespace ShopClock.Data.Repository
{
	public class ClockRepository : IAllClocks
	{

		private readonly AppDbContent appDbContent;

		public ClockRepository(AppDbContent appDbContent)
		{
			this.appDbContent = appDbContent;
		}

		public IEnumerable<Clock> clocks => appDbContent.Clocks.Include(c=> c.Category);

		public IEnumerable<Clock> getFavClocks=> appDbContent.Clocks.Where(p => p.isFavourite).Include(c=> c.Category);

		public Clock getObjectClock(int clockId) => appDbContent.Clocks.FirstOrDefault(p => p.Id == clockId);
	}
}
