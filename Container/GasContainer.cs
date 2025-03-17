namespace Container;

public class GasContainer : Container, IHazardNotifier
{
    public double Pressure { get; }
    
    public GasContainer(double maxPayload, double pressure, double height, double width, double depth) : base("G", maxPayload, height, width, depth)
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