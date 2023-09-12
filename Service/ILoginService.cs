using JWTEg.Models;

namespace JWTEg.Service
{
    public interface ILoginService<Logintbl>
    {
        public Logintbl AuthenticateUser(Logintbl user);
        public string GenerateJsonWebToken(Logintbl user);
    }
}
