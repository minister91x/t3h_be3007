using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebDemoMVC.EntitiesFrameWork;
using WebDemoMVC.EntitiesFrameWork.Entites;

namespace WebDemoMVC.CategoryManager
{
    public class CategoryManager : ICategory
    {
        StudentDbContext dbContext = new StudentDbContext();
        public List<Category> Categories_GetList(int cateId, string Name)
        {
            var list = new List<Category>();
            try
            {
                //Bước 1 : đi lấy dữ liêu ( SQL , XML ...vvv)

                list = dbContext.categorie.ToList();
                if (cateId > 0)
                {
                    // Đã có dữ liệu trong tay thì dùng LINQ để lọc dữ liệu
                    list = list.FindAll(a => a.CategoryId == cateId && a.CategoryName.Contains("điện tử")).ToList();
                    //list = list.Where(a => a.CategoryId == cateId).ToList();

                    var list1 = from item
                                in list
                                where
                                item.CategoryId == cateId
                                orderby item.CategoryId descending
                                select item;

                }

                if (!string.IsNullOrEmpty(Name))
                {
                    list = list.FindAll(s => s.CategoryName.ToLower().Contains(Name)).ToList();
                }
            }
            catch (Exception ex)
            {

                throw;
            }

            return list;
        }

        public int Category_Delete(int CateId)
        {
            try
            {
                // Bước 1: lấy ra category theo CateId truyền vào 
                var categoryRemove = dbContext.categorie.Where(c => c.CategoryId == CateId).FirstOrDefault();

                // Bước 2 : Xóa
                dbContext.categorie.Remove(categoryRemove);
                return dbContext.SaveChanges();
            }
            catch (Exception ex)
            {

                return -1;
            }
        }

        public int Category_InsertUpdate(Category category, int IsUpdate)
        {
            try
            {
                if (IsUpdate == 0)
                {
                    // INSERT
                    var checkExist = dbContext.categorie.ToList().FindAll(s => s.CategoryId == category.CategoryId);
                    if (checkExist.Count > 0)
                    {
                        // đã tồn tại rồi
                        return -1;
                    }


                    dbContext.categorie.Add(category);
                }
                else
                {
                    // UPDATE
                    var cate = dbContext.categorie.ToList().FirstOrDefault();
                    cate.CategoryId = category.CategoryId;
                    cate.CategoryName = category.CategoryName;
                }

                return dbContext.SaveChanges();

            }
            catch (Exception ex)
            {

                throw;
            }
        }

    }
}