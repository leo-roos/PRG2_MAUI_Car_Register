using PRG_MAUI_Car_Register.ViewModel;
namespace PRG_MAUI_Car_Register.View;

public partial class RegisterNewMotorCyclePage : ContentPage
{
	public RegisterNewMotorCyclePage()
	{
		InitializeComponent();
		BindingContext = new RegisterNewMotorCycleViewModel();
	}
}