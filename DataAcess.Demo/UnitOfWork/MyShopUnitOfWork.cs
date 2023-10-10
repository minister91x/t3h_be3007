using DataAcess.Demo.DBContext;
using DataAcess.Demo.IServices;
using DataAcess.Demo.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcess.Demo.UnitOfWork
{
    public class MyShopUnitOfWork : IMyShopUnitOfWork
    {
        public IProductRepository Products { get; }

        public IOrderDetailRepository OrderDetails { get; }

        public IAccountRepository AccountRepository { get; }

        private MyShopUnitOfWorkDbContext _shopDbContext;

        public MyShopUnitOfWork(MyShopUnitOfWorkDbContext shopDbContext,
            IProductRepository productRepository,
            IOrderDetailRepository orderDetailRepository,
            IAccountRepository accountRepository)
        {
            _shopDbContext = shopDbContext;
            Products = productRepository;
            OrderDetails = orderDetailRepository;
            AccountRepository = accountRepository;
        }

        public int Save()
        {
            return _shopDbContext.SaveChanges();
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _shopDbContext.Dispose();
            }
        }

    }
}
