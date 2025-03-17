using Container;

class Program
{
    static void Main()
    {
        ContainerShip ship = new ContainerShip("Ship", 40000, 100);
        
        Container.Container bananaContainer = new RefrigeratedContainer(5000, "Bananas", 1000, 200, 300);
        bananaContainer.LoadCargo(4500);
        
        Container.Container heliumContainer = new GasContainer(2000, 150, 1000, 200, 300);
        heliumContainer.LoadCargo(1800);
        
        Container.Container fuelContainer = new LiquidContainer(3000, true, 1000, 200, 300);
        
        try
        {
            fuelContainer.LoadCargo(2000);
        }
        catch (OverfillException ex)
        {
            Console.WriteLine(ex.Message);
        }
        
        ship.LoadContainer(bananaContainer);
        ship.LoadContainer(heliumContainer);
        ship.LoadContainer(fuelContainer);
        
        Console.WriteLine(ship);

        ship.RemoveContainer(heliumContainer);
        Console.WriteLine("After removing helium container:");
        Console.WriteLine(ship);
        
        bananaContainer.UnloadCargo();
        Console.WriteLine("After unloading banana container:");
        Console.WriteLine(ship);
    }
}