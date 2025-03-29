namespace CW_2.Container
{
    
    public class ContainerCooling : Container
    {
        public string ProductType { get; set; }    // np. "banany",
        public double CurrentTemperature { get; set; }
        public double MinAllowedTemperature { get; private set; }

        public ContainerCooling(double mass, double height, double ownMass, double depth,
            double maxCapacity, string productType,
            double currentTemperature, double minAllowedTemperature)
            : base(mass, height, ownMass, depth, maxCapacity, "C")
        {
            ProductType = productType;
            CurrentTemperature = currentTemperature;
            MinAllowedTemperature = minAllowedTemperature;

            // Sprawdź, czy początkowa temperatura nie jest za niska
            if (CurrentTemperature < MinAllowedTemperature)
            {
                throw new Exception(
                    $"Temperature ({CurrentTemperature}°C) is lower than the minimum required ({MinAllowedTemperature}°C) for '{ProductType}'."
                );
            }
        }
        
        public void SetTemperature(double newTemp)
        {
            if (newTemp < MinAllowedTemperature)
            {
                throw new Exception(
                    $"The new temperature ({newTemp}°C) is lower than the required minimum ({MinAllowedTemperature}°C) for '{ProductType}'."
                );
            }
            CurrentTemperature = newTemp;
        }
    }
}