using JWTEg.Models;

namespace JWTEg.Repository
{
    public class LoginRepo : ILoginRepo<Logintbl>
    {
        private readonly LoanwfContext _context;
        public LoginRepo(LoanwfContext context)
        {
            _context = context;
        }
        public Logintbl GetUserDetail(Logintbl login)
        {
            return _context.Logintbls.SingleOrDefault(x => x.Username == login.Username && x.Password == login.Password);
        }
    }
}
