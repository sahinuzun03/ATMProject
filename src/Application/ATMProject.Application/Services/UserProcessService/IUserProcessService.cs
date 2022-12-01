using ATMProject.Application.Models.DTOs;
using ATMProject.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMProject.Application.Services.UserProcessService
{
    public interface IUserProcessService
    {
        //Kullanıcının bakiye bilgisini dönecek olan metot!!
        Task<decimal> GetUserBalance(int UserId);
        Task<UserProcess> AddUserProcess(ProcessDTO model, int userID);


    }
}
