using ContainerApp.Interfaces;

namespace ContainerApp.Containers;

public class GasContainer : Container, IHazardNotifier
{
    protected GasContainer(double height, double containerWeight, double depth, double maximumPayload) : base(height,
        containerWeight, depth, maximumPayload)
    {
        SerialNumber = "KON-G-" + NumberCount;
    }

    public override void EmptyTheCargo()
    {
        CargoMass = CargoMass * 0.05;
    }

    public void HazardSituation()
    {
        Console.WriteLine("In " + SerialNumber + " a hazardous situation!!!");
    }

    public override string ToString()
    {
        return "Container: \n" +
               "Height: " + Height +
               "\nWeight: " + ContainerWeight +
               "\nDepth: " + Depth +
               "\nMaximum payload: " + MaximumPayload +
               "\nSerial number: " + SerialNumber +
               "\nCurrent cargo mass: " + CargoMass;
    }
}