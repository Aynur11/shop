using Application.DTO;
using Application.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.FirstLevelImageSections
{
    public class UpdateFirstLevelImageSection
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

            public Handler(IDataContext context)
            {
                _context = context;
            }

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                _context.Update(request.Section);
                await _context.SaveChangesAsync(cancellationToken);
                return Unit.Value;
            }
        }
    }
}
