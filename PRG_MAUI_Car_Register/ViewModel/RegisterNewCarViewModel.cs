using PRG_MAUI_Car_Register.Model;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace PRG_MAUI_Car_Register.ViewModel
{
    internal class RegisterNewCarViewModel : INotifyPropertyChanged
    {
        public ICommand RegisterCommand { get; }
        public ICommand GoBackCommand { get; }

        public RegisterNewCarViewModel()
        {
            RegisterCommand = new Command(() =>
            {
                try
                {
                    if (!int.TryParse(YearModel, out int parsedYear))
                    {
                        throw new ArgumentException("Årsmodell måste anges i enbart siffror.");
                    }

                    if (!int.TryParse(Doors, out int parsedDoors))
                    {
                        throw new ArgumentException("Dörrar måste anges i enbart siffror.");
                    }

                    Vehicle vehicle = new Car(RegistrationNumber, Manufacturer, Model, parsedYear, parsedDoors);

                    MainPageViewModel.Instance.VehicleList.Add(vehicle);

                    ClearTextFields();
                }
                catch (ArgumentException ex)
                {

                }
            });

            GoBackCommand = new Command(async () =>
            {
                await Shell.Current.GoToAsync("//CarsPage");
            });
        }
        private void ClearTextFields()
        {
            RegistrationNumber = string.Empty;
            Manufacturer = string.Empty;
            Model = string.Empty;
            YearModel = string.Empty;
            Doors = string.Empty;
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

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
