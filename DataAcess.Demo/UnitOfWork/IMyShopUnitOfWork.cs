using DataAcess.Demo.IServices;
using DataAcess.Demo.Repository;
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

        IFuncitonServices funcitonServices { get; }
        IUserFuncitonServices userFuncitonServices { get; }

        IOrderRepository _orderRepository { get; }

        //IAccountRepositoryGeneric accountRepositoryGeneric { get; }
        //IProductRepositoryGeneric productRepositoryGeneric { get; } 

        int Save();
    }
}
