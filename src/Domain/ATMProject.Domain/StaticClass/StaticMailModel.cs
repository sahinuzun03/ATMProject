using ATMProject.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMProject.Domain.StaticClass
{
    public static class StaticMailModel
    {
        public static MailModel successMail = new MailModel()
        {
            Body = "İşlem başarılı bir şekilde gerçekleştirilmiştir",
            Subject = "BAŞARILI İŞLEM"
        };

        public static MailModel failedMail = new MailModel()
        {
            Body = "İşlem başarısız bir şekilde gerçekleştirilmiştir",
            Subject = "BAŞARISIZ İŞLEM"
        };
    }
}
