namespace Garther.Exceptions.Database;

public class CreateEntityException : Exception
{
    public CreateEntityException(string message, Exception? exception = null)
        : base(message, exception) { }
}