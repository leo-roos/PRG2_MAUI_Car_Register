namespace PRG_MAUI_Car_Register.Model
{
    internal class Car : Vehicle
    {
        private int doors;
        public Car(string registrationNumber, string manufacturer, string model, int yearModel, int doors) : base(registrationNumber, manufacturer, model, yearModel)
        {
            VehicleType = "Bil";
            Doors = doors;
        }

        public int Doors
        {
            get { return doors; }
            set
            {
                if (value < 1 || value > 6)
                {
                    throw new ArgumentException("Antal dörrar måste vara mellan 1 och 6.");
                }
                doors = value;
            }
        }

        public override string GetDescription()
        {
            return $"{VehicleType} - {Manufacturer} {Model} ({YearModel}), Reg: {RegistrationNumber}, Doors: {Doors}";
        }
    }
}
