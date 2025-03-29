namespace CW_2
{
    public class ContainerShip
    {
        
        private List<Container.Container> _containers = new List<Container.Container>();
        
        public double MaxSpeedKnots { get; set; }
        
        public int MaxContainerCount { get; set; }
        
        public double MaxWeightTons { get; set; }

        public ContainerShip(double maxSpeedKnots, int maxContainerCount, double maxWeightTons)
        {
            MaxSpeedKnots = maxSpeedKnots;
            MaxContainerCount = maxContainerCount;
            MaxWeightTons = maxWeightTons;
        }

        public void AddContainer(Container.Container container)
        {
            if (_containers.Count >= MaxContainerCount)
            {
                throw new OverfillException(
                    $"Attempt to add a container exceeds the maximum number of containers: {MaxContainerCount}.");
            }
            
            double currentWeightKg = 0;
            foreach (var c in _containers)
            {
                currentWeightKg += (c.Mass + c.OwnMass);
            }
            
            double newContainerWeightKg = container.Mass + container.OwnMass;
            double totalWeightKgAfterAdd = currentWeightKg + newContainerWeightKg;

            double maxWeightKg = MaxWeightTons * 1000; // konwersja ton → kg

            if (totalWeightKgAfterAdd > maxWeightKg)
            {
                throw new OverfillException(
                    $"Attempt to add a container exceeds the maximum total weight of {MaxWeightTons} tons (limit {maxWeightKg} kg). " +
                    $"Currently loaded: {currentWeightKg} kg, after adding: {totalWeightKgAfterAdd} kg."
                );
            }
            _containers.Add(container);
        }
        
        public bool RemoveContainer(Container.Container container)
        {
            return _containers.Remove(container);
        }

        public override string ToString()
        {
            return $"ContainerShip => MaxSpeed: {MaxSpeedKnots} knots, " +
                   $"MaxContainers: {MaxContainerCount}, MaxWeight: {MaxWeightTons} tons, " +
                   $"CurrentlyLoaded: {_containers.Count} containers.";
        }
    }
}
