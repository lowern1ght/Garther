namespace Garther.Shared.Extension;

public static class Type
{
    public static System.Type GetInterfaceByName(this System.Type type, string interfaceName)
    {
        return type.GetInterfaces()
            .First(t => t.Name.Contains(interfaceName));
    }
}