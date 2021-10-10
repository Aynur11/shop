using Domain;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Persistence;

namespace Application.Orders
{
    public class DeleteOrder
    {
        public class Command : IRequest<Order>
        {
            public int Id { get; set; }
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
                var order = await _context.Orders.FindAsync(request.Id, cancellationToken);
                _context.Orders.Remove(order);
                await _context.SaveChangesAsync(cancellationToken);
                return order;
            }
        }
    }
}
