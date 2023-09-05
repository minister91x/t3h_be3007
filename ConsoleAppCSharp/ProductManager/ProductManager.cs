using ConsoleAppCSharp.Database;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppCSharp.ProductManager
{
    public class ProductManager : IProduct
    {
        public int ProductInsert(ProductDataBase product)
        {
            try
            {
                // Bước 1: mở connection đến Database
                var sqlconn = DbHelper.GetSqlConnection();

                //Bước 2:SqlCommand để thực hiện thao tác với dữ liệu
                var cmd = new SqlCommand("SP_ProductInsertUpdate", sqlconn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@_ProductID", product.ProductID);
                cmd.Parameters.AddWithValue("@_ProductName", product.ProductName);
                cmd.Parameters.AddWithValue("@_Price", product.Price);
                cmd.Parameters.AddWithValue("@_CatId", product.CatId);
                cmd.Parameters.Add("@_ResponseCode", System.Data.SqlDbType.Int).Direction = System.Data.ParameterDirection.Output;

                // Bước 3: thực hiện insert
                cmd.ExecuteNonQuery();
                //sqlconn.Close();
                var result = cmd.Parameters["@_ResponseCode"].Value != null ? Convert.ToInt32(cmd.Parameters["@_ResponseCode"].Value) : 0;
                return result;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public List<ProductDataBase> ProductsGetList(int ProductID)
        {

            var list = new List<ProductDataBase>();
            try
            {
                //Bước 1: Truy cập vào kho (database)
                // mở connect đển địa chỉ của sqlserver 
                var sqlconn = DbHelper.GetSqlConnection();

                //Bước 2 :Lấy hàng 
                // SqlCommand để thực hiện thao tác với dữ liệu
                var cmd = new SqlCommand("SP_Product_GetList", sqlconn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                //var cmd1 = new SqlCommand("SELECT * FROM tblProduct", sqlconn);
                //cmd1.CommandType = System.Data.CommandType.Text;

                cmd.Parameters.AddWithValue("@_ProductID", ProductID);

                // Bước 3: Quay về
                var reader = cmd.ExecuteReader(); // trả về dữ lieuj ở dang bảng

                //Chất hàng lên xe 
                while (reader.Read())
                {
                    var product = new ProductDataBase();

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
