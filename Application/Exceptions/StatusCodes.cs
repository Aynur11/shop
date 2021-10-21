using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Exceptions
{
    public enum LoginStatusCodes
    {
        UserNotFound,
        UserNotSignedIn,
        SignInLockedOut,
        SignInIsNotAllowed,
        RequiresTwoFactor,
        UndefinedProblem
    }
}
