using Application.DTO;
using Application.Exceptions;
using Application.Interfaces;
using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.OrderItems
{
    public class GetOrderItem
    {
        public class Query : IRequest<OrderItemDto>
        {
            public Query(int id)
            {
                Id = id;
            }
            public int Id { get; set; }
        }

        public class Handler : IRequestHandler<Query, OrderItemDto>
        {
            private readonly IDataContext _context;
            private readonly IMapper _mapper;
            public Handler(IDataContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<OrderItemDto> Handle(Query request, CancellationToken cancellationToken)
            {
                var orderItems = await _context.OrderItems.FindAsync(new object[] { request.Id }, cancellationToken) ??
                            throw new EntityNotFoundException($"Раздел {request.Id} не найден");
                return _mapper.Map<OrderItemDto>(orderItems);
            }
        }
    }
}
