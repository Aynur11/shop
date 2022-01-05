using System.Linq;
using Application.DTO;
using Application.Interfaces;
using AutoMapper;
using Domain;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Application.Exceptions;

namespace Application.SecondLevelSections
{
    public class CreateSecondLevelSection
    {
        public class Command : IRequest
        {
            public Command(SecondLevelSectionDto section)
            {
                Section = section;
            }
            public SecondLevelSectionDto Section { get; set; }
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
                if (!_context.FirstLevelImageSections.Any(e => e.Id == request.Section.FirstLevelImageSectionId))
                {
                    throw new EntityNotFoundException($"Раздел по FK {request.Section.FirstLevelImageSectionId} не найден в таблице FirstLevelImageSection");
                }

                var section = _mapper.Map<SecondLevelSectionDto, SecondLevelSection>(request.Section);
                await _context.SecondLevelSections.AddAsync(section, cancellationToken);
                await _context.SaveChangesAsync(cancellationToken);
                return Unit.Value;
            }
        }
    }
}
