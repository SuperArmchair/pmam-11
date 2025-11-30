namespace ShopClock.Data.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }

        public string CategoryDescription { get; set; }

        public List<Clock> clocks { get; set; }
    }
}
