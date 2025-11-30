using ShopClock.Data.Interfaces;
using ShopClock.Data.Models;
using System.Collections.Generic;

namespace ShopClock.Data.Mocks
{
    public class MockCategory : IClockCategory
    {
        public IEnumerable<Category> allCategories
        {
            get
            {
                return new List<Category>
                {
                    new Category { CategoryName = "Класичні годинники", CategoryDescription = "Традиційні наручні годинники зі стрілками та циферблатом."},
                    new Category { CategoryName = "Спортивні годинники", CategoryDescription = "Водонепроникні годинники для активного відпочинку та спортивних заходів."},
                    new Category { CategoryName = "Смарт-годинники", CategoryDescription = "Годинники з сучасними смарт-функціями, такими як сповіщення та відстеження активності." }
                };
            }
        }
    }
}
