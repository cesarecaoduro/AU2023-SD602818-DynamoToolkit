using Autodesk.DesignScript.Runtime;
using System.Windows;

namespace AU2023DynamoToolkitToolbar.Utilities;

[IsVisibleInDynamoLibrary(false)]
public static class CustomMessages
{
    public static string NoDocument =>
        "No document is open. Standards will only work with a graph open and nodes selected.";

    public static string Group(string type) =>
        $"{type} will only work with at list one node selected or group.";

    /// <summary>
    /// Generates a customized error message.
    /// </summary>
    /// <param name="message">The custom message.</param>
    public static void Error(string message)
    {
        MessageBox.Show(message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
    }

    /// <summary>
    /// Generates a customized information message.
    /// </summary>
    /// <param name="message">The custom message.</param>
    public static void Info(string message)
    {
        MessageBox.Show(message, "FYI", MessageBoxButton.OK, MessageBoxImage.Information);
    }

    /// <summary>
    /// Generates a customized warning message.
    /// </summary>
    /// <param name="message">The custom message.</param>
    public static void Warning(string message)
    {
        MessageBox.Show(message, "FYI", MessageBoxButton.OK, MessageBoxImage.Warning);
    }

    /// <summary>
    /// Generates a customized success message.
    /// </summary>
    /// <param name="message">The custom message.</param>
    public static void Success(string message)
    {
        AutoClosingMessageBox.Show(message, "Success", 3000);
    }
}
