using DataAcess.Demo.DBContext;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;
using System.Security.Claims;
using WebApiCore.Models;

namespace WebApiCore.Filter
{
    public class MyShopAuthorizeAttribute : TypeFilterAttribute
    {
        public MyShopAuthorizeAttribute(string functionCode = "DEFAULT", string permission = "VIEW") :
            base(typeof(AuthorizeActionFilter))
        {
            Arguments = new object[] { functionCode, permission };
        }
    }
    public class AuthorizeActionFilter : IAsyncAuthorizationFilter
    {
        public readonly MyShopUnitOfWorkDbContext _dbcontext;
        private readonly string _functionCode;
        private readonly string _permission;

        private IHttpContextAccessor _hcontext;
        public AuthorizeActionFilter(string functionCode, string permission,
            MyShopUnitOfWorkDbContext dbcontext, IHttpContextAccessor hcontext)
        {
            _functionCode = functionCode;
            _permission = permission;
            _dbcontext = dbcontext;
            _hcontext = hcontext;
        }
        public async Task OnAuthorizationAsync(AuthorizationFilterContext context)
        {
            //ClaimsPrincipal cp = _hcontext.HttpContext.User;

            var identity = context.HttpContext.User.Identity as ClaimsIdentity;
            if (identity != null)
            {
                var userClaims = identity.Claims;
                var user = new UserModel
                {
                    ID = Convert.ToInt32(userClaims.FirstOrDefault(x => x.Type == ClaimTypes.PrimarySid)?.Value),
                    Email = userClaims.FirstOrDefault(x => x.Type == ClaimTypes.Name)?.Value,
                    FullName = userClaims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value,
                };

                if (user.ID <= 0)
                {
                    context.HttpContext.Response.ContentType = "application/json";
                    context.HttpContext.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                    context.Result = new JsonResult(new
                    {
                        Code = HttpStatusCode.Unauthorized,
                        Message = "Vui lòng đăng nhập để thực hiện chức năng này "
                    }) ;

                    return;
                }

                var abc = "";

            }
           
        }
    }
}
