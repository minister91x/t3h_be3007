using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebDemoMVC.Models;

namespace WebDemoMVC.Controllers
{
    public class ShoppingCartController : Controller
    {
        // GET: ShoppingCart
        public ActionResult Index()
        {
            var list_cart = new List<ShoppingCart>();
            try
            {
                var cart = Request.Cookies["ShoppingCart"] != null ? Request.Cookies["ShoppingCart"].Value : string.Empty;
                list_cart = Newtonsoft.Json.JsonConvert.DeserializeObject<List<ShoppingCart>>(HttpUtility.UrlDecode(cart));
            }
            catch (Exception ex)
            {

                throw;
            }

            return View(list_cart);
        }

        public JsonResult CheckOut(Customer customerReq)
        {
            var list_cart = new List<ShoppingCart>();
            var returnData = new ReturnData();
            var listProductSend = new List<OrderRequest>();
            try
            {
                // Lấy thông tin giỏ hàng từ cookies
                var cart = Request.Cookies["ShoppingCart"] != null ? Request.Cookies["ShoppingCart"].Value : string.Empty;
                list_cart = Newtonsoft.Json.JsonConvert.DeserializeObject<List<ShoppingCart>>(HttpUtility.UrlDecode(cart));

                if (list_cart == null || list_cart.Count <= 0 || customerReq == null)
                {
                    returnData.ResponseCode = -50;
                    returnData.Description = "Dữ liệu đầu vào không hợp lệ!";
                    return Json(returnData, JsonRequestBehavior.AllowGet);
                }

                // tạo thông tin ProductID ,Quantity sẽ gửi lên Server
                foreach (var item in list_cart)
                {
                    listProductSend.Add(new OrderRequest
                    {
                        ProductID = item.ProductId,
                        Quantity = item.Quantity
                    });
                }

                var url_api = System.Configuration.ConfigurationManager.AppSettings["URL_API"] ?? "http://localhost:5166/api/";
                var base_url = "Order/OrderInsert";


                var req = new CreateOrderRequestData
                {
                    customer = customerReq,
                    orderItems = listProductSend,
                    token = ""
                };
                var dataJson = JsonConvert.SerializeObject(req);

                //var token = Request.Cookies["TOKEN_SERVER"] != null ? Request.Cookies["TOKEN_SERVER"].Value : string.Empty;

                var result = Compuer.Common.HttpHelper.WebPost_WithToken(url_api, base_url, dataJson, "");
                if (!string.IsNullOrEmpty(result))
                {
                    returnData = JsonConvert.DeserializeObject<ReturnData>(result);
                }

                return Json(returnData, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}