using System.Linq;
using Application.Interfaces;
using Domain;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Application.DTO.UpdateEntity;
using Application.Exceptions;
using AutoMapper;

namespace Application.Orders
{
    public class UpdateOrder
    {
        public class Command : IRequest
        {
            public Command(UpdateOrderDto order)
            {
                Order = order;
            }
            public UpdateOrderDto Order { get; set; }
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
                if (!_context.Products.Any(e => e.Id == request.Order.Id))
                {
                    throw new EntityNotFoundException($"Продукт {request.Order.Id} не найден");
                }
                _context.Update(_mapper.Map<UpdateOrderDto, Order>(request.Order));
                await _context.SaveChangesAsync(cancellationToken);
                return Unit.Value;
            }
        }
    }
}
