using Application.DTO;
using Application.Interfaces;
using AutoMapper;
using Domain;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

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
            readonly IMapper _mapper;

            public Handler(IDataContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                var section = _mapper.Map<SecondLevelSectionDto, SecondLevelSection>(request.Section);
                await _context.SecondLevelSections.AddAsync(section, cancellationToken);
                await _context.SaveChangesAsync(cancellationToken);
                return Unit.Value;
            }
        }
    }
}
