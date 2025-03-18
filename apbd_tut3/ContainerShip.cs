namespace apbd_tut3;

public class ContainerShip
{
    private string Name { get; }
    private double MaxSpeed { get; } 
    private int MaxContainers { get; }
    private double MaxWeight { get; } 

    private List<Containers> ContainersOnBoard { get; }

    public ContainerShip(string name, double maxSpeed, int maxContainers, double maxWeight)
    {
        Name = name;
        MaxSpeed = maxSpeed;
        MaxContainers = maxContainers;
        MaxWeight = maxWeight * 1000; 
        ContainersOnBoard = new List<Containers>();
    }

    public void LoadContainer(Containers container)
    {
        if (ContainersOnBoard.Count >= MaxContainers)
        {
            throw new InvalidOperationException("Cannot load more containers. Ship is at full capacity.");
        }

        double totalWeight = ContainersOnBoard.Sum(c => c.Mass);
        if (totalWeight + container.Mass > MaxWeight)
        {
            throw new InvalidOperationException("Cannot load container. Exceeds ship's max weight capacity.");
        }

        ContainersOnBoard.Add(container);
        Console.WriteLine($"Container {container} loaded onto {Name}.");
    }

    public void LoadContainers(List<Containers> containers)
    {
        foreach (var container in containers)
        {
            LoadContainer(container);
        }
    }

    public void RemoveContainer(string serialNumber)
    {
        var container = FindContainer(serialNumber);
        if (container == null) return;

        ContainersOnBoard.Remove(container);
        Console.WriteLine($"Container {serialNumber} removed from {Name}.");
    }

    public void UnloadContainer(string serialNumber)
    {
        var container = FindContainer(serialNumber);
        if (container == null) return;

        container.EmptyCargo();
        Console.WriteLine($"Container {serialNumber} has been unloaded.");
    }

    public void ReplaceContainer(string serialNumber, Containers newContainer)
    {
        RemoveContainer(serialNumber);
        LoadContainer(newContainer);
    }

    public void TransferContainer(string serialNumber, ContainerShip targetShip)
    {
        var container = FindContainer(serialNumber);
        if (container == null) return;

        RemoveContainer(serialNumber);
        targetShip.LoadContainer(container);
        Console.WriteLine($"Container {serialNumber} transferred from {Name} to {targetShip.Name}.");
    }

    public void PrintShipInfo()
    {
        Console.WriteLine($"Ship: {Name}, Max Speed: {MaxSpeed} knots, Max Containers: {MaxContainers}, Max Weight: {MaxWeight / 1000} tons");
        Console.WriteLine("Containers on board:");
        foreach (var container in ContainersOnBoard)
        {
            Console.WriteLine(container);
        }
    }

    private Containers? FindContainer(string serialNumber)
    {
        var container = ContainersOnBoard.FirstOrDefault(c => c.ToString().Contains(serialNumber));
        if (container == null)
        {
            Console.WriteLine($"Container {serialNumber} not found on {Name}.");
        }

        return container;
    }
}