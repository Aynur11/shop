using System.Threading;
using System.Threading.Tasks;
using Domain;
using MediatR;
using Persistence;

namespace Application.Products
{
    public class GetProduct
    {
        public class Query : IRequest<Product>
        {
            public int Id { get; set; }
        }

        public class Handler : IRequestHandler<Query, Product>
        {
            readonly DataContext _context;
            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<Product> Handle(Query request, CancellationToken cancellationToken)
            {
                return await _context.Products.FindAsync(request.Id, cancellationToken);
            }
        }
    }
}
