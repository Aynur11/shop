using Application.DTO.UpdateEntity;
using Application.Exceptions;
using Application.Interfaces;
using AutoMapper;
using Domain;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.SecondLevelSections
{
    public class UpdateSecondLevelSection
    {
        public class Command : IRequest
        {
            public Command(UpdateSecondLevelSectionDto section)
            {
                Section = section;
            }
            public UpdateSecondLevelSectionDto Section { get; set; }
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
                if (!_context.SecondLevelSections.Any(e => e.Id == request.Section.Id))
                {
                    throw new EntityNotFoundException($"Раздел {request.Section.Id} не найден");
                }

                if (!_context.FirstLevelImageSections.Any(e => e.Id == request.Section.FirstLevelImageSectionId))
                {
                    throw new EntityNotFoundException($"Раздел по FK {request.Section.FirstLevelImageSectionId} не найден в таблице FirstLevelImageSection");
                }

                _context.Update(_mapper.Map<UpdateSecondLevelSectionDto, SecondLevelSection>(request.Section));
                await _context.SaveChangesAsync(cancellationToken);
                return Unit.Value;
            }
        }
    }
}
