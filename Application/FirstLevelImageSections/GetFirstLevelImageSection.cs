using System.Threading;
using System.Threading.Tasks;
using Application.DTO;
using Application.Exceptions;
using Application.Interfaces;
using AutoMapper;
using MediatR;

namespace Application.FirstLevelImageSections
{
    public class GetFirstLevelImageSection
    {
        public class Query : IRequest<FirstLevelImageSectionDto>
        {
            public Query(int id)
            {
                Id = id;
            }
            public int Id { get; set; }
        }

        public class Handler : IRequestHandler<Query, FirstLevelImageSectionDto>
        {
            private readonly IDataContext _context;
            private readonly IMapper _mapper;
            public Handler(IDataContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<FirstLevelImageSectionDto> Handle(Query request, CancellationToken cancellationToken)
            {
                var order = await _context.FirstLevelImageSections.FindAsync(new object[] { request.Id }, cancellationToken) ??
                            throw new EntityNotFoundException($"Раздел {request.Id} не найден");
                return _mapper.Map<FirstLevelImageSectionDto>(order);
            }
        }
    }
}
