using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PRG_MAUI_Car_Register.Model
{
    internal class Car : Vehicle
    {
        private int doors;
        public Car(string vehicleType, string registrationNumber, string manufacturer, string model, string yearModel, int doors) : base(vehicleType, registrationNumber, manufacturer, model, yearModel)
        {
            this.doors = doors;
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
