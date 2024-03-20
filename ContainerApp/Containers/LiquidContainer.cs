namespace ContainerApp.Containers;

public class LiquidContainer : Container
{
    public LiquidContainer(double height, double containerWeight, double depth) : base(height, containerWeight, depth)
    {
        serialNumber = "KON-L-" + numberCount;
        numberCount += 1;
    }
}