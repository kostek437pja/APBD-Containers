namespace Container;

public abstract class Container
{
    private static int counter = 1;
    public string SerialNumber { get; }
    public double MaxPayload { get; }
    public double CargoWeight { get; set; }
    
    public Container(string type, double maxPayload)
    {
        SerialNumber = $"KON-{type}-{counter++}";
        MaxPayload = maxPayload;
    }

    public virtual void LoadCargo(double weight)
    {
        if (weight > MaxPayload)
            throw new OverfillException("Cargo exceeds maximum payload.");
        CargoWeight = weight;
    }

    public virtual void UnloadCargo()
    {
        CargoWeight = 0;
    }

    public override string ToString()
    {
        return $"{SerialNumber}: {CargoWeight}/{MaxPayload} kg";
    }
}