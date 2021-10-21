using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
