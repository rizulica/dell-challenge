using DellChallenge.D1.Api.Dal;
using DellChallenge.D1.Api.Dto;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DellChallenge.D1.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductsService _productsService;

        public ProductsController(IProductsService productsService)
        {
            _productsService = productsService;
        }

        [HttpGet]
        [EnableCors("AllowReactCors")]
        public async Task<ActionResult<IEnumerable<ProductDto>>> Get()
        {
            return Ok(await _productsService.GetAll());
        }

        [HttpGet("{id}")]
        [EnableCors("AllowReactCors")]
        public async Task<ActionResult<string>> Get(string id)
        {
            return Ok(await _productsService.GetByID(id));
        }

        [HttpPost]
        [EnableCors("AllowReactCors")]
        public async Task<ActionResult<ProductDto>> Post([FromBody] NewProductDto newProduct)
        {
            var addedProduct = await _productsService.Add(newProduct);
            return Ok(addedProduct);
        }

        [HttpDelete("{id}")]
        [EnableCors("AllowReactCors")]
        public async Task<ActionResult> Delete(string id)
        {
            var result = await _productsService.Delete(id);
            if (result)
                return Ok();
            else
                return BadRequest("The product specified does not exist!");
        }

        [HttpPut("{id}")]
        [EnableCors("AllowReactCors")]
        public async Task<ActionResult> Put(string id, [FromBody] NewProductDto updatedProduct)
        {
            var result = await _productsService.Update(id, updatedProduct);
            if (result)
                return Ok();
            else
                return BadRequest("The product specified does not exist!");
        }
    }
}
