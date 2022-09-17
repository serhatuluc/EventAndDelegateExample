using Microsoft.AspNetCore.Mvc;
using PayCore.ProductCatalog.Application.Interfaces;
using PayCore.ProductCatalog.Domain.Token;
using System.Threading.Tasks;

namespace PayCore.ProductCatalog.WebAPI
{
    [ApiController]
    [Route("api/nhb/[controller]")]
    public class TokenController : ControllerBase
    {
        private readonly ITokenService tokenService;

        public TokenController(ITokenService tokenService)
        {
            this.tokenService = tokenService;
        }


        [HttpPost("Login")]
        public async Task<TokenResponse> Login([FromBody] TokenRequest request)
        {
            var response = await tokenService.GenerateToken(request);
            return response;
        }

    }
 }
