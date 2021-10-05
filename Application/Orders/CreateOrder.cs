using Domain;
using MediatR;
using Persistence;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Orders
{
    public class CreateOrder
    {
        public class Query : IRequest<Order>
        {
            public Order Order { get; set; }
        }

        public class Handler : IRequestHandler<Query, Order>
        {
            private readonly DataContext _context;

            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<Order> Handle(Query request, CancellationToken cancellationToken)
            {
                await _context.Orders.AddAsync(request.Order, cancellationToken);
                await _context.SaveChangesAsync(cancellationToken);
                return request.Order;
            }
        }
    }
}
