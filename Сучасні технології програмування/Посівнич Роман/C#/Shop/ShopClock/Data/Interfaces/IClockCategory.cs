using ShopClock.Data.Models;

namespace ShopClock.Data.Interfaces
{
    public interface IClockCategory
    {
        IEnumerable<Category> allCategories { get; }
    }
}
