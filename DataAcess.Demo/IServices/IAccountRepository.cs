﻿using DataAcess.Demo.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcess.Demo.IServices
{
    public interface IAccountRepository
    {
        Task<Account> Account_Login(AccountLoginRequestData requestData);

        Task<Account> Account_GetByUserName(Account_GetByUserName requestData);
        Task<int> Account_UpDateRefeshToken(AccountLoginUpdateRefeshTokenRequestData requestData);
    }
}
