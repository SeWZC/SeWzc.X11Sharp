using JetBrains.Annotations;
using SeWzc.X11Sharp.Internal;
using SeWzc.X11Sharp.Structs;

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

    /// <summary>
    /// 获取指定屏幕的的黑色像素。
    /// </summary>
    /// <remarks>
    /// 这里的黑色像素未必是 RGB 的黑色，只是在对应屏幕上用于表示黑色的一个值。
    /// </remarks>
    /// <param name="screenNumber">屏幕的编号。</param>
    /// <returns>指定屏幕的黑色像素值。</returns>
    public Pixel GetBlackPixel(int screenNumber)
    {
        return XLib.XBlackPixel(XDisplay, screenNumber);
    }

    /// <summary>
    /// 获取指定屏幕的白色像素。
    /// </summary>
    /// <remarks>
    /// 这里的白色像素未必是 RGB 的白色，只是在对应屏幕上用于表示白色的一个值。
    /// </remarks>
    /// <param name="screenNumber">屏幕的编号。</param>
    /// <returns>指定屏幕的白色像素值。</returns>
    public Pixel GetWhitePixel(int screenNumber)
    {
        return XLib.XWhitePixel(XDisplay, screenNumber);
    }

    /// <summary>
    /// 获取连接编号。
    /// </summary>
    /// <remarks>On a POSIX-conformant system, this is the file descriptor of the connection.</remarks>
    /// <returns></returns>
    public int GetConnectionNumber()
    {
        return XLib.XConnectionNumber(XDisplay);
    }

    internal ColormapHandle DefaultColormap(int screenNumber)
    {
        return XLib.XDefaultColormap(XDisplay, screenNumber);
    }

    public Window GetDefaultRootWindow()
    {
        var window = XLib.XDefaultRootWindow(XDisplay);
        return new Window(this, window);
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