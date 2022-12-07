using ATMProject.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMProject.Application.Models.DTOs
{
    public class CreateUserDTO
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string UserName { get; set; }
        public string EmailAdress { get; set; }
        public string Password { get; set; }
        public Status Status => Status.Active;
        public DateTime CreateDate { get; set; } = DateTime.Now;
    }
}
