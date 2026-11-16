using PRG_MAUI_Car_Register.Model;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace PRG_MAUI_Car_Register.ViewModel
{
    internal class CarsViewModel : INotifyPropertyChanged
    {
        public List<Vehicle> CarsList { get; set; }
        public ICommand SearchCommand { get; }
        public ICommand RegisterNewVehicleCommand { get; }

        public CarsViewModel()
        {
            SetFilter();

            SearchCommand = new Command(() =>
            {
                SetFilter();
            });
            RegisterNewVehicleCommand = new Command(async () =>
            {
                Debug.WriteLine("test");
                await Shell.Current.GoToAsync("//RegisterNewCarPage");
            });
        }

        public void SetFilter()
        {
            IEnumerable<Vehicle> filteredList = MainPageViewModel.Instance.VehicleList.Where(c => c is Car && c.RegistrationNumber.ToLower().Contains(SearchFilter.ToLower()));
            CarsList = filteredList.ToList();
            OnPropertyChanged(nameof(CarsList));
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

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}