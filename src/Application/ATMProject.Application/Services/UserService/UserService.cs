using ATMProject.Application.Models.DTOs;
using ATMProject.Application.Services.AnotherService;
using ATMProject.Domain.Entities;
using ATMProject.Domain.Repositories;
using AutoMapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMProject.Application.Services.UserService
{
    public class UserService : IUserService
    {
        private readonly ITokenHandler _tokenHandler;
        private readonly IMapper _mapper;
        private readonly IUserRepo _userRepo;
        private readonly IConfiguration _configuration;
        public UserService(ITokenHandler tokenHandler,IMapper mapper,IUserRepo userRepo,IConfiguration configuration)
        {
            _tokenHandler = tokenHandler;
            _mapper = mapper;
            _userRepo = userRepo;
            _configuration = configuration; 
        }


        /*Kullanıcının yaratılmasını istemediğiniz için öyle bir metot yazmadım ama yazmanız gerekmektedir!!*/
        public async Task<Token> Login(LoginDTO model)
        {
            var getUser = await _userRepo.GetDefault(x => x.UserName == model.UserName && x.Password == model.Password);


            if (getUser != null)
            {
                Token token = _tokenHandler.CreateAccessToken(getUser);
                getUser.RefreshToken= token.RefreshToken;
                getUser.RefreshTokenEndDate = token.Expiration.AddMinutes(45);
                await _userRepo.Update(getUser);
                return token;
            }

            return null;

        }

        public async Task CreateUser(CreateUserDTO model)
        {
            //Kullanıcı oluşturuldu.
            var newUser = _mapper.Map<User>(model);
            await _userRepo.Create(newUser);
        }
    }
}
