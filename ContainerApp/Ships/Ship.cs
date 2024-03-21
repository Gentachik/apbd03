using ContainerApp.Containers;

namespace ContainerApp.Ships;

public class Ship(double maximumSpeed, int maximumContainersCapacity, double maximumSumOfContainersWeight)
{
    private readonly List<Container> _containers = [];

    //knots
    private int _currentCapacity;

    private double _currentSumOfContainersWeight;

    //tons
    private readonly double _maximumSumOfContainersWeight = maximumSumOfContainersWeight;

    public void LoadContainer(Container container)
    {
        if (_currentCapacity + 1 < maximumContainersCapacity &&
            _currentSumOfContainersWeight + container.ContainerWeight + container.CargoMass <
            maximumContainersCapacity * 1000)
        {
            _containers.Add(container);
            _currentCapacity += 1;
            _currentSumOfContainersWeight += container.ContainerWeight + container.CargoMass;
        }
        else
        {
            Console.WriteLine("There no place for your container");
        }
    }

    public void LoadContainers(List<Container> containers)
    {
        var containersWeight = containers.Sum(container => container.ContainerWeight + container.CargoMass);


        if (_currentCapacity + containers.Count < maximumContainersCapacity &&
            _currentSumOfContainersWeight + containersWeight <
            maximumContainersCapacity * 1000)
        {
            foreach (var container in containers) _containers.Add(container);
            _currentCapacity += containers.Count;
            _currentSumOfContainersWeight += containersWeight;
        }
        else
        {
            Console.WriteLine("There no place for your containers");
        }
    }

    public void RemoveContainer(Container container)
    {
        if (!_containers.Remove(container))
        {
            Console.WriteLine("There no such a container");
        }
        else
        {
            _currentCapacity -= 1;
            _currentSumOfContainersWeight -= (container.ContainerWeight + container.CargoMass);
        }
    }

    public void UnloadContainer(Container container)
    {
        if (_containers.Contains(container))
        {
            _currentSumOfContainersWeight -= container.CargoMass;
            container.CargoMass = 0;
        }
        else
        {
            Console.WriteLine("This container not in this ship");
        }
    }

    public void ReplaceTwoContainers(int indexOfContainerToBeReplaced, Container containerToPlace)
    {
        if (indexOfContainerToBeReplaced < _currentCapacity)
        {
            Container containerToReplace = _containers[indexOfContainerToBeReplaced];
            if (_currentSumOfContainersWeight - containerToReplace.ContainerWeight - containerToReplace.CargoMass +
                containerToPlace.CargoMass + containerToPlace.ContainerWeight < _maximumSumOfContainersWeight)
            {
                _currentSumOfContainersWeight -= containerToReplace.ContainerWeight - containerToReplace.CargoMass +
                                                containerToPlace.CargoMass + containerToPlace.ContainerWeight;
                _containers[indexOfContainerToBeReplaced] = containerToPlace;
            }
            else
            {
                Console.WriteLine("There no place for your container");
            }
        }
        else
        {
            Console.WriteLine("There no such an index of container to replace");
        }
    }

    public override string ToString()
    {
        var output = "Ship:" +
                     "\nMaximum speed: " + maximumSpeed +
                     "\nMaximum containers capacity: " + maximumContainersCapacity +
                     "\nCurrent capacity: " + _currentCapacity +
                     "\nMaximum weight of containers on the board: " + _maximumSumOfContainersWeight +
                     "\nCurrent weight of containers on the board: " + _currentSumOfContainersWeight+"\n[";
        output = _containers.Aggregate(output, (current, t) => current + t);
        output += "]";
        return output;
    }

    public void TransferContainers(int indexOfCurrentContainer, Ship shipToTransfer, int indexOfContainerToTake)
    {
        var currentContainer = _containers[indexOfCurrentContainer];
        var containerToTake = shipToTransfer._containers[indexOfContainerToTake];
        if (_currentSumOfContainersWeight-currentContainer.ContainerWeight-currentContainer.CargoMass+containerToTake.ContainerWeight+containerToTake.CargoMass<_maximumSumOfContainersWeight &&
            shipToTransfer._currentSumOfContainersWeight+currentContainer.ContainerWeight+currentContainer.CargoMass-containerToTake.ContainerWeight-containerToTake.CargoMass<shipToTransfer._maximumSumOfContainersWeight)
        {
            ReplaceTwoContainers(indexOfCurrentContainer, containerToTake);
            shipToTransfer.ReplaceTwoContainers(indexOfContainerToTake, currentContainer);
        }
        else
        {
            Console.WriteLine("It's not possible to transfer them.");
        }
    }
}