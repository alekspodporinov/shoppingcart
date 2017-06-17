using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace ShoppingCart.BLL.ViewModels
{
    public class CategoryViewModel
    {
        public long Id { get; set; }
        public long? ParentCategoryId { get; set; }
        [Required]
        [Display(Name = "Опубликовать категорию?")]//TODO:Подумать на счет каталогов!!!(начальная категория)
        public bool Publish { get; set; }
        [Required(ErrorMessage = "Поле не должно быть пустым")]
        [Display(Name = "Название категории")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Длина строки должна быть от 3 до 50 символов")]
        [Remote("CheckCategoryName", "Category",AdditionalFields = "Name,Id", ErrorMessage = "Такое имя уже существует")]
        public string Name { get; set; }
        [StringLength(1000)]
        [Display(Name = "Описание")]
        public string Discription { get; set; }
    }
}
