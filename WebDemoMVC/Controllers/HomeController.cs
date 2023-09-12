using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebDemoMVC.EntitiesFrameWork;
using WebDemoMVC.EntitiesFrameWork.Entites;
using WebDemoMVC.Models;

namespace WebDemoMVC.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult Index(string name)
        {
            var productManger = new WebDemoMVC.CategoryManager.CategoryManager();
            var model = new List<Category>();

            //var cate = new Category
            //{
            //    CategoryId = 1,
            //    CategoryName = "Điện tử"
            //};

            //var result = productManger.Category_InsertUpdate(cate, 0);

            //if (result > 0)
            //{
            //    // xử lý thông báo
            //    model = productManger.Categories_GetList(0, "").ToList();
            //}

            model = productManger.Categories_GetList(0, "").ToList();

            return View(model);
        }

        [HttpPost]
        public ActionResult Insert(Category model)
        {
            try
            {
                var productManger = new WebDemoMVC.CategoryManager.CategoryManager();

                var cate = new Category
                {
                    CategoryId = model.CategoryId,
                    CategoryName = model.CategoryName
                };

                var result = productManger.Category_InsertUpdate(cate, 0);
                if (result > 0)
                {
                    return Json(new { code = 1, msg = "Thêm mới thành công" });
                }
                else
                {
                    return Json(new { code = 0, msg = "Thêm mới thất bại" });
                }
            }
            catch (Exception ex)
            {

                return Json(new { code = -99, msg = ex.Message });
            }
        }


        [HttpPut]
        public ActionResult Update(Category model)
        {
            try
            {
                var productManger = new WebDemoMVC.CategoryManager.CategoryManager();

                var cate = new Category
                {
                    CategoryId = model.CategoryId,
                    CategoryName = model.CategoryName
                };

                var result = productManger.Category_InsertUpdate(cate, 1);
                if (result > 0)
                {
                    return Json(new { code = 1, msg = "Thêm mới thành công" });
                }
                else
                {
                    return Json(new { code = 0, msg = "Thêm mới thất bại" });
                }
            }
            catch (Exception ex)
            {

                return Json(new { code = -99, msg = ex.Message });
            }
        }


        [HttpDelete]
        [ActionName("Del")]
        public JsonResult Delete(int? id)
        {
            try
            {
                var productManger = new WebDemoMVC.CategoryManager.CategoryManager();


                var result = productManger.Category_Delete(Convert.ToInt32(id));
                if (result > 0)
                {
                    return Json(new { code = 1, msg = "Xóa mới thành công" });
                }
                else
                {
                    return Json(new { code = 0, msg = "Xóa mới thất bại" });
                }
            }
            catch (Exception ex)
            {

                return Json(new { code = -99, msg = ex.Message });
            }
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}