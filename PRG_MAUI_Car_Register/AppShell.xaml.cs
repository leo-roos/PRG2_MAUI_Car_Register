using PRG_MAUI_Car_Register.ViewModel;

namespace PRG_MAUI_Car_Register
{
    public partial class AppShell : Shell
    {
        LoginViewModel loginViewModel;
        public AppShell()
        {
            InitializeComponent();

            loginViewModel = LoginViewModel.Instance;
        }
    }
}
