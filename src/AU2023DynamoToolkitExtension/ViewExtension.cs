using Dynamo.Graph.Nodes;
using Dynamo.Graph.Workspaces;
using Dynamo.Wpf.Extensions;
using Microsoft.Identity.Client;
using System;
using System.Threading.Tasks;

namespace AU2023DynamoToolkitExtension;

internal class ViewExtension : IViewExtension
{
    public string UniqueId => "68CAF9D0-C84A-45FF-B7FA-593053E23F5D";

    public string Name => Configurations.ExtensionName;

    public void Dispose()
    {
    }

    public void Loaded(ViewLoadedParams viewLoadedParams)
    {
        viewLoadedParams.CurrentWorkspaceChanged += ViewLoadedParamsOnCurrentWorkspaceChanged;
        viewLoadedParams.CurrentWorkspaceModel.NodeAdded += ObjOnNodeAdded;

        Menu au2023 = new Menu("Debug");
        au2023.AddMenuToDynamo(viewLoadedParams);
    }

    public void Shutdown()
    {
    }

    public void Startup(ViewStartupParams viewStartupParams)
    {
    }

    private void ViewLoadedParamsOnCurrentWorkspaceChanged(IWorkspaceModel obj)
    {
        obj.NodeAdded -= ObjOnNodeAdded;
        obj.NodeAdded += ObjOnNodeAdded;
    }

    private void ObjOnNodeAdded(NodeModel obj)
    {
        string creationName = obj.CreationName;
        // Do something with the node added.
    }
}
