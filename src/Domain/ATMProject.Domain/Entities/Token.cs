using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATMProject.Domain.Entities
{
    public class Token
    {
        public string AccessToken { get; set; } /*Token'ın ta kendisi*/
        public DateTime Expiration { get; set; } /**/
        public string RefreshToken { get; set; } /*Access token süresi son bulunca refresh token ile yeni token talebinde bulunabileceğiz.Kullanıcı sistemden düşürülmeden yeni token talebinde bulunacak ve işlemlerine devam edebilecek.*/
    }
}
