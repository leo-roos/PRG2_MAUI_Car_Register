using PRG_MAUI_Car_Register.Model;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace PRG_MAUI_Car_Register.View
{
    public partial class MainPage : ContentPage
    {
        ObservableCollection<Vehicle> vehicleList;

        public MainPage()
        {
            InitializeComponent();
            pickerType.SelectedIndex = 0;

            vehicleList = new ObservableCollection<Vehicle>();
            CollectionViewVehicles.ItemsSource = vehicleList;

            //Vehicle vehicle = new Vehicle((Vehicle.Type)(0));
            //vehicle.RegistrationNumber = "ABC 123";
            //vehicle.Manufacturer = "BMW";
            //vehicle.Model = "M4-325";
            //vehicle.YearModel = 2024;
        }

        private void OnRegisterClicked(object sender, EventArgs e)
        {
            Vehicle vehicle = null;
            try
            {
                if (!int.TryParse(entryYearModel.Text, out int YearModel))
                {
                    throw new ArgumentException("Årsmodell måste anges i enbart siffror.");
                }

                string selectedItem = pickerType.SelectedItem?.ToString() ?? "";

                switch (selectedItem)
                {
                    case "Bil":
                        vehicle = new Car(entryRegistrationNumber.Text, entryManufacturer.Text, entryModel.Text, YearModel, 5);
                        break;

                    case "MC":
                        vehicle = new MC(entryRegistrationNumber.Text, entryManufacturer.Text, entryModel.Text, YearModel);
                        break;

                    case "Lastbil":
                        vehicle = new Truck(entryRegistrationNumber.Text, entryManufacturer.Text, entryModel.Text, YearModel);
                        break;

                    default:
                        throw new ArgumentException($"Ogiltig bil typ: {selectedItem}");
                }

                if (vehicle == null)
                {
                    return;
                }
                vehicleList.Add(vehicle);
                CollectionViewVehicles.ItemsSource = null;
                CollectionViewVehicles.ItemsSource = vehicleList;

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

            RadioButton radioButton = (RadioButton)sender;

            // Skapa en temporär filtrerad lista baserat på vilken radioknapp som är vald
            IEnumerable<Vehicle> filteredList;

            switch (radioButton.Content)
            {
                case "Bil":
                    filteredList = vehicleList.Where(v => v is Car).ToList();
                    break;
                case "MC":
                    filteredList = vehicleList.Where(v => v is MC).ToList();
                    break;
                case "Lastbil":
                    filteredList = vehicleList.Where(v => v is Truck).ToList();
                    break;
                default:
                    filteredList = vehicleList;
                    break;
            }

            CollectionViewVehicles.ItemsSource = filteredList;
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
