namespace PRG_MAUI_Car_Register.Model
{
    internal class Staff : User
    {
        public Staff(string UserName, string Password) : base(UserName, Password)
        {
            IsStaff = true;
        }
    }
}
