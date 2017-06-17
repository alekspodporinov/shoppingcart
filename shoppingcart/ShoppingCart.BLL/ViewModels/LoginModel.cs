using System.ComponentModel.DataAnnotations;

namespace ShoppingCart.BLL.ViewModels
{
    public class LoginModel
    {
        [Required]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
