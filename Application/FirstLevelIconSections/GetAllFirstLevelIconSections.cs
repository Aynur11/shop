using Application.DTO;
using Application.Interfaces;
using AutoMapper;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Application.FirstLevelIconSections
{
    public class GetAllFirstLevelIconSections
    {
        public class Query : IRequest<List<FirstLevelIconSectionDto>> { }

        public class Handler : IRequestHandler<Query, List<FirstLevelIconSectionDto>>
        {
            readonly IDataContext _context;
            readonly IMapper _mapper;
            public Handler(IDataContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<List<FirstLevelIconSectionDto>> Handle(Query request, CancellationToken cancellationToken)
            {
                var sections = await _context.FirstLevelIconSections.ToListAsync(cancellationToken: cancellationToken);
                return _mapper.Map<List<FirstLevelIconSection>, List<FirstLevelIconSectionDto>>(sections);
            }
        }
    }
}
