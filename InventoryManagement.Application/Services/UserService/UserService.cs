using AutoMapper;
using InventoryManagement.Application.DTOs;
using InventoryManagement.Core.Enums;
using InventoryManagement.Core.IRepositories;
using InventoryManagement.Models;
using InventoryManagement.Utils.Helpers;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Application.Services.UserService
{
    public class UserService : Service<User, UserDto>, IUserService
    {
        private readonly IRepository<User> UserRepository;
        private readonly IRepository<UserRole> UserAndRoleRepository;
        private readonly IRepository<RoleAndRolePermession> RoleAndPermessionRepository;
        private readonly IMapper _mapper;

        public UserService(IRepository<User> UserRepository, IRepository<UserRole> UserAndRoleRepository, IRepository<RoleAndRolePermession> RoleAndPermessionRepository, IMapper _mapper) : base(UserRepository, _mapper)
        {
            this.UserRepository = UserRepository;
            this.UserAndRoleRepository = UserAndRoleRepository;
            this.RoleAndPermessionRepository = RoleAndPermessionRepository;
            this._mapper = _mapper;

        }



        public LoginResponse Login(LoginRequest loginRequest)
        {
            LoginResponse loginResponse = new LoginResponse();
            
            string PasswordHash = CalculateHashForNetCore(loginRequest.Password);
            User user = UserRepository.GetQuery(qu => qu.UserName == loginRequest.UserName).FirstOrDefault();


            if (user == null || user.Password != CalculateHash(PasswordHash + user.Salt))
            {
                //result.ResponseCode = ResponseCode.Error;
                //result.UIMessage = ErrorMessage.InvalidUserNamePassword;
                return new LoginResponse() { IsAuthenticated = false };
            }

            SetUserCreds(loginResponse,user);
            var role = UserAndRoleRepository.GetQuery(gq => gq.UserId == user.Id).FirstOrDefault();
            if (role != null)
            {
                loginResponse.IsAuthenticated = true;
                var UserPermissions = RoleAndPermessionRepository.GetQuery(gq => gq.RoleId == role.RoleId).Select(se => se.RolePermession).ToList();
                var ParentMenus = UserPermissions.Where(wh => wh.IsParent).ToList();

                ParentMenus.ForEach(fe =>
                {
                    var children = UserPermissions.Where(wh => wh.ParentId == fe.RoleKey);
                    loginResponse.NavigationItems.Add(new NavigationItems
                    {
                        Icon = fe.Icon,
                        Key = fe.RoleKey,
                        Title = fe.Title,
                        Translate = fe.Translate,
                        Type = children.Any() ? "collapsable" : "item",
                        URL = fe.URL,
                        Children = children.Select(se => new NavigationItems
                        {
                            Icon = se.Icon,
                            Key = se.RoleKey,
                            Title = se.Title,
                            Translate = se.Translate,
                            Type = "item",
                            URL = se.URL,
                            Children = new List<NavigationItems>()
                        }).ToList()
                    });
                });

            }


            return loginResponse;

        }

        private void SetUserCreds(LoginResponse loginResponse, User user)
        {
            loginResponse.UserName = user.UserName;
            loginResponse.UserCode = user.UserCode;
        }

        public async Task<UserDto> InsertUser(UserDto userDto)
        {
            var user = UserRepository.GetQuery(u => u.UserName == userDto.UserName && u.UserStatus == UserStatus.Active).FirstOrDefault();
            if (user != null)
            {
                return new UserDto() { };
            }


            userDto.Salt = Guid.NewGuid().ToString();

            string newPass = CalculateHashForNetCore(userDto.Password);
            newPass = newPass + userDto.Salt;
            string compPass = CalculateHashForNetCore(newPass);
            userDto.Password = compPass;
            userDto.UserStatus = UserStatus.Active;


            User User = _mapper.Map<User>(userDto);
            await UserRepository.PostEntity(User);
            return userDto;

        }

        private string CalculateHashForNetCore(string inputData)
        {
            string result = "";
            SHA512 sHA512 = new SHA512CryptoServiceProvider();
            byte[] bytes3 = CodePagesEncodingProvider.Instance.GetEncoding("ISO-8859-9").GetBytes(inputData);
            byte[] inArray3 = sHA512.ComputeHash(bytes3);
            result = Convert.ToBase64String(inArray3);
            return result;
        }

        public static string CalculateHash(string inputData)
        {
            string result = "";
            byte[] bytes3 = CodePagesEncodingProvider.Instance.GetEncoding("ISO-8859-9").GetBytes(inputData);
            SHA512 sHA512 = new SHA512CryptoServiceProvider();
            byte[] inArray3 = sHA512.ComputeHash(bytes3);
            result = Convert.ToBase64String(inArray3);
            return result;
        }
    }
}
