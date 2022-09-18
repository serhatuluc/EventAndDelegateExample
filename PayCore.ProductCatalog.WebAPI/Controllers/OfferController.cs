using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PayCore.ProductCatalog.Application.Dto_Validator;
using PayCore.ProductCatalog.Application.Interfaces.Services;
using System.Security.Claims;
using System.Threading.Tasks;

namespace PayCore.ProductCatalog.WebAPI.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/v1/[controller]")]
    public class OfferController : ControllerBase
    {
        private readonly IOfferService offerService;

        public OfferController(IOfferService offerService)
        {
            this.offerService = offerService;
        }

        [HttpGet("getoffersforuser")]
        public virtual async Task<IActionResult> GetAll()
        {
            var accountId = int.Parse((User.Identity as ClaimsIdentity).FindFirst("AccountId").Value);
            var result = await offerService.GetOffersForUser(accountId);
            return Ok(result);
        }

        //[HttpGet("getoffersbyid")]
        //public virtual async Task<IActionResult> GetById(int id)
        //{
        //    var result = await offerService.GetById(id);
        //    return Ok(result);
        //}

        [HttpPost("createoffer")]
        public virtual async Task<IActionResult> Create([FromBody] OfferUpsertDto dto)
        {
            var accountId = int.Parse((User.Identity as ClaimsIdentity).FindFirst("AccountId").Value);
            await offerService.OfferOnProduct(accountId,dto);
            return Ok();
        }

        //[HttpPut("updateoffer")]
        //public virtual async Task<IActionResult> Update(int id, [FromBody] OfferUpsertDto dto)
        //{
        //    await offerService.Update(id, dto);
        //    return Ok();
        //}

        //[HttpDelete("deleteoffer")]
        //public virtual async Task<IActionResult> Delete(int id)
        //{
        //    await offerService.Remove(id);
        //    return Ok();
        //}
    }
}
