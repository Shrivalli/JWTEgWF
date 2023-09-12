using JWTEg.Models;
namespace JWTEg.Repository
{
    public interface ILoginRepo<Logintbl>
    {
        public Logintbl GetUserDetail(Logintbl login);
    }
}
