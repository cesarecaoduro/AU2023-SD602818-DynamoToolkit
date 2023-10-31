using AU2023DynamoToolkitToolbar.Utilities;
using Dynamo.Wpf.Extensions;

namespace AU2023DynamoToolkitToolbar.Model;

public class ToolbarModel
{
    public GraphOperations ToolbarGraphOperations { get; }
    public ToolbarModel(object loader)
    {
        if (loader is ViewLoadedParams @params)
        {
            ToolbarGraphOperations = new DynGraphOperations(@params);
        }
    }
}
