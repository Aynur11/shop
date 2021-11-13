using Domain;
using FluentValidation;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Application.Exceptions;
using Microsoft.AspNetCore.Identity;
using Application.Interfaces;
using AutoMapper;
using Application.DTO;

namespace Application.User
{
    public class Login
    {
        public class Query : IRequest<ApplicationUser>
        {
            public string Email { get; set; }
            public string Password { get; set; }
        }

        public class QueryValidator : AbstractValidator<Query>
        {
            public QueryValidator()
            {
                RuleFor(x => x.Email).NotEmpty();
                RuleFor(x => x.Password).NotEmpty();
            }
        }

        public class Handler : IRequestHandler<Query, ApplicationUser>
        {
            private readonly UserManager<ApplicationUser> _userManager;
            private readonly SignInManager<ApplicationUser> _signInManager;
            private readonly IMapper _mapper;
            private readonly IJwtService _jwtService;
            public Handler(
                UserManager<ApplicationUser> userManager, 
                SignInManager<ApplicationUser> signInManager,
                IMapper mapper,
                IJwtService jwtService)
            {
                _userManager = userManager;
                _signInManager = signInManager;
                _mapper = mapper;
                _jwtService = jwtService;
            }

            public async Task<ApplicationUser> Handle(Query request, CancellationToken cancellationToken)
            {
                var user = await _userManager.FindByEmailAsync(request.Email) ?? 
                           throw new LoginException(LoginStatusCodes.UserNotFound, "Указанный пользователь не найден.");

                if (user == null)
                {
                    /// ?????
                }

                var signInResult = await _signInManager.CheckPasswordSignInAsync(user, request.Password, false);

                var userDto = _mapper.Map<UserDto>(user);
                userDto.Token = _jwtService.Create(user);

                if (signInResult.Succeeded)
                {
                    return user;
                }
                if (signInResult.IsLockedOut)
                {
                    throw new LoginException(LoginStatusCodes.SignInLockedOut, "Аутентификация заблокирована.");
                }
                if (signInResult.IsNotAllowed)
                {
                    throw new LoginException(LoginStatusCodes.SignInIsNotAllowed, "Аутентификация не разрешена.");
                }
                if (signInResult.RequiresTwoFactor)
                {
                    throw new LoginException(LoginStatusCodes.RequiresTwoFactor, "Требуется двухфакторная аутентификация.");
                }

                throw new LoginException(LoginStatusCodes.UndefinedProblem, "При выполнении аутентификации что-то пошло не так.");
            }
        }
    }
}
