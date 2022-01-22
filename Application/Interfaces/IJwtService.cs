using Domain;

namespace Application.Interfaces
{
    public interface IJwtService
    {
        string Create(ApplicationUser applicationUser, string secret);
    }
}
