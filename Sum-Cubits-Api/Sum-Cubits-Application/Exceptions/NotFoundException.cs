namespace Sum_Cubits_Application.Application.Exceptions;

public class NotFoundException : Exception
{
    public NotFoundException() : base("NotFound")
    {
    }

    public NotFoundException(string message) : base(message)
    {
    }
}