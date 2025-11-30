using ShopClock.Data.Models;

namespace ShopClock.Data
{
	public class DBObjects
	{
		public static void Initial(AppDbContent content)
		{		

			if (!content.Category.Any()) 
			{
				content.Category.AddRange(Categories.Select(c => c.Value));
			}
			if (!content.Clocks.Any())
			{
				content.AddRange(
					new Clock
					{
						Name = "Fossil",
						ShortDesc = "Чоловічий годинник",
						LongDesc = "Шанувальники Fossil – стильні молоді люди, які цінують комфорт, функціональність та високі технології в годиннику.",
						img = "/img/Fossil.jpg",
						price = 10000,
						isFavourite = false,
						available = true,
						Category = Categories["Класичні годинники"]
					},
					new Clock
					{
						Name = "Apple Watch Series 7",
						ShortDesc = "Смарт-годинник від Apple",
						LongDesc = "Новий Apple Watch Series 7 з великим дисплеєм, широким функціоналом та стильним дизайном.",
						img = "/img/Apple Watch Series 7.jpg",
						price = 8000,
						isFavourite = true,
						available = true,
						Category = Categories["Смарт-годинники"]
					},
					new Clock
					{
						Name = "Garmin Forerunner 945",
						ShortDesc = "Спортивний годинник з GPS",
						LongDesc = "Garmin Forerunner 945 із вимірюванням пульсу, GPS та розширеними функціями для тренувань.",
						img = "/img/Garmin Forerunner 945.jpg",
						price = 7000,
						isFavourite = false,
						available = true,
						Category = Categories["Спортивні годинники"]
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
						Category = Categories["Класичні годинники"]
					},
                    new Clock
                    {
                        Name = "Omega Seamaster Aqua Terra",
                        ShortDesc = "Чоловічий годинник",
                        LongDesc = "Omega Seamaster Aqua Terra - годинник з водонепроникністю та стильним дизайном.",
                        img = "/img/Omega_Seamaster_Aqua_Terra.jpg",
                        price = 5500,
                        isFavourite = false,
                        available = true,
                        Category = Categories["Класичні годинники"]
                    },
new Clock
{
    Name = "Cartier Tank Solo",
    ShortDesc = "Жіночий годинник",
    LongDesc = "Cartier Tank Solo - класичний та елегантний годинник для жінок.",
    img = "/img/Cartier_Tank_Solo.jpg",
    price = 3800,
    isFavourite = false,
    available = true,
    Category = Categories["Класичні годинники"]
},


new Clock
{
    Name = "Suunto 9 Baro",
    ShortDesc = "Спортивний годинник з альтиметром",
    LongDesc = "Suunto 9 Baro - годинник з високоточним альтиметром для альпінізму та гірських тренувань.",
    img = "/img/Suunto_9_Baro.jpg",
    price = 6000,
    isFavourite = false,
    available = true,
    Category = Categories["Спортивні годинники"]
},
new Clock
{
    Name = "Adidas Process_SP1",
    ShortDesc = "Спортивний годинник для бігу",
    LongDesc = "Adidas Process_SP1 - годинник із функціями для бігу та підсумками тренувань.",
    img = "/img/Adidas_Process_SP1.jpg",
    price = 1200,
    isFavourite = false,
    available = true,
    Category = Categories["Спортивні годинники"]
},


new Clock
{
    Name = "Samsung Galaxy Watch 4",
    ShortDesc = "Смарт-годинник від Samsung",
    LongDesc = "Samsung Galaxy Watch 4 - сучасний смарт-годинник з функціями для здоров'я та фітнесу.",
    img = "/img/Samsung_Galaxy_Watch_4.jpg",
    price = 2500,
    isFavourite = false,
    available = true,
    Category = Categories["Смарт-годинники"]
},
new Clock
{
    Name = "Fitbit Versa 3",
    ShortDesc = "Спортивний смарт-годинник",
    LongDesc = "Fitbit Versa 3 - годинник із великим дисплеєм та функціями для відстеження активності.",
    img = "/img/Fitbit_Versa_3.jpg",
    price = 1800,
    isFavourite = false,
    available = true,
    Category = Categories["Смарт-годинники"]
},
new Clock
{
    Name = "Seiko Presage",
    ShortDesc = "Чоловічий годинник",
    LongDesc = "Seiko Presage - годинник з класичним дизайном та автоматичним механізмом.",
    img = "/img/Seiko_Presage.jpg",
    price = 1200,
    isFavourite = true,
    available = true,
    Category = Categories["Класичні годинники"]
},
new Clock
{
    Name = "Citizen Eco-Drive",
    ShortDesc = "Жіночий годинник",
    LongDesc = "Citizen Eco-Drive - екологічний годинник для жінок із сонячним панеллю.",
    img = "/img/Citizen_Eco-Drive.jpg",
    price = 5500,
    isFavourite = false,
    available = true,
    Category = Categories["Класичні годинники"]
},
new Clock
{
    Name = "Casio G-Shock",
    ShortDesc = "Спортивний годинник",
    LongDesc = "Casio G-Shock - знаменитий спортивний годинник із високою міцністю до ударів.",
    img = "/img/Casio_G-Shock.jpg",
    price = 1000,
    isFavourite = false,
    available = true,
    Category = Categories["Спортивні годинники"]
},
new Clock
{
    Name = "Garmin Fenix 6",
    ShortDesc = "Спортивний годинник для екстремальних умов",
    LongDesc = "Garmin Fenix 6 - високотехнологічний годинник для екстремальних тренувань та подорожей.",
    img = "/img/Garmin_Fenix_6.jpg",
    price = 8000,
    isFavourite = false,
    available = true,
    Category = Categories["Спортивні годинники"]
},
new Clock
{
    Name = "Huawei Watch GT 3",
    ShortDesc = "Смарт-годинник від Huawei",
    LongDesc = "Huawei Watch GT 3 - стильний смарт-годинник з великим обсягом функцій та тривалим часом роботи від акумулятора.",
    img = "/img/Huawei_Watch_GT_3.jpg",
    price = 3000,
    isFavourite = true,
    available = true,
    Category = Categories["Смарт-годинники"]
},
new Clock
{
    Name = "Xiaomi Mi Band 6",
    ShortDesc = "Фітнес-браслет",
    LongDesc = "Xiaomi Mi Band 6 - бюджетний фітнес-браслет із функціями відстеження активності та серцевого ритму.",
    img = "/img/Xiaomi_Mi_Band_6.jpg",
    price = 4000,
    isFavourite = false,
    available = true,
    Category = Categories["Смарт-годинники"]
}
                    );
			}
			content.SaveChanges();
			}
		private static Dictionary<string, Category> category;
		public static Dictionary<string, Category> Categories
		{
			get 
			{
				if(category == null) 
				{
					var list = new Category[]
					{
					new Category { CategoryName = "Класичні годинники", CategoryDescription = "Традиційні наручні годинники зі стрілками та циферблатом."},
					new Category { CategoryName = "Спортивні годинники", CategoryDescription = "Водонепроникні годинники для активного відпочинку та спортивних заходів."},
					new Category { CategoryName = "Смарт-годинники", CategoryDescription = "Годинники з сучасними смарт-функціями, такими як сповіщення та відстеження активності." }
					};
					category = new Dictionary<string, Category>();
					foreach(Category element in list)
					{
						category.Add(element.CategoryName, element);
					}
				}
				return category;
			}
		}
	}
}
