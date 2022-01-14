using Application.DTO;
using Application.Interfaces;
using AutoMapper;
using Domain;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Application.Exceptions;

namespace Application.Products
{
    public class GetProduct
    {
        public class Query : IRequest<ProductDto>
        {
            public Query(int id)
            {
                Id = id;
            }
            public int Id { get; set; }
        }

        public class Handler : IRequestHandler<Query, ProductDto>
        {
            private readonly IDataContext _context;
            private readonly IMapper _mapper;

            public Handler(IDataContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<ProductDto> Handle(Query request, CancellationToken cancellationToken)
            {
                var product = await _context.Products.FindAsync(new object[] { request.Id }, cancellationToken) ??
                              throw new EntityNotFoundException($"Раздел {request.Id} не найден");
                return _mapper.Map<Product, ProductDto>(product);
            }
        }
    }
}
