using Application.Interfaces;
using AutoMapper;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.DTO;

namespace Application.Products
{
    public class GetAllProducts
    {
        public class Query : IRequest<List<ProductDto>> { }

        public class Handler : IRequestHandler<Query, List<ProductDto>>
        {
            private readonly IDataContext _context;
            private readonly IMapper _mapper;
            public Handler(IDataContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<List<ProductDto>> Handle(Query request, CancellationToken cancellationToken)
            {
                var products = await _context.Products.ToListAsync(cancellationToken);
                return _mapper.Map<List<Product>, List<ProductDto>>(products);
            }
        }
    }
}
