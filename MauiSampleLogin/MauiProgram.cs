using MauiSampleLogin.Inferfaces;
using MauiSampleLogin.Services;

using Plugin.Fingerprint.Abstractions;
using Plugin.Fingerprint;

namespace MauiSampleLogin;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.UseMauiCommunityToolkit()
			.UseSentry(options =>
			{
				options.Dsn = "https://53c5be16f70fcd17f68a83f6b07075e4@o4506349886177280.ingest.sentry.io/4506349892927489";
                options.Debug = true;
                options.TracesSampleRate = 1.0;
            })
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

		builder.Services.AddScoped<ILoginService, LoginService>();
        builder.Services.AddSingleton<MainViewModel>();
        builder.Services.AddSingleton<MainPage>();
        builder.Services.AddSingleton<CreateAccountViewModel>();
		builder.Services.AddSingleton<CreateAccountPage>();
		builder.Services.AddSingleton<ProductsPage>();
		builder.Services.AddScoped<IRestaurantService, RestaurantService>();
		builder.Services.AddSingleton<RestaurantsViewModel>();
		builder.Services.AddSingleton<RestaurantsPage>();

        builder.Services.AddSingleton(typeof(IFingerprint), CrossFingerprint.Current);

        return builder.Build();
	}
}
