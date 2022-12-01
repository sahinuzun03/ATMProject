using ATMProject.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMProject.Application.Models.DTOs
{
    public class ProcessDTO
    {
        public decimal Amount { get; set; }
        public Process Process { get; set; }
    }
}
