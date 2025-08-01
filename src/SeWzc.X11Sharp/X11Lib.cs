using JetBrains.Annotations;
using SeWzc.X11Sharp.Internal;

namespace SeWzc.X11Sharp;

/// <summary>
/// xlib 的实现。
/// </summary>
public static partial class X11Lib
{
    /// <summary>
    /// 连接到 X 服务器。通过这个方法创建的 Display，在 GC 清理时会自动关闭连接。
    /// </summary>
    /// <param name="displayName">Display 名称。如果为 <see langword="null" />，则默认为 DISPLAY 环境变量。</param>
    /// <returns></returns>
    [MustDisposeResource(true)]
    public static X11Display OpenDisplay(string? displayName = null)
    {
        var display = XLib.XOpenDisplay(displayName);
        if (display == default)
            throw new InvalidOperationException("连接到 X 服务器失败。");
        return new X11Display(display, true);
    }

    /// <summary>
    /// 设置错误处理函数。
    /// </summary>
    /// <param name="errorHandler">错误处理函数。</param>
    /// <remarks>
    /// 这里设置的错误处理函数会覆盖默认的错误处理函数。因为 C# 无法直接获取 C 的函数，所以这里不返回上一个错误处理函数。
    /// </remarks>
    public static unsafe void SetErrorHandler(Func<X11Display?, X11Event.ErrorEvent, int> errorHandler)
    {
        _errorHandler = errorHandler;
        XLib.XSetErrorHandler(&ErrorHandler);
    }

    private static Func<X11Display?, X11Event.ErrorEvent, int> _errorHandler = static (_, _) => 0;

    private static unsafe int ErrorHandler(DisplayPtr displayPtr, XErrorEvent* xEvent)
    {
        return _errorHandler.Invoke(displayPtr, X11Event.ErrorEvent.FromXEventCore(*xEvent));
    }
}
