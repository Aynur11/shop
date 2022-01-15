using Application.DTO;
using Application.Exceptions;
using Application.Interfaces;
using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace Application.Orders
{
    public class GetOrder
    {
        public class Query : IRequest<OrderDto>
        {
            public Query(int id)
            {
                Id = id;
            }
            public int Id { get; set; }
        }

        public class Handler : IRequestHandler<Query, OrderDto>
        {
            private readonly IDataContext _context;
            private readonly IMapper _mapper;
            public Handler(IDataContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<OrderDto> Handle(Query request, CancellationToken cancellationToken)
            {
                var order = await _context.Orders
                                .Include(e => e.Items)
                                .FirstOrDefaultAsync(i => i.Id == request.Id, cancellationToken) ?? 
                            throw new EntityNotFoundException($"Заказ {request.Id} не найден");

                var orderDto = _mapper.Map<OrderDto>(order);
                foreach (var item in order.Items)
                {
                    var orderItemDto = _mapper.Map<OrderItem, OrderItemDto>(item);
                    orderItemDto.Quantity = item.Quantity.Value;
                    orderDto.Items.Add(orderItemDto);
                }
                return orderDto;
            }
        }
    }
}
