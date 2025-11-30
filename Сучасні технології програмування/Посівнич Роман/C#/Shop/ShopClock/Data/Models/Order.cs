using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;

namespace ShopClock.Data.Models
{
    public class Order
    {

        [BindNever]
        public int id { get; set; }

        [Display(Name = "Введіть ваше ім'я")]
        [MinLength(3, ErrorMessage = "Довжина імені повинна бути більше 3 символів")]
        [MaxLength(25, ErrorMessage = "Довжина імені повинна бути менше 25 символів")]
        [Required(ErrorMessage = "Довжина імені повинна бути більше трьох символів")]
        public string name { get; set; }

        [Display(Name = "Введіть ваше прізвище")]
        [MinLength(3, ErrorMessage = "Довжина прізвища повинна бути більше 3 символів")]
        [MaxLength(25, ErrorMessage = "Довжина прізвища повинна бути менше 25 символів")]
        [Required(ErrorMessage = "Довжина прізвища повинна бути більше трьох символів")]
        public string surname { get; set; }

        [Display(Name = "Введіть ваш номер телефону")]
        [StringLength(15, MinimumLength = 10, ErrorMessage = "Довжина номера телефону повинна бути від 10 до 15 символів")]
        [Required(ErrorMessage = "Довжина номера телефону повинна бути більше десяти символів")]
        public string phone { get; set; }

        [Display(Name = "Введіть ваш email")]
        [StringLength(30, MinimumLength = 15, ErrorMessage = "Довжина email повинна бути від 15 до 30 символів")]
        [Required(ErrorMessage = "Довжина email повинна бути більше десяти символів")]
        [EmailAddress(ErrorMessage = "Введіть коректну адресу електронної пошти")]
        public string email { get; set; }

        [BindNever]
		[ScaffoldColumn(false)]
		public DateTime orderTime { get; set; }
        public List<OrderDetail> orderDetails { get; set; }
    }
}
