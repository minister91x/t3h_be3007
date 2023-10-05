using DataAcess.Demo.DBContext;
using DataAcess.Demo.Entities;
using DataAcess.Demo.IServices;
using DataAcess.Demo.Request.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcess.Demo.Services
{
    public class ProductServices : IProductServices
    {
        MyShopUnitOfWorkDbContext _dbContext;

        public ProductServices(MyShopUnitOfWorkDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Product>> GetProducts(ProductGetListRequestData requestData)
        {
            var list = new List<Product>();
            try
            {

                list = _dbContext.sanpham.ToList();

                if (list.Count > 0 && requestData.PrductID > 0)
                {
                    list = list.FindAll(s => s.PrductID == requestData.PrductID).ToList();
                }
            }
            catch (Exception ex)
            {

                throw;
            }

            return list;
        }

        public async Task<int> ProductInsert(Product product)
        {
            try
            {
                _dbContext.sanpham.Add(product);
                return _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
