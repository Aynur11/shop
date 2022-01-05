using Application.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Application.Exceptions;

namespace Application.OrderItems
{
    public class DeleteOrderItem
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
                var orderItem = await _context.OrderItems.FindAsync(new object[] { request.Id }, cancellationToken) ??
                              throw new EntityNotFoundException($"Элемент {request.Id} не найден");
                _context.OrderItems.Remove(orderItem);
                await _context.SaveChangesAsync(cancellationToken);
                return Unit.Value;
            }
        }
    }
}
