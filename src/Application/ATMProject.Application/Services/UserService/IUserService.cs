using ATMProject.Application.Models.DTOs;
using ATMProject.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMProject.Application.Services.UserService
{
    public interface IUserService
    {
        //Burada Register vs koyabilirsiniz!!

        //Kullanıcı bilgilerini güncellemek için UpdateUser kullanabilirsiniz.
        Task<Token> Login(LoginDTO model); // Biz sadece giriş yapacağız diğer işlemler kullanıcının UserProcess kısmında yapılacak.
        Task CreateUser(CreateUserDTO model);
    }
}
