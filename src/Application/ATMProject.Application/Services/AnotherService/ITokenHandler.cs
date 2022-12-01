using ATMProject.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMProject.Application.Services.AnotherService
{
    public interface ITokenHandler
    {
        public Token CreateAccessToken(User user);
        public string CreateRefreshToken();
    }
}
