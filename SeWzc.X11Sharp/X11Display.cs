using JetBrains.Annotations;
using SeWzc.X11Sharp.Internal;
using SeWzc.X11Sharp.Structs;

namespace SeWzc.X11Sharp;

/// <summary>
/// 与 X 服务器的连接。
/// </summary>
public sealed class X11Display : IDisposable
{
    internal readonly DisplayPtr XDisplay;

    /// <summary>
    /// </summary>
    /// <param name="xDisplay"></param>
    /// <param name="isCreateByOpen">是否由 <see cref="Open(string?)" /> 创建。</param>
    /// <exception cref="ArgumentNullException"></exception>
    private X11Display(DisplayPtr xDisplay, bool isCreateByOpen = false)
    {
        if (xDisplay == default)
            throw new ArgumentNullException(nameof(xDisplay));

        XDisplay = xDisplay;
        // 如果是 Open 方法创建的，需要主动释放资源
        // 如果是通过其他方式创建的，不需要主动释放资源
        if (!isCreateByOpen)
            GC.SuppressFinalize(this);
    }

    private static WeakReferenceValueDictionary<nint, X11Display> Cache { get; } = new();

    /// <summary>
    /// 该 Display 相关的原子。
    /// </summary>
    public X11DisplayAtoms Atoms => new(this);

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
    /// 下一个请求的序列号。
    /// </summary>
    public uint NextRequest => (uint)XLib.XNextRequest(XDisplay);

    /// <summary>
    /// 获取 X 协议的版本。
    /// </summary>
    public Version ProtocolVersion => new(XLib.XProtocolVersion(XDisplay), XLib.XProtocolRevision(XDisplay));

    /// <summary>
    /// 获取可用的屏幕数量。
    /// </summary>
    public int ScreenCount => XLib.XScreenCount(XDisplay);

    /// <summary>
    /// 获取 XY 格式中每个扫描线单元或 Z 格式中每个像素值的图像的字节顺序。
    /// </summary>
    public ByteOrder ImageByteOrder => XLib.XImageByteOrder(XDisplay);

    /// <summary>
    /// 不要自动关闭连接。相当于 <see cref="GC.SuppressFinalize(object)" />。
    /// </summary>
    /// <remarks>
    /// 只有通过 <see cref="Open(string?)" /> 方法创建的 Display 不希望在 GC 时关闭连接，才需要调用这个方法。
    /// </remarks>
    public void DisableAutoClose()
    {
        GC.SuppressFinalize(this);
    }

