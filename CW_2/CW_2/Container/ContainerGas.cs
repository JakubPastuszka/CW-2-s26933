namespace CW_2.Container
{
    public class ContainerGas : Container, IHazardNotifier
    {
        public double Pressure { get; set; } // w atmosferach

        public ContainerGas(double height, double ownMass, double depth, double maxCapacity, double pressure)
            : base(0, height, ownMass, depth, maxCapacity, "G")
        {
            Pressure = pressure;
        }
        
        public void NotifyHazard(string message)
        {
            Console.WriteLine($"[GAS HAZARD] {message} (Container: {SerialNumber})");
        }

        // zostaje 5% ładunku
        public override void EmptyTheCargo()
        {
            // Zostawiamy 5% dotychczasowej masy
            Mass = Mass * 0.05;
        }
        
        public override void LoadTheCargo(double mass)
        {
            if (mass > MaxCapacity)
            {
                NotifyHazard($"Attempt to load {mass} kg exceeds the maximum capacity {MaxCapacity} kg!");
                throw new OverfillException("Exceeded capacity in ContainerGas.");
            }
            base.LoadTheCargo(mass);
        }
    }
}