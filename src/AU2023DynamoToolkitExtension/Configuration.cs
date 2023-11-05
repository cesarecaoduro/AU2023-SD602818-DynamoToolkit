using Autodesk.DesignScript.Runtime;

namespace AU2023DynamoToolkitExtension;

[IsVisibleInDynamoLibrary(false)]
public static class Configurations
{
    public static string PackageName => "AU2023DynamoToolkit";

    public static string ExtensionName => $"{PackageName}Extension";
}
