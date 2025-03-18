namespace apbd_tut3;

public static class ProductTemperature
{
    public static readonly Dictionary<string, double> RequiredTemperatures = new()
    {
        { "Bananas", 13.3 },
        { "Chocolate", 18.0 },
        { "Fish", 2.0 },
        { "Meat", -15.0 },
        { "Ice Cream", -18.0 },
        { "Frozen Pizza", -30.0 },
        { "Cheese", 7.2 },
        { "Sausages", 5.0 },
        { "Butter", 20.5 },
        { "Eggs", 19.0 }
    };
}
