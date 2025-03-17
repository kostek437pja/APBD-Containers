namespace Container;

public class RefrigeratedContainer : Container
{
    public double Temperature { get; }
    private static Dictionary<string, double> ProductTemperatures = new()
    {
        {"Bananas", 13.3}, {"Chocolate", 18}, {"Fish", 2}, {"Meat", -15},
        {"Ice cream", -18}, {"Frozen pizza", -30}, {"Cheese", 7.2}, {"Sausages", 5},
        {"Butter", 20.5}, {"Eggs", 19}
    };
    public string StoredProduct { get; set; }
    
    public RefrigeratedContainer(double maxPayload, string product) : base("C", maxPayload)
    {
        if (!ProductTemperatures.ContainsKey(product))
            throw new ArgumentException("Invalid product type.");
        
        Temperature = ProductTemperatures[product];
        StoredProduct = product;
    }
    
    public override void LoadCargo(double weight)
    {
        if (weight > MaxPayload * 0.9)
            throw new OverfillException("Cargo exceeds 90% capacity limit.");
        base.LoadCargo(weight);
    }
}