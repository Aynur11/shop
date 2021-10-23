using System;

namespace Application.Exceptions
{
    public class LoginException : Exception
    {
        public LoginStatusCodes StatusCode { get; set; }

        public LoginException(string message) : base(message) { }

        public LoginException(LoginStatusCodes statusCode, string message) : base(message)
        {
            StatusCode = statusCode;
        }
    }
}
