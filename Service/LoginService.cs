using JWTEg.Models;
using JWTEg.Repository;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace JWTEg.Service
{
    public class LoginService : ILoginService<Logintbl>
    {
        private readonly ILoginRepo<Logintbl> _repo;
        private readonly IConfiguration _config;

        public LoginService(ILoginRepo<Logintbl> repo,IConfiguration config) 
        {
            _repo = repo;
            _config = config;
        }
        public Logintbl AuthenticateUser(Logintbl user)
        {
            Logintbl result=_repo.GetUserDetail(user);

            return result;
        }

        public string GenerateJsonWebToken(Logintbl user)
        {
            if (user is null)
            {
                throw new ArgumentNullException(nameof(user));
            }
            
                List<Claim> claims = new List<Claim>();
                var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
                var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
                claims.Add(new Claim("Username", user.Username));
                if (user.IsEmployee)
                {
                    claims.Add(new Claim("role", "admin"));
                }
                else
                {
                    claims.Add(new Claim("role", "POC"));

                }
                var token = new JwtSecurityToken(_config["Jwt:Issuer"],
                  _config["Jwt:Issuer"],
                  claims,
                  expires: DateTime.Now.AddMinutes(10),
                  signingCredentials: credentials);
            
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
