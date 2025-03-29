namespace CW_2.Container
{
    public class ContainerLiquid : Container, IHazardNotifier
    {
        // Pole określające, czy ładunek niebezpieczny
        public bool IsHazardous { get; set; }

        public ContainerLiquid(double height, double ownMass, double depth, double maxCapacity, bool isHazardous)
            : base(0, height, ownMass, depth, maxCapacity, "L")
        {
            IsHazardous = isHazardous;
        }
        
        public void NotifyHazard(string message)
        {
            Console.WriteLine($"[HAZARD] {message} (Container: {SerialNumber})");
        }

        
        // niebezpieczny: max 50% 
        // zwykły: max 90%
        public override void LoadTheCargo(double mass)
        {
            double limit = IsHazardous ? 0.50 * MaxCapacity : 0.90 * MaxCapacity; // można też ifem ale do powtórzenia operator warunkowy

            if (mass > limit)
            {
                NotifyHazard($"Attempt to load {mass} kg exceeds the allowed limit {limit} kg!");
                throw new OverfillException("Attempt to perform a hazardous operation (limit exceeded in ContainerLiquid).");
            }
            
            base.LoadTheCargo(mass);
        }
    }
}