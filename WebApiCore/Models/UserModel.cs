using Microsoft.AspNetCore.Identity;

namespace WebApiCore.Models
{
    public class UserModel
    {
       public string Email { get; set; }
       public int ID { get; set; }
        public string FullName { get; set; }


    }

    public class TokenModel
    {
        public string? AccessToken { get; set; }
        public string? RefreshToken { get; set; }
    }
    public class ApplicationUser : IdentityUser
    {
        public string? RefreshToken { get; set; }
        public DateTime RefreshTokenExpiryTime { get; set; }
    }
}
