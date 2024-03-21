using ContainerApp.Exceptions;

namespace ContainerApp.Containers;

public class Container
{
    //serial number count
    protected static int NumberCount = 1;

    //kg
    public double CargoMass { get; set; }

    //cm
    protected double Height { get; set; }

    //kg
    public double ContainerWeight { get; set; }

    //cm
    protected double Depth { get; set; }

    protected string? SerialNumber { get; init; }

    //kg
    protected double MaximumPayload { get; set; }

    protected Container(double height, double containerWeight, double depth, double maximumPayload)
    {
        this.MaximumPayload = maximumPayload;
        this.Height = height;
        this.ContainerWeight = containerWeight;
        this.Depth = depth;
    }

    internal static Container CreateInstance(double height, double containerWeight, double depth, double maximumPayload)
    {
        return new Container(height, containerWeight, depth, maximumPayload);
    }

    public virtual void EmptyTheCargo()
    {
        CargoMass = 0;
    }

    protected virtual void LoadTheContainer(double givenCargoMass)
    {
        if (MaximumPayload - CargoMass - givenCargoMass < 0)
        {
            throw new OverfillException("This mass: " + givenCargoMass + " can't be stored!");
        }

        CargoMass += givenCargoMass;
    }
}