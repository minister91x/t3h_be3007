using DataAcess.Demo.DO;
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
        public async Task<List<Product>> GetProducts(ProductGetListRequestData requestData)
        {
            var list = new List<Product>();
            try
            {
               
                for (int i = 10; i < 15; i++)
                {
                    list.Add(new Product { Id = i, Name = "Iphone " + i });
                }

                if(list.Count>0 && requestData.PrductID > 0)
                {
                    list = list.FindAll(s => s.Id == requestData.PrductID).ToList();
                }
            }
            catch (Exception ex)
            {

                throw;
            }

            return list;
        }
    }
}
