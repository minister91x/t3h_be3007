using DataAcess.Demo.DBContext;
using DataAcess.Demo.Entities;
using DataAcess.Demo.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcess.Demo.Services
{
    public class FuncitonServices : IFuncitonServices
    {
        MyShopUnitOfWorkDbContext _dbContext;
        public FuncitonServices(MyShopUnitOfWorkDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task< int> GetFunctionIDByCode(string code)
        {
            try
            {
                var function = _dbContext.function.ToList().FindAll(s => s.FunctionCode == code).FirstOrDefault();
                if (function == null || function.FunctionID < 0) { return 0; }
                return function.FunctionID;

            }
            catch (Exception EX)
            {

                throw;
            }
        }

        public async Task<List<Function>> GetFunctions()
        {
            return _dbContext.function.ToList();
        }
    }
}
