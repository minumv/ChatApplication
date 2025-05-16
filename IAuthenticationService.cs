using ChatApplication.DTOs;

namespace ChatApplication.Services
{
    public interface IAuthenticationService
    {
        Task<object> Register(RegisterRequest request);
        Task<object> Login(LoginRequest request);
    }
}
