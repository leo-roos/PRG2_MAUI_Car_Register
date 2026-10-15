namespace PRG_MAUI_Car_Register.Model
{
    internal class MC : Vehicle
    {
        private string cylinderVolume = string.Empty;
        public MC(string registrationNumber, string manufacturer, string model, int yearModel, int cylinderVolume) : base(registrationNumber, manufacturer, model, yearModel)
        {
            VehicleType = "MC";
            CylinderVolume = cylinderVolume;
        }

        public override string GetDescription()
        {
            return $"{VehicleType} - {Manufacturer} {Model} ({YearModel}), Reg: {RegistrationNumber}";
        }

        public int CylinderVolume
        {
            get
            {
                if (int.TryParse(this.cylinderVolume, out int result))
                    return result;
                return 0; // or throw new InvalidOperationException("YearModel not set or invalid");
            }
            set
            {
                string stringValue = value.ToString();

                if (string.IsNullOrWhiteSpace(stringValue))
                {
                    throw new ArgumentException("Cylindervolym måste ha ett värde, det kan inte vara tomt.");
                }

                if (value < 0 || value > 35000)
                {
                    throw new ArgumentException("Ogiltig cylindervolym");
                }

                this.cylinderVolume = stringValue;
            }
        }
    }
}
