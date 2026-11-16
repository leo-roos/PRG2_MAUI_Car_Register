using PRG_MAUI_Car_Register.Model;
using PRG_MAUI_Car_Register.ViewModel;
using System.Collections.ObjectModel;

namespace PRG_MAUI_Car_Register.View
{
    public partial class MainPage : ContentPage
    {
        //MainPageViewModel mainPageViewModel = new MainPageViewModel();

        public MainPage()
        {
            InitializeComponent();

            BindingContext = MainPageViewModel.Instance;


            //Vehicle vehicle = new Vehicle((Vehicle.Type)(0));
            //vehicle.RegistrationNumber = "ABC 123";
            //vehicle.Manufacturer = "BMW";
            //vehicle.Model = "M4-325";
            //vehicle.YearModel = 2024;
        }
    }
}
