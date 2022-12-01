using ATMProject.Application.Models.DTOs;
using ATMProject.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMProject.Application.Services.MailService
{
    public interface IMailService
    {
        void SendEmailAsync(MailModel model);
    }
}
