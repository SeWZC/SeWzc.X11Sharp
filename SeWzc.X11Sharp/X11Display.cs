using JetBrains.Annotations;
using SeWzc.X11Sharp.Handles;
using SeWzc.X11Sharp.Internal;
using SeWzc.X11Sharp.Structs;

namespace SeWzc.X11Sharp;

/// <summary>
/// 与 X 服务器的连接。
/// </summary>
public sealed class X11Display : IDisposable
{
    internal readonly DisplayPtr XDisplay;

    private X11Display(DisplayPtr xDisplay)
    {
        if (xDisplay == default)
            throw new ArgumentNullException(nameof(xDisplay));

        XDisplay = xDisplay;
    }

    private static WeakReferenceValueDictionary<nint, X11Display> Cache { get; } = new();

    /// <summary>
    /// 获取连接编号。
    /// </summary>
    /// <remarks>On a POSIX-conformant system, this is the file descriptor of the connection.</remarks>
    public int ConnectionNumber => XLib.XConnectionNumber(XDisplay);

    /// <summary>
    /// 获取默认的根窗口。
    /// </summary>
    public X11DisplayWindow DefaultRootWindow => XLib.XDefaultRootWindow(XDisplay).WithDisplay(this);

    /// <summary>
    /// 获取默认屏幕。
    /// </summary>
    public X11Screen DefaultScreen => (X11Screen?)XLib.XDefaultScreenOfDisplay(XDisplay) ?? throw new InvalidOperationException("Default screen is null.");

    /// <summary>
    /// 获取默认屏幕编号。
    /// </summary>
    /// <remarks>This function should be used to retrieve the screen number in applications that will use only a single screen.</remarks>
    public int DefaultScreenNumber => XLib.XDefaultScreen(XDisplay);

    /// <summary>
    /// 获取打开连接时的 Display 名称。
    /// </summary>
    public string? DisplayString => XLib.XDisplayString(XDisplay);

    /// <summary>
    /// 获取 X 协议的版本。
    /// </summary>
    public Version ProtocolVersion => new(XLib.XProtocolVersion(XDisplay), XLib.XProtocolRevision(XDisplay));

    /// <summary>
    /// 获取可用的屏幕数量。
    /// </summary>
    public int ScreenCount => XLib.XScreenCount(XDisplay);

    /// <summary>
    /// 连接到 X 服务器。
    /// </summary>
    /// <param name="displayName">Display 名称。如果为 <see langword="null" />，则默认为 DISPLAY 环境变量。</param>
    /// <returns></returns>
    [MustDisposeResource]
    public static X11Display Open(string? displayName = null)
    {
        var display = XLib.XOpenDisplay(displayName);
        if (display == default)
            throw new InvalidOperationException("连接到 X 服务器失败。");
        return new X11Display(display);
    }

    /// <summary>
    /// 获取指定屏幕的的黑色像素。
    /// </summary>
    /// <remarks>
    /// 这里的黑色像素未必是 RGB 的黑色，只是在对应屏幕上用于表示颜色深度的一个值。
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
    /// 这里的白色像素未必是 RGB 的白色，只是在对应屏幕上用于表示颜色深度的一个值。
    /// </remarks>
    /// <param name="screenNumber">屏幕的编号。</param>
    /// <returns>指定屏幕的白色像素值。</returns>
    public Pixel GetWhitePixel(int screenNumber)
    {
        return XLib.XWhitePixel(XDisplay, screenNumber);
    }

    /// <summary>
    /// 获取指定屏幕上的默认颜色图。
    /// </summary>
    /// <param name="screenNumber">屏幕的编号。</param>
    /// <returns>指定屏幕上的默认颜色图。</returns>
    public X11Colormap GetDefaultColormap(int screenNumber)
    {
        return XLib.XDefaultColormap(XDisplay, screenNumber);
    }

    /// <summary>
    /// 获取指定屏幕上的默认深度（平面数）。
    /// </summary>
    /// <param name="screenNumber">屏幕的编号。</param>
    /// <returns>指定屏幕上的默认深度。</returns>
    public int GetDefaultDepth(int screenNumber)
    {
        return XLib.XDefaultDepth(XDisplay, screenNumber);
    }

    /// <summary>
    /// 获取指定屏幕上的所有深度。
    /// </summary>
    /// <param name="screenNumber">屏幕的编号。</param>
    /// <returns>如果 <see cref="screenNumber" /> 屏幕无效，则返回 <see langword="null" />；否则返回指定屏幕上的所有深度。</returns>
    public unsafe int[]? GetDepths(int screenNumber)
    {
        var depths = XLib.XListDepths(XDisplay, screenNumber, out var count);
        if (depths == default)
            return null;
        var result = new int[count];
        fixed (int* p = result)
            Buffer.MemoryCopy(depths, p, count * sizeof(int), count * sizeof(int));
        XLib.XFree(depths);
        return result;
    }

    /// <summary>
    /// 获取指定屏幕上的默认图形上下文。
    /// </summary>
    /// <param name="screenNumber">屏幕的编号。</param>
    /// <returns>指定屏幕上的默认图形上下文。</returns>
    public X11GC GetDefaultGC(int screenNumber)
    {
        return (X11GC?)XLib.XDefaultGC(XDisplay, screenNumber) ?? throw new InvalidOperationException("Default GC is null.");
    }

    /// <summary>
    /// 获取指定编号的屏幕。
    /// </summary>
    /// <param name="screenNumber">屏幕的编号。</param>
    /// <returns>指定编号的屏幕。</returns>
    public X11Screen? GetScreen(int screenNumber)
    {
        return XLib.XScreenOfDisplay(XDisplay, screenNumber);
    }

