using Compuer.Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebDemoMVC.Models;

namespace WebDemoMVC.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        public JsonResult Authen(AccountLoginRequestData requestData)
        {
            var returnData = new ReturnData();
            try
            {
                // Kiểm tra thông tin từ Ajax gửi xuống
                if (requestData == null ||
                    string.IsNullOrEmpty(requestData.UserName)
                    || string.IsNullOrEmpty(requestData.Password))
                {
                    returnData.ResponseCode = -1;
                    returnData.Description = "Vui lòng điền đầy đủ thông tin";
                    return Json(returnData, JsonRequestBehavior.AllowGet);
                }

                // CONVERT MẬT KHẨU SANG MD5
                var passwordHash = Compuer.Common.Security.MD5Hash(requestData.Password);
                requestData.Password = passwordHash;


                // Nếu pass kiểm trả thì goi sang API Net Core
                var url_api = System.Configuration.ConfigurationManager.AppSettings["URL_API"] ?? "http://localhost:5166/api/";
                var base_url = "Account/Account_Login";
                var dataJson = JsonConvert.SerializeObject(requestData);

                var result = Compuer.Common.HttpHelper.WebPost(url_api, base_url, dataJson);

                // Nhận kết quả trả về 

                if (string.IsNullOrEmpty(result))
                {
                    returnData.ResponseCode = -1;
                    returnData.Description = "Đăng nhập thất bại";
                    return Json(returnData, JsonRequestBehavior.AllowGet);
                }

                returnData = JsonConvert.DeserializeObject<ReturnData>(result);

                if (returnData.ResponseCode > 0)
                {
                    Session["USER_ID"] = returnData.ResponseCode;
                    Session["USER_FULLNAME"] = returnData.Extention;
                }
                // trả kết quả về View 
                return Json(returnData, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}