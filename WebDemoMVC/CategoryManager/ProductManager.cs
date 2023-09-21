using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebDemoMVC.EntitiesFrameWork.Entites;

namespace WebDemoMVC.CategoryManager
{
    public class ProductManager : IProduct
    {
        List<Product> list = new List<Product>();
        public List<Product> GetProducts(string KeySearch)
        {
            var list_p = new List<Product>();

            for (int i = 0; i < 10; i++)
            {
                list_p.Add(new Product
                {
                    Id = i,
                    Name = "PRODUCT" + i
                });
            }
            list = list_p;
            if (!string.IsNullOrEmpty(KeySearch))
            {
                list = list.FindAll(s => s.Name.ToLower().Contains(KeySearch.ToLower()));
            }
            return list;
        }

        public int Product_Delete(Product product)
        {
            var list_p = new List<Product>();

            for (int i = 0; i < 10; i++)
            {
                list_p.Add(new Product
                {
                    Id = i,
                    Name = "PRODUCT" + i
                });
            }
            list = list_p;
            var p = list.Where(s => s.Id == product.Id).FirstOrDefault();
            if (p == null || p.Id <= 0)
            {
                // có sản phẩm nào trong danh sách trùng với id truyền vào
                return -1;// không tồn tại sản phẩm nào tương ứng
            }

            list.Remove(product);

            return 1;

        }

        public int Product_InsertOrUpdate(Product product)
        {
            if (product.Id == 0)
            {
                list.Add(product);

                return 1; // thêm thành công
            }
            else
            {
                // lấy ra xem có product nào trùng với id người dùng truyền vào ko

                var p = list.Where(s => s.Id == product.Id).FirstOrDefault();
                if (p == null || p.Id <= 0)
                {
                    // có sản phẩm nào trong danh sách trùng với id truyền vào
                    return -1;// không tồn tại sản phẩm nào tương ứng
                }

                p.Id = product.Id;
                p.Name = product.Name;
                return 1; // cập nhật thành công
                //update
            }

        }
    }
}