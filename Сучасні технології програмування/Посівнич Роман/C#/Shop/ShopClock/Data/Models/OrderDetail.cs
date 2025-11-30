namespace ShopClock.Data.Models
{
    public class OrderDetail
    {
        public int id { get; set; }
        public int orderId { get; set; }
        public int ClockId  { get; set; }
        public uint price { get; set; }
        public virtual Clock clock { get; set; }
        public virtual Order order { get; set; }

    }
}
