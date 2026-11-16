using PRG_MAUI_Car_Register.ViewModel;
namespace PRG_MAUI_Car_Register.View;

public partial class RegisterNewCarPage : ContentPage
{
	public RegisterNewCarPage()
	{
		InitializeComponent();
		BindingContext = new RegisterNewCarViewModel();
	}
}