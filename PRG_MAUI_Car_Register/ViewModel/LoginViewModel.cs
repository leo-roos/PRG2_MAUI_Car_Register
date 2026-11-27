
using PRG_MAUI_Car_Register.Model;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace PRG_MAUI_Car_Register.ViewModel
{
    internal class LoginViewModel : INotifyPropertyChanged
    {
        private static LoginViewModel _instance;
        public static LoginViewModel Instance => _instance ??= new LoginViewModel();

        public List<User> Users = new List<User>();
        public User? ActiveUser;
        public ICommand LoginCommand { get; }

        public LoginViewModel()
        {
            Users.Add(new Staff("admin", "123"));
            Users.Add(new Customer("customer", "123"));

            LoginCommand = new Command(() => {
                User? user = Users.Find(user => user.UserName == UserName);
                if(user == null || !user.Login(UserName, Password))
                {
                    Shell.Current.DisplayAlert("Fel", "Du har angett ett användarnamn som ej finns eller fel lösenord. Försök igen.", "Ok");
                    return;
                }
                ActiveUser = user;
                Shell.Current.GoToAsync("//MainPage");

                string userLabel = "en användare";
                if (user.IsStaff == true)
                {
                    userLabel = "personal";
                } else if (user.IsCustomer == true)
                {
                    userLabel = "en kund";
                }
                Shell.Current.DisplayAlert("Inloggad", $"Du är nu inloggad som {user.UserName}! Du är {userLabel}.", "Ok");
            });
        }

        private string userName = string.Empty;
        public string UserName
        {
            get
            {
                return userName;
            }
            set
            {
                if(userName != value)
                {
                    userName = value;
                    OnPropertyChanged();
                }
            }
        }
        private string password = string.Empty;
        public string Password
        {
            get
            {
                return password;
            }
            set
            {
                if (password != value)
                {
                    password = value;
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
