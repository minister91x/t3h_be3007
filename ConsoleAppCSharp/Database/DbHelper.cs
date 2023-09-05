using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppCSharp.Database
{
    public static class DbHelper
    {
        static string db_address = "Data Source=DESKTOP-IFRSV3F;Initial Catalog=MyDatabase2;User ID=sa;Password=123456;";

        public static SqlConnection GetSqlConnection()
        {
            try
            {
                var sqlconn = new SqlConnection(db_address);
                // kiểm tra trạng thái kết nối xem đang là đóng hay mở 
                if (sqlconn.State == System.Data.ConnectionState.Closed)
                {
                    sqlconn.Open();
                }

                return sqlconn;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

    }


}
