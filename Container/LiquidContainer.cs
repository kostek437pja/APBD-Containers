namespace Container;

public class LiquidContainer : Container, IHazardNotifier
{
    public bool IsHazardous { get; }
    
    public LiquidContainer(double maxPayload, bool isHazardous) : base("L", maxPayload)
    {
        IsHazardous = isHazardous;
    }
    
    public override void LoadCargo(double weight)
    {
        double maxAllowed = IsHazardous ? MaxPayload * 0.5 : MaxPayload * 0.9;
        if (weight > maxAllowed)
        {
            NotifyHazard(SerialNumber);
            throw new OverfillException("Hazardous cargo over limit.");
        }
        base.LoadCargo(weight);
    }
    
    public void NotifyHazard(string containerNumber)
    {
        Console.WriteLine($"Container {containerNumber} exceeded limit.");
    }
}