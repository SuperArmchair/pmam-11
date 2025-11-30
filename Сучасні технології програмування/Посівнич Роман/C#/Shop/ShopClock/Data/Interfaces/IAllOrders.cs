using ShopClock.Data.Models;

namespace ShopClock.Data.Interfaces
{
    public interface IAllOrders
    {
        void createOrder(Order order);
    }
}
