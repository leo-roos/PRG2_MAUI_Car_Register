using PRG_MAUI_Car_Register.ViewModel;
namespace PRG_MAUI_Car_Register.View;

public partial class RegisterNewTruckPage : ContentPage
{
	public RegisterNewTruckPage()
	{
		InitializeComponent();
		BindingContext = new RegisterNewTruckViewModel();
	}
}