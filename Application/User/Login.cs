using Domain;
using MediatR;
using Persistence;
using System.Threading;
using System.Threading.Tasks;

namespace Application.User
{
    public class Login
    {
        public class Query : IRequest<ApplicationUser>
        {
            public string UserName { get; set; }
        }

        public class Handler : IRequestHandler<Query, ApplicationUser>
        {
            readonly DataContext _context;
            public Handler(DataContext context)
            {
                _context = context;
            }

            public async Task<ApplicationUser> Handle(Query request, CancellationToken cancellationToken)
            {
                return await _context.Users.FindAsync(request.UserName, cancellationToken);
            }
        }
    }
}
