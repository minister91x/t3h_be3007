using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcess.Demo.IServices
{
    public interface IOrderDetailRepository
    {
        Task<int> OrderDetailInsert();
    }
}
