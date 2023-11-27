using MauiSampleLogin.Inferfaces;
using MauiSampleLogin.Models;
using MauiSampleLogin.ViewModels;

using Moq;

namespace MauiSampleLogin.Tests;

public class LoginValidation
{
	[Fact]
	public async Task LoginDataValidation()
	{
		var mock = new Mock<ILoginService>();
		mock.Setup(x => x.LoginAsync(It.IsAny<LoginRequest>()))
			.ReturnsAsync(new LoginResponse { Token = "1234", RefreshToken = "5678" });

		var vm = new MainViewModel(mock.Object);

		await vm.Login();

		mock.Verify(x => x.LoginAsync(It.IsAny<LoginRequest>()), Times.Once);
	}
}
