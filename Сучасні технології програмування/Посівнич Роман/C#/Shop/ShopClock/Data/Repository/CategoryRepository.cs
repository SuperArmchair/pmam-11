using ShopClock.Data.Interfaces;
using ShopClock.Data.Models;

namespace ShopClock.Data.Repository
{
	public class CategoryRepository : IClockCategory
	{
		private readonly AppDbContent appDbContent;

		public CategoryRepository(AppDbContent appDbContent)
		{
			this.appDbContent = appDbContent;
		}

		public IEnumerable<Category> allCategories => appDbContent.Category;
	}
}
