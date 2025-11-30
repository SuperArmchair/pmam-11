using ShopClock.Data.Interfaces;
using ShopClock.Data.Models;

namespace ShopClock.Data.Mocks
{
    public class MockClocks : IAllClocks
    {
        private readonly IClockCategory _categoryClocks = new MockCategory();
        public IEnumerable<Clock> clocks
        {
            get
            {
                return new List<Clock>
                {
                    new Clock
                    {
                        Name = "Fossil",
                        ShortDesc = "Чоловічий годинник",
                        LongDesc ="Шанувальники Fossil – стильні молоді люди, які цінують комфорт, функціональність та високі технології в годиннику.",
                        img = "/img/Fossil.jpg",
                        price = 1000,
                        isFavourite =true,
                        available =true,
                        Category = _categoryClocks.allCategories.First()
                    },
                    new Clock
                    {
                        Name = "Apple Watch Series 7",
                        ShortDesc = "Смарт-годинник від Apple",
                        LongDesc = "Новий Apple Watch Series 7 з великим дисплеєм, широким функціоналом та стильним дизайном.",
                        img = "/img/Apple Watch Series 7.jpg",
                        price = 800,
                        isFavourite = true,
                        available = true,
                        Category = _categoryClocks.allCategories.Last() 
                    },
                    new Clock
                    {
                        Name = "Garmin Forerunner 945",
                        ShortDesc = "Спортивний годинник з GPS",
                        LongDesc = "Garmin Forerunner 945 із вимірюванням пульсу, GPS та розширеними функціями для тренувань.",
                        img = "/img/Garmin Forerunner 945.jpg",
                        price = 700,
                        isFavourite = true,
                        available = true,
                        Category = _categoryClocks.allCategories.ElementAt(1) 
                    },
                    new Clock
                    {
                        Name = "Rolex Submariner",
                        ShortDesc = "Чоловічий механічний годинник",
                        LongDesc = "Іконічний годинник Rolex Submariner із водонепроникністю та стильним дизайном.",
                        img = "/img/Rolex Submariner.jpg",
                        price = 5000,
                        isFavourite = false,
                        available = true,
                        Category = _categoryClocks.allCategories.First() 
                    }
                };
            }
        }
        public IEnumerable<Clock> getFavClocks { get; set; }

        public Clock getObjectClock(int clockId)
        {
            throw new NotImplementedException();
        }
    }

}
