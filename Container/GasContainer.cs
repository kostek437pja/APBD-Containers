namespace Container;

public class GasContainer : Container, IHazardNotifier
{
    public double Pressure { get; }
    
    public GasContainer(double maxPayload, double pressure) : base("G", maxPayload)
    {
        Pressure = pressure;
    }

    public override void UnloadCargo()
    {
        CargoWeight *= 0.05; 
    }
    
    public void NotifyHazard(string containerNumber)
    {
        Console.WriteLine($"Gas hazard detected in container {containerNumber}!");
    }
}