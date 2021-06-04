using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using WebLab5.Models;

namespace WebLab5.Services
{
    public class AccountService
    {
        private static Dictionary<string, User> usersDictionary = new Dictionary<string, User>();

        public string Register(string login, string tgLogin, string conId)
        {
            if (usersDictionary.Values.Any(x => x.Login == login))
            {
                return null;
            }
            var user = new User { Login = login, TelegramLogin = tgLogin, ConnectionId = conId };
            var token = GenerateToken(user);
            usersDictionary.Add(token, user);
            return token;
        }

        public string Getusername(string token)
        {
            return usersDictionary[token].Login;
        }

        public string GetConnId(string username)
        {
            return usersDictionary.Values.FirstOrDefault(x => x.Login == username)?.ConnectionId;
        }

        public IEnumerable<string> GetConsExcept(IEnumerable<string> cons)
        {
            return usersDictionary.Values.Select(x => x.ConnectionId).Where(x => !cons.Any(y => y == x));
        }

        private string GenerateToken(User user)
        {
            var mySecret = "doesntMatterForNow";
            var mySecurityKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(mySecret));

            var myIssuer = "http://mysite.com";
            var myAudience = "http://myaudience.com";

            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.NameIdentifier, user.Login),
                    new Claim("tgLogin", user.TelegramLogin),
                    new Claim("connId", user.ConnectionId),
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                Issuer = myIssuer,
                Audience = myAudience,
                SigningCredentials = new SigningCredentials(mySecurityKey, SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
