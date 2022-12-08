using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;
using System.Security.Cryptography;
using Microsoft.Extensions.Configuration;
using ATMProject.Domain.Entities;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace ATMProject.Application.Services.AnotherService
{
    public class TokenHandler : ITokenHandler
    {
        public IConfiguration _configuration { get; set; }
        public TokenHandler(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public Token CreateAccessToken(User user)
        {
            //Token oluşturucu sınıfında bir örnek alıyoruz.
            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();

            //Security  Key'in simetriğini alıyoruz.
            SymmetricSecurityKey securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Token:SecurityKey"]));

            //Şifrelenmiş kimliği oluşturuyoruz.
            SigningCredentials signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var expiry = DateTime.Now.AddDays(1);

            var claims = new[]
            {
                new Claim(ClaimTypes.Email,user.EmailAdress),
                new Claim(ClaimTypes.Name,user.UserName),
                new Claim(ClaimTypes.UserData,user.Id.ToString())
            };

            var token = new JwtSecurityToken(_configuration["Token:Issuer"], _configuration["Token:Audience"], claims, null, expiry, signingCredentials);

            Token userToken = new Token();

            userToken.AccessToken = tokenHandler.WriteToken(token);
            userToken.RefreshToken = CreateRefreshToken();

            return userToken;
        }
        //Refresh Token üretecek metot.
        public string CreateRefreshToken()
        {
            byte[] number = new byte[32];
            using (RandomNumberGenerator random = RandomNumberGenerator.Create())
            {
                random.GetBytes(number);
                return Convert.ToBase64String(number);
            }
        }
    }
}

/*
 //Oluşturulacak token ayarlarını veriyoruz.
           tokenInstance.Expiration = DateTime.Now.AddMinutes(5);
           JwtSecurityToken securityToken = new JwtSecurityToken(
               issuer: _configuration["Token:Issuer"],
               audience: _configuration["Token:Audience"],
               expires: tokenInstance.Expiration,//Token süresini 5 dk olarak belirliyorum
               notBefore: DateTime.Now,//Token üretildikten ne kadar süre sonra devreye girsin ayarlıyouz.
               signingCredentials: signingCredentials
               );
           //Token üretiyoruz.
           tokenInstance.AccessToken = tokenHandler.WriteToken(securityToken);

           //Refresh Token üretiyoruz.
           tokenInstance.RefreshToken = CreateRefreshToken();
           return tokenInstance; */