using Application.DTO;
using Application.Exceptions;
using Application.Interfaces;
using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.FirstLevelIconSections
{
    public class GetFirstLevelIconSection
    {
        public class Query : IRequest<FirstLevelIconSectionDto>
        {
            public Query(int id)
            {
                Id = id;
            }
            public int Id { get; set; }
        }

        public class Handler : IRequestHandler<Query, FirstLevelIconSectionDto>
        {
            readonly IDataContext _context;
            readonly IMapper _mapper;
            public Handler(IDataContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<FirstLevelIconSectionDto> Handle(Query request, CancellationToken cancellationToken)
            {
                var order = await _context.FirstLevelIconSections.FindAsync(new object[] { request.Id }, cancellationToken) ??
                    throw new EntityNotFoundException($"Заказ {request.Id} не найден");
                return _mapper.Map<FirstLevelIconSectionDto>(order);
            }
        }
    }
}
