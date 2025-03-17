namespace Container;

public class RefrigeratedContainer : Container
{
    public double Temperature { get; }
    
    public RefrigeratedContainer(double maxPayload, double temperature) : base("C", maxPayload)
    {
        Temperature = temperature;
    }
}