using SeWzc.X11Sharp.Internal;
using SeWzc.X11Sharp.Structs;

namespace SeWzc.X11Sharp;

public sealed class Window : IDisposable
{
    private readonly Display _display;
    private readonly WindowHandle _window;

    internal Window(Display display, WindowHandle window)
    {
        _display = display;
        _window = window;
    }

    /// <summary>
    /// 创建窗口。
    /// </summary>
    /// <param name="display">与 X 服务器的连接。</param>
    /// <param name="parent">父窗口。</param>
    /// <param name="location">窗口左上角在父窗口的位置。</param>
    /// <param name="size">窗口的大小。</param>
    /// <param name="borderWidth">窗口的边框宽度。</param>
    /// <param name="depth">窗口深度。</param>
    /// <param name="windowClass">窗口的类别。</param>
    /// <param name="attributes">窗口的 Attributes。</param>
    /// <returns></returns>
    public static Window Create(Display display, Window parent, Point location, Size size, uint borderWidth, int depth,
        WindowClasses windowClass = WindowClasses.CopyFromParent, SetWindowAttributes? attributes = null)
    {
        unsafe
        {
            var valueMask = attributes?.GetValueMask() ?? 0;
            var windowAttributes = attributes?.ToXSetWindowAttributes() ?? default;
            var window = XLib.XCreateWindow(display.XDisplay, parent._window,
                location.X, location.Y,
                size.Width, size.Height,
                borderWidth,
                depth,
                windowClass,
                null, // 暂未实现
                valueMask,
                &windowAttributes);
            return new Window(display, window);
        }
    }

    public void Dispose()
    {
        XLib.XDestroyWindow(_display.XDisplay, _window);
    }
}
