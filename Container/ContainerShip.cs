namespace Container;

public class ContainerShip
{
    public string Name { get; }
    public double MaxWeight { get; }
    public int MaxContainers { get; }
    public List<Container> Containers { get; }

    public ContainerShip(string name, double maxWeight, int maxContainers)
    {
        Name = name;
        MaxWeight = maxWeight;
        MaxContainers = maxContainers;
        Containers = new List<Container>();
    }

    public void LoadContainer(Container container)
    {
        if (Containers.Count >= MaxContainers)
            throw new Exception("Ship at full capacity.");
        if (GetTotalWeight() + container.CargoWeight > MaxWeight)
            throw new Exception("Exceeds maximum ship weight.");
        
        Containers.Add(container);
    }
    
    public void RemoveContainer(Container container)
    {
        Containers.Remove(container);
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
}
