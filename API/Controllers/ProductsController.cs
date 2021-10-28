using Application.DTO;
using Application.Products;
using AutoMapper;
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
        private DataContext _context;
        private IMapper _mapper;
        public ProductsController(DataContext context, IMapper mapper)
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
    }
}