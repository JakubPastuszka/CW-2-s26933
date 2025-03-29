namespace CW_2.Container

{
    using SerialNumberGenerator;

    public abstract class Container
    {
        public double Mass { get; set; }         // w kilo
        public double Height { get; set; }       // w centy
        public double OwnMass { get; set; }      // w kilo
        public double Depth { get; set; }        // w centy
        public string SerialNumber { get; set; } // unikalne ogarne przez oddzielną klasę 
        public double MaxCapacity { get; set; }  // w kilo

        // Ten konstruktor jest "protected", bo klasa jest abstrakcyjna.
        protected Container(double mass, double height, double ownMass, double depth, double maxCapacity, string containerType)
        {
            Mass = mass;
            Height = height;
            OwnMass = ownMass;
            Depth = depth;
            MaxCapacity = maxCapacity;
            SerialNumber = SerialNumberGenerator.GenerateSerialNumber(containerType);
        }
        
        public virtual void EmptyTheCargo()
        {
            Mass = 0;
        }
        
        public virtual void LoadTheCargo(double mass)
        {
            if (mass > MaxCapacity)
            {
                throw new OverfillException($"Loaded {mass} kg, which exceeds the capacity: {MaxCapacity} kg.");
            }
            Mass = mass;
        }

        public override string ToString()
        {
            return $"SerialNumber: {SerialNumber}, " +
                   $"Mass: {Mass}, Height: {Height}, OwnMass: {OwnMass}, Depth: {Depth}, MaxCapacity: {MaxCapacity}";
        }
    }
}