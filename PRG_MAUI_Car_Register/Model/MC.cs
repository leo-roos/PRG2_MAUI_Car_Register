using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRG_MAUI_Car_Register.Model
{
    internal class MC : Vehicle
    {
        public MC(string vehicleType, string registrationNumber, string manufacturer, string model, string yearModel) : base(vehicleType, registrationNumber, manufacturer, model, yearModel)
        {
        }

        public override string GetDescription()
        {
            return $"{VehicleType} - {Manufacturer} {Model} ({YearModel}), Reg: {RegistrationNumber}";
        }
    }
}
