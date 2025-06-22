using GL.CompanyCatalog.WebApp.Services.Base;

namespace GL.CompanyCatalog.WebApp.Contracts
{
    public interface IAuthenticationService
    {
        Task<ApiResponse> Login(string email, string password);
        Task<ApiResponse> Register(string email, string password);
        Task Logout();
    }
}
