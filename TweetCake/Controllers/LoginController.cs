using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
//using AutoMapper.Configuration;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Configuration;
using TweetCake.DAL;
using TweetCake.Shared.Models;
using JwtRegisteredClaimNames = Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TweetCake.Controllers
{
    [Route("api/[controller]")]
    public class LoginController : Controller
    {
        private readonly IConfiguration _config;

        public LoginController(IConfiguration config)
        {
            _config = config;
        }

        private List<UserLoginModel> _appUserLoginModels = new List<UserLoginModel>
        {
            new UserLoginModel {Role = "admin", UserName = "Sema", Password = "8523"}
        };
        [HttpPost]
        [AllowAnonymous]
        public IActionResult Login([FromBody] UserLoginModel loginUserLoginModel)
        {
            IActionResult response = Unauthorized();
            var authenticateUserLoginModel = AuthenticateUserLoginModel(loginUserLoginModel);
            if (authenticateUserLoginModel != null)
            {
                var generateJwtToken = GenerateJWTToken(authenticateUserLoginModel);
                response = Ok(new
                {
                    token = generateJwtToken,
                    userDetails = authenticateUserLoginModel
                });
            }

            return response;
        }

        private UserLoginModel AuthenticateUserLoginModel(UserLoginModel loginCredentials)
        {
            UserLoginModel user = _appUserLoginModels.SingleOrDefault(x =>
                x.UserName == loginCredentials.UserName && x.Password == loginCredentials.Password);
            return user;
        }

        private object GenerateJWTToken(UserLoginModel userInfo)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:SecretKey"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, userInfo.UserName),
                new Claim("userName",userInfo.UserName.ToString()),
                new Claim("role",userInfo.Role),
                new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
            };
            var token = new JwtSecurityToken(
                issuer:_config["Jwt:Issuer"],
                audience:_config["Jwt:Audience"],
                claims:claims,
                expires:DateTime.Now.AddMinutes(30),
                signingCredentials:credentials
                );
            return new JwtSecurityTokenHandler().WriteToken(token);

        }


        /*Mobil etiketleri UI üzerinde özelleştirmek.
         Etiketin son halinin configürasyonu tablodan bakılabilir.
         dinleme moduna geçen etikete sp*/
    }
}
