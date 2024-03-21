namespace ContainerApp.Containers;

public class RefrigeratedContainer : Container
{
    private readonly string _typeOfProduct;
    private readonly double _requiredTemperature;
    private double TemperatureInContainer { set; get; }

    protected RefrigeratedContainer(double height, double containerWeight, double depth, double maximumPayload,
        string typeOfProduct, double temperatureInContainer) : base(height, containerWeight, depth, maximumPayload)
    {
        _typeOfProduct = typeOfProduct;
        TemperatureInContainer = temperatureInContainer;
        _requiredTemperature = _typeOfProduct switch
        {
            "Bananas" => 13.3,
            "Chocolate" => 18,
            "Fish" => 2,
            "Meat" => -15,
            "Ice cream" => -18,
            "Frozen pizza" => -30,
            "Cheese" => 7.2,
            "Sausages" => 5,
            "Butter" => 20.5,
            "Eggs" => 19,
            _ => _requiredTemperature
        };
    }

    protected void LoadTheContainer(double givenCargoMass, string type)
    {
        if (type == _typeOfProduct)
        {
            base.LoadTheContainer(givenCargoMass);
        }
        else
        {
            Console.WriteLine("Wrong type of product");
        }
    }

    public override string ToString()
    {
        return "Container: \n" +
               "Height: " + Height +
               "\nWeight: " + ContainerWeight +
               "\nDepth: " + Depth +
               "\nMaximum payload: " + MaximumPayload +
               "\nSerial number: " + SerialNumber +
               "\nCurrent cargo mass: " + CargoMass +
               "\nType of products: " + _typeOfProduct +
               "\nCurrent temperature: " + TemperatureInContainer +
               "\nRequired temperature: " + _requiredTemperature;
    }
}