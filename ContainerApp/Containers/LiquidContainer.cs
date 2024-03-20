using ContainerApp.Interfaces;

namespace ContainerApp.Containers;

public class LiquidContainer : Container, IHazardNotifier
{
    private bool IsHazardous { set; get; }

    public LiquidContainer(double height, double containerWeight, double depth, double maximumPayload, bool isHazardous)
        : base(height, containerWeight, depth, maximumPayload)
    {
        SerialNumber = "KON-L-" + NumberCount;
        NumberCount += 1;
        IsHazardous = isHazardous;
    }

    public void HazardousSituation()
    {
        Console.WriteLine("In " + SerialNumber + " a hazardous situation!!!");
    }

    protected override void LoadTheContainer(double givenCargoMass)
    {
        base.LoadTheContainer(givenCargoMass);
        if (IsHazardous)
        {
            if (MaximumPayload * 0.5 - CargoMass - givenCargoMass < 0)
            {
                HazardousSituation();
            }
            else
            {
                CargoMass += givenCargoMass;
            }
        }
        else
        {
            if (MaximumPayload * 0.9 - CargoMass - givenCargoMass < 0)
            {
                HazardousSituation();
            }
            else
            {
                CargoMass += givenCargoMass;
            }
        }
    }
}