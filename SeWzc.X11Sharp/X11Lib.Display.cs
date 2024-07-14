using SeWzc.X11Sharp.Internal;
using SeWzc.X11Sharp.Structs;

namespace SeWzc.X11Sharp;

public static partial class X11Lib
{
    /// <summary>
    /// 关闭连接。
    /// </summary>
    /// <param name="display">要关闭的连接。</param>
    /// <seealso cref="X11Display.Dispose" />
    public static void CloseDisplay(X11Display display)
    {
        display.Dispose();
    }

    /// <summary>
    /// 获取连接编号。
    /// </summary>
    /// <seealso cref="X11Display.ConnectionNumber" />
    public static int ConnectionNumber(X11Display display)
    {
        return XLib.XConnectionNumber(display);
    }

    /// <summary>
    /// 获取默认的根窗口。
    /// </summary>
    /// <seealso cref="X11Display.DefaultRootWindow" />
    public static X11DisplayWindow DefaultRootWindow(X11Display display)
    {
        return XLib.XDefaultRootWindow(display).WithDisplay(display);
    }

    /// <summary>
    /// 获取默认屏幕。
    /// </summary>
    /// <seealso cref="X11Display.DefaultScreen" />
    public static X11Screen? DefaultScreen(X11Display display)
    {
        return XLib.XDefaultScreenOfDisplay(display);
    }

    /// <summary>
    /// 获取默认屏幕编号。
    /// </summary>
    /// <seealso cref="X11Display.DefaultScreenNumber" />
    public static int DefaultScreenNumber(X11Display display)
    {
        return XLib.XDefaultScreen(display);
    }

    /// <summary>
    /// 获取打开连接时的 Display 名称。
    /// </summary>
    /// <seealso cref="X11Display.DisplayString" />
    public static string? DisplayString(X11Display display)
    {
        return XLib.XDisplayString(display);
    }

    /// <summary>
    /// 下一个请求的序列号。
    /// </summary>
    /// <seealso cref="X11Display.NextRequestNumber" />
    public static uint NextRequest(X11Display display)
    {
        return (uint)XLib.XNextRequest(display);
    }

    /// <summary>
    /// 获取 X 协议的主版本。
    /// </summary>
    /// <seealso cref="X11Display.ProtocolVersion" />
    public static int ProtocolVersion(X11Display display)
    {
        return XLib.XProtocolVersion(display);
    }

    /// <summary>
    /// 获取 X 协议的次版本。
    /// </summary>
    /// <seealso cref="X11Display.ProtocolVersion" />
    public static int ProtocolRevision(X11Display display)
    {
        return XLib.XProtocolRevision(display);
    }

    /// <summary>
    /// 获取可用的屏幕数量。
    /// </summary>
    /// <seealso cref="X11Display.ScreenCount" />
    public static int ScreenCount(X11Display display)
    {
        return XLib.XScreenCount(display);
    }

    /// <summary>
    /// 获取 XY 格式中每个扫描线单元或 Z 格式中每个像素值的图像的字节顺序。
    /// </summary>
    /// <seealso cref="X11Display.ImageByteOrder" />
    public static ByteOrder ImageByteOrder(X11Display display)
    {
        return XLib.XImageByteOrder(display);
    }

    /// <summary>
    /// 获取指定编号的屏幕。
    /// </summary>
    /// <param name="display">与 X 服务的连接。</param>
    /// <param name="screenNumber">屏幕的编号。</param>
    /// <returns>指定编号的屏幕。</returns>
    /// <seealso cref="X11Display.GetScreen" />
    public static X11Screen? ScreenOfDisplay(X11Display display, int screenNumber)
    {
        return XLib.XScreenOfDisplay(display, screenNumber);
    }

    /// <summary>
    /// 获取指定屏幕的的黑色像素。
    /// </summary>
    /// <remarks>
    /// 这里的黑色像素未必是 RGB 的黑色，只是在对应屏幕上用于表示颜色深度的一个值。
    /// </remarks>
    /// <param name="display">与 X 服务的连接。</param>
    /// <param name="screenNumber">屏幕的编号。</param>
    /// <returns>指定屏幕的黑色像素值。</returns>
    /// <seealso cref="X11Screen.BlackPixel" />
    public static Pixel BlackPixel(X11Display display, int screenNumber)
    {
        return XLib.XBlackPixel(display, screenNumber);
    }

