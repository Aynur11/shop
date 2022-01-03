using System.Linq;
using Application.DTO;
using Application.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Domain;

namespace Application.FirstLevelIconSections
{
    public class UpdateFirstLevelIconSection
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
            readonly IMapper _mapper;

            public Handler(IDataContext context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                //FirstLevelIconSectionDto section = _context.FirstLevelIconSections.FirstOrDefault(e => e.Id == request.Section.Id)
                
                _context.Update(_mapper.Map<FirstLevelIconSectionDto, FirstLevelIconSection>(request.Section));
                await _context.SaveChangesAsync(cancellationToken);
                return Unit.Value;
            }
        }
    }
}
