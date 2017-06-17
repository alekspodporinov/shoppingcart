using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart.BLL.ViewModels
{
    public class ProductCreateViewModel
    {

        public long Id { get; set; }

        [Required]
        [Display(Name = "Опубликовать товар?")]
        public bool Publish { get; set; }

        [Required(ErrorMessage = "Поле не должно быть пустым")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Длина строки должна быть от 3 до 50 символов")]
        [Display(Name = "Заголовок(полное название)")]
        public string Title { get; set; }

        [StringLength(1000)]
        [Display(Name = "Описание")]
        public string Discription { get; set; }

        [StringLength(50, MinimumLength = 3, ErrorMessage = "Длина строки должна быть от 3 до 50 символов")]
        [Required(ErrorMessage = "Поле не должно быть пустым")]
        [Display(Name = "Модель")]
        public string Model { get; set; }

        [StringLength(50, MinimumLength = 3, ErrorMessage = "Длина строки должна быть от 3 до 50 символов")]
        [Required(ErrorMessage = "Поле не должно быть пустым")]
        [Display(Name = "Производить")]
        public string Manufacturer { get; set; }

        [StringLength(50, MinimumLength = 3, ErrorMessage = "Длина строки должна быть от 3 до 50 символов")]
        [Required(ErrorMessage = "Поле не должно быть пустым")]
        [Display(Name = "Серийный номер")]
        public string SerialNumber { get; set; }

        [Required(ErrorMessage = "Поле не должно быть пустым")]
        [Display(Name = "Цена")]
        public decimal Price { get; set; }

        [StringLength(30, MinimumLength = 3, ErrorMessage = "Длина строки должна быть от 3 до 30 символов")]
        [Required(ErrorMessage = "Поле не должно быть пустым")]
        [Display(Name = "Код товара")]
        public string Code { get; set; }
        public long ParentCategoryId { get; set; }
    }
}
