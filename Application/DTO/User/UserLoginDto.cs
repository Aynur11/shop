namespace Application.DTO.User
{
    /// <summary>
    /// Описывает пользователя при авторизации.
    /// </summary>
    public class UserLoginDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
