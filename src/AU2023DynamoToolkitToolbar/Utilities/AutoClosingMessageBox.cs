using System;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows;

namespace AU2023DynamoToolkitToolbar.Utilities;

/// <summary>
/// Auto closing message.
/// </summary>
internal class AutoClosingMessageBox
{
    private static Timer _timeoutTimer;
    private static string _caption;
    private const int WM_CLOSE = 0x0010;

    [DllImport("user32.dll", SetLastError = true)]
    private static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

    [DllImport("user32.dll", CharSet = CharSet.Auto)]
    private static extern IntPtr SendMessage(IntPtr hWnd, uint Msg, IntPtr wParam, IntPtr lParam);

    /// <summary>
    /// Shows the message.
    /// </summary>
    /// <param name="text">The text file in the message.</param>
    /// <param name="caption">The type of message, such as success or error.</param>
    /// <param name="timeout">The duration of the message.</param>
    internal static void Show(string text, string caption, int timeout)
    {
        _caption = caption;
        _timeoutTimer = new Timer(OnTimerElapsed, null, timeout, Timeout.Infinite);
        MessageBox.Show(text, caption);
    }

    static void OnTimerElapsed(object state)
    {
        IntPtr mbWnd = FindWindow(null, _caption);
        if (mbWnd != IntPtr.Zero)
            SendMessage(mbWnd, WM_CLOSE, IntPtr.Zero, IntPtr.Zero);
        _timeoutTimer.Dispose();
    }
}
