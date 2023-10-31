using Autodesk.DesignScript.Runtime;
using System.Drawing;

namespace AU2023DynamoToolkitToolbar.Utilities;

/// <summary>
/// This class collects all the standards.
/// </summary>
public static class GraphStandards
{
    public static string GroupTitle => "AU 2023";
    public static Color ColorTemplateGroup => ColorTranslator.FromHtml("#000000");
    public static Color ColorInfoGroup => ColorTranslator.FromHtml("#CCCCCC");
    public static Color ColorSetGroup => ColorTranslator.FromHtml("#71C6A8");
    public static Color ColorGetGroup => ColorTranslator.FromHtml("#BB87C6");
    public static Color ColorInputGroup => ColorTranslator.FromHtml("#FF7BAC");
    public static Color ColorOutputGroup => ColorTranslator.FromHtml("#C1D676");
    public static Color ColorDebugGroup => ColorTranslator.FromHtml("#48B9FF");
    public static Color ColorWipGroup => ColorTranslator.FromHtml("#848484");
    public static Color ColorMiscellaneousGroup => ColorTranslator.FromHtml("#E9E9E9");
    public static Color ColorFunctionGroup => ColorTranslator.FromHtml("#FFAA45");
    public static string GraphInfo => "GRAPH INFORMATION\n__________________________________________\n\nCopyright: AECOM\n\nCompany: AECOM\n\nGraph Version: 0.0.0\n\nTested on:\nDynamo Core 2.X\n\nPackages Required:";
    public static string Description => "DESCRIPTION\n__________________________________________\n\nA short and meaningful description.";
    public static string Instructions => "INSTRUCTIONS\n__________________________________________\n\nShort and meaningful descriptions.";
    public static string Issues => "KNOWN ISSUES AND LIMITATIONS\n__________________________________________\n\nDescribe the problem.";
    public static string Ideas => "FURTHER DEVELOPMENTS AND IDEAS\n__________________________________________\n\nFuture ideas or developments.";
}
