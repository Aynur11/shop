using Application.Exceptions;
using Application.Interfaces;
using AutoMapper;
using Domain;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Products
{
    public class GetProduct
    {
        public class Query : IRequest<Product>
        {
            public Query(int id)
            {
                Id = id;
            }
            public int Id { get; set; }
        }

        public class Handler : IRequestHandler<Query, Product>
        {
            private readonly IDataContext _context;
            public Handler(IDataContext context, IMapper mapper)
            {
                _context = context;
            }

            public async Task<Product> Handle(Query request, CancellationToken cancellationToken)
            {
                return await _context.Products.FindAsync(new object[] { request.Id }, cancellationToken) ??
                              throw new EntityNotFoundException($"Продукт {request.Id} не найден");
            }
        }
    }
}
