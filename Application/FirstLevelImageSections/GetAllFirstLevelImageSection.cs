using Application.Interfaces;
using AutoMapper;
using Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Application.DTO;


namespace Application.FirstLevelImageSections
{
    public class GetAllFirstLevelImageSection
    {
        public class Query : IRequest<List<FirstLevelImageSectionDto>> { }

        public class Handler : IRequestHandler<Query, List<FirstLevelImageSectionDto>>
        {
            readonly IDataContext _context;
            readonly IMapper _mapper;
            public Handler(IDataContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<List<FirstLevelImageSectionDto>> Handle(Query request, CancellationToken cancellationToken)
            {
                var sections = await _context.FirstLevelImageSections.ToListAsync(cancellationToken);
                return _mapper.Map<List<FirstLevelImageSection>, List<FirstLevelImageSectionDto>>(sections);
            }
        }
    }
}
