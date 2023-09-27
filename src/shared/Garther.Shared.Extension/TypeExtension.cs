namespace Garther.Shared.Extension;

public static class TypeExtension
{
    public static Type GetInterfaceByName(this Type type, string interfaceName)
    {
        return type.GetInterfaces()
            .First(t => t.Name.Contains(interfaceName));
    }
}