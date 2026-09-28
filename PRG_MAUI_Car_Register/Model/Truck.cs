namespace PRG_MAUI_Car_Register.Model
{
    internal class Truck : Vehicle
    {
        public Truck(string registrationNumber, string manufacturer, string model, int yearModel) : base(registrationNumber, manufacturer, model, yearModel)
        {
            VehicleType = "Lastbil";
        }

        public override string GetDescription()
        {
            return $"{VehicleType} - {Manufacturer} {Model} ({YearModel}), Reg: {RegistrationNumber}";
        }
    }
}
