using ATMProject.Application.Models.DTOs;
using ATMProject.Domain.Entities;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace ATMProject.Application.Services.MailService
{
    public class MailService : IMailService
    {
        public IConfiguration _configuration { get; set; }
        public MailService(IConfiguration configuration)
        {
            _configuration = configuration;   
        }
        public void SendEmailAsync(MailModel model)
        {
            SmtpClient smtpClient = new SmtpClient();
            smtpClient.Port = Convert.ToInt32(_configuration["EmailConfiguration:Port"]);
            smtpClient.Host = _configuration["EmailConfiguration:Host"];
            smtpClient.EnableSsl = true;
            smtpClient.Credentials = new NetworkCredential(_configuration["EmailConfiguration:Mail"], _configuration["EmailConfiguration:Password"]);

            MailMessage mailMessage = new MailMessage();
            mailMessage.From = new MailAddress(_configuration["EmailConfiguration:Mail"], _configuration["EmailConfiguration:DisplayName"]);
            mailMessage.To.Add(model.ToEmail);
            mailMessage.Subject = model.Subject;
            smtpClient.Send(mailMessage);
        }
    }
}
