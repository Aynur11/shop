namespace Application.DTO.User
{
    /// <summary>
    /// Пользователь.
    /// </summary>
    public class UserDto
    {
        public string DisplayName { get; set; }
        public string Token { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ImageUrl { get; set; }
    }
}
