using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using ShoppingCart.BLL.DTO;
using ShoppingCart.BLL.Infrastructure;

namespace ShoppingCart.BLL.Interfaces
{
    public interface IIdentityUserService : IDisposable
    {
        Task<OperationDetails> Create(UserDto userDto);
        Task<ClaimsIdentity> Authenticate(UserDto userDto);
        Task SetInitialData(UserDto adminDto, List<string> roles);
    }
}