    /// <summary>
    /// 获取指定屏幕的白色像素。
    /// </summary>
    /// <remarks>
    /// 这里的白色像素未必是 RGB 的白色，只是在对应屏幕上用于表示颜色深度的一个值。
    /// </remarks>
    /// <param name="display">与 X 服务的连接。</param>
    /// <param name="screenNumber">屏幕的编号。</param>
    /// <returns>指定屏幕的白色像素值。</returns>
    /// <seealso cref="X11Screen.WhitePixel" />
    public static Pixel WhitePixel(X11Display display, int screenNumber)
    {
        return XLib.XWhitePixel(display, screenNumber);
    }

    /// <summary>
    /// 获取指定屏幕上的默认颜色映射表。
    /// </summary>
    /// <param name="display">与 X 服务的连接。</param>
    /// <param name="screenNumber">屏幕的编号。</param>
    /// <returns>指定屏幕上的默认颜色映射表。</returns>
    /// <seealso cref="X11Screen.DefaultColormap" />
    public static X11Colormap DefaultColormap(X11Display display, int screenNumber)
    {
        return XLib.XDefaultColormap(display, screenNumber);
    }

    /// <summary>
    /// 获取指定屏幕上的默认深度（平面数）。
    /// </summary>
    /// <param name="display">与 X 服务的连接。</param>
    /// <param name="screenNumber">屏幕的编号。</param>
    /// <returns>指定屏幕上的默认深度。</returns>
    /// <seealso cref="X11Screen.DefaultDepth" />
    public static int DefaultDepth(X11Display display, int screenNumber)
    {
        return XLib.XDefaultDepth(display, screenNumber);
    }

    /// <summary>
    /// 获取指定屏幕上的所有深度。
    /// </summary>
    /// <param name="display">与 X 服务的连接。</param>
    /// <param name="screenNumber">屏幕的编号。</param>
    /// <returns>如果 <paramref name="screenNumber" /> 屏幕无效，则返回 <see langword="null" />；否则返回指定屏幕上的所有深度。</returns>
    /// <seealso cref="X11Display.GetDepthsOfScreen" />
    public static unsafe int[]? ListDepths(X11Display display, int screenNumber)
    {
        var depths = XLib.XListDepths(display, screenNumber, out var count);
        if (depths == default)
            return null;

        var result = new int[count];
        fixed (int* p = result)
            Buffer.MemoryCopy(depths, p, count * sizeof(int), count * sizeof(int));

        _ = XLib.XFree(depths);
        return result;
    }

    /// <summary>
    /// 获取指定屏幕上的默认图形上下文。
    /// </summary>
    /// <param name="display">与 X 服务的连接。</param>
    /// <param name="screenNumber">屏幕的编号。</param>
    /// <returns>指定屏幕上的默认图形上下文。</returns>
    /// <seealso cref="X11Screen.DefaultGC" />
    public static X11GC DefaultGC(X11Display display, int screenNumber)
    {
        return (X11GC?)XLib.XDefaultGC(display, screenNumber) ?? throw new InvalidOperationException("Default GC is null.");
    }

    /// <summary>
    /// 获取指定屏幕上的默认视觉效果。
    /// </summary>
    /// <param name="display">与 X 服务的连接。</param>
    /// <param name="screenNumber">屏幕的编号。</param>
    /// <returns>指定屏幕上的默认视觉效果。</returns>
    /// <seealso cref="X11Screen.DefaultVisual" />
    public static X11Visual DefaultVisual(X11Display display, int screenNumber)
    {
        return (X11Visual?)XLib.XDefaultVisual(display, screenNumber) ?? throw new InvalidOperationException("Default visual is null.");
    }

    /// <summary>
    /// 获取指定屏幕上颜色映射表的条目数。
    /// </summary>
    /// <param name="display">与 X 服务的连接。</param>
    /// <param name="screenNumber">屏幕的编号。</param>
    /// <returns>指定屏幕上颜色映射表的条目数。</returns>
    /// <seealso cref="X11Screen.Cells" />
    public static int DisplayCells(X11Display display, int screenNumber)
    {
        return XLib.XDisplayCells(display, screenNumber);
    }

    /// <summary>
    /// 获取指定屏幕的平面数量。
    /// </summary>
    /// <param name="display">与 X 服务的连接。</param>
    /// <param name="screenNumber">需要获取平面数量的屏幕编号。</param>
    /// <returns>返回指定屏幕的平面数量。</returns>
    /// <seealso cref="X11Screen.DefaultDepth" />
    public static int DisplayPlane(X11Display display, int screenNumber)
    {
        return XLib.XDisplayPlanes(display, screenNumber);
    }

