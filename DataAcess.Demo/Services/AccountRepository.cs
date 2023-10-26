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

        public async Task<Account> Account_GetByUserName(Account_GetByUserName requestData)
        {
            var user = _dbContext.user.ToList().FindAll(s => s.UserName == requestData.UserName).FirstOrDefault();

            return user;
        }

        public async Task<Account> Account_Login(AccountLoginRequestData requestData)
        {

            try
            {
                // Login : tìm xem có username và passwork nào trong db giống client truyền lên không 
                var result = _dbContext.user.ToList().FindAll(s => s.UserName == requestData.UserName
                && s.PassWord == requestData.Password).FirstOrDefault();

                // nếu không có thì trả về acc rỗng
                if (result == null || result.UserID <= 0) { return new Account(); }

                //nếu có thì trả về thông tin user
                var user = _dbContext.user.ToList().FindAll(s => s.UserID == result.UserID).FirstOrDefault(); ;
                return user;
            }
            catch (Exception ex)
            {

            }
            return new Account();
        }

        public async Task<int> Account_UpDateRefeshToken(AccountLoginUpdateRefeshTokenRequestData requestData)
        {
            try
            {
                var user = _dbContext.user.ToList().FindAll(s => s.UserID == requestData.UserID).FirstOrDefault();
                if (user != null)
                {
                    user.RefreshToken = requestData.RefreshToken;
                    user.RefreshTokenExpiryTime = requestData.RefreshTokenExpiryTime;
                    _dbContext.user.Update(user);
                    return await _dbContext.SaveChangesAsync();
                }


            }
            catch (Exception ex)
            {

                throw;
            }

            return 0;
        }


    }
}
