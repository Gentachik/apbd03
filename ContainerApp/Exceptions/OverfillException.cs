namespace ContainerApp.Exceptions;

public class OverfillException : Exception
{
    public OverfillException()
    {
    }

    public OverfillException(string? message) : base(message)
    {
        Console.WriteLine("This mass: " + message + " can't be stored!");
    }
}