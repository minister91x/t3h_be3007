using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppCSharp.Database
{
    internal static class DbHelper
    {
        static string db_address = "Data Source=[YOUR_SERVICE_NAME];Initial Catalog=[YOUR_DATABASE_NAME];User ID=[YOUR_SA];Password=[YOUR_PASSWORD];";

        public static List<Product> Product_GetList()
        {
            var list = new List<Product>();
            try
            {
                //Bước 1: Truy cập vào kho (database)
                // mở connect đển địa chỉ của sqlserver 
                var sqlconn = new SqlConnection(db_address);
                // kiểm tra trạng thái kết nối xem đang là đóng hay mở 
                if (sqlconn.State == System.Data.ConnectionState.Closed)
                {
                    sqlconn.Open();
                }

                //Bước 2 :Lấy hàng 
                // SqlCommand để thực hiện thao tác với dữ liệu
                var cmd = new SqlCommand("SP_Product_GetList", sqlconn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                //var cmd1 = new SqlCommand("SELECT * FROM tblProduct", sqlconn);
                //cmd1.CommandType = System.Data.CommandType.Text;

                // Bước 3: Quay về
                var reader = cmd.ExecuteReader(); // trả về dữ lieuj ở dang bảng

                //Chất hàng lên xe 
                while (reader.Read())
                {
                    var product = new Product();

                    int id = reader["ProductID"] != null ? Convert.ToInt32(reader["ProductID"].ToString()) : 0;
                    string productName = reader["ProductName"] != null ? reader["ProductName"].ToString() : "";
                    int Price = reader["Price"] != null ? Convert.ToInt32(reader["Price"].ToString()) : 0;

                    product.ProductID = id;
                    product.ProductName = productName;
                    product.Price = Price;
                    list.Add(product);
                }

                //Quay về 
                return list;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

    }


}
