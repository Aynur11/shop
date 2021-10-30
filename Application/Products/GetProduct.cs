using System.Threading;
using System.Threading.Tasks;
using Application.DTO;
using AutoMapper;
using Domain;
using MediatR;
using Persistence;

namespace Application.Products
{
    public class GetProduct
    {
        public class Query : IRequest<ProductDto>
        {
            public int Id { get; set; }
        }

        public class Handler : IRequestHandler<Query, ProductDto>
        {
            readonly DataContext _context;
            readonly IMapper _mapper;
            public Handler(DataContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<ProductDto> Handle(Query request, CancellationToken cancellationToken)
            {
                var product = await _context.Products.FindAsync(request.Id, cancellationToken);
                return _mapper.Map<Product, ProductDto>(product);
            }
        }
    }
}
