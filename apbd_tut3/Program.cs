namespace apbd_tut3;

class Program
{
    static void Main(string[] args)
    {
        var containers = new List<Containers>
        {
            new Liquid_containers(150, 400, 250, 900, true), 
            new GasContainer(200, 500, 300, 1100, 18),    
            new RefrigeratedContainer(240, 600, 350, 1400, "Fish", 2), 
            new RefrigeratedContainer(260, 650, 370, 1500, "Meat", -15) 
        };
        
        Console.WriteLine("\n--- Loading Containers With Cargo ---");
        containers[0].LoadCargo(350); // LiquidContainer
        containers[1].LoadCargo(450); // GasContainer
        containers[2].LoadCargo(900); // RefrigeratedContainer
        containers[3].LoadCargo(500); // RefrigeratedContainer

        // creating first ship
        Console.WriteLine("\n--- Preparing Ship 1: Neptune ---");
        var neptune = new ContainerShip("Neptune", 35, 3, 4800); 
        neptune.LoadContainers(containers.Take(3).ToList()); 

        // info
        Console.WriteLine("\n--- Ship 1 Initial State ---");
        neptune.PrintShipInfo();

        // unloading
        Console.WriteLine("\n--- Unloading First Container From Ship 1 ---");
        neptune.UnloadContainer("KON-L-1"); // Жидкостный контейнер
        
        Console.WriteLine("\n--- Removing Refrigerated Container (Fish) From Ship 1 ---");
        neptune.RemoveContainer("KON-C-1");

        // second one
        Console.WriteLine("\n--- Preparing Ship 2: Atlantis ---");
        var atlantis = new ContainerShip("Atlantis", 40, 2, 4000); 

        // replace
        Console.WriteLine("\n--- Replacing Container on Ship 2 (Atlantis) ---");
        var anotherContainer = new RefrigeratedContainer(250, 630, 360, 1480, "Bananas", 13.3);
        atlantis.ReplaceContainer("KON-C-3", anotherContainer);
        Console.WriteLine($"Container 'KON-C-3' replaced with new container: {anotherContainer}.");

        // transfer
        Console.WriteLine("\n--- Transferring Refrigerated Container to Ship 2 (Atlantis) ---");
        neptune.TransferContainer("KON-C-2", atlantis); 

        // final info
        Console.WriteLine("\n--- Final State of Ships ---");
        Console.WriteLine("\n--- Ship 1: Neptune ---");
        neptune.PrintShipInfo();

        Console.WriteLine("\n--- Ship 2: Atlantis ---");
        atlantis.PrintShipInfo();
    }
}