using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Domain;
using MediatR;
using Persistence;

namespace Application.Orders
{
    public class UpdateOrder
    {
        public class Command : IRequest<Order>
        {
            public Order Order { get; set; }
        }

        public class Handler : IRequestHandler<Command, Order>
        {
            private readonly DataContext _context;

            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<Order> Handle(Command request, CancellationToken cancellationToken)
            {
                _context.Update(request.Order);
                await _context.SaveChangesAsync(cancellationToken);
                return request.Order;
            }
        }
    }
}
