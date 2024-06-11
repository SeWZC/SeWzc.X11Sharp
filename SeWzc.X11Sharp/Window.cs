using SeWzc.X11Sharp.Internal;
using SeWzc.X11Sharp.Structs;

namespace SeWzc.X11Sharp;

public sealed class Window
{
    private readonly WindowHandle _window;

    internal Window(WindowHandle window)
    {
        _window = window;
    }

    private static WeakReferenceValueDictionary<nint, Window> Cache { get; } = new();

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
    public static unsafe Window Create(Display display, Window parent, Point location, Size size, uint borderWidth, int depth,
        WindowClasses windowClass = WindowClasses.CopyFromParent, SetWindowAttributes? attributes = null)
    {
        var valueMask = attributes?.GetValueMask() ?? 0;
        var windowAttributes = attributes?.ToXSetWindowAttributes() ?? default;
        var window = XLib.XCreateWindow(display.XDisplay, parent._window,
            location.X, location.Y,
            size.Width, size.Height,
            borderWidth,
            depth,
            windowClass,
            null, // TODO 暂未实现
            valueMask,
            &windowAttributes);
        return new Window(window);
    }

    /// <summary>
    /// 销毁窗口。
    /// </summary>
    /// <param name="display">与 X 服务的连接。</param>
    public void Destroy(Display display)
    {
        _ = XLib.XDestroyWindow(display.XDisplay, _window);
    }

    /// <summary>
    /// 销毁子窗口。
    /// </summary>
    /// <param name="display">与 X 服务的连接。</param>
    public void DestroySubwindows(Display display)
    {
        _ = XLib.XDestroySubwindows(display.XDisplay, _window);
    }

    /// <summary>
    /// 映射窗口。
    /// </summary>
    /// <param name="display">与 X 服务的连接。</param>
    public void Map(Display display)
    {
        _ = XLib.XMapWindow(display.XDisplay, _window);
    }

    /// <summary>
    /// 映射并提升窗口。
    /// </summary>
    /// <param name="display">与 X 服务的连接。</param>
    public void MapRaised(Display display)
    {
        _ = XLib.XMapRaised(display.XDisplay, _window);
    }

    /// <summary>
    /// 映射子窗口。
    /// </summary>
    /// <param name="display">与 X 服务的连接。</param>
    public void MapSubwindows(Display display)
    {
        _ = XLib.XMapSubwindows(display.XDisplay, _window);
    }

    /// <summary>
    /// 取消映射窗口。
    /// </summary>
    /// <param name="display">与 X 服务的连接。</param>
    public void Unmap(Display display)
    {
        _ = XLib.XUnmapWindow(display.XDisplay, _window);
    }

    /// <summary>
    /// 取消映射子窗口。
    /// </summary>
    /// <param name="display">与 X 服务的连接。</param>
    public void UnmapSubwindows(Display display)
    {
        _ = XLib.XUnmapSubwindows(display.XDisplay, _window);
    }

    /// <summary>
    /// 配置窗口。
    /// </summary>
    /// <param name="display">与 X 服务的连接。</param>
    /// <param name="changes">窗口变化。</param>
    public unsafe void Configure(Display display, WindowChanges changes)
    {
        var windowConfigureMask = changes.GetValueMask();
        var windowChanges = changes.ToXWindowChanges();
        _ = XLib.XConfigureWindow(display.XDisplay, _window, windowConfigureMask, &windowChanges);
    }

    /// <summary>
    /// 移动窗口。
    /// </summary>
    /// <param name="display">与 X 服务的连接。</param>
    /// <param name="location">窗口左上角在父窗口的位置。</param>
    public void Move(Display display, Point location)
    {
        _ = XLib.XMoveWindow(display.XDisplay, _window, location.X, location.Y);
    }

    /// <summary>
    /// 重置窗口大小。
    /// </summary>
    /// <param name="display">与 X 服务的连接。</param>
    /// <param name="size">窗口的大小。</param>
    public void Resize(Display display, Size size)
    {
        _ = XLib.XResizeWindow(display.XDisplay, _window, size.Width, size.Height);
    }

    /// <summary>
    /// 移动和重置窗口大小。
    /// </summary>
    /// <param name="display">与 X 服务的连接。</param>
    /// <param name="location">窗口左上角在父窗口的位置。</param>
    /// <param name="size">窗口的大小。</param>
    public void MoveResize(Display display, Point location, Size size)
    {
        _ = XLib.XMoveResizeWindow(display.XDisplay, _window, location.X, location.Y, size.Width, size.Height);
    }

    /// <summary>
    /// 设置窗口边框宽度。
    /// </summary>
    /// <param name="display">与 X 服务的连接。</param>
    /// <param name="borderWidth">窗口边框宽度。</param>
    public void SetWindowBorderWidth(Display display, uint borderWidth)
    {
        _ = XLib.XSetWindowBorderWidth(display.XDisplay, _window, borderWidth);
    }

    /// <summary>
    /// 升起窗口到堆栈顶部。
    /// </summary>
    /// <param name="display">与 X 服务的连接。</param>
    public void Raise(Display display)
    {
        _ = XLib.XRaiseWindow(display.XDisplay, _window);
    }

    /// <summary>
    /// 降低窗口到堆栈底部。
    /// </summary>
    /// <param name="display">与 X 服务的连接。</param>
    public void Lower(Display display)
    {
        _ = XLib.XLowerWindow(display.XDisplay, _window);
    }

    /// <summary>
    /// 改变窗口的 Attributes。
    /// </summary>
    /// <param name="display">与 X 服务的连接。</param>
    /// <param name="attributes">新的 Attributes。</param>
    public unsafe void ChangeAttributes(Display display, SetWindowAttributes attributes)
    {
        var windowAttributeValueMask = attributes.GetValueMask();
        var setWindowAttributes = attributes.ToXSetWindowAttributes();
        _ = XLib.XChangeWindowAttributes(display.XDisplay, _window, windowAttributeValueMask, &setWindowAttributes);
    }

    /// <summary>
    /// 设置窗口的背景。
    /// </summary>
    /// <param name="display">与 X 服务的连接。</param>
    /// <param name="pixel">背景像素。</param>
    public void SetBackground(Display display, Pixel pixel)
    {
        _ = XLib.XSetWindowBackground(display.XDisplay, _window, pixel);
    }

    /// <summary>
    /// 设置窗口的边框。
    /// </summary>
    /// <param name="display">与 X 服务的连接。</param>
    /// <param name="pixel">边框像素。</param>
    public void SetBorder(Display display, Pixel pixel)
    {
        _ = XLib.XSetWindowBorder(display.XDisplay, _window, pixel);
    }

    #region 运算符

    public static explicit operator nint(Window window)
    {
        return window._window.Value;
    }

    public static explicit operator Window(nint handle)
    {
        return Cache.GetOrAdd(handle, key => new Window(new WindowHandle(key)));
    }

    #endregion
}
