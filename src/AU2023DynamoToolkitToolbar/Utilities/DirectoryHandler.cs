using Autodesk.DesignScript.Runtime;
using System;
using System.Diagnostics;

namespace AU2023DynamoToolkitToolbar.Utilities;

public static class DirectoryHandler
{     
    /// <summary>
    /// Opens the documentation webpage.
    /// </summary>
    public static void Handsout(object sender, EventArgs e) => Process.Start(@"https://www.aecom.com/");        
}
