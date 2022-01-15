using Application.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Application.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace Application.Orders
{
    public class DeleteOrder
    {
        public class Command : IRequest
        {
            public Command(int id)
            {
                Id = id;
            }
            public int Id { get; set; }
        }

        public class Handler : IRequestHandler<Command>
        {
            private readonly IDataContext _context;

            public Handler(IDataContext context)
            {
                _context = context;
            }

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                var order = await _context.Orders
                    .Include(e => e.Items)
                    .FirstOrDefaultAsync(i => i.Id == request.Id, cancellationToken) ?? 
                            throw new EntityNotFoundException($"Заказ {request.Id} не найден");

                foreach (var orderItem in order.Items)
                {
                    _context.OrderItems.Remove(orderItem);
                }
                await _context.SaveChangesAsync(cancellationToken);
                _context.Orders.Remove(order);
                await _context.SaveChangesAsync(cancellationToken);
                return Unit.Value;
            }
        }
    }
}
