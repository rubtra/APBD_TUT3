namespace apbd_tut3;

public class Liquid_containers : Containers, IHazardNotifier
{
    private bool IsHazardous { get; }

    public Liquid_containers(
        double height, 
        double tareWeight, 
        double depth, 
        double maxPayload, 
        bool isHazardous) 
        : base("L", height, tareWeight, depth, maxPayload)
    {
        IsHazardous = isHazardous;
    }

    public override void LoadCargo(double cargoMass)
    {
        double maxAllowedLoad = IsHazardous ? Max_Payload * 0.5 : Max_Payload * 0.9;

        if (Mass + cargoMass > maxAllowedLoad)
        {
            NotifyHazard($"Dangerous Operation: Attempted to load {cargoMass}kg into {ToString()}, exceeding allowed limit of {maxAllowedLoad}kg.");
            throw new InvalidOperationException($"Loading exceeds safe capacity! Allowed: {maxAllowedLoad}kg.");
        }

        base.LoadCargo(cargoMass);
    }
    
    public override void EmptyCargo()
    {
        Console.WriteLine($"Emptying liquid container {Serial_Number}");
        
        base.EmptyCargo();
    }


    public void NotifyHazard(string message)
    {
        Console.WriteLine($"HAZARD ALERT: {message}");
    }
}