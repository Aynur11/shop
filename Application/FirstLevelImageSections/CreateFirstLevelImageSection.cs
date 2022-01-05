using System.Linq;
using Application.DTO;
using Application.Interfaces;
using AutoMapper;
using Domain;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Application.Exceptions;

namespace Application.FirstLevelImageSections
{
    public class CreateFirstLevelImageSection
    {
        public class Command : IRequest
        {
            public Command(FirstLevelImageSectionDto section)
            {
                Section = section;
            }
            public FirstLevelImageSectionDto Section { get; set; }
        }

        public class Handler : IRequestHandler<Command>
        {
            private readonly IDataContext _context;
            private readonly IMapper _mapper;

            public Handler(IDataContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                if (!_context.FirstLevelIconSections.Any(e => e.Id == request.Section.FirstLevelIconSectionId))
                {
                    throw new EntityNotFoundException($"Раздел по FK {request.Section.FirstLevelIconSectionId} не найден в таблице FirstLevelIconSections");
                }

                var section = _mapper.Map<FirstLevelImageSectionDto, FirstLevelImageSection>(request.Section);
                await _context.FirstLevelImageSections.AddAsync(section, cancellationToken);
                await _context.SaveChangesAsync(cancellationToken);
                return Unit.Value;
            }
        }
    }
}
