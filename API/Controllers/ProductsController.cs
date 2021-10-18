using Application.Products;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Persistence;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsController : BaseApiController
    {
        private DataContext context;

        public ProductsController(DataContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<List<Product>> GetProductsAsync()
        {
            GetAllProducts.Handler handler = new GetAllProducts.Handler(context);
            return await handler.Handle(new GetAllProducts.Query(), new CancellationToken());
        }
    }
}