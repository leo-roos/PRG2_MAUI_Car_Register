using PRG_MAUI_Car_Register.ViewModel;

namespace PRG_MAUI_Car_Register.View;

public partial class MotorCyclesPage : ContentPage
{
    MotorCyclesViewModel MotorCyclesViewModel;
	public MotorCyclesPage()
    {
		InitializeComponent();
        MotorCyclesViewModel = new MotorCyclesViewModel();
        BindingContext = MotorCyclesViewModel;
	}

    protected override void OnAppearing()
    {
        base.OnAppearing();

        MotorCyclesViewModel.SetFilter();
    }
}