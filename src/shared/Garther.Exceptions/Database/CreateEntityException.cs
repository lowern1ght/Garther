namespace Garther.Exceptions.Database;

public class CreateEntityException : Exception
{
    public CreateEntityException(string message)
        : base(message) { }
}