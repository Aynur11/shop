using Application.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Application.Exceptions;

namespace Application.FirstLevelIconSections
{
    public class DeleteFirstLevelIconSection
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
                var section = await _context.FirstLevelIconSections.FindAsync(new object[] { request.Id }, cancellationToken) ??
                              throw new EntityNotFoundException($"Раздел {request.Id} не найден");
                _context.FirstLevelIconSections.Remove(section);
                await _context.SaveChangesAsync(cancellationToken);
                return Unit.Value;
            }
        }
    }
}
