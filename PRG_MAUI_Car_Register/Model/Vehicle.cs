using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;

namespace PRG_MAUI_Car_Register.Model
{
    abstract public class Vehicle
    {
        private string registrationNumber = string.Empty;
        private string manufacturer = string.Empty;
        private string model = string.Empty;
        private string yearModel = string.Empty;

        public Vehicle(string registrationNumber, string manufacturer, string model, int yearModel)
        {
            RegistrationNumber = registrationNumber;
            Manufacturer = manufacturer;
            Model = model;
            YearModel = yearModel;
        }

        public string RegistrationNumber
        {
            get { return registrationNumber; }
            set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Ett registreringsnummer måste bestå av exakt 6 tecken, med tre bokstäver följt av två siffror och en siffra eller bokstav.");
                }

                if (value.Length != 6)
                {
                    throw new ArgumentException("Ett registreringsnummer måste bestå av exakt 6 tecken, med tre bokstäver följt av två siffror och en siffra eller bokstav.");
                }

                bool isValid = true;
                char[] chars = value.ToCharArray();
                for (int i = 0; i < chars.Length; i++)
                {
                    char c = chars[i];
                    if (i <= 2)
                    {
                        if (!char.IsLetter(c))
                        {
                            isValid = false;
                        }
                    }
                    else if (i <= 4)
                    {
                        if (!char.IsDigit(c))
                        {
                            isValid = false;
                        }
                    }
                    else if (i == 5)
                    {
                        if (!char.IsLetterOrDigit(c))
                        {
                            isValid = false;
                        }
                    }
                }

                if (!isValid)
                {
                    throw new ArgumentException("Fel format för registreringsnummret, formattering måste vara antingen: ABC123, eller: ABC12D");
                }

                registrationNumber = value.ToUpper();
            }
        }

        public string Model
        {
            get { return model; }
            set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("En bil modell måste bestå av bokstäver, det kan inte vara tomt.");
                }

                foreach (char c in value)
                {
                    if (!char.IsLetterOrDigit(c) && c != ' ' && c != '-')
                    {
                        throw new ArgumentException("Modell får endast innehålla bokstäver, siffror, mellanslag och bindestreck.");
                    }
                }
                this.model = value;
            }
        }

        public string Manufacturer
        {
            get { return manufacturer; }
            set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("En bils märke måste bestå av bokstäver, det kan inte vara tomt.");
                }

                foreach (char c in value)
                {
                    if (!char.IsLetterOrDigit(c) && c != ' ' && c != '-')
                    {
                        throw new ArgumentException("Märke får endast innehålla bokstäver, siffror, mellanslag och bindestreck.");
                    }
                }
                this.manufacturer = value;
            }
        }

        public int YearModel
        {
            get
            {
                if (int.TryParse(this.yearModel, out int result))
                    return result;
                return 0;
            }
            set
            {
                string stringValue = value.ToString();

                if (string.IsNullOrWhiteSpace(stringValue))
                {
                    throw new ArgumentException("Årsmodell måste ha ett värde, det kan inte vara tomt.");
                }

                bool isValid = Regex.IsMatch(stringValue, "^[1-2][0-9][0-9][0-9]$");
                if (!isValid)
                {
                    throw new ArgumentException("Årsmodell måste vara ett fyrsiffrigt år.");
                }

                if (value < 1895 || value > DateTime.Now.Year)
                {
                    throw new ArgumentException($"Årsmodell måste vara högre än 1895 och lägre än {DateTime.Now.Year}");
                }

                this.yearModel = stringValue;
            }
        }

        public abstract string GetDescription();
    }
}
