using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PayCore.ProductCatalog.Application.Dto_Validator.Product.Dto;
using PayCore.ProductCatalog.Application.Interfaces.Services;
using System.Security.Claims;
using System.Threading.Tasks;

namespace PayCore.ProductCatalog.WebAPI.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService productService;

        public ProductController(IProductService offerService)
        {
            this.productService = offerService;
        }

        [HttpGet("getproducts")]
        public virtual async Task<IActionResult> GetAll()
        {
            //Fetching objects using service
            var result = await productService.GetAll();
            return Ok(result);
        }

        [HttpGet("getproductbyid")]
        public virtual async Task<IActionResult> GetById(int id)
        {
            //Fetching object using service
            var result = await productService.GetById(id);
            return Ok(result);
        }

        [HttpPost("createproduct")]
        public virtual async Task<IActionResult> Create([FromBody] ProductUpsertDto dto)
        {
            var accountId = int.Parse((User.Identity as ClaimsIdentity).FindFirst("AccountId").Value);
            await productService.InsertProduct(accountId, dto);
            return Ok();
        }

        [HttpPut("updateproduct")]
        public virtual async Task<IActionResult> Update(int productId,[FromBody] ProductUpsertDto dto)
        {
            var accountId = int.Parse((User.Identity as ClaimsIdentity).FindFirst("AccountId").Value);
            await productService.Update(productId,accountId, dto);
            return Ok();
        }

        [HttpDelete("deleteproduct")]
        public virtual async Task<IActionResult> Delete(int productId)
        {
            var accountId = int.Parse((User.Identity as ClaimsIdentity).FindFirst("AccountId").Value);
            await productService.Remove(productId,accountId);
            return Ok();
        }

        [HttpPut]
        public virtual async Task<IActionResult> BuyProductWithoutOffer(int productId)
        {
            var accountId = int.Parse((User.Identity as ClaimsIdentity).FindFirst("AccountId").Value);
            await productService.Remove(productId, accountId);
            return Ok();
        }
    }
}
