namespace Application.Exceptions
{
    public enum LoginStatusCodes
    {
        UserNotFound,
        SignInLockedOut,
        SignInIsNotAllowed,
        RequiresTwoFactor,
        UndefinedProblem
    }
}
