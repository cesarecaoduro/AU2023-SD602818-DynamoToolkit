using Autodesk.DesignScript.Runtime;
using Autodesk.Revit.DB.Architecture;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AU2023DynamoToolkitFunctions
{
    [IsVisibleInDynamoLibrary(false)]
    public static class Strings
    {
        public static string GreetSomeone(string name)
        {
            return $"Hello {name}";
        }
    }
}
