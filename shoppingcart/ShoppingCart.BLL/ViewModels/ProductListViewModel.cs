using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingCart.BLL.ViewModels
{
    public class ProductListViewModel
    {
        public long Id { get; set; }
        [Required]
        public bool Publish { get; set; }
        [Display(Name = "Производитель")]
        public string Manufacturer { get; set; }
        [Display(Name = "Модель")]
        public string Model { get; set; }
        [Display(Name = "Серийный номер")]
        public string SerialNumber { get; set; }
        [Display(Name = "Код")]
        public string Code { get; set; }
        [Display(Name = "Цена")]
        public decimal Price { get; set; }
        [Display(Name = "Фото")]
        public string SmallFoto { get; set; }
    }
}
