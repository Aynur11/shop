using Application.Products;
using Domain;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Application.DTO;
using Application.DTO.UpdateEntity;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsController : BaseApiController
    {
        [HttpPost("AddProduct")]
        public async Task<IActionResult> AddProduct(ProductDto product)
        {
            await Mediator.Send(new CreateProduct.Command(product));
            return Ok();
        }

        [HttpDelete("DeleteProduct")]
        public async Task DeleteProduct(int id)
        {
            await Mediator.Send(new DeleteProduct.Command(id));
        }

        [HttpGet("GetAllProduct")]
        public async Task<List<ProductDto>> GetAllProduct()
        {
            return await Mediator.Send(new GetAllProducts.Query());
        }

        [HttpGet("GetProduct/{id:int}")]
        public async Task<ProductDto> GetProduct(int id)
        {
            return await Mediator.Send(new GetProduct.Query(id));
        }

        [HttpPut("UpdateProduct")]
        public async Task UpdateProduct(UpdateProductDto section)
        {
            await Mediator.Send(new UpdateProduct.Command(section));
        }
    }
}