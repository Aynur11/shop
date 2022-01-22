namespace Application.DTO.User
{
    /// <summary>
    /// Описывает пользователя при регистрации.
    /// </summary>
    public class UserRegistrationDto
    {
        public string DisplayName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ImageUrl { get; set; }
    }
}
