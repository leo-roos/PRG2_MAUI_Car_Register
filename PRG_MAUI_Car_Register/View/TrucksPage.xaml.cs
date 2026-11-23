using PRG_MAUI_Car_Register.ViewModel;

namespace PRG_MAUI_Car_Register.View;

public partial class TrucksPage : ContentPage
{
    TrucksViewModel trucksViewModel;
	public TrucksPage()
    {
		InitializeComponent();
        trucksViewModel = new TrucksViewModel();
        BindingContext = trucksViewModel;
	}

    protected override void OnAppearing()
    {
        base.OnAppearing();

        trucksViewModel.SetFilter();
    }
}