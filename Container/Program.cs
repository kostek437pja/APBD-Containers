using Container;

class Program
{
    static void Main()
    {
        ContainerShip ship = new ContainerShip("Titanic", 40000, 100);
        
        Container.Container bananaContainer = new RefrigeratedContainer(5000, -5);
        bananaContainer.LoadCargo(4500);
        
        Container.Container heliumContainer = new GasContainer(2000, 150);
        heliumContainer.LoadCargo(1800);
        
        ship.LoadContainer(bananaContainer);
        ship.LoadContainer(heliumContainer);
        
        Console.WriteLine(ship);
    }
}