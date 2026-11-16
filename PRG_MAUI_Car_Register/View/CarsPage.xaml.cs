using PRG_MAUI_Car_Register.ViewModel;

namespace PRG_MAUI_Car_Register.View;

public partial class CarsPage : ContentPage
{
    CarsViewModel carsViewModel;
	public CarsPage()
    {
		InitializeComponent();
        carsViewModel = new CarsViewModel();
        BindingContext = carsViewModel;
	}

    protected override void OnAppearing()
    {
        base.OnAppearing();

        carsViewModel.SetFilter();
    }
}