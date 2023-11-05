using Autodesk.DesignScript.Runtime;

namespace AU2023DynamoToolkitFunctions
{
    [IsVisibleInDynamoLibrary(false)]
    public class Strings
    {
        public static string GreetSomeone(string name)
        {
            return $"Hello {name}!";
        }
    }
}
