using JetBrains.Annotations;
using SeWzc.X11Sharp.Internal;

namespace SeWzc.X11Sharp;

/// <summary>
/// 与 X 服务器的连接。
/// </summary>
public unsafe class Display : IDisposable
{
    private readonly XDisplay* _display;

    private Display(XDisplay* display)
    {
        if (display is null)
            throw new ArgumentNullException(nameof(display));

        _display = display;
    }

    /// <summary>
    /// 连接到 X 服务器。
    /// </summary>
    /// <param name="displayName">显示器名称。如果为 <see langword="null" />，则默认为 DISPLAY 环境变量。</param>
    /// <returns></returns>
    [MustDisposeResource]
    public static Display Open(string? displayName = null)
    {
        return new Display(XLib.XOpenDisplay(displayName));
    }

    #region 运算符重载

    public static explicit operator IntPtr(Display display)
    {
        return new IntPtr(display._display);
    }

    public static explicit operator Display(IntPtr display)
    {
        return new Display((XDisplay*)display.ToPointer());
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
        _ = XLib.XCloseDisplay(_display);
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
