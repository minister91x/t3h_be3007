using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppCSharp.ProductManager
{
    public interface IProduct
    {
        List<ProductDataBase> ProductsGetList(int ProductID);
        int ProductInsert(ProductDataBase product);
        
    }
}
