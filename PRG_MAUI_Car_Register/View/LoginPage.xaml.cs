using PRG_MAUI_Car_Register.ViewModel;

namespace PRG_MAUI_Car_Register.View;

public partial class LoginPage : ContentPage
{
    LoginViewModel loginViewModel;
	public LoginPage()
    {
		InitializeComponent();

        loginViewModel = LoginViewModel.Instance;
        BindingContext = loginViewModel;
    }
}