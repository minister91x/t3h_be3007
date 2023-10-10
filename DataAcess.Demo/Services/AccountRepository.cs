using DataAcess.Demo.DBContext;
using DataAcess.Demo.Entities;
using DataAcess.Demo.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcess.Demo.Services
{
    public class AccountRepository : IAccountRepository
    {
        MyShopUnitOfWorkDbContext _dbContext;

        public AccountRepository(MyShopUnitOfWorkDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> Account_Login(AccountLoginRequestData requestData)
        {
            return 1;
        }
    }
}
