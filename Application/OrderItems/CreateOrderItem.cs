using Application.DTO;
using Application.Interfaces;
using AutoMapper;
using Domain;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.OrderItems
{
    public class CreateOrderItem
    {
        public class Command : IRequest
        {
            public Command(OrderItemDto orderItem)
            {
                OrderItem = orderItem;
            }
            public OrderItemDto OrderItem { get; set; }
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
                var orderItem = _mapper.Map<OrderItemDto, OrderItem>(request.OrderItem);
                await _context.OrderItems.AddAsync(orderItem, cancellationToken);
                await _context.SaveChangesAsync(cancellationToken);
                return Unit.Value;
            }
        }
    }
}
