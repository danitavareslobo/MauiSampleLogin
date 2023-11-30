namespace MauiSampleLogin;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();

		Routing.RegisterRoute(nameof(CreateAccountPage), typeof(CreateAccountPage));
		// Routing.RegisterRoute(nameof(ProductsPage), typeof(ProductsPage));
    }

	private async void Button_Clicked(object sender, EventArgs e)
	{
		Preferences.Default.Clear();
		await Shell.Current.GoToAsync($"//{nameof(MainPage)}");
	}
}
