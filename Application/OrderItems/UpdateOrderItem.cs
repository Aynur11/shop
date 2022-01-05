using Application.DTO.UpdateEntity;
using Application.Exceptions;
using Application.Interfaces;
using AutoMapper;
using Domain;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.OrderItems
{
    public class UpdateOrderItem
    {
        public class Command : IRequest
        {
            public Command(UpdateOrderItemDto orderItem)
            {
                OrderItem = orderItem;
            }
            public UpdateOrderItemDto OrderItem { get; set; }
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
                if (!_context.OrderItems.Any(e => e.Id == request.OrderItem.Id))
                {
                    throw new EntityNotFoundException($"Элемент {request.OrderItem.Id} не найден");
                }
                _context.Update(_mapper.Map<UpdateOrderItemDto, UpdateOrderItem>(request.OrderItem));
                await _context.SaveChangesAsync(cancellationToken);
                return Unit.Value;
            }
        }
    }
}
