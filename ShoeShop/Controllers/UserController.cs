﻿using InventoryManagement.Application.DTOs;
using InventoryManagement.Application.Services.UserService;
using InventoryManagement.Utils.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using Sample;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Interface.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserController : ControllerBase
    {
        private readonly IUserService userService;
        private readonly TokenSettings tokenSettings;
        public UserController(IUserService userService, IOptions<TokenSettings> tokenSettings)
        {
            this.userService = userService;
            this.tokenSettings = tokenSettings.Value;
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("Login")]
        public ActionResult<LoginResponse> Login([FromForm] string values)
        {
            LoginRequest loginRequest = new LoginRequest();
            JsonConvert.PopulateObject(values, loginRequest);

            var loginResponse = userService.Login(loginRequest);
            if (loginResponse.IsAuthenticated)
            {
                loginResponse.Token = generateJwtToken(loginRequest);
            }

            return Ok(loginResponse);
        }

        
        [HttpPost]
        [Route("InsertUser")]
        public async Task<ActionResult<UserDto>> InsertUser([FromForm] string values)
        {
            UserDto userDto = new UserDto();
            JsonConvert.PopulateObject(values, userDto);
            await userService.InsertUser(userDto);
            return Ok();
        }

        [HttpGet]
        [Route("GetUsers")]
        public ActionResult GetUsers(DataSourceLoadOptions loadOptions)
        {
            var result = userService.GetEntities(loadOptions);
            return Ok(result);
        }

        [HttpDelete]
        [Route("DeleteUser")]
        public async Task<ActionResult<UserDto>> DeleteUser([FromForm] int key)
        {
            var User = await userService.DeleteEntity(key);
            if (User == null)
            {
                return NotFound();
            }

            return Ok();
        }

        public string generateJwtToken(LoginRequest user)
        {
            // generate token that is valid for 7 days
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(tokenSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim("UserName", user.UserName.ToString()) }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}