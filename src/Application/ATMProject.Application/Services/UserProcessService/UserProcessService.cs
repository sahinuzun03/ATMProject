using ATMProject.Application.Models.DTOs;
using ATMProject.Application.Services.MailService;
using ATMProject.Domain.Entities;
using ATMProject.Domain.Repositories;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATMProject.Domain.Enums;
using ATMProject.Domain.StaticClass;

namespace ATMProject.Application.Services.UserProcessService
{
    public class UserProcessService : IUserProcessService
    {
        private readonly IMapper _mapper;
        private readonly IUserRepo _userRepo;
        private readonly IMailService _mailService;
        private readonly IUserProcessRepo _userProcessRepo;
        public UserProcessService(IMapper mapper, IUserRepo userRepo, IMailService mailService, IUserProcessRepo userProcessRepo)
        {
            _mapper = mapper;
            _userRepo = userRepo;
            _mailService = mailService;
            _userProcessRepo = userProcessRepo;
        }

        public async Task<decimal> GetUserBalance(int UserId)
        {
            var getUser = await _userRepo.GetDefault(x => x.Id == UserId);
            var userBalanceList = await _userProcessRepo.GetDefaults(x => x.UserId == UserId);
            decimal userBalance = 0;
            foreach (var item in userBalanceList)
            {
                if(item.Process == Process.Deposit)
                {
                    userBalance += item.Amount;
                }
                else
                {
                    userBalance -= item.Amount;
                }
            }

            return userBalance;
        }
        
        public async Task<UserProcess> AddUserProcess(ProcessDTO model, int userID)
        {
            var getUser = await _userRepo.GetDefault(x => x.Id == userID);
            StaticMailModel.successMail.ToEmail = getUser.EmailAdress;
            StaticMailModel.failedMail.ToEmail = getUser.EmailAdress;
            //var userProcess = _mapper.Map<UserProcess>(model); --> DTO kısmında veri değişikliğine gittiğim için burası çalışmaz o yüzdenşöyle bir şey yaptık

            UserProcess newUserProcess = new UserProcess();
            newUserProcess.Process = model.Process;
            if (model.Process == Process.Withdraw)
            {
                newUserProcess.Amount = model.Amount * (-1);
            }
            else
                newUserProcess.Amount = model.Amount;
            
            var userBalance = await GetUserBalance(userID);
            

            if (newUserProcess.Process == Process.Withdraw)
            {
                if (userBalance > newUserProcess.Amount)
                {
                    newUserProcess.Amount *= -1;
                    _mailService.SendEmailAsync(StaticMailModel.successMail); // Para çekme işlemi başarılı olduğu zaman.
                }
                else
                {
                    _mailService.SendEmailAsync(StaticMailModel.failedMail);//Para çekme işlemi başarısız olduğu zaman
                }
            }

            else
            {
                _mailService.SendEmailAsync(StaticMailModel.successMail);//Para yatırma başarılı oldu mesajı
            }

            ///<summary>
            ///Buradan belki gelen process'in içerisindeki user'a atama yapıp hareketlenme yapabilirim.
            ///</summary>
            getUser.UserProcesses.Add(newUserProcess);
            await _userRepo.Update(getUser);
            return newUserProcess;

        }
    }
}
