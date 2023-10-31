using AU2023DynamoToolkitFunctions;
using AU2023DynamoToolkitUI.View;
using AU2023DynamoToolkitUI.ViewModel;
using Autodesk.DesignScript.Runtime;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Dynamo.Controls;
using Dynamo.Graph.Nodes;
using Dynamo.UI.Commands;
using Dynamo.Utilities;
using Dynamo.Wpf;
using Newtonsoft.Json;
using ProtoCore.AST.AssociativeAST;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;

namespace AU2023DynamoToolkitUI;

[NodeName("GreetingUI")]
[NodeDescription("An Example of explicit node with a custom UI.")]
[NodeCategory("AU2023.UI")]
[InPortNames("Name")]
[InPortTypes("string")]
[OutPortNames("Result")]
[OutPortTypes("string")]
[OutPortDescriptions("Say Hi to someone.")]
[IsDesignScriptCompatible]
public partial class GreetingsUIModel : NodeModel
{
    private string _name;
    public string Name
    {
        get { return _name; }
        set
        {
            _name = value;
            RaisePropertyChanged("Name");
            OnNodeModified(false);
        }
    }


    [JsonConstructor]
    public GreetingsUIModel(
        IEnumerable<PortModel> inPorts,
        IEnumerable<PortModel> outPorts
        ) : base( inPorts, outPorts )
    {    
    }

    public GreetingsUIModel()
    {
        RegisterAllPorts();
    }

    [IsVisibleInDynamoLibrary(false)]
    public override IEnumerable<AssociativeNode> BuildOutputAst(List<AssociativeNode> inputAsNodes)
    {
        if (!InPorts[0].IsConnected)
        {
            return OutPorts.Enumerate().Select(output =>
              AstFactory.BuildAssignment(GetAstIdentifierForOutputIndex(output.Index), new NullNode()));
        }

        var dataFunctionCall = AstFactory.BuildFunctionCall(
        new Func<string, string>(Strings.GreetSomeone),
        new List<AssociativeNode> { inputAsNodes[0] });

        return new[] { AstFactory.BuildAssignment(GetAstIdentifierForOutputIndex(0), dataFunctionCall) };
    }
}
