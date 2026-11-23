using PRG_MAUI_Car_Register.Model;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace PRG_MAUI_Car_Register.ViewModel
{
    internal class MotorCyclesViewModel : INotifyPropertyChanged
    {
        public List<Vehicle> MotorCyclesList { get; set; }
        public ICommand GoBackCommand { get; }
        public ICommand SearchCommand { get; }
        public ICommand RegisterNewVehicleCommand { get; }
        public ICommand ChooseVehicleCommand { get; }

        public MotorCyclesViewModel()
        {
            SetFilter();

            GoBackCommand = new Command(async () =>
            {
                await Shell.Current.GoToAsync("//MainPage");
            });
            SearchCommand = new Command(() =>
            {
                SetFilter();
            });
            RegisterNewVehicleCommand = new Command(async () =>
            {
                await Shell.Current.GoToAsync("//RegisterNewMotorCyclePage");
            });
            ChooseVehicleCommand = new Command(() =>
            {
                ChosenVehicleDetails = SelectedItem.GetDescription();
            });
        }

        public void SetFilter()
        {
            IEnumerable<Vehicle> filteredList = MainPageViewModel.Instance.VehicleList.Where(c => c is MC && c.RegistrationNumber.ToLower().Contains(SearchFilter.ToLower()));
            MotorCyclesList = filteredList.ToList();
            OnPropertyChanged(nameof(MotorCyclesList));
        }

        private string searchFilter = string.Empty;
        public string SearchFilter
        {
            get
            {
                return searchFilter;
            }
            set
            {
                if (searchFilter != value)
                {
                    searchFilter = value;
                    SetFilter();
                    OnPropertyChanged();
                }
            }
        }

        private Vehicle selectedItem;
        public Vehicle SelectedItem
        {
            get
            {
                return selectedItem;
            }
            set
            {
                if (selectedItem != value)
                {
                    selectedItem = value;
                    OnPropertyChanged();
                }
            }
        }

        private string chosenVehicleDetails = "Ingen bil vald.";
        public string ChosenVehicleDetails
        {
            get
            {
                return chosenVehicleDetails;
            }
            set
            {
                if (chosenVehicleDetails != value)
                {
                    chosenVehicleDetails = value;
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