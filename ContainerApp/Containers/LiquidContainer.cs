using ContainerApp.Interfaces;

namespace ContainerApp.Containers;

public class LiquidContainer : Container, IHazardNotifier
{
    private bool IsHazard { set; get; }

    public LiquidContainer(double height, double containerWeight, double depth, double maximumPayload, bool isHazard)
        : base(height, containerWeight, depth, maximumPayload)
    {
        SerialNumber = "KON-L-" + NumberCount;
        NumberCount += 1;
        IsHazard = isHazard;
    }

    public void HazardSituation()
    {
        Console.WriteLine("In " + SerialNumber + " a hazardous situation!!!");
    }

    protected override void LoadTheContainer(double givenCargoMass)
    {
        base.LoadTheContainer(givenCargoMass);
        if (IsHazard)
        {
            if (MaximumPayload * 0.5 - CargoMass - givenCargoMass < 0)
            {
                HazardSituation();
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
                HazardSituation();
            }
            else
            {
                CargoMass += givenCargoMass;
            }
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
               "\nIs hazard: " + (IsHazard ? "yes" : "no");
    }
}