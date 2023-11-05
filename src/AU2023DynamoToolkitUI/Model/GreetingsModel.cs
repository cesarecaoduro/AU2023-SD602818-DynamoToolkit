using AU2023DynamoToolkitFunctions;
using Dynamo.Graph.Nodes;
using Newtonsoft.Json;
using ProtoCore.AST.AssociativeAST;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AU2023DynamoToolkitUI;

[NodeName("SayHello")]
[NodeDescription("An Example of explicit node with a custom UI.")]
[NodeCategory("AU2023.UI")]
[InPortNames("input")]
[InPortTypes("string")]
[OutPortNames("output")]
[OutPortTypes("string")]
[OutPortDescriptions("Say Hi to someone.")]
[IsDesignScriptCompatible]
public partial class GreetingsModel : NodeModel
{
    [JsonConstructor]
    public GreetingsModel(
        IEnumerable<PortModel> inPorts,
        IEnumerable<PortModel> outPorts
        ) : base( inPorts, outPorts )
    {
    }
   
    public GreetingsModel()
    {
        RegisterAllPorts();
    }


    public override IEnumerable<AssociativeNode> BuildOutputAst(List<AssociativeNode> inputAstNodes)
    {
        if (!InPorts[0].Connectors.Any())
        {
            return new[] { AstFactory.BuildAssignment(GetAstIdentifierForOutputIndex(0), AstFactory.BuildNullNode()) };
        }

        var functionNode =
                AstFactory.BuildFunctionCall(
                    new Func<string, string>(Strings.GreetSomeone),
                    new List<AssociativeNode> { inputAstNodes[0] });

        return new[] { AstFactory.BuildAssignment(GetAstIdentifierForOutputIndex(0), functionNode) };
    }


}
