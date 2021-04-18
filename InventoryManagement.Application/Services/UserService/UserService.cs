using AutoMapper;
using InventoryManagement.Application.DTOs;
using InventoryManagement.Core.Enums;
using InventoryManagement.Core.IRepositories;
using InventoryManagement.Models;
using InventoryManagement.Utils.Helpers;
using InventoryManagement.Utils.Response;
using Microsoft.AspNetCore.Authorization;
using Newtonsoft.Json;
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
        private readonly IRepository<RoleAndRolePermession> RoleAndPermessionRepository;
        private readonly IMapper _mapper;

        public UserService(IRepository<User> UserRepository, IRepository<RoleAndRolePermession> RoleAndPermessionRepository, IMapper _mapper) : base(UserRepository, _mapper)
        {
            this.UserRepository = UserRepository;
            this.RoleAndPermessionRepository = RoleAndPermessionRepository;
            this._mapper = _mapper;

        }



        public UIResponse Login(LoginRequest loginRequest)
        {
            LoginResponse loginResponse = new LoginResponse();

            string PasswordHash = CalculateHashForNetCore(loginRequest.Password);
            User user = UserRepository.GetQuery(qu => qu.UserName == loginRequest.UserName).FirstOrDefault();


            if (user == null || user.Password != CalculateHash(PasswordHash + user.Salt))
            {
                //result.ResponseCode = ResponseCode.Error;
                //result.UIMessage = ErrorMessage.InvalidUserNamePassword;
                return new UIResponse { Entity = new LoginResponse() { IsAuthenticated = false }, IsError = true, Message = "ADMIN_MODULE.LOGIN.WRNOG_LOGIN_CREDENTIALS" };
            }

            SetUserCreds(loginResponse, user);
            var role = UserRepository.GetQuery(gq => gq.Id == user.Id).Select(se => se.Role).FirstOrDefault();
            if (role != null)
            {
                loginResponse.IsAuthenticated = true;
                var UserPermissions = RoleAndPermessionRepository.GetQuery(gq => gq.RoleId == role.Id).Select(se => se.RolePermession).OrderBy(ob => ob.Priority).ToList();
                var ParentMenus = UserPermissions.Where(wh => wh.ParentId == 0).ToList();
                ParentMenus.ForEach(fe =>
                {
                    loginResponse.NavigationItems.Add(UserPermissionsCreator(fe, UserPermissions));
                });

                //ParentMenus.ForEach(fe =>
                //{
                //    var children = UserPermissions.Where(wh => wh.ParentId == fe.Id).ToList();
                //    loginResponse.NavigationItems.Add(new NavigationItems
                //    {
                //        Icon = fe.Icon,
                //        Key = fe.RoleKey,
                //        Title = fe.Title,
                //        Translate = fe.Translate,
                //        Type = children.Any() ? "collapsable" : "item",
                //        URL = fe.URL,
                //        Children = children.Select(se => new NavigationItems
                //        {
                //            Icon = se.Icon,
                //            Key = se.RoleKey,
                //            Title = se.Title,
                //            Translate = se.Translate,
                //            Type = "item",
                //            URL = se.URL,
                //            Children = new List<NavigationItems>()
                //        }).ToList()
                //    });
                //});

            }

            return new UIResponse { Entity = loginResponse };

        }

        public NavigationItems UserPermissionsCreator(RolePermession ParentMenue, List<RolePermession> UserPermessions)
        {
            NavigationItems navigationItems = new NavigationItems() { Icon = ParentMenue.Icon, Key = ParentMenue.RoleKey, Title = ParentMenue.Title, Translate = ParentMenue.Translate, URL = ParentMenue.URL, Type = "collapsable" };
            var parentChildren = UserPermessions.Where(wh => wh.ParentId == ParentMenue.Id).ToList();
            parentChildren.ForEach(child =>
            {
                if (child.IsParent)
                {
                    navigationItems.Children.Add(UserPermissionsCreator(child, UserPermessions));
                }
                else
                {
                    navigationItems.Children.Add(new NavigationItems
                    {
                        Icon = child.Icon,
                        Key = child.RoleKey,
                        Title = child.Title,
                        Translate = child.Translate,
                        Type = "item",
                        URL = child.URL,
                        Children = new List<NavigationItems>()
                    });
                }
            });
            return navigationItems;
        }

        private void SetUserCreds(LoginResponse loginResponse, User user)
        {
            loginResponse.UserId = user.Id;
            loginResponse.UserName = user.UserName;
            loginResponse.UserCode = user.UserCode;
        }


        public async Task<UserDto> UpdateUser(int key, string values)
        {
            var newuser = new User();
            JsonConvert.PopulateObject(values, newuser);
            var user = UserRepository.GetQuery(u => u.Id == key).FirstOrDefault();

            if (newuser.Password != null && newuser.Password != user.Password)
            {
                newuser.Salt = Guid.NewGuid().ToString();

                string newPass = CalculateHashForNetCore(newuser.Password);
                newPass = newPass + newuser.Salt;
                string compPass = CalculateHashForNetCore(newPass);
                newuser.Password = compPass;
            }
            JsonConvert.PopulateObject(values, user);
            if (newuser.Password != null)
            {
                user.Salt = newuser.Salt;
                user.Password = newuser.Password;
            }

            UserRepository.PutEntity(user);
            await UserRepository.SaveChangesAsync();
            return _mapper.Map<UserDto>(user);
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
            await UserRepository.SaveChangesAsync();
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
