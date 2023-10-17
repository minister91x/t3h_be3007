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
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private MyShopUnitOfWorkDbContext _dbContext;
        public GenericRepository(MyShopUnitOfWorkDbContext dbContext)
        {
            _dbContext = dbContext;
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

        public int Add(T entity)
        {
            _dbContext.Add(entity);
            return _dbContext.SaveChanges();
        }

        public IEnumerable<T> GetAll()
        {
            return _dbContext.Set<T>().ToList();
        }

        public void Remove(T entity)
        {
            _dbContext.Set<T>().Remove(entity);
        }
    }
}
