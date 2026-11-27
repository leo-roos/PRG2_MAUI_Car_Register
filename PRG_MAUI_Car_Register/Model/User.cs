namespace PRG_MAUI_Car_Register.Model
{
    abstract internal class User
    {
        public readonly string id = Guid.NewGuid().ToString();
        public string UserName;
        private readonly string Password;
        public bool LoggedIn;
        public bool IsStaff = false;
        public bool IsCustomer = false;

        public User(string userName, string password) {
            UserName = userName;
            Password = password;
        }

        public bool Login(string userName, string password)
        {
            if(userName == UserName && password == Password)
            {
                LoggedIn = true;
                return true;
            }
            return false;
        }
    }
}
