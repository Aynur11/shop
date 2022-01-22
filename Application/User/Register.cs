using Application.DTO.User;
using Application.Exceptions;
using AutoMapper;
using Domain;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System.Threading;
using System.Threading.Tasks;

namespace Application.User
{
    public class Register
    {
        public class Command : IRequest
        {
            public Command(UserRegistrationDto user)
            {
                User = user;
            }

            public UserRegistrationDto User { get; set; }
        }

        public class CommandValidator : AbstractValidator<Command>
        {
            public CommandValidator()
            {
                RuleFor(x => x.User.Email)
                    .NotEmpty()
                    .MinimumLength(4)
                    .EmailAddress();
                RuleFor(x => x.User.Password)
                    .NotEmpty()
                    .MinimumLength(6);
            }
        }

        public class Handler : IRequestHandler<Command>
        {
            private readonly UserManager<ApplicationUser> _userManager;
            private readonly IMapper _mapper;

            public Handler(UserManager<ApplicationUser> userManager, IMapper mapper)
            {
                _userManager = userManager;
                _mapper = mapper;
            }

            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                var user = _mapper.Map<UserRegistrationDto, ApplicationUser>(request.User);

                var createResult = await _userManager.CreateAsync(user, request.User.Password);

                if (createResult.Succeeded)
                {
                    return Unit.Value;
                }

                throw new RegistrationException(createResult);
            }
        }
    }
}
