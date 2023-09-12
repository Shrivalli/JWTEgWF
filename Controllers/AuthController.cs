using Azure;
using JWTEg.Models;
using JWTEg.Service;
using JWTEg.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JWTEg.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly ILoginService<Logintbl> _serv;
        public AuthController(ILoginService<Logintbl> serv)
        {
            _serv = serv;
        }

        [HttpPost]
        public async Task<IActionResult> Login(Logintbl login)
        {
            IActionResult response = Unauthorized();
            var result=_serv.AuthenticateUser(login);
            if(result!= null)
            {
               var token= _serv.GenerateJsonWebToken(result);
               response = Ok(new LoginResponse { token = token, User_Id = login.Username, Role = login.IsEmployee });
            }

            return response;
            
        }
    }
}
