using DataAcess.Demo.DBContext;
using DataAcess.Demo.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcess.Demo.Services
{
    public class OrderDetailRepository: IOrderDetailRepository
    {
        MyShopUnitOfWorkDbContext _dbContext;
        public OrderDetailRepository(MyShopUnitOfWorkDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Task<int> OrderDetailInsert()
        {
            throw new NotImplementedException();
        }

       
    }
}
