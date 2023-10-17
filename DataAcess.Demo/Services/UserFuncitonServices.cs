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

    public class UserFuncitonServices : IUserFuncitonServices
    {
        MyShopUnitOfWorkDbContext _dbContext;
        public UserFuncitonServices(MyShopUnitOfWorkDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<UserFuntion> GetUserFuntion(int functionId, int UserId)
        {
            try
            {
                var userFunction = _dbContext.userfunction.ToList().FindAll(
                    s => s.FunctionID == functionId && s.UserID == UserId).FirstOrDefault();

                return userFunction;


            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
