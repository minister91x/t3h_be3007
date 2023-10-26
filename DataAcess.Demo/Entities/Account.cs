using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcess.Demo.Entities
{
    public class Account
    {
        [Key]
        public int UserID { get; set; }
        public string UserName { get; set; }
        public string PassWord { get; set; }
        public string FullName { get; set; }
        public int IsAdmin { get; set; }

        public string RefreshToken { get; set; }
        public DateTime RefreshTokenExpiryTime { get; set; }
    }
    public class AccountLoginRequestData
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }

    public class Account_GetByUserName
    {
        public string UserName { get; set; }
    }


    public class AccountLoginUpdateRefeshTokenRequestData
    {
        public int UserID { get; set; }
        public string RefreshToken { get; set; }
        public DateTime RefreshTokenExpiryTime { get; set; }
    }
}
