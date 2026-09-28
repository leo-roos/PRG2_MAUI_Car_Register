namespace PRG_MAUI_Car_Register.Model
{
    internal class MC : Vehicle
    {
        public MC(string registrationNumber, string manufacturer, string model, int yearModel) : base(registrationNumber, manufacturer, model, yearModel)
        {
            VehicleType = "MC";
        }

        public override string GetDescription()
        {
            return $"{VehicleType} - {Manufacturer} {Model} ({YearModel}), Reg: {RegistrationNumber}";
        }
    }
}
