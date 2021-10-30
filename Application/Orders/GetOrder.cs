using Application.DTO;
using Application.Exceptions;
using AutoMapper;
using MediatR;
using Persistence;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Orders
{
    public class GetOrder
    {
        public class Query : IRequest<OrderDto>
        {
            public int Id { get; set; }
        }

        public class Handler : IRequestHandler<Query, OrderDto>
        {
            readonly IDataContext _context;
            readonly IMapper _mapper;
            public Handler(IDataContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<OrderDto> Handle(Query request, CancellationToken cancellationToken)
            {
                var order = await _context.Orders.FindAsync(request.Id, cancellationToken) ??
                    throw new EntityNotFoundException($"Заказ {request.Id} не найден");
                return _mapper.Map<OrderDto>(order);
            }
        }
    }
}
