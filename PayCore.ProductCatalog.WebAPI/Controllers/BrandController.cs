using Microsoft.AspNetCore.Mvc;
using PayCore.ProductCatalog.Application.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PayCore.ProductCatalog.WebAPI.Controllers
{
    [ApiController]
    [Route("api/nhb/[controller]")]
    public class BrandController:ControllerBase
    {
        private readonly IBrandService brandService;

        public BrandController(IBrandService brandService)
        {
            this.brandService = brandService;
        }

        [HttpGet("getbrands")]
        public virtual async Task<IActionResult> GetAll()
        {

            var result = await brandService.GetAll();
            return Ok(result);
        }
    }
}
