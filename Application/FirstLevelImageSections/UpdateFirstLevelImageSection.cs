using Application.DTO.UpdateEntity;
using Application.Exceptions;
using Application.Interfaces;
using Domain;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;

namespace Application.FirstLevelImageSections
{
    public class UpdateFirstLevelImageSection
    {
        public class Command : IRequest
        {
            public Command(UpdateFirstLevelImageSectionDto section)
            {
                Section = section;
            }
            public UpdateFirstLevelImageSectionDto Section { get; set; }
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
                if (!_context.FirstLevelImageSections.Any(e => e.Id == request.Section.Id))
                {
                    throw new EntityNotFoundException($"Раздел {request.Section.Id} не найден");
                }

                if (!_context.FirstLevelIconSections.Any(e => e.Id == request.Section.FirstLevelIconSectionId))
                {
                    throw new EntityNotFoundException($"Раздел по FK {request.Section.FirstLevelIconSectionId} не найден в таблице FirstLevelIconSections");
                }

                _context.Update(_mapper.Map<UpdateFirstLevelImageSectionDto, FirstLevelImageSection>(request.Section));
                await _context.SaveChangesAsync(cancellationToken);
                return Unit.Value;
            }
        }
    }
}
