   using Application.DTO;
using Application.Interfaces;
using Application.Products;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsController : BaseApiController
    {
        private readonly IDataContext _context;
        private readonly IMapper _mapper;
        public ProductsController(IDataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<List<ProductDto>> GetProductsAsync()
        {
            GetAllProducts.Handler handler = new GetAllProducts.Handler(_context, _mapper);
            return await handler.Handle(new GetAllProducts.Query(), new CancellationToken());
        }

        [HttpPost]
        public async Task AddProduct(ProductDto product)
        {
            CreateProduct.Handler handler = new CreateProduct.Handler(_context, _mapper);
            CreateProduct.Command command = new CreateProduct.Command
            {
                Product = product
            };
            await handler.Handle(command, new CancellationToken());
        }
    }
}