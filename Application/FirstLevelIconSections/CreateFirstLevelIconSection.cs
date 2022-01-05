using Application.DTO;
using Application.Interfaces;
using AutoMapper;
using Domain;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.FirstLevelIconSections
{
    public class CreateFirstLevelIconSection
    {
        public class Command : IRequest
        {
            public Command(FirstLevelIconSectionDto section)
            {
                Section = section;
            }
            public FirstLevelIconSectionDto Section { get; set; }
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
                var section = _mapper.Map<FirstLevelIconSectionDto, FirstLevelIconSection>(request.Section);
                await _context.FirstLevelIconSections.AddAsync(section, cancellationToken);
                await _context.SaveChangesAsync(cancellationToken);
                return Unit.Value;
            }
        }
    }
}
