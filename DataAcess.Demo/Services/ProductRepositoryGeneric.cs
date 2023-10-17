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
    public class ProductRepositoryGeneric : GenericRepository<Product>, IProductRepositoryGeneric
    {
        public ProductRepositoryGeneric(MyShopUnitOfWorkDbContext dbContext) : base(dbContext)
        {
        }


    }
}
