using DataAcess.Demo.Entities;
using DataAcess.Demo.UnitOfWork;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace WebApiCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private IMyShopUnitOfWork _myShopUnitOfWork;
        private IConfiguration _configuration;
        public AccountController(IMyShopUnitOfWork myShopUnitOfWork, IConfiguration configuration)
        {
            _myShopUnitOfWork = myShopUnitOfWork;
            _configuration = configuration;
        }

        [HttpPost("Account_Login")]
        public async Task<ActionResult> Account_Login(AccountLoginRequestData requestData)
        {
            var returnData = new ReturnData();
            try
            {
                // bước 1: login để lấy acc theo username và password truyền vào
                var user = await _myShopUnitOfWork.AccountRepository.Account_Login(requestData);

                if (user == null || user.UserID <= 0)
                {
                    returnData.ResponseCode = 0;
                    returnData.Description = "Đăng nhập thất bại";
                    return Ok(returnData);
                }

                // bước 2 : Tạo token dựa trên object user
                var authClaims = new List<Claim> {
                      new Claim(ClaimTypes.PrimarySid, user.UserID.ToString()),
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(ClaimTypes.NameIdentifier, user.FullName) };

                var newAccessToken = CreateToken(authClaims);

                var token = new JwtSecurityTokenHandler().WriteToken(newAccessToken);

                returnData.ResponseCode =user.UserID;
                returnData.Extention = user.FullName;
                returnData.Description = token;
                return Ok(returnData);

            }
            catch (Exception ex)
            {

                throw;
            }
        }

        private JwtSecurityToken CreateToken(List<Claim> authClaims)
        {
            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));
            _ = int.TryParse(_configuration["JWT:TokenValidityInMinutes"], out int tokenValidityInMinutes);

            var token = new JwtSecurityToken(
                issuer: _configuration["JWT:ValidIssuer"],
                audience: _configuration["JWT:ValidAudience"],
                expires: DateTime.Now.AddMinutes(tokenValidityInMinutes),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                );

            return token;
        }

    }
}
