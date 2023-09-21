using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDemoMVC.EntitiesFrameWork.Entites;

namespace WebDemoMVC.CategoryManager
{
    public interface IProduct
    {
        List<Product> GetProducts(string KeySearch);
        int Product_InsertOrUpdate(Product product);
        int Product_Delete(Product product);

    }
}
