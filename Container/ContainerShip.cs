namespace Container;

public class ContainerShip
{
    public string Name { get; }
    public double MaxWeight { get; }
    public int MaxContainers { get; }
    public List<Container> Containers { get; }
    public int Speed { get; set; }

    public ContainerShip(string name, double maxWeight, int maxContainers, int speed)
    {
        Name = name;
        MaxWeight = maxWeight;
        MaxContainers = maxContainers;
        Containers = new List<Container>();
        Speed = speed;
    }

  public void LoadContainer(Container container)
    {
        if (Containers.Count >= MaxContainers)
            throw new Exception("Ship at full capacity.");
        if (GetTotalWeight() + container.CargoWeight > MaxWeight)
            throw new Exception("Exceeds maximum ship weight.");
        
        Containers.Add(container);
    }
  
    public void LoadContainers(List<Container> newContainers)
    {
        foreach (var container in newContainers)
        {
            LoadContainer(container);
        }
    }

    public void RemoveContainer(Container container)
    {
        Containers.Remove(container);
    }
    
    public void ReplaceContainer(string containerNumber, Container newContainer)
    {
        var existingContainer = Containers.Find(c => c.SerialNumber == containerNumber);
        if (existingContainer == null)
            throw new Exception($"Container {containerNumber} not found.");
        
        Containers.Remove(existingContainer);
        LoadContainer(newContainer);
    }
    
    public void TransferContainer(Container container, ContainerShip targetShip)
    {
        if (!Containers.Contains(container))
            throw new Exception("Container not found on this ship.");
        
        RemoveContainer(container);
        targetShip.LoadContainer(container);
    }

    public double GetTotalWeight()
    {
        double total = 0;
        foreach (var container in Containers)
            total += container.CargoWeight;
        return total;
    }

    public override string ToString()
    {
        return $"{Name}: {Containers.Count}/{MaxContainers} containers, {GetTotalWeight()}/{MaxWeight} kg";
    }
    
    public void PrintContainers()
    {
        Console.WriteLine($"Ship {Name} - Containers:");
        foreach (var container in Containers)
            Console.WriteLine(container);
    }
}
