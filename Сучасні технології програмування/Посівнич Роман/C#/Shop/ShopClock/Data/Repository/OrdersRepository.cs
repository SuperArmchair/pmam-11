using ShopClock.Data.Interfaces;
using ShopClock.Data.Models;

namespace ShopClock.Data.Repository
{
    public class OrdersRepository : IAllOrders
    {
        private readonly AppDbContent appDbContent;
        private readonly ShopCart shopCart;

        public OrdersRepository(AppDbContent appDbContent, ShopCart shopCart)
        {
            this.appDbContent = appDbContent;
            this.shopCart = shopCart;
        }
        public void createOrder(Order order)
        {
            order.orderTime = DateTime.Now;
            appDbContent.Order.Add(order);
            appDbContent.SaveChanges();
            var items = shopCart.listShopItems;

            foreach(var el in items) 
            {
                var orderDetail = new OrderDetail() {
                    ClockId =el.clock.Id,
                    orderId = order.id,
                    price = el.clock.price
                };
                appDbContent.OrderDetail.Add(orderDetail);
                shopCart.RemoveFromCart(el.clock);
            }            		
		}
    }
}
