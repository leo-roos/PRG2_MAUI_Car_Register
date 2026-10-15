namespace PRG_MAUI_Car_Register.Model
{
    internal class Truck : Vehicle
    {
        private string loadCapacity = string.Empty;
        public Truck(string registrationNumber, string manufacturer, string model, int yearModel, int loadCapacity) : base(registrationNumber, manufacturer, model, yearModel)
        {
            VehicleType = "Lastbil";
            LoadCapacity = loadCapacity;
        }

        public override string GetDescription()
        {
            return $"{VehicleType} - {Manufacturer} {Model} ({YearModel}), Reg: {RegistrationNumber}";
        }

        public int LoadCapacity
        {
            get
            {
                if (int.TryParse(this.loadCapacity, out int result))
                    return result;
                return 0; // or throw new InvalidOperationException("YearModel not set or invalid");
            }
            set
            {
                string stringValue = value.ToString();

                if (string.IsNullOrWhiteSpace(stringValue))
                {
                    throw new ArgumentException("Lastkapacitet måste ha ett värde, det kan inte vara tomt.");
                }

                if (value < 0 || value > 35000)
                {
                    throw new ArgumentException("Ogiltigt lastkapacitet");
                }

                this.loadCapacity = stringValue;
            }
        }
    }
}
