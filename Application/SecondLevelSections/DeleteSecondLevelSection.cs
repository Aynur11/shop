using Application.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Application.Exceptions;

namespace Application.SecondLevelSections
{
    public class DeleteSecondLevelSection
    {
        public class Command : IRequest
        {
            public Command(int id)
            {
                Id = id;
            }
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
                var section = await _context.SecondLevelSections.FindAsync(request.Id, cancellationToken) ??
                              throw new EntityNotFoundException($"Раздел {request.Id} не найден");
                _context.SecondLevelSections.Remove(section);
                await _context.SaveChangesAsync(cancellationToken);
                return Unit.Value;
            }
        }
    }
}
