using System.Diagnostics.CodeAnalysis;
using SeWzc.X11Sharp.Internal;
using SeWzc.X11Sharp.Structs;

namespace SeWzc.X11Sharp;

/// <summary>
/// Display 和 Window 的组合。
/// </summary>
public readonly record struct X11DisplayWindow
{
    /// <summary>
    /// Display 和 Window 的组合。
    /// </summary>
    /// <param name="display">与 X 服务的连接。</param>
    /// <param name="window">窗口。</param>
    public X11DisplayWindow(X11Display display, X11Window window)
    {
        Window = window;
        Display = display;
    }

    public X11Window Window { get; }

    public X11Display Display { get; }

    /// <summary>
    /// 销毁窗口。
    /// </summary>
    public void Destroy()
    {
        _ = XLib.XDestroyWindow(Display.XDisplay, Window.XWindow);
    }

    /// <summary>
    /// 销毁子窗口。
    /// </summary>
    public void DestroySubwindows()
    {
        _ = XLib.XDestroySubwindows(Display.XDisplay, Window.XWindow);
    }

    /// <summary>
    /// 映射窗口。
    /// </summary>
    public void Map()
    {
        _ = XLib.XMapWindow(Display.XDisplay, Window.XWindow);
    }

    /// <summary>
    /// 映射并提升窗口。
    /// </summary>
    public void MapRaised()
    {
        _ = XLib.XMapRaised(Display.XDisplay, Window.XWindow);
    }

    /// <summary>
    /// 映射子窗口。
    /// </summary>
    public void MapSubwindows()
    {
        _ = XLib.XMapSubwindows(Display.XDisplay, Window.XWindow);
    }

    /// <summary>
    /// 取消映射窗口。
    /// </summary>
    public void Unmap()
    {
        _ = XLib.XUnmapWindow(Display.XDisplay, Window.XWindow);
    }

    /// <summary>
    /// 取消映射子窗口。
    /// </summary>
    public void UnmapSubwindows()
    {
        _ = XLib.XUnmapSubwindows(Display.XDisplay, Window.XWindow);
    }

    /// <summary>
    /// 配置窗口。
    /// </summary>
    /// <param name="changes">窗口变化。</param>
    public unsafe void Configure(WindowChanges changes)
    {
        var windowConfigureMask = changes.GetValueMask();
        var windowChanges = changes.ToXWindowChanges();
        _ = XLib.XConfigureWindow(Display.XDisplay, Window.XWindow, windowConfigureMask, &windowChanges);
    }

    /// <summary>
    /// 移动窗口。
    /// </summary>
    /// <param name="location">窗口左上角在父窗口的位置。</param>
    public void Move(Point location)
    {
        _ = XLib.XMoveWindow(Display.XDisplay, Window.XWindow, location.X, location.Y);
    }

    /// <summary>
    /// 重置窗口大小。
    /// </summary>
    /// <param name="size">窗口的大小。</param>
    public void Resize(Size size)
    {
        _ = XLib.XResizeWindow(Display.XDisplay, Window.XWindow, size.Width, size.Height);
    }

    /// <summary>
    /// 移动和重置窗口大小。
    /// </summary>
    /// <param name="location">窗口左上角在父窗口的位置。</param>
    /// <param name="size">窗口的大小。</param>
    public void MoveResize(Point location, Size size)
    {
        _ = XLib.XMoveResizeWindow(Display.XDisplay, Window.XWindow, location.X, location.Y, size.Width, size.Height);
    }

    /// <summary>
    /// 设置窗口边框宽度。
    /// </summary>
    /// <param name="borderWidth">窗口边框宽度。</param>
    public void SetWindowBorderWidth(uint borderWidth)
    {
        _ = XLib.XSetWindowBorderWidth(Display.XDisplay, Window.XWindow, borderWidth);
    }

    /// <summary>
    /// 升起窗口到堆栈顶部。
    /// </summary>
    public void Raise()
    {
        _ = XLib.XRaiseWindow(Display.XDisplay, Window.XWindow);
    }

    /// <summary>
    /// 降低窗口到堆栈底部。
    /// </summary>
    public void Lower()
    {
        _ = XLib.XLowerWindow(Display.XDisplay, Window.XWindow);
    }

    /// <summary>
    /// 改变窗口的 Attributes。
    /// </summary>
    /// <param name="attributes">新的 Attributes。</param>
    public unsafe void ChangeAttributes(SetWindowAttributes attributes)
    {
        var windowAttributeValueMask = attributes.GetValueMask();
        var setWindowAttributes = attributes.ToXSetWindowAttributes();
        _ = XLib.XChangeWindowAttributes(Display.XDisplay, Window.XWindow, windowAttributeValueMask, &setWindowAttributes);
    }

    /// <summary>
    /// 设置窗口的背景。
    /// </summary>
    /// <param name="pixel">背景像素。</param>
    public void SetBackground(Pixel pixel)
    {
        _ = XLib.XSetWindowBackground(Display.XDisplay, Window.XWindow, pixel);
    }

    /// <summary>
    /// 设置窗口的边框。
    /// </summary>
    /// <param name="pixel">边框像素。</param>
    public void SetBorder(Pixel pixel)
    {
        _ = XLib.XSetWindowBorder(Display.XDisplay, Window.XWindow, pixel);
    }

    /// <summary>
    /// 查询窗口的根窗口、父窗口和子窗口。
    /// </summary>
    /// <param name="root">根窗口。</param>
    /// <param name="parent">父窗口。</param>
    /// <param name="children">子窗口。</param>
    /// <returns>是否查询成功。</returns>
    public unsafe bool QueryTree([NotNullWhen(true)] out X11DisplayWindow? root, [NotNullWhen(true)] out X11DisplayWindow? parent,
        out X11DisplayWindow[] children)
    {
        var success = XLib.XQueryTree(Display.XDisplay, Window.XWindow, out var rootWindow, out var parentWindow, out var childrenPtr, out var childrenCount);
        if (!success)
        {
            root = default;
            parent = default;
            children = [];
            return false;
        }

        root = new X11Window(rootWindow).WithDisplay(Display);
        parent = new X11Window(parentWindow).WithDisplay(Display);
        children = new X11DisplayWindow[childrenCount];
        for (var i = 0; i < childrenCount; i++)
            children[i] = new X11Window(childrenPtr[i]).WithDisplay(Display);

        XLib.XFree(childrenPtr);
        return true;
    }
}
