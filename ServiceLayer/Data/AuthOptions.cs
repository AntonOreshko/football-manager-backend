using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace BusinessLayer.Data
{
    public class AuthOptions
    {
        public const string ISSUER = "ARAXIS GAMES";

        public const string AUDIENCE = "http://localhost:13666/";

        private const string KEY = "sPdfD9Sw-BZVfAcQG-O6Jwcl19-AAqwXFCJ";

        public const int LIFETIME = 1;

        public static SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(KEY));
        }
    }
}
