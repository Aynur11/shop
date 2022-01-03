using Application.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Application.Exceptions;

namespace Application.FirstLevelImageSections
{
    public class DeleteFirstLevelImageSection
    {
        public class Command : IRequest
        {
            public int Id { get; set; }
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
                var section = await _context.FirstLevelImageSections.FindAsync(request.Id, cancellationToken) ??
                              throw new EntityNotFoundException($"Раздел {request.Id} не найден");
                _context.FirstLevelImageSections.Remove(section);
                await _context.SaveChangesAsync(cancellationToken);
                return Unit.Value;
            }
        }
    }
}
