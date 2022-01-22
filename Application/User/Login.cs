using Application.DTO.User;
using Application.Exceptions;
using Application.Interfaces;
using AutoMapper;
using Domain;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;

namespace Application.User
{
    public class Login
    {
        public class Query : IRequest<UserDto>
        {
            public Query(UserLoginDto user)
            {
                Email = user.Email;
                Password = user.Password;
            }

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

        public class Handler : IRequestHandler<Query, UserDto>
        {
            private readonly UserManager<ApplicationUser> _userManager;
            private readonly SignInManager<ApplicationUser> _signInManager;
            private readonly IMapper _mapper;
            private readonly IJwtService _jwtService;
            private readonly KeySettings _keySettings;
            public Handler(
                UserManager<ApplicationUser> userManager, 
                SignInManager<ApplicationUser> signInManager,
                IMapper mapper,         
                IJwtService jwtService,
                IOptions<KeySettings> keySettings)
            {
                _userManager = userManager;
                _signInManager = signInManager;
                _mapper = mapper;
                _jwtService = jwtService;
                _keySettings = keySettings.Value;
            }

            public async Task<UserDto> Handle(Query request, CancellationToken cancellationToken)
            {
                var user = await _userManager.FindByEmailAsync(request.Email) ?? 
                           throw new LoginException(LoginStatusCodes.UserNotFound, "Указанный пользователь не найден.");

                if (user == null)
                {
                    throw new LoginException(LoginStatusCodes.UserNotFound, "Указанный пользователь не найден.");
                }

                var signInResult = await _signInManager.CheckPasswordSignInAsync(user, request.Password, false);

                if (signInResult.Succeeded)
                {
                    var userDto = _mapper.Map<ApplicationUser, UserDto>(user);
                    userDto.Token = _jwtService.Create(user, _keySettings.Secret);
                    return userDto;
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
