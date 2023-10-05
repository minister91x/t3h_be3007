
using DataAcess.Demo.Entities;
using DataAcess.Demo.Request.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcess.Demo.IServices
{
    public interface IProductServices
    {
        Task<int> ProductInsert(Product product);
        Task<List<Product>> GetProducts(ProductGetListRequestData requestData);
    }
}
