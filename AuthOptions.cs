using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace SilvershotCore
{
    public class AuthOptions
    {
        public const string ISSUER = "issuer.info";
        public const string AUDIENCE = "MyAuthClient";
        const string KEY = "This is my custom Secret key for authentication";
        public const int LIFETIME = 1;
        public static SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(KEY));
        }
    }
}
