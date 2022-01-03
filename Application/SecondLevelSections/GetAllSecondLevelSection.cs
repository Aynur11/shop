using Application.DTO;
using Application.Interfaces;
using AutoMapper;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.SecondLevelSections
{
    public class GetAllSecondLevelSection
    {
        public class Query : IRequest<List<SecondLevelSectionDto>> { }

        public class Handler : IRequestHandler<Query, List<SecondLevelSectionDto>>
        {
            readonly IDataContext _context;
            readonly IMapper _mapper;
            public Handler(IDataContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<List<SecondLevelSectionDto>> Handle(Query request, CancellationToken cancellationToken)
            {
                var sections = await _context.SecondLevelSections.ToListAsync(cancellationToken);
                return _mapper.Map<List<SecondLevelSection>, List<SecondLevelSectionDto>>(sections);
            }
        }
    }
}
