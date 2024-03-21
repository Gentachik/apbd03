using ContainerApp.Interfaces;

namespace ContainerApp.Containers;

public class GasContainer : Container, IHazardNotifier
{
    protected GasContainer(double height, double containerWeight, double depth, double maximumPayload) : base(height, containerWeight, depth, maximumPayload)
    {
        SerialNumber = "KON-G-" + NumberCount;
    }

    public override void EmptyTheCargo()
    {
        CargoMass = CargoMass * 0.05;
    }

    public void HazardousSituation()
    {
        Console.WriteLine("In " + SerialNumber + " a hazardous situation!!!");
    }
}