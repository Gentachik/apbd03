using ContainerApp.Exceptions;

namespace ContainerApp.Containers;

public class Container
{
    //serial number count
    protected static int numberCount = 1;

    //kg
    private double cargoMass { get; set; }

    //cm
    protected double Height { get; set; }

    //kg
    protected double containerWeight { get; set; }

    //cm
    protected double depth { get; set; }

    protected string serialNumber { get; set; }

    //kg
    private double maximumPayload { get; set; }

    public Container(double height, double containerWeight, double depth)
    {
        Height = height;
        this.containerWeight = containerWeight;
        this.depth = depth;
    }


    public void emptyngTheCargo()
    {
        cargoMass = 0;
    }

    public void loadTheContainer(double givenCargoMass)
    {
        if (maximumPayload - cargoMass - givenCargoMass < 0)
        {
            throw new OverfillException(givenCargoMass.ToString());
        }

        cargoMass += givenCargoMass;
    }
}