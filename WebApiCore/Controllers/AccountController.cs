using DataAcess.Demo.Entities;
using DataAcess.Demo.UnitOfWork;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using WebApiCore.Models;

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
                var refreshToken = GenerateRefreshToken();

                var token = new JwtSecurityTokenHandler().WriteToken(newAccessToken);

                // UPDATE LẠI refreshToken VÀ RefreshTokenExpiryTime  VÀO DATABASE
                int refreshTokenValidityInDays = Convert.ToInt32(_configuration["JWT:RefreshTokenValidityInDays"].ToString());
                var result = await _myShopUnitOfWork.AccountRepository.Account_UpDateRefeshToken(new AccountLoginUpdateRefeshTokenRequestData
                {
                    UserID = user.UserID,
                    RefreshToken = refreshToken,
                    RefreshTokenExpiryTime = DateTime.Now.AddDays(refreshTokenValidityInDays)
                });


                returnData.ResponseCode = user.UserID;
                returnData.Extention = user.FullName;
                returnData.Token = token;
                returnData.RefreshToken = refreshToken;
                return Ok(returnData);

            }
            catch (Exception ex)
            {

                throw;
            }
        }

        [HttpPost]
        [Route("refresh-token")]
        public async Task<IActionResult> RefreshToken(TokenModel tokenModel)
        {
            var returnData = new ReturnData();
            try
            {


                if (tokenModel is null)
                {
                    return BadRequest("Invalid client request");
                }

                string? accessToken = tokenModel.AccessToken;
                string? refreshToken = tokenModel.RefreshToken;

                var principal = GetPrincipalFromExpiredToken(accessToken);
                if (principal == null)
                {
                    return BadRequest("Invalid access token or refresh token");
                }

#pragma warning disable CS8600 // Converting null literal or possible null value to non-nullable type.
#pragma warning disable CS8602 // Dereference of a possibly null reference.
                string username = principal.Identity.Name;
#pragma warning restore CS8602 // Dereference of a possibly null reference.
#pragma warning restore CS8600 // Converting null literal or possible null value to non-nullable type.

                var user = await _myShopUnitOfWork.AccountRepository.Account_GetByUserName(new Account_GetByUserName
                {
                    UserName = username
                });

                if (user == null || user.RefreshToken != refreshToken || user.RefreshTokenExpiryTime <= DateTime.Now)
                {
                    return BadRequest("Chưa đến hạn hạn tạo token mới");
                }

                var newAccessToken = CreateToken(principal.Claims.ToList());
                var newRefreshToken = GenerateRefreshToken();

                user.RefreshToken = newRefreshToken;
                int refreshTokenValidityInDays = Convert.ToInt32(_configuration["JWT:RefreshTokenValidityInDays"].ToString());
               
                var result = await _myShopUnitOfWork.AccountRepository.Account_UpDateRefeshToken(new AccountLoginUpdateRefeshTokenRequestData
                {
                    UserID = user.UserID,
                    RefreshToken = refreshToken,
                    RefreshTokenExpiryTime = DateTime.Now.AddDays(refreshTokenValidityInDays)
                });

                //return new ObjectResult(new
                //{
                //    accessToken = new JwtSecurityTokenHandler().WriteToken(newAccessToken),
                //    refreshToken = newRefreshToken
                //});

                var token = new JwtSecurityTokenHandler().WriteToken(newAccessToken);

                returnData.ResponseCode = user.UserID;
                returnData.Extention = user.FullName;
                returnData.Token = token;
                returnData.RefreshToken = refreshToken;
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

        private static string GenerateRefreshToken()
        {
            var randomNumber = new byte[64];
            using var rng = RandomNumberGenerator.Create();
            rng.GetBytes(randomNumber);
            return Convert.ToBase64String(randomNumber);
        }

        private ClaimsPrincipal? GetPrincipalFromExpiredToken(string? token)
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
            var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out SecurityToken securityToken);
            if (securityToken is not JwtSecurityToken jwtSecurityToken || !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
                throw new SecurityTokenException("Invalid token");

            return principal;

        }

    }
}
