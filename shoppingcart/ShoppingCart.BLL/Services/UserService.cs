using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using ShoppingCart.BLL.DTO;
using ShoppingCart.BLL.Infrastructure;
using ShoppingCart.BLL.Interfaces;
using ShoppingCart.DAL.CustomIdentity;
using ShoppingCart.DAL.Entities;
using ShoppingCart.DAL.Infrastructure;
using ShoppingCart.DAL.Repositories;

namespace ShoppingCart.BLL.Services
{
    /// <summary>
    /// Сервис для авторизации
    /// </summary>
    public class IdentityUserService : IIdentityUserService
    {
        readonly IUnitOfWork _database;
        readonly IIdentityUserRepository _userService;
        readonly IUserProfileRepository _userProfileRepository;

        public IdentityUserService(IUnitOfWork dataBaase, IIdentityUserRepository userService, IUserProfileRepository userProfileRepository)
        {
            _database = dataBaase;
            _userService = userService;
            _userProfileRepository = userProfileRepository;
        }

        public async Task<OperationDetails> Create(UserDto userDto)
        {
            ApplicationUser user = await _userService.UserManager.FindByEmailAsync(userDto.Email);
            if (user == null)
            {
                user = new ApplicationUser { Email = userDto.Email, UserName = userDto.Email };
                await _userService.UserManager.CreateAsync(user, userDto.Password);
                // добавляем роль
                await _userService.UserManager.AddToRoleAsync(user.Id, userDto.Role);
                // создаем профиль клиента
                _userProfileRepository.Add(new UserProfile { Id = user.Id, SurnameName = userDto.SurnameName, Name = userDto.Name });
                
                await _database.SaveAsync();
                return new OperationDetails(true, "Регистрация успешно пройдена", "");
            }
            else
            {
                return new OperationDetails(false, "Пользователь с таким логином уже существует", "Email");
            }
        }

        public async Task<ClaimsIdentity> Authenticate(UserDto userDto)
        {
            ClaimsIdentity claim = null;
            // находим пользователя
            ApplicationUser user = await _userService.UserManager.FindAsync(userDto.Email, userDto.Password);
            // авторизуем его и возвращаем объект ClaimsIdentity
            if (user != null)
                claim = await _userService.UserManager.CreateIdentityAsync(user,
                                            DefaultAuthenticationTypes.ApplicationCookie);
            return claim;
        }

        // начальная инициализация бд
        public async Task SetInitialData(UserDto adminDto, List<string> roles)
        {
            foreach (string roleName in roles)
            {
                var role = await _userService.RoleManager.FindByNameAsync(roleName);
                if (role == null)
                {
                    role = new CustomRole { Name = roleName };
                    await _userService.RoleManager.CreateAsync(role);
                }
            }
            await Create(adminDto);
        }

        public void Dispose()
        {
            _userService.Dispose();
        }
    }
}
