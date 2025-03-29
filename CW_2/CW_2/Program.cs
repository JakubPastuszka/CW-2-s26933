namespace CW_2
{
    using System;
    using Container;
    public class Program
    {
        public static void Main(String[] args)
        {
            try
            {
                var liquid1 = new ContainerLiquid(
                    height: 200, ownMass: 50, depth: 100,
                    maxCapacity: 500, isHazardous: false);

                var gas1 = new ContainerGas(
                    height: 180, ownMass: 80, depth: 100,
                    maxCapacity: 400, pressure: 2.5);

                var cooling1 = new ContainerCooling(
                    mass: 0, height: 190, ownMass: 90, depth: 120,
                    maxCapacity: 600, productType: "Fish",
                    currentTemperature: 2, minAllowedTemperature: 2 
                );
                
                // 2) Loading cargo into containers
                liquid1.LoadTheCargo(200);   
                gas1.LoadTheCargo(300);      
                cooling1.LoadTheCargo(100);  
                // 3) Creating a container ship
                var shipA = new ContainerShip(
                    maxSpeedKnots: 25,
                    maxContainerCount: 5,   
                    maxWeightTons: 5        
                );
                Console.WriteLine($"[INFO] Created shipA: {shipA}");
                
                shipA.AddContainer(liquid1);
                shipA.AddContainer(gas1);

                // 4b) Loading a LIST of containers onto the ship
                // 
                var extraContainers = new List<Container.Container>
                {
                    cooling1,
                    new ContainerLiquid(
                        height: 210, ownMass: 60, depth: 110,
                        maxCapacity: 400, isHazardous: true
                    ),
                };
                // Load them all
                foreach (var c in extraContainers)
                {
                    // Possibly load them with cargo first if needed...
                    // c.LoadTheCargo(...);
                    shipA.AddContainer(c);
                }
                
                //_________________________________________________________inne przykłady
                
                
                
                
                ContainerLiquid liquidHazard = new ContainerLiquid(
                    height: 200, ownMass: 100, depth: 150,
                    maxCapacity: 1000, isHazardous: true);

                liquidHazard.LoadTheCargo(300); // OK
                //liquidHazard.LoadTheCargo(600); // TO by wyrzuciło OverfillException

                ContainerGas gasContainer = new ContainerGas(
                    height: 200, ownMass: 120, depth: 150,
                    maxCapacity: 1000, pressure: 5.0);
                gasContainer.LoadTheCargo(900); // OK
                // gasContainer.LoadTheCargo(1100); // Błąd
                
                gasContainer.EmptyTheCargo();
                Console.WriteLine($"After emptying the gas container: {gasContainer.Mass} kg left (5% of previous load).");
                
                ContainerCooling coolingContainer = new ContainerCooling(
                    mass: 100,   
                    height: 200, ownMass: 250,
                    depth: 100, maxCapacity: 2000,
                    productType: "Bananas",
                    currentTemperature: -10.0,
                    minAllowedTemperature: -15.0
                );
                Console.WriteLine($"Created cooling container: {coolingContainer}");
                
                coolingContainer.SetTemperature(-14.0);   // OK
                // coolingContainer.SetTemperature(-16.0); // Zgłosi błąd (za zimno)
                
            }
            catch (OverfillException ex)
            {
                Console.WriteLine("[OverfillException] " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("[Exception] " + ex.Message);
            }
        }
    }
}