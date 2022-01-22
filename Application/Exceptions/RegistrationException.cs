using Microsoft.AspNetCore.Identity;
using System;
using System.Diagnostics;

namespace Application.Exceptions
{
    public class RegistrationException : Exception
    {
        public RegistrationException(string message) : base(message) { }

        public RegistrationException(IdentityResult result, string message = null) : base(message)
        {

            Debug.WriteLine("Найденные ошибки при регистрации:");

            foreach (var item in result.Errors)
            {
                Debug.WriteLine($"{item.Code}:{item.Description}");
            }
        }
    }
}
