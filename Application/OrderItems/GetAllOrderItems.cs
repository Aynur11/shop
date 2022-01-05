using Application.DTO;
using Application.Interfaces;
using AutoMapper;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.OrderItems
{
    public class GetAllOrderItems
    {
        public class Query : IRequest<List<OrderItemDto>> { }

        public class Handler : IRequestHandler<Query, List<OrderItemDto>>
        {
            private readonly IDataContext _context;
            private readonly IMapper _mapper;
            public Handler(IDataContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<List<OrderItemDto>> Handle(Query request, CancellationToken cancellationToken)
            {
                var orderItems = await _context.OrderItems.ToListAsync(cancellationToken);
                return _mapper.Map<List<OrderItem>, List<OrderItemDto>>(orderItems);
            }
        }
    }
}
