using Container;

public class Program
{
    static void Main()
    {
        ContainerShip ship1 = new ContainerShip("Ship1", 50000, 120, 30);
        ContainerShip ship2 = new ContainerShip("Ship2", 40000, 100, 50);
        
        Container.Container bananaContainer = new RefrigeratedContainer(5000, "Bananas", 1000, 200, 300);
        bananaContainer.LoadCargo(4500);
        
        Container.Container heliumContainer = new GasContainer(2000, 150, 1000, 200, 300);
        heliumContainer.LoadCargo(1800);
        
        Container.Container fuelContainer = new LiquidContainer(3000, true, 1000, 200, 300);
        fuelContainer.LoadCargo(1500);

        Container.Container milkContainer = new LiquidContainer(2500, false, 1000, 200, 300);
        milkContainer.LoadCargo(2000);
        
        try
        {
            fuelContainer.LoadCargo(2000);
        }
        catch (OverfillException ex)
        {
            Console.WriteLine(ex.Message);
        }
        
        ship1.LoadContainers(new List<Container.Container> { bananaContainer, heliumContainer, fuelContainer });
        Console.WriteLine(ship1);

        ship1.PrintContainers();
        
        ship1.ReplaceContainer(heliumContainer.SerialNumber, milkContainer);
        ship1.PrintContainers();

        
        ship1.TransferContainer(bananaContainer, ship2);
        Console.WriteLine("Ship 1:");
        ship1.PrintContainers();
        Console.WriteLine("Ship 2:");
        ship2.PrintContainers();

        
        fuelContainer.UnloadCargo();
        ship1.PrintContainers();
    }
}
