using PRG_MAUI_Car_Register.Model;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace PRG_MAUI_Car_Register.ViewModel
{
    public class MainPageViewModel : INotifyPropertyChanged
    {
        private static MainPageViewModel _instance;
        public static MainPageViewModel Instance => _instance ??= new MainPageViewModel();

        public ObservableCollection<Vehicle> VehicleList { get; set; }
        public ICommand ViewFilterCommand { get; }

        public MainPageViewModel()
        {
            VehicleList = new ObservableCollection<Vehicle>();
            VehicleList.Add(new Car("ABC123", "BMW", "M5", 2026, 4));
            VehicleList.Add(new Car("ABC124", "BMW", "M5", 2026, 4));
            VehicleList.Add(new Car("ABC125", "BMW", "M5", 2026, 4));
            VehicleList.Add(new Car("ABC126", "BMW", "M5", 2026, 4));
            VehicleList.Add(new Car("ABC127", "BMW", "M5", 2026, 4));
            VehicleList.Add(new Car("ABC128", "BMW", "M5", 2026, 4));
            VehicleList.Add(new Car("ABC129", "BMW", "M5", 2026, 4));
            VehicleList.Add(new Car("ABC120", "BMW", "M5", 2026, 4));
            VehicleList.Add(new Car("ABC133", "BMW", "M5", 2026, 4));
            VehicleList.Add(new Car("ABC134", "BMW", "M5", 2026, 4));
            VehicleList.Add(new Car("ABC135", "BMW", "M5", 2026, 4));
            VehicleList.Add(new Car("ABC136", "BMW", "M5", 2026, 4));
            VehicleList.Add(new Car("ABC137", "BMW", "M5", 2026, 4));
            VehicleList.Add(new Car("ABC138", "BMW", "M5", 2026, 4));
            VehicleList.Add(new Truck("ABC139", "Volvo", "FH 500", 2026, 15000));
            VehicleList.Add(new Truck("ABC130", "Volvo", "FH 500", 2026, 15000));
            VehicleList.Add(new MC("ABC141", "Yamaha", "MT-07", 2026, 700));
            VehicleList.Add(new MC("ABC142", "Yamaha", "MT-07", 2026, 700));

            ViewFilterCommand = new Command<string>(async (type) =>
            {
                string pageRoute = string.Empty;
                switch (type)
                {
                    case "all":
                        //pageRoute = "";
                        break;
                    case "car":
                        pageRoute = "CarsPage";
                        break;
                    case "truck":
                        pageRoute = "TrucksPage";
                        break;
                    case "mc":
                        pageRoute = "MotorCyclesPage";
                        break;
                }

                if (pageRoute == string.Empty)
                {
                    throw new ArgumentOutOfRangeException(nameof(type));
                }
                await Shell.Current.GoToAsync($"//{pageRoute}");
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