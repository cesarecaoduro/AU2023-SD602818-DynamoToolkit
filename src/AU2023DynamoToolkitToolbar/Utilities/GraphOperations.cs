using Autodesk.DesignScript.Runtime;
using System;
using System.Collections.Generic;
using System.Text;

namespace AU2023DynamoToolkitToolbar.Utilities;
public abstract class GraphOperations
{
    /// <summary>
    /// Add the standard information into the canvas. We like to say, we are templatising the file.
    /// </summary>
    public abstract void TemplatiseGraph();

    /// <summary>
    /// Creates group around selected nodes.
    /// </summary>
    public abstract void CreateGroup(GroupType groupName, byte red, byte green, byte blue);
}

public enum GroupType
{
    Information,
    Get,
    Input,
    Function,
    Output,
    WIP,
    Set,
    Debug,
    Miscellaneous,
    Python
}
