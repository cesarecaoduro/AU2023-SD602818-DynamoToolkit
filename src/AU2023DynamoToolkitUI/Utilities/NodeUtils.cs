using Dynamo.Engine;
using Dynamo.Graph.Nodes;
using ProtoCore.Mirror;
using System.Collections.Generic;
using System.Linq;

namespace AU2023DynamoToolkitUI.Utilities
{
    public static class NodeUtils
    {
        public static T GetInputs<T> (EngineController engine, NodeModel nodeModel, int port, bool count = false)
        {
            var valuesNode = nodeModel.InPorts[port].Connectors[0].Start.Owner;
            var valuesIndex = nodeModel.InPorts[port].Connectors[0].Start.Index;
            var astId = valuesNode.GetAstIdentifierForOutputIndex(valuesIndex).Name;
            var inputMirror = engine.GetMirror(astId);

            if (inputMirror?.GetData() == null)
                return default(T);

            var data = inputMirror.GetData();
            var value = RecurseInput(data);

            return (T)value;
        }

        private static object RecurseInput(MirrorData data)
        {
            object @object;
            if (data.IsCollection)
            {
                var list = new List<object>();
                var elements = data.GetElements();
                list.AddRange(elements.Select(x => RecurseInput(x)));
                @object = list;
            }
            else
            {
                @object = data.Data;
            }

            return @object;
        }
    }
}
