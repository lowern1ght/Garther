namespace Garther.Exceptions.Database;

public class CreateEntityException : Exception
{
    public CreateEntityException(object entity, Exception? exception = null)
        : base($"Fail to commit new entity {entity}", exception) { }
}