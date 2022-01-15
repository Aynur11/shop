using System.Linq;
using Application.DTO;
using Application.Interfaces;
using AutoMapper;
using Domain;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Application.Exceptions;

namespace Application.Orders
{
    public class CreateOrder
    {
        public class Command : IRequest
        {
            public Command(OrderDto order)
            {
                Order = order;
            }
            public OrderDto Order { get; set; }
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
                var order = _mapper.Map<OrderDto, Order>(request.Order);
                foreach (var item in request.Order.Items)
                {
                    if (!_context.Products.Any(e => e.Id == item.ProductId))
                    {
                        throw new EntityNotFoundException($"Продукт с ID = {item.ProductId} не найден в таблице Products." +
                                                          " Повторите операцию, удалив из заказа отсутствующие продукты.");
                    }

                    var orderItem = _mapper.Map<OrderItemDto, OrderItem>(item);
                    orderItem.Quantity = ProductQuantity.Create(item.Quantity).Value;
                    order.Items.Add(orderItem);
                }
                await _context.Orders.AddAsync(order, cancellationToken);
                await _context.SaveChangesAsync(cancellationToken);
                return Unit.Value;
            }
        }
    }
}
