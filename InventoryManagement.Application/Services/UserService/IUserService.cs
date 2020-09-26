using InventoryManagement.Application.DTOs;
using InventoryManagement.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Application.Services.UserService
{
    public interface IUserService : IService<User, UserDto>
    {
        LoginResponse Login(LoginRequest loginRequest);
        Task<UserDto> InsertUser(UserDto userDto);
        Task<UserDto> UpdateUser(int key, string values);
    }
}
