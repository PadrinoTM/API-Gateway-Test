using JWTAuthManager;
using JWTAuthManager.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AuthenticationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly JwtTokenHandler _jwtTokenHandler;

        public AccountController(JwtTokenHandler jwtTokenHandler)
        {
            _jwtTokenHandler = jwtTokenHandler;   
        }

        [HttpPost]

        public ActionResult<AuthenticationResponse> Aunthenticate([FromBody] AuthenticationRequest authReq)
        {
            var authRsponse = _jwtTokenHandler.GenerateJwtToken(authReq);
            if (authRsponse != null) return authRsponse;
            
            return Unauthorized();
        }
    }
}
