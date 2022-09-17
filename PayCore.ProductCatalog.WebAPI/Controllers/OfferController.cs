using Microsoft.AspNetCore.Mvc;
using PayCore.ProductCatalog.Application.Dto_Validator;
using PayCore.ProductCatalog.Application.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PayCore.ProductCatalog.WebAPI.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class OfferController : ControllerBase
    {
        private readonly IOfferService offerService;

        public OfferController(IOfferService offerService)
        {
            this.offerService = offerService;
        }

        [HttpGet("getoffers")]
        public virtual async Task<IActionResult> GetAll()
        {
            //Fetching objects using service
            var result = await offerService.GetAll();
            return Ok(result);
        }

        [HttpGet("getoffersbyid")]
        public virtual async Task<IActionResult> GetById(int id)
        {
            //Fetching object using service
            var result = await offerService.GetById(id);
            return Ok(result);
        }

        [HttpPost("createoffer")]
        public virtual async Task<IActionResult> Create([FromBody] OfferUpsertDto dto)
        {
            await offerService.Insert(dto);
            return Ok();
        }

        [HttpPut("updateoffer")]
        public virtual async Task<IActionResult> Update(int id, [FromBody] OfferUpsertDto dto)
        {
            await offerService.Update(id, dto);
            return Ok();
        }

        [HttpDelete("deleteoffer")]
        public virtual async Task<IActionResult> Delete(int id)
        {
            await offerService.Remove(id);
            return Ok();
        }
    }
}
