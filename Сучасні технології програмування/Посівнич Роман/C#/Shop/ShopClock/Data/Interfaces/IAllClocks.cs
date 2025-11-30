using ShopClock.Data.Models;

namespace ShopClock.Data.Interfaces
{
    public interface IAllClocks
    {
        IEnumerable<Clock> clocks { get; }
        IEnumerable<Clock> getFavClocks { get;  }
        Clock getObjectClock(int clockId);
    }
}
