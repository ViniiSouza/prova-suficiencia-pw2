using Microsoft.IdentityModel.Tokens;
using ProgWebII.Modelos;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ProgWebII.Seguranca
{
    public class TokenServico
    {
        private static IConfiguration _config;

        public static void Initialize(IConfiguration config)
        {
            _config = config;
        }

        public static string GerarToken(Master master)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var secret = _config["Secret"].ToString();
            var key = Encoding.UTF8.GetBytes(secret);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, master.Login.ToLower()),
                }),
                Expires = DateTime.UtcNow.AddHours(2),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
