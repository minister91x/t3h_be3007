using DataAcess.Demo.DBContext;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;
using System.Security.Claims;
using WebApiCore.Models;

namespace WebApiCore.Filter
{
    public class MyCustomAuthorizeAttribute : TypeFilterAttribute

    {

        public MyCustomAuthorizeAttribute(string functionCode = "DEFAULT", string permission = "VIEW") :
    base(typeof(MyAuthorizeActionFilter))
        {
            Arguments = new object[] { functionCode, permission };
        }
    }

    public class MyAuthorizeActionFilter : IAsyncAuthorizationFilter
    {
        public readonly MyShopUnitOfWorkDbContext _dbcontext;
        private readonly string _functionCode;
        private readonly string _permission;

        public MyAuthorizeActionFilter(MyShopUnitOfWorkDbContext dbcontext, string functionCode, string permission)
        {
            _functionCode = functionCode;
            _permission = permission;
            _dbcontext = dbcontext;
        }

        public async Task OnAuthorizationAsync(AuthorizationFilterContext context)
        {
            var identity = context.HttpContext.User.Identity as ClaimsIdentity;
            // Đọc thông tin từ User.Identity
            if (identity != null)
            {
                var userClaims = identity.Claims;
                var user = new UserModel
                {
                    ID = Convert.ToInt32(userClaims.FirstOrDefault(x => x.Type == ClaimTypes.PrimarySid)?.Value),
                    Email = userClaims.FirstOrDefault(x => x.Type == ClaimTypes.Name)?.Value,
                    FullName = userClaims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value,
                };
                // Nếu không có user nào thì báo lỗi chưa đăng nhập
                if (user.ID <= 0)
                {
                    context.HttpContext.Response.ContentType = "application/json";
                    context.HttpContext.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                    context.Result = new JsonResult(new
                    {
                        Code = HttpStatusCode.Unauthorized,
                        Message = "Vui lòng đăng nhập để thực hiện chức năng này "
                    });

                    return;
                }

                // xem user là Admin hay user thường
                var userIfor = _dbcontext.user.ToList().FindAll(s => s.UserID == user.ID).FirstOrDefault();
                if (userIfor == null || userIfor.UserID <= 0)
                {
                    context.HttpContext.Response.ContentType = "application/json";
                    context.HttpContext.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                    context.Result = new JsonResult(new
                    {
                        Code = HttpStatusCode.Unauthorized,
                        Message = "Lỗi truy cập"
                    });

                    return;
                }

                // User thường
                if (userIfor.IsAdmin == 0)
                {
                    // CHECK ROLE VỚI FUNCTION
                    var functionInfor = _dbcontext.function.ToList().FindAll(s => s.FunctionCode == _functionCode).FirstOrDefault();
                    if (functionInfor == null || functionInfor.FunctionID < 0)
                    {
                        context.HttpContext.Response.ContentType = "application/json";
                        context.HttpContext.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                        context.Result = new JsonResult(new
                        {
                            Code = HttpStatusCode.Unauthorized,
                            Message = "Lỗi truy cập"
                        });

                        return;
                    }


                    var userfunction = _dbcontext.userfunction.ToList().FindAll(s => s.UserID == user.ID
                    && s.FunctionID == functionInfor.FunctionID).FirstOrDefault();

                    if (userfunction == null || userfunction.UserFunctionID < 0)
                    {
                        context.HttpContext.Response.ContentType = "application/json";
                        context.HttpContext.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                        context.Result = new JsonResult(new
                        {
                            Code = HttpStatusCode.Unauthorized,
                            Message = "Lỗi truy cập"
                        });

                        return;
                    }


                    if (_permission == "VIEW")
                    {
                        if (userfunction.IsView == 0)
                        {
                            context.HttpContext.Response.ContentType = "application/json";
                            context.HttpContext.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                            context.Result = new JsonResult(new
                            {
                                Code = HttpStatusCode.Unauthorized,
                                Message = "Không có quyền sử dụng chức năng này!"
                            });

                            return;
                        }
                    }

                    if (_permission == "INSERT")
                    {
                        if (userfunction.IsUpdate == 0)
                        {
                            context.HttpContext.Response.ContentType = "application/json";
                            context.HttpContext.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                            context.Result = new JsonResult(new
                            {
                                Code = HttpStatusCode.Unauthorized,
                                Message = "Không có quyền sử dụng chức năng này!"
                            });

                            return;
                        }
                    }
                }
            }
        }
    }
}
