using Autodesk.DesignScript.Runtime;
using System.Collections.Generic;

namespace AU2023DynamoToolkit;

/// <summary>
/// A set of nodes to greet people.
/// </summary>
public static class Greetings
{
    /// <summary>
    /// Say hello to someone.
    /// </summary>
    /// <param name="name">The name.</param>
    /// <returns>The message that says hello.</returns>
    [MultiReturn("output")]
    public static Dictionary<string, object> SayHello(string input)
    {
        return new Dictionary<string, object>()
        {
            {"output", $"Hello, {input} after the PR!" },
        };
    }
}
