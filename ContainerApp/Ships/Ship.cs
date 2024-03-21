using ContainerApp.Containers;

namespace ContainerApp.Ships;

public class Ship
{
    private List<Container> _containers;
    //knots
    private double maximumSpeed;
    private int maximumContainersCapacity;
    //tons
    private double maximumSumOfContainersWeight;

    public Ship(List<Container> containers, double maximumSpeed, int maximumContainersCapacity, double maximumSumOfContainersWeight)
    {
        _containers = containers;
        this.maximumSpeed = maximumSpeed;
        this.maximumContainersCapacity = maximumContainersCapacity;
        this.maximumSumOfContainersWeight = maximumSumOfContainersWeight;
    }
}