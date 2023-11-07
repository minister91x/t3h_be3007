using Dapper;
using DataAcess.Demo.Dapper;
using DataAcess.Demo.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcess.Demo.Repository
{
    public class OrderRepository : BaseApplicationService, IOrderRepository
    {
        public OrderRepository(IServiceProvider serviceProvider) : base(serviceProvider)
        {
        }

        public async Task<int> OrderDetailInsert(OrderDetail orderDetail)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@Thamso", 1);
                var rs = await DbConnectionHelper.ExecuteAsync("TEN_STOREPROCEDURE", parameters);
                return rs;

            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public async Task<int> OrderInsert(Order order)
        {
            try
            {
                var parameters = new DynamicParameters();
                parameters.Add("@_TotalAmount", order.TotalAmount);
                parameters.Add("@_ResponseCode", 0,System.Data.DbType.Int32, System.Data.ParameterDirection.Output);
                await DbConnectionHelper.ExecuteAsync("SP_ORDER_INSERT", parameters);
                var Id = Convert.ToInt32(parameters.Get<System.Int32>("@_ResponseCode").ToString());
                return Id;

            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
