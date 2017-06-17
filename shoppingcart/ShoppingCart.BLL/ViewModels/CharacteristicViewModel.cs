using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace ShoppingCart.BLL.ViewModels
{
    public class CharacteristicViewModel
    {
        [HiddenInput(DisplayValue = false)]
        public long Id { get; set; }

        [Required(ErrorMessage = "Поле не должно быть пустым")]
        [Display(Name = "Название характеристики")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Длина строки должна быть от 3 до 50 символов")]
        [Remote("CheckCategoryName", "Characteristic", AdditionalFields = "Name,Id", ErrorMessage = "Такое имя уже существует")]
        public string Name { get; set; }

        [Display(Name = "Использовать как фильтр?")]
        public bool Filter { get; set; }

        [HiddenInput(DisplayValue = false)]
        public long ParentCategoryId { get; set; }

        [Display(Name = "Тип значения")]
        [Required(ErrorMessage = "Нужно выбрать одно из значений")]
        public string MetaValue { get; set; }

        [Display(Name = "Мера")]
        public string Measure { get; set; }

        [Required]
        [Display(Name = "Опубликовать?")]
        public bool Publish { get; set; }
    }
}
