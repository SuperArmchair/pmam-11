namespace ShopClock.Data.Models
{
	public class ShopCartItem
	{
		public int id { get; set; }
		public Clock clock { get; set; }
		public int price { get; set; }
		public string ShopCartId { get; set; }

	}
}
