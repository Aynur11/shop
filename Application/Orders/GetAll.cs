using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.DTO;
using AutoMapper;

namespace Application.Orders
{
    public class GetAll
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
                var orders = await _context.Orders.ToListAsync(cancellationToken: cancellationToken);
                return _mapper.Map<List<Order>, List<OrderDto>>(orders);
            }
        }
    }
}
