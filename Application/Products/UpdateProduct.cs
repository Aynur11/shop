using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Application.DTO.UpdateEntity;
using Application.Exceptions;
using Application.Interfaces;
using AutoMapper;
using Domain;
using MediatR;

namespace Application.Products
{
    public class UpdateProduct
    {
        public class Command : IRequest
        {
            public Command(UpdateProductDto product)
            {
                Product = product;
            }
            public UpdateProductDto Product { get; set; }
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
                if (!_context.Products.Any(e => e.Id == request.Product.Id))
                {
                    throw new EntityNotFoundException($"Продукт {request.Product.Id} не найден");
                }

                var product = _mapper.Map<UpdateProductDto, Product>(request.Product);
                product.QuantityInStock = ProductQuantity.Create(request.Product.QuantityInStock).Value;
                _context.Update(product);
                await _context.SaveChangesAsync(cancellationToken);
                return Unit.Value;
            }
        }
    }
}
