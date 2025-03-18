namespace apbd_tut3;
public class RefrigeratedContainer : Containers
{
    private const string ContainerType = "C";
    private string StoredProduct { get; }
    private double Temperature { get; }

    public RefrigeratedContainer(double height, double tareWeight, double depth, double maxPayload, string product, double temperature) 
        : base(ContainerType, height, tareWeight, depth, maxPayload)
    {
        ValidateProductAndTemperature(product, temperature);
        StoredProduct = product;
        Temperature = temperature;
    }

    private void ValidateProductAndTemperature(string product, double temperature)
    {
        if (!ProductTemperature.RequiredTemperatures.TryGetValue(product, out var requiredTemperature))
        {
            throw new ArgumentException($"Invalid product type: {product}");
        }

        if (temperature < requiredTemperature)
        {
            throw new InvalidOperationException($"Error: Temperature {temperature}°C is too low for {product}. Minimum required: {requiredTemperature}°C.");
        }
    }

    public override void LoadCargo(double cargoMass)
    {
        base.LoadCargo(cargoMass);
        Console.WriteLine($"Loaded {cargoMass}kg of {StoredProduct} at {Temperature}°C.");
    }

    public override string ToString()
    {
        return $"{base.ToString()}, Product={StoredProduct}, Temperature={Temperature}°C";
    }
}