using CommunityToolkit.Maui.Alerts;

using MauiSampleLogin.Contracts.Login;
using MauiSampleLogin.Inferfaces;

using System.Text;

namespace MauiSampleLogin.ViewModels;

[ObservableObject]
public partial class MainViewModel
{
    private readonly ILoginService _loginService;
    [ObservableProperty]
    private string email;

    [ObservableProperty]
    private string password;
    
    public MainViewModel(ILoginService loginService) 
    {
        _loginService = loginService;
    }

    [RelayCommand]
    public async Task Login()
    {
        if (Xamarin.Essentials.Connectivity.NetworkAccess == Xamarin.Essentials.NetworkAccess.Unknown ||
            Xamarin.Essentials.Connectivity.NetworkAccess == Xamarin.Essentials.NetworkAccess.None)
        {
            await Toast.Make("Sem conexão com a internet", CommunityToolkit.Maui.Core.ToastDuration.Long).Show();
            return;
        }

        var loginRequest = new Models.LoginRequest    
        {
            Email = email,
            Password = password
        };

        var validator = new LoginContract(loginRequest);
        if(!validator.IsValid) 
        {
            var messages = validator.Notifications.Select(x => x.Message);
            var sb = new StringBuilder();

            foreach (var message in messages)
                sb.Append($"{message}\n");

            await Shell.Current.DisplayAlert("Atenção", sb.ToString(),"Ok");
            return;
        }

        var result = await _loginService.LoginAsync(loginRequest);
        
        if(string.IsNullOrEmpty(result.Access_Token)) 
        {
            await Toast.Make("A requisição falhou, tente novamente", CommunityToolkit.Maui.Core.ToastDuration.Long).Show();
            return;
        }

        Preferences.Default.Set("token", result.Access_Token);
        Preferences.Default.Set("refreshToken", result.Refresh_Token);

        await Shell.Current.GoToAsync($"//{nameof(RestaurantsPage)}");
    }

    [RelayCommand]
    public async Task CreateAccount()
    {
        await Shell.Current.GoToAsync(nameof(CreateAccountPage));
    }
}
