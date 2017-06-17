using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace ShoppingCart.BLL.ViewModels
{

    public class CharacteristicValueViewModel
    {
        public long Id { get; set; }
        public long CharacteristicId { get; set; }
        [Display(Name = "Характеристика")]
        public string Name { get; set; }
        [Display(Name = "Значение")]
        [Required(ErrorMessage = "Поле не должно быть пустым")]
        public string Value { get; set; }
        [Display(Name = "Мера")]
        public string Measure { get; set; }
    }
}
