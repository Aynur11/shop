using Application.DTO.UpdateEntity;
using Application.Exceptions;
using Application.Interfaces;
using AutoMapper;
using Domain;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.FirstLevelIconSections
{
    public class UpdateFirstLevelIconSection
    {
        public class Command : IRequest
        {
            public Command(UpdateFirstLevelIconSectionDto section)
            {
                Section = section;
            }
            public UpdateFirstLevelIconSectionDto Section { get; set; }
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
                if (!_context.FirstLevelIconSections.Any(e => e.Id == request.Section.Id))
                {
                    throw new EntityNotFoundException($"Раздел {request.Section.Id} не найден");
                }
                _context.Update(_mapper.Map<UpdateFirstLevelIconSectionDto, FirstLevelIconSection>(request.Section));
                await _context.SaveChangesAsync(cancellationToken);
                return Unit.Value;
            }
        }
    }
}
