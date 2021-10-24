using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.DTO;
using AutoMapper;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;

namespace Application.Products
{
    public class GetAllProducts
    {
        public class Query : IRequest<List<ProductDto>> { }

        public class Handler : IRequestHandler<Query, List<ProductDto>>
        {
            readonly DataContext _context;
            readonly IMapper _mapper;
            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<List<ProductDto>> Handle(Query request, CancellationToken cancellationToken)
            {
                var products = await _context.Products.ToListAsync(cancellationToken: cancellationToken);
                return _mapper.Map<List<Product>, List<ProductDto>>(products);
            }
        }
    }
}
