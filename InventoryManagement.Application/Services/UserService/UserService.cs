using AutoMapper;
using InventoryManagement.Application.DTOs;
using InventoryManagement.Core.IRepositories;
using InventoryManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

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
        }



        public List<LoginResponse> Login(LoginRequest loginRequest)
        {
            List<LoginResponse> navigationItems = new List<LoginResponse>();
            string PasswordHash = CalculateHashForNetCore(loginRequest.Password);
            User user = UserRepository.GetQuery(qu => qu.UserName == loginRequest.UserName).FirstOrDefault();


            if (user == null || user.Password != CalculateHashForNetCore(PasswordHash + user.Salt))
            {
                //result.ResponseCode = ResponseCode.Error;
                //result.UIMessage = ErrorMessage.InvalidUserNamePassword;
                return new List<LoginResponse>();
            }

            var role = UserAndRoleRepository.GetQuery(gq => gq.UserId == user.Id).FirstOrDefault();
            if (role != null)
            {

                var UserPermissions = RoleAndPermessionRepository.GetQuery(gq => gq.RoleId == role.RoleId).Select(se => se.RolePermession).ToList();
                var ParentMenus = UserPermissions.Where(wh => wh.IsParent).ToList();

                ParentMenus.ForEach(fe =>
                {
                    navigationItems.AddRange(UserPermissions.Where(wh => wh.ParentId == fe.ParentId).Select(se => new LoginResponse
                    {
                        Icon = se.Icon,
                        Key = se.RoleKey,
                        Title = se.Title,
                        Translate = se.Translate,
                        Type = se.RoleKey == null ? "item" : "collapsable",
                        URL = se.URL
                    }).ToList());
                });

            }


            return navigationItems;

        }

        private string CalculateHashForNetCore(string inputData)
        {
            string result = "";
            SHA1 sHA3 = new SHA1CryptoServiceProvider();
            byte[] bytes3 = CodePagesEncodingProvider.Instance.GetEncoding("ISO-8859-9").GetBytes(inputData);
            byte[] inArray3 = sHA3.ComputeHash(bytes3);
            result = Convert.ToBase64String(inArray3);
            return result;
        }
    }
}
