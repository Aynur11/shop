using Application.DTO.UpdateEntity;
using Application.Exceptions;
using Application.Interfaces;
using AutoMapper;
using Domain;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

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
                if (!_context.Orders.Any(e => e.Id == request.Order.Id))
                {
                    throw new EntityNotFoundException($"Заказ {request.Order.Id} не найден");
                }

                var order = _mapper.Map<UpdateOrderDto, Order>(request.Order);

                foreach (var item in request.Order.Items)
                {
                    if (!_context.OrderItems.Any(e => e.Id == item.Id))
                    {
                        throw new EntityNotFoundException($"Элемент заказа с ID = {item.Id}  не найден в таблице OrderItems.");
                    }
                    if (!_context.Products.Any(e => e.Id == item.ProductId))
                    {
                        throw new EntityNotFoundException($"Продукт с ID = {item.ProductId} не найден в таблице Products." +
                                                          " Повторите операцию, удалив из заказа отсутствующие продукты.");
                    }
                    var orderItem = _mapper.Map<UpdateOrderItemDto, OrderItem>(item);
                    orderItem.Quantity = ProductQuantity.Create(item.Quantity).Value;
                    order.Items.Add(orderItem);
                }

                // TODO: Добавить транзакцию.
                foreach (var item in order.Items)
                {
                    _context.Update(item);
                }
                _context.Update(order);
                await _context.SaveChangesAsync(cancellationToken);
                return Unit.Value;
            }
        }
    }
}
