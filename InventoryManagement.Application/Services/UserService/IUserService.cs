using InventoryManagement.Application.DTOs;
using InventoryManagement.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace InventoryManagement.Application.Services.UserService
{
    public interface IUserService : IService<User, UserDto>
    {
        List<LoginResponse> Login(LoginRequest loginRequest);
    }
}
