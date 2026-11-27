namespace PRG_MAUI_Car_Register.Model
{
    internal class Customer : User
    {
        public Customer(string UserName, string Password) : base(UserName, Password)
        {
            IsCustomer = true;
        }
    }
}
