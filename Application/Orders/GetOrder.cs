using Domain;
using MediatR;
using Persistence;
using System.Threading;
using System.Threading.Tasks;
using Application.Exceptions;

namespace Application.Orders
{
    public class GetOrder
    {
        public class Query : IRequest<Order>
        {
            public int Id { get; set; }
        }

        public class Handler : IRequestHandler<Query, Order>
        {
            readonly DataContext _context;
            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<Order> Handle(Query request, CancellationToken cancellationToken) =>
                await _context.Orders.FindAsync(request.Id, cancellationToken) ?? 
                throw new EntityNotFoundException($"Заказ {request.Id} не найден");
        }
    }
}
