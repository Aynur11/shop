using Application.Interfaces;
using AutoMapper;
using Domain;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.FirstLevelImageSections
{
    public class CreateElement<T1, T2>
    {
        public class Command : IRequest
        {
            public Command(T1 section)
            {
                Section = section;
            }
            public T1 Section { get; set; }
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
                var section = _mapper.Map<T1, T2>(request.Section);
                //await _context.FirstLevelIconSections.AddAsync(section, cancellationToken);
                await _context.SaveChangesAsync(cancellationToken);
                return Unit.Value;
            }
        }
    }
}
