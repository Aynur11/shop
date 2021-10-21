using System;
using Domain;
using FluentValidation;
using MediatR;
using Persistence;
using System.Threading;
using System.Threading.Tasks;
using Application.Exceptions;
using Microsoft.AspNetCore.Identity;

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
            public Handler(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
            {
                _userManager = userManager;
                _signInManager = signInManager;
            }

            public async Task<ApplicationUser> Handle(Query request, CancellationToken cancellationToken)
            {
                var user = await _userManager.FindByEmailAsync(request.Email) ?? 
                           throw new LoginException(LoginStatusCodes.UserNotFound, "Указанный пользователь не найден.");

                var signInResult = await _signInManager.CheckPasswordSignInAsync(user, request.Password, false);

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
