using Company.Domain;

namespace DeviceManagement.Domain.Entities
{
    public class Vehicle : Entity
    {
        public Vehicle() { }

        private Vehicle(string make, string model, string year)
        {
            Make = make;
            Model = model;
            Year = year;
        }

        public static Vehicle Create(string make, string model, string year)
        {
            return new Vehicle(make, model, year);
        }

        public string Make { get; private set; } = string.Empty;
        public string Model { get; private set; } = string.Empty;
        public string Year { get; private set; } = string.Empty;
    }
}