    /// <summary>
    /// 连接到 X 服务器。通过这个方法创建的 Display，在 GC 清理时会自动关闭连接。
    /// </summary>
    /// <param name="displayName">Display 名称。如果为 <see langword="null" />，则默认为 DISPLAY 环境变量。</param>
    /// <returns></returns>
    [MustDisposeResource(true)]
    public static X11Display Open(string? displayName = null)
    {
        var display = XLib.XOpenDisplay(displayName);
        if (display == default)
            throw new InvalidOperationException("连接到 X 服务器失败。");
        return new X11Display(display, true);
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
    /// 获取指定屏幕上的默认颜色映射表。
    /// </summary>
    /// <param name="screenNumber">屏幕的编号。</param>
    /// <returns>指定屏幕上的默认颜色映射表。</returns>
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
    /// <returns>如果 <paramref name="screenNumber" /> 屏幕无效，则返回 <see langword="null" />；否则返回指定屏幕上的所有深度。</returns>
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
    /// 获取指定屏幕上颜色映射表的条目数。
    /// </summary>
    /// <param name="screenNumber">屏幕的编号。</param>
    /// <returns>指定屏幕上颜色映射表的条目数。</returns>
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
    /// 列出支持的 Z 格式图像的类型。
    /// </summary>
    /// <returns>支持的 Z 格式图像的类型数组。</returns>
    public unsafe X11PixmapFormat[] ListPixmapFormats()
    {
        var pixmapFormats = XLib.XListPixmapFormats(this, out var count);
        if (pixmapFormats == default)
            return [];

        var result = new X11PixmapFormat[count];
        for (var i = 0; i < count; i++)
            result[i] = pixmapFormats[i];

        _ = XLib.XFree(pixmapFormats);
        return result;
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
    /// 获取指定名称的原子。相比于 <see cref="InternAtom(string,bool)" />，该方法可以一次获取多个原子。
    /// </summary>
    /// <param name="atomName">原子名称。</param>
    /// <param name="onlyIfExists">是否仅获取已存在的原子。</param>
    /// <returns></returns>
    public X11DisplayAtom[] InternAtoms(string[] atomName, bool onlyIfExists = false)
    {
        var atoms = new X11Atom[atomName.Length];
        XLib.XInternAtoms(XDisplay, atomName, atomName.Length, onlyIfExists, atoms);
        var result = new X11DisplayAtom[atomName.Length];
        for (var i = 0; i < atomName.Length; i++)
            result[i] = atoms[i].WithDisplay(this);
        return result;
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

    /// <summary>
    /// 强制发送 GC 更改。
    /// </summary>
    /// <param name="gc">图形上下文。</param>
    public void FlushGC(X11GC gc)
    {
        XLib.XFlushGC(XDisplay, gc);
    }

    /// <summary>
    /// 在事件队列中查找与指定事件掩码的匹配事件，返回并删除找到的事件。
    /// 如果没有匹配的事件，则会清空输出缓冲区并阻塞直到有匹配的事件到来。
    /// </summary>
    /// <param name="eventMask">事件掩码。</param>
    /// <returns>与指定事件掩码的匹配事件。</returns>
    public X11Event MaskEvent(EventMask eventMask)
    {
        XLib.XMaskEvent(XDisplay, eventMask, out var xEvent);
        return X11Event.FromXEvent(xEvent);
    }

    /// <summary>
    /// 在事件队列中查找与指定事件掩码的匹配事件，返回并删除找到的事件。
    /// 如果没有匹配的事件，则会立即返回 <see langword="null" />，并清空输出缓冲区。
    /// </summary>
    /// <param name="eventMask">事件掩码。</param>
    /// <returns>与指定事件掩码的匹配事件，如果没有匹配的事件，则返回 <see langword="null" />。</returns>
    public X11Event? CheckMaskEvent(EventMask eventMask)
    {
        return XLib.XCheckMaskEvent(XDisplay, eventMask, out var xEvent) ? X11Event.FromXEvent(xEvent) : null;
    }

    /// <summary>
    /// 在事件队列和服务器连接中查找与指定事件类型的匹配事件，返回并删除找到的事件。
    /// 如果没有匹配的事件，则会立即返回 <see langword="null" />，并清空输出缓冲区。
    /// </summary>
    /// <param name="eventType">事件类型。</param>
    /// <returns>与指定事件类型的匹配事件，如果没有匹配的事件，则返回 <see langword="null" />。</returns>
    public X11Event? CheckTypedEvent(EventType eventType)
    {
        return XLib.XCheckTypedEvent(XDisplay, eventType, out var xEvent) ? X11Event.FromXEvent(xEvent) : null;
    }

    /// <summary>
    /// 将事件放回事件队列头部。
    /// </summary>
    /// <param name="xEvent">要放回的事件。</param>
    public void PutBackEvent(X11Event xEvent)
    {
        XLib.XPutBackEvent(XDisplay, xEvent.ToXEvent());
    }

    #region 运算符重载

    /// <summary>
    /// 强制转换为 <see cref="nint" />。
    /// </summary>
    /// <param name="display"></param>
    public static explicit operator nint(X11Display display)
    {
        return display.XDisplay.Value;
    }

    /// <summary>
    /// 将一个 <see cref="nint" /> 转换为 <see cref="X11Display" />。如果 <paramref name="ptr" /> 为 0，则返回 <see langword="null" />。
    /// </summary>
    /// <param name="ptr"></param>
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

    // 终结器不需要文档
#pragma warning disable CS1591
    ~X11Display()
    {
        Close();
    }
#pragma warning restore CS1591

    #endregion
}
