using PRG_MAUI_Car_Register.Model;
using System.Collections.ObjectModel;

namespace PRG_MAUI_Car_Register.View
{
    public partial class MainPage : ContentPage
    {
        ObservableCollection<Vehicle> vehicleList = new ObservableCollection<Vehicle>();

        public MainPage()
        {
            InitializeComponent();
            pickerType.SelectedIndex = 0;

            //Vehicle vehicle = new Vehicle((Vehicle.Type)(0));
            //vehicle.RegistrationNumber = "ABC 123";
            //vehicle.Manufacturer = "BMW";
            //vehicle.Model = "M4-325";
            //vehicle.YearModel = 2024;
        }

        private void pickerType_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void OnRegisterClicked(object sender, EventArgs e)
        {
            //int YearModel = 0;
            //if (!int.TryParse(entryYearModel.Text, out YearModel))
            //{
            //    throw new ArgumentNullException("Årsmodell måste anges i enbart siffror.");
            //}

            try
            {
                Car vehicle = new Car(pickerType.SelectedItem.ToString(), entryRegistrationNumber.Text, entryManufacturer.Text, entryModel.Text, entryYearModel.Text, 5);

                //vehicle.RegistrationNumber = entryRegistrationNumber.Text;
                //vehicle.Manufacturer = entryManufacturer.Text;
                //vehicle.Model = entryModel.Text;
                //vehicle.YearModel = YearModel;

                vehicleList.Add(vehicle);
                listViewVehicles.ItemsSource = null;
                listViewVehicles.ItemsSource = vehicleList;

                ClearTextFields();
            }

            // här "fångas" eventuella felmeddelanden från Vehicle
            catch (ArgumentException ex)
            {
                DisplayAlert("Fel", ex.Message, "OK");
            }
        }

        private void OnRadioCheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            if (e.Value != true) return;

            // Skapa en temporär filtrerad lista baserat på vilken radioknapp som är vald
            IEnumerable<Vehicle> filteredList;

            if (radioCar.IsChecked)
            {
                filteredList = vehicleList.Where(v => v is Car).ToList();
            }
            else if (radioMC.IsChecked)
            {
                filteredList = vehicleList.Where(v => v is MC).ToList();
            }
            else if (radioTruck.IsChecked)
            {
                filteredList = vehicleList.Where(v => v is Truck).ToList();
            }
            else
            {
                // Om "Alla" är vald, visa hela listan
                filteredList = vehicleList;
            }

            listViewVehicles.ItemsSource = filteredList;
        }

        private void OnSearchClicked(object sender, EventArgs e)
        {
            string searchTerm = entrySearchRegistrationNumber.Text?.ToLower();

            if (string.IsNullOrEmpty(searchTerm))
            {
                entrySearchRegistrationNumber.Text = "Ange ett registreringsnummer för att söka.";
                return;
            }

            var foundVehicle = vehicleList.FirstOrDefault(v => v.RegistrationNumber?.ToLower() == searchTerm);

            if (foundVehicle != null)
            {
                labelSearchResult.Text = $"Fordon hittat:\n" +
                                         $"Registreringsnummer: {foundVehicle.RegistrationNumber}\n" +
                                         $"Tillverkare: {foundVehicle.Manufacturer}\n" +
                                         $"Modell: {foundVehicle.Model}\n" +
                                         $"Typ: {foundVehicle.VehicleType}";
            }
            else
            {
                labelSearchResult.Text = "Inget fordon hittades med det registreringsnumret.";
            }
        }

        private void ClearTextFields()
        {
            entryRegistrationNumber.Text = string.Empty;
            entryManufacturer.Text = string.Empty;
            entryModel.Text = string.Empty;
            entryYearModel.Text = string.Empty;
        }
    }
}
