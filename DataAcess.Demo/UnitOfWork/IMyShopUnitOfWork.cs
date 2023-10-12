using DataAcess.Demo.IServices;
using DataAcess.Demo.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcess.Demo.UnitOfWork
{
    public interface IMyShopUnitOfWork
    {
        IProductRepository Products { get; }
        IOrderDetailRepository OrderDetails { get; }
        IAccountRepository AccountRepository { get; }

      
        int Save();
    }
}
