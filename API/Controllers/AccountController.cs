using Application.DTO;
using Application.User;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net;
using System.Threading.Tasks;
using Application.DTO.User;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccountController : BaseApiController
    {
        [HttpPost("Login")]
        public async Task<IActionResult> Login(UserLoginDto user)
        {
            try
            {
                await Mediator.Send(new Login.Query(user));
            }
            catch (Exception e)
            {
                // Log.Print();
                Console.WriteLine(e.Message);
                return Problem(e.Message, statusCode: (int)HttpStatusCode.BadRequest);
            }
            return Ok();
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register(UserRegistrationDto user)
        {
            try
            {
                await Mediator.Send(new Register.Command(user));
            }
            catch(Exception e)
            {
                // Log.Print();
                Console.WriteLine(e.Message);
                return Problem(e.Message, statusCode: (int)HttpStatusCode.BadRequest);
            }
            return Ok();
        }
    }
}
