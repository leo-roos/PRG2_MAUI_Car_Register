using PRG_MAUI_Car_Register.Model;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace PRG_MAUI_Car_Register.ViewModel
{
    internal class RegisterNewTruckViewModel : INotifyPropertyChanged
    {
        public ICommand RegisterCommand { get; }
        public ICommand GoBackCommand { get; }

        public RegisterNewTruckViewModel()
        {
            RegisterCommand = new Command(async () =>
            {
                try
                {
                    if (!int.TryParse(YearModel, out int parsedYear))
                    {
                        throw new ArgumentException("Årsmodell måste anges i enbart siffror.");
                    }

                    if (!int.TryParse(LoadCapacity, out int parsedLoadCapacity))
                    {
                        throw new ArgumentException("Lastkapacitet måste anges i enbart siffror.");
                    }

                    Vehicle vehicle = new Truck(RegistrationNumber, Manufacturer, Model, parsedYear, parsedLoadCapacity);

                    MainPageViewModel.Instance.VehicleList.Add(vehicle);

                    ClearTextFields();
                }
                catch (ArgumentException ex)
                {
                    await Shell.Current.DisplayAlert("Fel", ex.Message, "OK");
                }
            });

            GoBackCommand = new Command(async () =>
            {
                await Shell.Current.GoToAsync("//TrucksPage");
            });
        }
        private void ClearTextFields()
        {
            RegistrationNumber = string.Empty;
            Manufacturer = string.Empty;
            Model = string.Empty;
            YearModel = string.Empty;
            LoadCapacity = string.Empty;
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

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
