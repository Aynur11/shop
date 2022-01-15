using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.DTO;
using AutoMapper;
using Application.Interfaces;

namespace Application.Orders
{
    public class GetAllOrders
    {
        public class Query : IRequest<List<OrderDto>> { }

        public class Handler : IRequestHandler<Query, List<OrderDto>>
        {
            readonly IDataContext _context;
            readonly IMapper _mapper;
            public Handler(IDataContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<List<OrderDto>> Handle(Query request, CancellationToken cancellationToken)
            {
                var orders = await _context.Orders.Include(e => e.Items).ToListAsync(cancellationToken);
                //var ordersDto = _mapper.Map<List<Order>, List<OrderDto>>(orders);
                List<OrderDto> ordersDto = new();
                foreach (var order in orders)
                {
                    var orderDto = _mapper.Map<Order, OrderDto>(order);
                    foreach (var orderItem in order.Items)
                    {
                        var orderItemDto = _mapper.Map<OrderItem, OrderItemDto>(orderItem);
                        orderItemDto.Quantity = orderItem.Quantity.Value;
                        orderDto.Items.Add(orderItemDto);
                    }
                    ordersDto.Add(orderDto);
                }
                return ordersDto;
            }
        }
    }
}
