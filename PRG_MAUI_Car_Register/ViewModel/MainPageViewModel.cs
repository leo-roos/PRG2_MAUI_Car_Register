using PRG_MAUI_Car_Register.Model;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using static System.Net.Mime.MediaTypeNames;

namespace PRG_MAUI_Car_Register.ViewModel
{
    public class MainPageViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Vehicle> VehicleList { get; set; }
        public ICommand RegisterCommand { get; }
        public ICommand SearchCommand { get; }
        
        public MainPageViewModel()
        {
            VehicleList = new ObservableCollection<Vehicle>();

            RegisterCommand = new Command(() =>
            {
                Vehicle vehicle = null;
                try
                {
                    if (!int.TryParse(YearModel, out int parsedYear))
                    {
                        throw new ArgumentException("Årsmodell måste anges i enbart siffror.");
                    }

                    switch (VehicleType)
                    {
                        case "Bil":
                            if (!int.TryParse(Doors, out int parsedDoors))
                            {
                                throw new ArgumentException("Dörrar måste anges i enbart siffror.");
                            }

                            vehicle = new Car(RegistrationNumber, Manufacturer, Model, parsedYear, parsedDoors);
                            break;

                        case "MC":
                            if (!int.TryParse(CylinderVolume, out int parsedCylinder))
                            {
                                throw new ArgumentException("Cylindervolym måste anges i enbart siffror.");
                            }

                            vehicle = new MC(RegistrationNumber, Manufacturer, Model, parsedYear, parsedCylinder);
                            break;

                        case "Lastbil":
                            if (!int.TryParse(LoadCapacity, out int parsedCapacity))
                            {
                                throw new ArgumentException("Lastkapacitet måste anges i enbart siffror.");
                            }

                            vehicle = new Truck(RegistrationNumber, Manufacturer, Model, parsedYear, parsedCapacity);
                            break;

                        default:
                            throw new ArgumentException($"Ogiltig bil typ: {VehicleType}");
                    }

                    if (vehicle == null)
                    {
                        return;
                    }

                    VehicleList.Add(vehicle);

                    ClearTextFields();
                }
                catch (ArgumentException ex)
                {

                }
            });

            SearchCommand = new Command(() =>
            {
                string searchTerm = SearchValue.ToLower();

                if (string.IsNullOrEmpty(searchTerm))
                {
                    SearchResult = "Ange ett registreringsnummer för att söka.";
                    return;
                }

                Vehicle foundVehicle = VehicleList.FirstOrDefault(v => v.RegistrationNumber?.ToLower() == searchTerm);

                if (foundVehicle != null)
                {
                    SearchResult = $"Fordon hittat:\n" +
                                  $"{foundVehicle.GetDescription()}";
                }
                else
                {
                    SearchResult = "Inget fordon hittades med det registreringsnumret.";
                }
            });
        }

        private void ClearTextFields()
        {
            RegistrationNumber = string.Empty;
            Manufacturer = string.Empty;
            Model = string.Empty;
            YearModel = string.Empty;
            Doors = string.Empty;
            LoadCapacity = string.Empty;
            CylinderVolume = string.Empty;
        }

        private bool isCar = false;
        public bool IsCar
        {
            get
            {
                return isCar;
            }
            set
            {
                if (isCar != value)
                {
                    isCar = value;
                    OnPropertyChanged();
                }
            }
        }

        private bool isMC = false;
        public bool IsMC
        {
            get
            {
                return isMC;
            }
            set
            {
                if (isMC != value)
                {
                    isMC = value;
                    OnPropertyChanged();
                }
            }
        }

        private bool isTruck = false;
        public bool IsTruck
        {
            get
            {
                return isTruck;
            }
            set
            {
                if (isTruck != value)
                {
                    isTruck = value;
                    OnPropertyChanged();
                }
            }
        }

        private string registrationNumber = string.Empty;
        public string RegistrationNumber
        {
            get
            {
                return registrationNumber;
            }
            set
            {
                if (registrationNumber != value)
                {
                    registrationNumber = value;
                    OnPropertyChanged();
                }
            }
        }

        private string vehicleType = string.Empty;
        public string VehicleType
        {
            get
            {
                return vehicleType;
            }
            set
            {
                if (vehicleType != value)
                {
                    vehicleType = value;

                    IsCar = vehicleType == "Bil";
                    IsMC = vehicleType == "MC";
                    IsTruck = vehicleType == "Lastbil";
                    OnPropertyChanged();
                }
            }
        }

        private string manufacturer = string.Empty;
        public string Manufacturer
        {
            get
            {
                return manufacturer;
            }
            set
            {
                if (manufacturer != value)
                {
                    manufacturer = value;
                    OnPropertyChanged();
                }
            }
        }

        private string model = string.Empty;
        public string Model
        {
            get
            {
                return model;
            }
            set
            {
                if (model != value)
                {
                    model = value;
                    OnPropertyChanged();
                }
            }
        }

        private string yearModel = string.Empty;
        public string YearModel
        {
            get
            {
                return yearModel;
            }
            set
            {
                if (yearModel != value)
                {
                    yearModel = value;
                    OnPropertyChanged();
                }
            }
        }


        private string doors = string.Empty;
        public string Doors
        {
            get
            {
                return doors;
            }
            set
            {
                if (doors != value)
                {
                    doors = value;
                    OnPropertyChanged();
                }
            }
        }


        private string cylinderVolume = string.Empty;
        public string CylinderVolume
        {
            get
            {
                return cylinderVolume;
            }
            set
            {
                if (cylinderVolume != value)
                {
                    cylinderVolume = value;
                    OnPropertyChanged();
                }
            }
        }


        private string loadCapacity = string.Empty;
        public string LoadCapacity
        {
            get
            {
                return loadCapacity;
            }
            set
            {
                if (loadCapacity != value)
                {
                    loadCapacity = value;
                    OnPropertyChanged();
                }
            }
        }

        private string searchValue = string.Empty;
        public string SearchValue
        {
            get
            {
                return searchValue;
            }
            set
            {
                if (searchValue != value)
                {
                    searchValue = value;
                    OnPropertyChanged();
                }
            }
        }

        private string searchResult = "Sökresultat visas här...";
        public string SearchResult
        {
            get
            {
                return searchResult;
            }
            set
            {
                if (searchResult != value)
                {
                    searchResult = value;
                    OnPropertyChanged();
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
