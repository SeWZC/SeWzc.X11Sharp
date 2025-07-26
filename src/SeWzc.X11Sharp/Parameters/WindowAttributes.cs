using SeWzc.X11Sharp.Internal;
using SeWzc.X11Sharp.Structs;

namespace SeWzc.X11Sharp;

/// <summary>
/// 窗口的 Attributes。
/// </summary>
public sealed class WindowAttributes
{
    internal WindowAttributes(XWindowAttributes windowAttributes)
    {
        Bounds = new SRectangle(windowAttributes.x, windowAttributes.y, windowAttributes.width, windowAttributes.height);
        BorderWidth = windowAttributes.border_width;
        Depth = windowAttributes.depth;
        Visual = (X11Visual?)windowAttributes.visual ?? throw new ArgumentNullException(nameof(windowAttributes.visual));
        Root = windowAttributes.root;
        WindowClass = windowAttributes.c_class;
        BitGravity = windowAttributes.bit_gravity;
        WinGravity = windowAttributes.win_gravity;
        BackingStore = windowAttributes.backing_store;
        BackingPlanes = (uint)windowAttributes.backing_planes;
        BackingPixel = windowAttributes.backing_pixel;
        SaveUnder = windowAttributes.save_under;
        Colormap = windowAttributes.colormap;
        MapInstalled = windowAttributes.map_installed;
        MapState = windowAttributes.map_state;
        AllEventMasks = windowAttributes.all_event_masks;
        YourEventMask = windowAttributes.your_event_mask;
        DoNotPropagateMask = windowAttributes.do_not_propagate_mask;
        OverrideRedirect = windowAttributes.override_redirect;
        Screen = (X11Screen?)windowAttributes.screen ?? throw new ArgumentNullException(nameof(windowAttributes.screen));
    }

    /// <summary>
    /// 边界。
    /// </summary>
    public SRectangle Bounds { get; }

    /// <summary>
    /// <see cref="Bounds" /> 的左上角坐标。
    /// </summary>
    public Point Position => Bounds.Location;

    /// <summary>
    /// <see cref="Position" /> 的 X 坐标。
    /// </summary>
    public int X => Position.X;

    /// <summary>
    /// <see cref="Position" /> 的 Y 坐标。
    /// </summary>
    public int Y => Position.Y;

    /// <summary>
    /// <see cref="Bounds" /> 的大小。
    /// </summary>
    public SSize Size => Bounds.Size;

    /// <summary>
    /// <see cref="Size" /> 的宽度。
    /// </summary>
    public int Width => Size.Width;

    /// <summary>
    /// <see cref="Size" /> 的高度。
    /// </summary>
    public int Height => Size.Height;

    /// <summary>
    /// 边框宽度。
    /// </summary>
    public int BorderWidth { get; }

    /// <summary>
    /// 颜色深度。
    /// </summary>
    public int Depth { get; }

    /// <summary>
    /// 关联的 Visual。
    /// </summary>
    public X11Visual Visual { get; }

    /// <summary>
    /// 根窗口。
    /// </summary>
    public X11Window Root { get; }

    /// <summary>
    /// 窗口的类别。
    /// </summary>
    public WindowClasses WindowClass { get; }

    /// <summary>
    /// 位重力。表示窗口大小改变时，窗口中的内容保持与窗口的哪个方向的对齐。
    /// </summary>
    public Gravity BitGravity { get; }

    /// <summary>
    /// 窗口重力。表示当父窗口的大小改变时，窗口保持与父窗口哪个方向的对齐。
    /// </summary>
    public Gravity WinGravity { get; }

    /// <summary>
    /// 窗口不可见时是否保存其内容。如果窗口不可见时没有保存其内容，则在窗口重新变为可见时，窗口内容需要重新绘制。
    /// </summary>
    public BackingStore BackingStore { get; }

    /// <summary>
    /// 要保存的平面。
    /// </summary>
    public uint BackingPlanes { get; }

    /// <summary>
    /// 如果窗口某些位置的内容丢失，应该用什么像素填充。
    /// </summary>
    public Pixel BackingPixel { get; }

    /// <summary>
    /// 是否保存窗口下方的内容。
    /// </summary>
    public bool SaveUnder { get; }

    /// <summary>
    /// 颜色映射表。
    /// </summary>
    public X11Colormap Colormap { get; }

    /// <summary>
    /// 颜色映射表是否已安装。
    /// </summary>
    public bool MapInstalled { get; }

    /// <summary>
    /// Map 状态。
    /// </summary>
    public MapState MapState { get; }

    /// <summary>
    /// 所有窗口都感兴趣的事件掩码。
    /// </summary>
    public EventMask AllEventMasks { get; }

    /// <summary>
    /// 当前窗口感兴趣的事件掩码。
    /// </summary>
    public EventMask YourEventMask { get; }

    /// <summary>
    /// 不传播的事件掩码。
    /// </summary>
    public EventMask DoNotPropagateMask { get; }

    /// <summary>
    /// 覆盖重定向。
    /// </summary>
    public bool OverrideRedirect { get; }

    /// <summary>
    /// 所在的屏幕。
    /// </summary>
    public X11Screen Screen { get; }
}
