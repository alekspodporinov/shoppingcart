using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart.BLL.ViewModels
{
    public class ProductUpdateViewModel
    {
        public ProductUpdateViewModel()
        {
            Characteristics = new List<CharacteristicValueViewModel>();
            OldPhotoes = new List<PhotoProductViewModel>();
            EditProduct = new ProductCreateViewModel();
            NewPhotoes = new List<PhotoViewModel>();
        }

  //      public long Id { get; set; }

		//[Required(ErrorMessage = "Поле не должно быть пустым")]
		//[StringLength(50, MinimumLength = 3, ErrorMessage = "Длина строки должна быть от 3 до 50 символов")]
		//[Display(Name = "Заголовок(полное название)")]
		//public string Title { get; set; }

		//[StringLength(1000, MinimumLength = 3, ErrorMessage = "Длина строки должна быть от 3 до 1000 символов")]
		//[Required(ErrorMessage = "Поле не должно быть пустым")]
		//[Display(Name = "Описание")]
		//public string Discription { get; set; }

		//[StringLength(50, MinimumLength = 3, ErrorMessage = "Длина строки должна быть от 3 до 50 символов")]
		//[Required(ErrorMessage = "Поле не должно быть пустым")]
		//[Display(Name = "Модель")]
		//public string Model { get; set; }

		//[StringLength(50, MinimumLength = 3, ErrorMessage = "Длина строки должна быть от 3 до 50 символов")]
		//[Required(ErrorMessage = "Поле не должно быть пустым")]
		//[Display(Name = "Производить")]
		//public string Manufacturer { get; set; }

		//[StringLength(50, MinimumLength = 3, ErrorMessage = "Длина строки должна быть от 3 до 50 символов")]
		//[Required(ErrorMessage = "Поле не должно быть пустым")]
		//[Display(Name = "Серийный номер")]
		//public string SerialNumber { get; set; }

		//[Required(ErrorMessage = "Поле не должно быть пустым")]
		//[Display(Name = "Цена")]
		//public decimal Price { get; set; }

		//[StringLength(30, MinimumLength = 3, ErrorMessage = "Длина строки должна быть от 3 до 30 символов")]
		//[Required(ErrorMessage = "Поле не должно быть пустым")]
		//[Display(Name = "Код товара")]
		//public string Code { get; set; }

		//public long ParentCategoryId { get; set; }

		public ProductCreateViewModel EditProduct { get; set; }
        public List<CharacteristicValueViewModel> Characteristics { get; set; }
        public List<PhotoProductViewModel> OldPhotoes { get; set; }
        public List<PhotoViewModel> NewPhotoes { get; set; }

    }
}
