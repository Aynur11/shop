using Application.Interfaces;
using Domain;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Application.DTO;
using AutoMapper;

namespace Application.Products
{
    public class CreateProduct
    {
        public class Command : IRequest
        {
            public Command(ProductDto product)
            {
                Product = product;
            }
            public ProductDto Product { get; set; }
        }

        public class Handler : IRequestHandler<Command>
        {
            private readonly IDataContext _context;
            private readonly IMapper _mapper;

            public Handler(IDataContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                var product = _mapper.Map<ProductDto, Product>(request.Product);
                product.QuantityInStock = ProductQuantity.Create(request.Product.QuantityInStock).Value;
                await _context.Products.AddAsync(product, cancellationToken);
                await _context.SaveChangesAsync(cancellationToken);
                return Unit.Value;
            }
        }
    }
}
