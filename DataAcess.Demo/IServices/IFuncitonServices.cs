using DataAcess.Demo.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcess.Demo.IServices
{
    public interface IFuncitonServices
    {
         Task<int> GetFunctionIDByCode(string code);
        Task<List<Function>> GetFunctions();
    }
}