    /// <summary>
    /// 获取指定屏幕上的默认视觉效果。
    /// </summary>
    /// <param name="screenNumber">屏幕的编号。</param>
    /// <returns>指定屏幕上的默认视觉效果。</returns>
    public X11Visual GetDefaultVisual(int screenNumber)
    {
        return (X11Visual?)XLib.XDefaultVisual(XDisplay, screenNumber) ?? throw new InvalidOperationException("Default visual is null.");
    }

    /// <summary>
    /// 获取指定屏幕上颜色图的条目数。
    /// </summary>
    /// <param name="screenNumber">屏幕的编号。</param>
    /// <returns>指定屏幕上颜色图的条目数。</returns>
    public int GetDisplayCells(int screenNumber)
    {
        return XLib.XDisplayCells(XDisplay, screenNumber);
    }

    /// <summary>
    /// 获取指定屏幕的平面数量（默认深度？）。
    /// </summary>
    /// <param name="screenNumber">需要获取平面数量的屏幕编号。</param>
    /// <returns>返回指定屏幕的平面数量。</returns>
    public int GetDisplayPlanes(int screenNumber)
    {
        return XLib.XDisplayPlanes(XDisplay, screenNumber);
    }

    /// <summary>
    /// 获取指定屏幕的根窗口。
    /// </summary>
    /// <param name="screenNumber">屏幕的编号。</param>
    /// <returns>指定屏幕的根窗口。</returns>
    public X11DisplayWindow GetRootWindow(int screenNumber)
    {
        return XLib.XRootWindow(XDisplay, screenNumber).WithDisplay(this);
    }

    /// <summary>
    /// 设置关闭连接时的模式。
    /// </summary>
    /// <param name="mode">关闭模式。</param>
    public void SetCloseDownMode(CloseDownMode mode)
    {
        _ = XLib.XSetCloseDownMode(XDisplay, mode);
    }

    /// <summary>
    /// 创建窗口。
    /// </summary>
    /// <param name="parent">父窗口。</param>
    /// <param name="location">窗口左上角在父窗口的位置。</param>
    /// <param name="size">窗口的大小。</param>
    /// <param name="borderWidth">窗口的边框宽度。</param>
    /// <param name="depth">窗口深度。</param>
    /// <param name="windowClass">窗口的类别。</param>
    /// <param name="attributes">窗口的 Attributes。</param>
    /// <returns></returns>
    public X11DisplayWindow CreateWindow(X11Window parent, Point location, Size size, uint borderWidth, int depth,
        WindowClasses windowClass = WindowClasses.CopyFromParent, SetWindowAttributes? attributes = null)
    {
        var valueMask = attributes?.GetValueMask() ?? 0;
        var windowAttributes = attributes?.ToXSetWindowAttributes() ?? default;
        var window = XLib.XCreateWindow(XDisplay, parent,
            location.X, location.Y,
            size.Width, size.Height,
            borderWidth,
            depth,
            windowClass,
            default, // TODO 暂未实现
            valueMask,
            in windowAttributes);
        return window.WithDisplay(this);
    }

    /// <summary>
    /// 创建简单窗口。
    /// </summary>
    /// <param name="parent">父窗口。</param>
    /// <param name="location">窗口左上角在父窗口的位置。</param>
    /// <param name="size">窗口的大小。</param>
    /// <param name="borderWidth">窗口的边框宽度。</param>
    /// <param name="border">窗口的边框颜色。</param>
    /// <param name="background">窗口的背景颜色。</param>
    /// <returns></returns>
    public X11DisplayWindow CreateSimpleWindow(X11Window parent, Point location, Size size, uint borderWidth, Pixel border, Pixel background)
    {
        var window = XLib.XCreateSimpleWindow(XDisplay, parent,
            location.X, location.Y,
            size.Width, size.Height,
            borderWidth,
            border,
            background);
        return window.WithDisplay(this);
    }

    /// <summary>
    /// 获取指定名称的原子。
    /// </summary>
    /// <param name="atomName">原子名称。</param>
    /// <param name="onlyIfExists">是否仅获取已存在的原子。</param>
    /// <returns>
    /// 指定名称的原子，如果 <paramref name="onlyIfExists" /> 为 <see langword="true" /> 而且不存在指定的名称，则返回
    /// <see langword="default" />。
    /// </returns>
    public X11DisplayAtom InternAtom(string atomName, bool onlyIfExists = false)
    {
        return XLib.XInternAtom(XDisplay, atomName, onlyIfExists).WithDisplay(this);
    }

    /// <summary>
    /// 创建图形上下文。
    /// </summary>
    /// <param name="drawable">可绘制对象。</param>
    /// <param name="values">设置的值。</param>
    /// <returns>具有指定值的图形上下文。</returns>
    public X11GC? CreateGC(X11Drawable drawable, GCValues values)
    {
        var gcValues = values.ToXGCValues();
        var valueMarks = values.GetMarks();
        var gcPtr = XLib.XCreateGC(XDisplay, drawable, valueMarks, in gcValues);
        return gcPtr;
    }

    #region 运算符重载

    public static explicit operator nint(X11Display display)
    {
        return display.XDisplay.Value;
    }

    public static explicit operator X11Display?(nint ptr)
    {
        return ptr is 0 ? null : Cache.GetOrAdd(ptr, static ptr => new X11Display(new DisplayPtr(ptr)));
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
        Cache.Remove(XDisplay.Value);
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

    ~X11Display()
    {
        Close();
    }

    #endregion
}
