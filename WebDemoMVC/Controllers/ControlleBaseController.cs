using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebDemoMVC.Models;

namespace WebDemoMVC.Controllers
{
    public class ControlleBaseController : Controller
    {
        // GET: ControlleBase
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult CheckToken(GetPrincipalFromExpiredTokenRequestData requestData)
        {
            var returnData = new ReturnData();
            try
            {
                // Nếu pass kiểm trả thì goi sang API Net Core
                var url_api = System.Configuration.ConfigurationManager.AppSettings["URL_API"] ?? "http://localhost:5166/api/";
                var base_url = "Config/CheckToken";
                var dataJson = JsonConvert.SerializeObject(requestData);

                var result = Compuer.Common.HttpHelper.WebPost(url_api, base_url, dataJson);

                // Nhận kết quả trả về 

                if (string.IsNullOrEmpty(result))
                {
                    returnData.ResponseCode = -1;
                    returnData.Description = "token không hợp lệ";
                    return Json(returnData, JsonRequestBehavior.AllowGet);
                }

                returnData = JsonConvert.DeserializeObject<ReturnData>(result);

                returnData.ResponseCode = returnData.ResponseCode;
                returnData.Description = returnData.Description;
                return Json(returnData, JsonRequestBehavior.AllowGet);

                // trả kết quả về View 

            }
            catch (Exception ex)
            {

                returnData.ResponseCode = -1;
                returnData.Description = "token không hợp lệ";
                return Json(returnData, JsonRequestBehavior.AllowGet);
            }
        }
    }
}