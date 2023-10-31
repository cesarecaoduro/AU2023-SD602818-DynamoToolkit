using Autodesk.DesignScript.Runtime;
using Microsoft.Identity.Client;

namespace AU2023DynamoToolkitExtension;

[IsVisibleInDynamoLibrary(false)]
public static class Configurations
{
    public static string PackageName => "AU2023DynamoToolkit";

    public static string ExtensionName => $"{PackageName}Extension";

    //public static AuthenticationResult AuthenticationResult;
}
