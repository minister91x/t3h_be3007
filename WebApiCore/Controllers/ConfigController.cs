using DataAcess.Demo.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using WebApiCore.Models;

namespace WebApiCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConfigController : ControllerBase
    {
        private IConfiguration _configuration;
        public ConfigController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpPost("CheckToken")]
        public async Task<ActionResult> CheckToken(GetPrincipalFromExpiredTokenRequestData requestData)
        {
            var returnData = new ReturnData();
            try
            {
                var tokenValidationParameters = new TokenValidationParameters
                {
                    ValidateAudience = false,
                    ValidateIssuer = false,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"])),
                    ValidateLifetime = false
                };

                var tokenHandler = new JwtSecurityTokenHandler();
                var principal = tokenHandler.ValidateToken(requestData.token, tokenValidationParameters, out SecurityToken securityToken);
                if (securityToken is not JwtSecurityToken jwtSecurityToken || !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
                {
                    returnData.ResponseCode = -1;
                    returnData.Description = "token không hợp lệ!";
                    return Ok(returnData);
                }

                var username = principal.Identity.Name;

              //  var user = await _userManager.FindByNameAsync(username);
                if (!string.IsNullOrEmpty(username))
                {
                    returnData.ResponseCode = 1;
                    returnData.Description = "token hợp lệ";
                    return Ok(returnData);
                }

                returnData.ResponseCode = 1;
                returnData.Description = "token hợp lệ";
                return Ok(returnData);

            }
            catch (Exception ex)
            {

                returnData.ResponseCode = 1;
                returnData.Description = "token hợp lệ";
                return Ok(returnData);

            }

        }
    }
}
