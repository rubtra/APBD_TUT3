namespace apbd_tut3;

public class GasContainer : Containers, IHazardNotifier
{
    private const double ResidualCargoPercentage = 0.05; 
    public double Pressure { get; } 

    public GasContainer(double height, double tareWeight, double depth, double maxPayload, double pressure) 
        : base("G", height, tareWeight, depth, maxPayload)
    {
        Pressure = pressure;
    }

    public override void LoadCargo(double cargoMass)
    {
        double futureMass = Mass + cargoMass;
        if (futureMass > Max_Payload)
        {
            string message = FormatHazardMessage($"Overfill Attempt: {ToString()} exceeded max payload of {Max_Payload}kg.");
            NotifyHazard(message);
            throw new InvalidOperationException($"Overfill Error: Cannot load {cargoMass}kg. Max payload: {Max_Payload}kg.");
        }

        base.LoadCargo(cargoMass);
    }

    public override void EmptyCargo()
    {
        string message = FormatHazardMessage($"Gas container {Serial_Number} emptied, leaving 5% of cargo.");
        NotifyHazard(message);
        Mass *= ResidualCargoPercentage; 
    }

    public void NotifyHazard(string message)
    {
        Console.WriteLine($"HAZARD ALERT: {message}");
    }

    public override string ToString()
    {
        return $"{base.ToString()}, Pressure={Pressure}atm"; 
    }

    private static string FormatHazardMessage(string message)
    {
        return $"HAZARD ALERT: {message}";
    }
}