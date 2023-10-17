using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebDemoMVC.CategoryManager;
using WebDemoMVC.EntitiesFrameWork.Entites;
using WebDemoMVC.Models;

namespace WebDemoMVC.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {


            return View();
        }

        public ActionResult ProductListPartialView(ProductListRequestData requestData)
        {
            //var productManager = new ProductManager();
            var list = new List<ProductModels>();
            if (string.IsNullOrEmpty(requestData.token))
            {
                return PartialView(list);
            }

            var url_api = System.Configuration.ConfigurationManager.AppSettings["URL_API"] ?? "http://localhost:5166/api/";
            var base_url = "Home/GetList";

            var req = new ProductGetListRequest { prductID = 0 };
            var dataJson = JsonConvert.SerializeObject(req);

            //var token = Request.Cookies["TOKEN_SERVER"] != null ? Request.Cookies["TOKEN_SERVER"].Value : string.Empty;

            var result = Compuer.Common.HttpHelper.WebPost_WithToken(url_api, base_url, dataJson, requestData.token);
            if (!string.IsNullOrEmpty(result))
            {
                list = JsonConvert.DeserializeObject<List<ProductModels>>(result);
            }

            TempData["list"] = list;
            return PartialView(list);
        }

        public ActionResult Product_Delete(int id)
        {
            var returnData = new ReturnData();
            var productManager = new ProductManager();
            try
            {
                var result = productManager.Product_Delete(new Product
                {
                    Id = id
                });

                if (result < 0)
                {
                    // returnData.ReturnMsg = "Xóa thất bại";
                    return Json(returnData, JsonRequestBehavior.AllowGet);
                }

                // returnData.ReturnMsg = "Xoá thành công";
                return Json(returnData, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {

                //returnData.ReturnMsg = ex.Message;
                return Json(returnData, JsonRequestBehavior.AllowGet);
            }


        }


    }
}