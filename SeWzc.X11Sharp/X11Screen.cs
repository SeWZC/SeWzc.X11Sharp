using SeWzc.X11Sharp.Internal;
using SeWzc.X11Sharp.Structs;

namespace SeWzc.X11Sharp;

/// <summary>
/// X 服务上的屏幕。
/// </summary>
public sealed class X11Screen
{
    private X11Screen(ScreenPtr ptr)
    {
        Ptr = ptr;
    }

    private ScreenPtr Ptr { get; }

    private static WeakReferenceValueDictionary<nint, X11Screen> Cache { get; } = new();

    /// <summary>
    /// 获取黑色像素。
    /// </summary>
    /// <remarks>
    /// 这里的黑色像素未必是 RGB 的黑色，只是在对应屏幕上用于表示颜色深度的一个值。
    /// </remarks>
    public Pixel BlackPixel => XLib.XBlackPixelOfScreen(Ptr);

    /// <summary>
    /// 获取白色像素。
    /// </summary>
    /// <remarks>
    /// 这里的白色像素未必是 RGB 的白色，只是在对应屏幕上用于表示颜色深度的一个值。
    /// </remarks>
    public Pixel WhitePixel => XLib.XWhitePixelOfScreen(Ptr);

    /// <summary>
    /// 获取默认颜色映射表中颜色映射表单元格的数量。
    /// </summary>
    public int Cells => XLib.XCellsOfScreen(Ptr);

    /// <summary>
    /// 获取默认深度。
    /// </summary>
    public int DefaultDepth => XLib.XDefaultDepthOfScreen(Ptr);

    /// <summary>
    /// 获取默认图形上下文。
    /// </summary>
    public X11GC? DefaultGC => XLib.XDefaultGCOfScreen(Ptr);

    /// <summary>
    /// 获取默认视觉效果.
    /// </summary>
    public X11Visual? DefaultVisual => XLib.XDefaultVisualOfScreen(Ptr);

    /// <summary>
    /// 获取屏幕关联的与 X 服务的连接。
    /// </summary>
    public X11Display Display => (X11Display?)XLib.XDisplayOfScreen(Ptr) ?? throw new InvalidOperationException("Display is null.");

    /// <summary>
    /// 获取屏幕编号。
    /// </summary>
    public int Number => (int)XLib.XScreenNumberOfScreen(Ptr);

    /// <summary>
    /// 获取屏幕上根窗口的事件掩码。
    /// </summary>
    public EventMask EventMask => XLib.XEventMaskOfScreen(Ptr);

    /// <summary>
    /// 获取屏幕宽度。
    /// </summary>
    public int Width => XLib.XWidthOfScreen(Ptr);

    /// <summary>
    /// 获取屏幕高度。
    /// </summary>
    public int Height => XLib.XHeightOfScreen(Ptr);

    /// <summary>
    /// 获取屏幕宽度（毫米）。
    /// </summary>
    public int MillimeterWidth => XLib.XWidthMMOfScreen(Ptr);

    /// <summary>
    /// 获取屏幕高度（毫米）。
    /// </summary>
    public int MillimeterHeight => XLib.XHeightMMOfScreen(Ptr);

    /// <summary>
    /// 获取屏幕的平面数（根窗口的深度）。
    /// </summary>
    public int Planes => XLib.XPlanesOfScreen(Ptr);

    /// <summary>
    /// s
    /// 获取该屏幕的根窗口。
    /// </summary>
    public X11Window RootWindow => XLib.XRootWindowOfScreen(Ptr);

    #region 运算符重载

    // 强制转换不需要文档
#pragma warning disable CS1591

    public static explicit operator nint(X11Screen screen)
    {
        return screen.Ptr.Value;
    }

    public static explicit operator X11Screen?(nint ptr)
    {
        return ptr is 0 ? null : Cache.GetOrAdd(ptr, key => new X11Screen(new ScreenPtr(key)));
    }

#pragma warning restore CS1591

    #endregion
}
