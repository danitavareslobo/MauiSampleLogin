using MauiSampleLogin.Models;
using MauiSampleLogin.Models.CreateAccount;

namespace MauiSampleLogin.Inferfaces
{
    public interface ILoginService
    {
        Task<LoginResponse> LoginAsync(LoginRequest loginRequest);
        Task<bool> CreateAccount(CreateAccountRequest createAccountRequest);
    }
}
