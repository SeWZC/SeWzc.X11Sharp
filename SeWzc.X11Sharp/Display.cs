using JetBrains.Annotations;
using SeWzc.X11Sharp.Internal;

namespace SeWzc.X11Sharp;

/// <summary>
/// 与 X 服务器的连接。
/// </summary>
public sealed class Display : IDisposable
{
    internal readonly DisplayPtr XDisplay;

    private Display(DisplayPtr xDisplay)
    {
        if (xDisplay == default)
            throw new ArgumentNullException(nameof(xDisplay));

        XDisplay = xDisplay;
    }

    /// <summary>
    /// 连接到 X 服务器。
    /// </summary>
    /// <param name="displayName">显示器名称。如果为 <see langword="null" />，则默认为 DISPLAY 环境变量。</param>
    /// <returns></returns>
    [MustDisposeResource]
    public static Display Open(string? displayName = null)
    {
        var display = XLib.XOpenDisplay(displayName);
        if (display == default)
            throw new InvalidOperationException("连接到 X 服务器失败。");
        return new Display(display);
    }

    #region 运算符重载

    public static explicit operator nint(Display display)
    {
        return display.XDisplay.Ptr;
    }

    public static explicit operator Display(nint display)
    {
        return new Display(new DisplayPtr(display));
    }

    #endregion

    #region 处置模式

    private bool _disposed;

    /// <summary>
    /// 关闭连接。和 <see cref="Dispose" /> 等价。
    /// </summary>
    private void Close()
    {
        if (_disposed)
            return;

        _disposed = true;
        _ = XLib.XCloseDisplay(XDisplay);
    }

    /// <summary>
    /// 关闭连接。和 <see cref="Close" /> 等价。
    /// </summary>
    public void Dispose()
    {
        Close();
        GC.SuppressFinalize(this);
    }

    ~Display()
    {
        Close();
    }

    #endregion
}
