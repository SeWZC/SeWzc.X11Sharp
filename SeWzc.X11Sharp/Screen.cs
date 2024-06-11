using SeWzc.X11Sharp.Internal;
using SeWzc.X11Sharp.Structs;

namespace SeWzc.X11Sharp;

/// <summary>
/// X 服务上的屏幕。
/// </summary>
public sealed unsafe class Screen
{
    private readonly XScreen* _screen;

    internal Screen(XScreen* screen)
    {
        _screen = screen;
    }

    private static WeakReferenceValueDictionary<IntPtr, Screen> Cache { get; } = new();

    /// <summary>
    /// 获取黑色像素。
    /// </summary>
    /// <remarks>
    /// 这里的黑色像素未必是 RGB 的黑色，只是在对应屏幕上用于表示颜色深度的一个值。
    /// </remarks>
    public Pixel BlackPixel => XLib.XBlackPixelOfScreen(_screen);

    /// <summary>
    /// 获取白色像素。
    /// </summary>
    /// <remarks>
    /// 这里的白色像素未必是 RGB 的白色，只是在对应屏幕上用于表示颜色深度的一个值。
    /// </remarks>
    public Pixel WhitePixel => XLib.XWhitePixelOfScreen(_screen);

    /// <summary>
    /// 获取默认颜色图中颜色图单元格的数量。
    /// </summary>
    public int Cells => XLib.XCellsOfScreen(_screen);

    /// <summary>
    /// 获取默认深度。
    /// </summary>
    public int DefaultDepth => XLib.XDefaultDepthOfScreen(_screen);

    /// <summary>
    /// 获取默认图形上下文。
    /// </summary>
    public GraphicsContext DefaultGC => new(XLib.XDefaultGCOfScreen(_screen));

    /// <summary>
    /// 获取默认视觉效果.
    /// </summary>
    public Visual DefaultVisual => new(XLib.XDefaultVisualOfScreen(_screen));

    /// <summary>
    /// 获取屏幕关联的与 X 服务的连接。
    /// </summary>
    public Display Display => XLib.XDisplayOfScreen(_screen);

    /// <summary>
    /// 获取屏幕编号。
    /// </summary>
    public int Number => (int)XLib.XScreenNumberOfScreen(_screen);

    /// <summary>
    /// 获取屏幕上根窗口的事件掩码。
    /// </summary>
    public EventMask EventMask => XLib.XEventMaskOfScreen(_screen);

    /// <summary>
    /// 获取屏幕宽度。
    /// </summary>
    public int Width => XLib.XWidthOfScreen(_screen);

    /// <summary>
    /// 获取屏幕高度。
    /// </summary>
    public int Height => XLib.XHeightOfScreen(_screen);

    /// <summary>
    /// 获取屏幕宽度（毫米）。
    /// </summary>
    public int MillimeterWidth => XLib.XWidthMMOfScreen(_screen);

    /// <summary>
    /// 获取屏幕高度（毫米）。
    /// </summary>
    public int MillimeterHeight => XLib.XHeightMMOfScreen(_screen);

    /// <summary>
    /// 获取屏幕的平面数（根窗口的深度）。
    /// </summary>
    public int Planes => XLib.XPlanesOfScreen(_screen);

    /// <summary>
    /// 获取该屏幕的根窗口。
    /// </summary>
    public Window RootWindow => new(XLib.XRootWindowOfScreen(_screen));

    #region 运算符重载

    public static explicit operator IntPtr(Screen screen)
    {
        return (IntPtr)screen._screen;
    }

    public static explicit operator Screen(IntPtr ptr)
    {
        return Cache.GetOrAdd(ptr, static ptr => new Screen((XScreen*)ptr));
    }

    #endregion
}
