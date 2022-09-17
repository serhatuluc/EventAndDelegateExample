using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PayCore.ProductCatalog.Application.Dto_Validator.Product.Dto;
using PayCore.ProductCatalog.Application.Interfaces.Services;
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

        [HttpGet("getcategories")]
        public virtual async Task<IActionResult> GetAll()
        {
            //Fetching objects using service
            var result = await productService.GetAll();
            return Ok(result);
        }

        [HttpGet("getcategorybyid")]
        public virtual async Task<IActionResult> GetById(int id)
        {
            //Fetching object using service
            var result = await productService.GetById(id);
            return Ok(result);
        }

        [HttpPost("createcategory")]
        public virtual async Task<IActionResult> Create([FromBody] ProductUpsertDto dto)
        {
            await productService.Insert(dto);
            return Ok();
        }

        [HttpPut("updatecategory")]
        public virtual async Task<IActionResult> Update(int id, [FromBody] ProductUpsertDto dto)
        {
            await productService.Update(id, dto);
            return Ok();
        }

        [HttpDelete("deletecategory")]
        public virtual async Task<IActionResult> Delete(int id)
        {
            await productService.Remove(id);
            return Ok();
        }
    }
}
