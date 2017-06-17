using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.Owin.Security;
using ShoppingCart.BLL.DTO;
using ShoppingCart.BLL.Infrastructure;
using ShoppingCart.BLL.Interfaces;
using ShoppingCart.BLL.ViewModels;

namespace ShoppingCart.WEB.Controllers
{
    public class AccountController : Controller
    {
        readonly IIdentityUserService _userService;

        public AccountController(IIdentityUserService userService)
        {
            _userService = userService;
        }

        private IAuthenticationManager AuthenticationManager => HttpContext.GetOwinContext().Authentication;

        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginModel model, string returnUrl)
        {
            await _userService.SetInitialData(new UserDto
            {
                Email = "aleks.podp@gmail.com",
                UserName = "aleks.podp@gmail.com",
                Password = "aleks.podp@gmail.com",
                Name = "aleks.podp@gmail.com",
                SurnameName = "aleks.podp@gmail.com",
                Role = "admin",
            }, new List<string> {"user", "admin"});

            if (ModelState.IsValid)
            {
                var userDto = new UserDto { Email = model.Email, Password = model.Password };
                var claim = await _userService.Authenticate(userDto);
                if (claim == null)
                {
                    ModelState.AddModelError("", "Неверный логин или пароль.");
                }
                else
                {
                    AuthenticationManager.SignOut();
                    AuthenticationManager.SignIn(new AuthenticationProperties
                    {
                        IsPersistent = true
                    }, claim);
                    return RedirectToAction("Index", "Home");
                }
            }
            return View(model);
        }
        public ActionResult LoginAdmin()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> LoginAdmin(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var userDto = new UserDto { Email = model.Email, Password = model.Password };
                var claim = await _userService.Authenticate(userDto);
                if (claim == null)
                {
                    ModelState.AddModelError("", "Неверный логин или пароль.");
                }
                else
                {
                    AuthenticationManager.SignOut();
                    AuthenticationManager.SignIn(new AuthenticationProperties
                    {
                        IsPersistent = true
                    }, claim);
                    return RedirectToAction("Index", "Panel", new { area = "Admin" });
                }
            }
            return View(model);
        }

        public ActionResult Logout()
        {
            AuthenticationManager.SignOut();
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(RegisterModel model)
        {
            await _userService.SetInitialData(new UserDto
            {
                Email = "aleks.podp@gmail.com",
                UserName = "aleks.podp@gmail.com",
                Password = "aleks.podp@gmail.com",
                Name = "aleks.podp@gmail.com",
                SurnameName = "aleks.podp@gmail.com",
                Role = "admin",
            }, new List<string> { "user", "admin" });

            if (ModelState.IsValid)
            {
                var userDto = new UserDto
                {
                    Email = model.Email,
                    Password = model.Password,
                    Address = model.SurnameName,
                    Name = model.Name,
                    Role = "user"
                };
                OperationDetails operationDetails = await _userService.Create(userDto);
                if (operationDetails.Succedeed)
                    return View("SuccessRegister");
                else
                    ModelState.AddModelError(operationDetails.Property, operationDetails.Message);
            }
            return View(model);
        }

    }
}