namespace apbd_tut3;

public class Containers
{
    protected string Serial_Number { get; set; }
    public double Mass { get; set; }
    private double Height { get; set; }
    private double Tare_Weight { get; }
    private double Depth { get; set; }
    protected double Max_Payload { get; set; }
    private static int counter = 1;

    protected Containers(string type, double height, double tare_Weight, double depth, double max_Payload)
    {
        Serial_Number = $"KON-{type}-{counter++}";
        Height = height;
        Tare_Weight = tare_Weight;
        Depth = depth;
        Max_Payload = max_Payload;
        Mass = 0;
    }

    public virtual void LoadCargo(double Cargo_Mass)
    {
        if (Cargo_Mass + Mass > Max_Payload)
        {
            throw new InvalidOperationException(
                $"Overfill Error: Cannot load {Cargo_Mass}kg. Exceeds max payload {Max_Payload}kg.");
        }

        Mass += Cargo_Mass;
    }

    public virtual void EmptyCargo()
    {
        Mass = 0;
    }

    public override string ToString()
    {
        return
            $"{Serial_Number}: Mass={Mass}kg, Height={Height}cm, Tare Weight={Tare_Weight}kg, Depth={Depth}cm, Max Payload={Max_Payload}";

    }
}