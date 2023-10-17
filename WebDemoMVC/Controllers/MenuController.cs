using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebDemoMVC.Models;

namespace WebDemoMVC.Controllers
{
    public class MenuController : Controller
    {
        // GET: Menu
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult MenuLeftPartialView()
        {
            //var productManager = new ProductManager();
            var list = new List<FunctionModels>();
           

            var url_api = System.Configuration.ConfigurationManager.AppSettings["URL_API"] ?? "http://localhost:5166/api/";
            var base_url = "Menu/GetList";

            var req = new ProductGetListRequest { prductID = 0 };
            var dataJson = JsonConvert.SerializeObject(req);

            var token = Request.Cookies["TOKEN_SERVER"] != null ? Request.Cookies["TOKEN_SERVER"].Value : string.Empty;

            var result = Compuer.Common.HttpHelper.WebPost_WithToken(url_api, base_url, dataJson, token);
            if (!string.IsNullOrEmpty(result))
            {
                list = JsonConvert.DeserializeObject<List<FunctionModels>>(result);
            }

            TempData["list"] = list;
            return PartialView(list);
        }
    }
}