    /// <summary>
    /// 获取指定屏幕的根窗口。
    /// </summary>
    /// <param name="display">与 X 服务的连接。</param>
    /// <param name="screenNumber">屏幕的编号。</param>
    /// <returns>指定屏幕的根窗口。</returns>
    /// <seealso cref="X11Screen.RootWindow" />
    public static X11DisplayWindow RootWindow(X11Display display, int screenNumber)
    {
        return XLib.XRootWindow(display, screenNumber).WithDisplay(display);
    }

    /// <summary>
    /// 列出支持的 Z 格式图像的类型。
    /// </summary>
    /// <returns>支持的 Z 格式图像的类型数组。</returns>
    /// <seealso cref="X11Display.GetPixmapFormats" />
    public static unsafe X11PixmapFormat[] ListPixmapFormats(X11Display display)
    {
        var pixmapFormats = XLib.XListPixmapFormats(display, out var count);
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
    /// <param name="display">与 X 服务的连接。</param>
    /// <param name="mode">关闭模式。</param>
    public static void SetCloseDownMode(this X11Display display, CloseDownMode mode)
    {
        _ = XLib.XSetCloseDownMode(display, mode);
    }

    /// <summary>
    /// 创建窗口。
    /// </summary>
    /// <param name="display">与 X 服务的连接。</param>
    /// <param name="parent">父窗口。</param>
    /// <param name="location">窗口左上角在父窗口的位置。</param>
    /// <param name="size">窗口的大小。</param>
    /// <param name="borderWidth">窗口的边框宽度。</param>
    /// <param name="depth">窗口深度。</param>
    /// <param name="windowClass">窗口的类别。</param>
    /// <param name="visual">窗口的 Visual。如果为 null，则从父窗口继承。</param>
    /// <param name="attributes">窗口的 Attributes。如果为 null，则使用默认值。</param>
    /// <returns></returns>
    public static X11DisplayWindow CreateWindow(this X11Display display, X11Window parent, Point location,
        Size size, uint borderWidth, int depth,
        WindowClasses windowClass = WindowClasses.CopyFromParent,
        X11Visual? visual = null,
        SetWindowAttributes? attributes = null)
    {
        var valueMask = attributes?.GetValueMask() ?? 0;
        var windowAttributes = attributes?.ToXSetWindowAttributes() ?? default;
        var window = XLib.XCreateWindow(display, parent,
            location.X, location.Y,
            size.Width, size.Height,
            borderWidth,
            depth,
            windowClass,
            visual,
            valueMask,
            in windowAttributes);
        return window.WithDisplay(display);
    }

    /// <summary>
    /// 创建简单窗口。从父窗口继承属性。
    /// </summary>
    /// <param name="display">与 X 服务的连接。</param>
    /// <param name="parent">父窗口。</param>
    /// <param name="location">窗口左上角在父窗口的位置。</param>
    /// <param name="size">窗口的大小。</param>
    /// <param name="borderWidth">窗口的边框宽度。</param>
    /// <param name="border">窗口的边框颜色。</param>
    /// <param name="background">窗口的背景颜色。</param>
    /// <returns></returns>
    public static X11DisplayWindow CreateSimpleWindow(this X11Display display, X11Window parent, Point location, Size size, uint borderWidth, Pixel border,
        Pixel background)
    {
        var window = XLib.XCreateSimpleWindow(display, parent,
            location.X, location.Y,
            size.Width, size.Height,
            borderWidth,
            border,
            background);
        return window.WithDisplay(display);
    }

    /// <summary>
    /// 获取指定名称的原子。
    /// </summary>
    /// <param name="display">与 X 服务的连接。</param>
    /// <param name="atomName">原子名称。</param>
    /// <param name="onlyIfExists">是否仅获取已存在的原子。</param>
    /// <returns>
    /// 指定名称的原子，如果 <paramref name="onlyIfExists" /> 为 <see langword="true" /> 而且不存在指定的名称，则返回
    /// <see langword="default" />。
    /// </returns>
    public static X11DisplayAtom InternAtom(this X11Display display, string atomName, bool onlyIfExists = false)
    {
        return XLib.XInternAtom(display, atomName, onlyIfExists).WithDisplay(display);
    }

    /// <summary>
    /// 获取指定名称的原子。相比于 <see cref="InternAtom" />，该方法可以一次获取多个原子。
    /// </summary>
    /// <param name="display">与 X 服务的连接。</param>
    /// <param name="atomName">原子名称。</param>
    /// <param name="onlyIfExists">是否仅获取已存在的原子。</param>
    /// <returns></returns>
    public static X11DisplayAtom[] InternAtoms(this X11Display display, string[] atomName, bool onlyIfExists = false)
    {
        var atoms = new X11Atom[atomName.Length];
        XLib.XInternAtoms(display, atomName, atomName.Length, onlyIfExists, atoms);
        var result = new X11DisplayAtom[atomName.Length];
        for (var i = 0; i < atomName.Length; i++)
            result[i] = atoms[i].WithDisplay(display);
        return result;
    }

    /// <summary>
    /// 创建一个像素图。
    /// </summary>
    /// <param name="display">与 X 服务的连接。</param>
    /// <param name="drawable">可绘制对象。用于指示在哪个屏幕上创建像素图。</param>
    /// <param name="size">像素图大小。</param>
    /// <param name="depth">像素图深度。</param>
    /// <returns></returns>
    public static X11DisplayPixmap CreatePixmap(this X11Display display, X11Drawable drawable, Size size, uint depth)
    {
        return XLib.XCreatePixmap(display, drawable, size.Width, size.Height, depth).WithDisplay(display);
    }

    /// <summary>
    /// 从标准光标字体创建光标。
    /// </summary>
    /// <param name="display">与 X 服务的连接。</param>
    /// <param name="cursor">标准光标字体。</param>
    /// <returns></returns>
    public static X11DisplayCursor CreateFontCursor(this X11Display display, CursorShape cursor)
    {
        return XLib.XCreateFontCursor(display, cursor).WithDisplay(display);
    }

    /// <summary>
    /// 从像素图创建光标。
    /// </summary>
    /// <param name="display">与 X 服务的连接。</param>
    /// <param name="source">源像素图。</param>
    /// <param name="mask">掩码像素图。</param>
    /// <param name="foreground">前景色。</param>
    /// <param name="background">背景色。</param>
    /// <param name="x">指定指针在像素图的 x 坐标。</param>
    /// <param name="y">指定指针在像素图的 y 坐标。</param>
    /// <returns></returns>
    public static X11DisplayCursor CreatePixmapCursor(this X11Display display, X11Pixmap source, X11Pixmap mask, XColor foreground, XColor background,
        uint x, uint y)
    {
        return XLib.XCreatePixmapCursor(display, source, mask, foreground, background, x, y).WithDisplay(display);
    }

    /// <summary>
    /// 查询最佳光标大小。
    /// </summary>
    /// <param name="display">与 X 服务的连接。</param>
    /// <param name="drawable">可绘制对象。</param>
    /// <param name="size">希望的大小。</param>
    /// <returns></returns>
    public static Size? QueryBestCursor(this X11Display display, X11Drawable drawable, Size size)
    {
        return XLib.XQueryBestCursor(display, drawable, size.Width, size.Height, out var bw, out var bh)
            ? new Size(bw, bh)
            : null;
    }

    /// <summary>
    /// 创建图形上下文。
    /// </summary>
    /// <param name="display">与 X 服务的连接。</param>
    /// <param name="drawable">可绘制对象。</param>
    /// <param name="values">设置的值。</param>
    /// <returns>具有指定值的图形上下文。</returns>
    public static X11GC? CreateGC(this X11Display display, X11Drawable drawable, GCValues values)
    {
        var gcValues = values.ToXGCValues();
        var valueMarks = values.GetMarks();
        return XLib.XCreateGC(display, drawable, valueMarks, in gcValues);
    }

    /// <summary>
    /// 清空输出缓冲区。
    /// </summary>
    /// <param name="display">与 X 服务的连接。</param>
    public static void Flush(this X11Display display)
    {
        _ = XLib.XFlush(display);
    }

    /// <summary>
    /// 清空输出缓冲区并同步。
    /// </summary>
    /// <param name="display">与 X 服务的连接。</param>
    /// <param name="discard">是否丢弃事件队列上的所有事件。</param>
    public static void Sync(this X11Display display, bool discard)
    {
        _ = XLib.XSync(display, discard);
    }

    /// <summary>
    /// 检查事件队列中的事件。
    /// </summary>
    /// <param name="display">与 X 服务的连接。</param>
    /// <param name="mode">检查事件的模式。</param>
    /// <returns>根据模式获取到的队列中的事件数。</returns>
    /// <seealso cref="EventsQueuedMode" />
    public static int EventsQueued(this X11Display display, EventsQueuedMode mode)
    {
        return XLib.XEventsQueued(display, mode);
    }

    /// <summary>
    /// 返回待处理事件的数量。
    /// </summary>
    /// <remarks>
    /// 相当于 <see cref="EventsQueued" /> 的 <see cref="EventsQueuedMode.AfterFlush" /> 模式。
    /// </remarks>
    /// <param name="display">与 X 服务的连接。</param>
    /// <returns>待处理事件的数量</returns>
    public static int Pending(this X11Display display)
    {
        return XLib.XPending(display);
    }

    /// <summary>
    /// 返回队列中事件的数量。
    /// </summary>
    /// <remarks>
    /// 相当于 <see cref="EventsQueued" /> 的 <see cref="EventsQueuedMode.Already" /> 模式。
    /// </remarks>
    /// <param name="display">与 X 服务的连接。</param>
    /// <returns></returns>
    public static int QLength(this X11Display display)
    {
        return XLib.XQLength(display);
    }

    /// <summary>
    /// 获取下一个事件并将其从队列中删除。
    /// </summary>
    /// <remarks>
    /// 如果队列中没有事件，则会清空输出缓冲区并阻塞直到有事件到来。
    /// </remarks>
    /// <param name="display">与 X 服务的连接。</param>
    /// <returns>获取到的事件。</returns>
    public static X11Event NextEvent(this X11Display display)
    {
        XLib.XNextEvent(display, out var xEvent);
        return X11Event.FromXEvent(xEvent);
    }

    /// <summary>
    /// 获取下一个事件但不将其从队列中删除。
    /// </summary>
    /// <remarks>
    /// 如果队列中没有事件，则会清空输出缓冲区并阻塞直到有事件到来。
    /// </remarks>
    /// <param name="display">与 X 服务的连接。</param>
    /// <returns>获取到的事件。</returns>
    public static X11Event PeekEvent(this X11Display display)
    {
        XLib.XPeekEvent(display, out var xEvent);
        return X11Event.FromXEvent(xEvent);
    }

    /// <summary>
    /// 在事件队列中查找与指定事件掩码的匹配事件，返回并删除找到的事件。
    /// 如果没有匹配的事件，则会清空输出缓冲区并阻塞直到有匹配的事件到来。
    /// </summary>
    /// <param name="display">与 X 服务的连接。</param>
    /// <param name="eventMask">事件掩码。</param>
    /// <returns>与指定事件掩码的匹配事件。</returns>
    public static X11Event MaskEvent(this X11Display display, EventMask eventMask)
    {
        XLib.XMaskEvent(display, eventMask, out var xEvent);
        return X11Event.FromXEvent(xEvent);
    }

    /// <summary>
    /// 在事件队列中查找与指定事件掩码的匹配事件，返回并删除找到的事件。
    /// 如果没有匹配的事件，则会立即返回 <see langword="null" />，并清空输出缓冲区。
    /// </summary>
    /// <param name="display">与 X 服务的连接。</param>
    /// <param name="eventMask">事件掩码。</param>
    /// <returns>与指定事件掩码的匹配事件，如果没有匹配的事件，则返回 <see langword="null" />。</returns>
    public static X11Event? CheckMaskEvent(this X11Display display, EventMask eventMask)
    {
        return XLib.XCheckMaskEvent(display, eventMask, out var xEvent) ? X11Event.FromXEvent(xEvent) : null;
    }

    /// <summary>
    /// 在事件队列和服务器连接中查找与指定事件类型的匹配事件，返回并删除找到的事件。
    /// 如果没有匹配的事件，则会立即返回 <see langword="null" />，并清空输出缓冲区。
    /// </summary>
    /// <param name="display">与 X 服务的连接。</param>
    /// <param name="eventType">事件类型。</param>
    /// <returns>与指定事件类型的匹配事件，如果没有匹配的事件，则返回 <see langword="null" />。</returns>
    public static X11Event? CheckTypedEvent(this X11Display display, EventType eventType)
    {
        return XLib.XCheckTypedEvent(display, eventType, out var xEvent) ? X11Event.FromXEvent(xEvent) : null;
    }

    /// <summary>
    /// 将事件放回事件队列头部。
    /// </summary>
    /// <param name="display">与 X 服务的连接。</param>
    /// <param name="xEvent">要放回的事件。</param>
    public static void PutBackEvent(this X11Display display, X11Event xEvent)
    {
        XLib.XPutBackEvent(display, xEvent.ToXEvent());
    }
}
