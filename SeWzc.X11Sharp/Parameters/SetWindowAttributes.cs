using SeWzc.X11Sharp.Internal;
using SeWzc.X11Sharp.Structs;

namespace SeWzc.X11Sharp;

/// <summary>
/// 设置窗口属性。
/// </summary>
public sealed class SetWindowAttributes
{
    /// <summary>
    /// 用作背景的像素图。
    /// </summary>
    public X11Pixmap? BackgroundPixmap { get; set; }

    /// <summary>
    /// 用作背景的像素。
    /// </summary>
    public Pixel? BackgroundPixel { get; set; }

    /// <summary>
    /// 用作边框的像素图。
    /// </summary>
    public X11Pixmap? BorderPixmap { get; set; }

    /// <summary>
    /// 用作边框的像素。
    /// </summary>
    public Pixel? BorderPixel { get; set; }

    /// <summary>
    /// 位重力。表示窗口大小改变时，窗口中的内容保持与窗口的哪个方向的对齐。
    /// </summary>
    public Gravity? BitGravity { get; set; }

    /// <summary>
    /// 窗口重力。表示当父窗口的大小改变时，窗口保持与父窗口哪个方向的对齐。
    /// </summary>
    public Gravity? WinGravity { get; set; }

    /// <summary>
    /// 窗口不可见时是否保存其内容。如果窗口不可见时没有保存其内容，则在窗口重新变为可见时，窗口内容需要重新绘制。
    /// </summary>
    public BackingStore? BackingStore { get; set; }

    /// <summary>
    /// 要保存的平面。
    /// </summary>
    public uint? BackingPlanes { get; set; }

    /// <summary>
    /// 如果窗口某些位置的内容丢失，应该用什么像素填充。
    /// </summary>
    public Pixel? BackingPixel { get; set; }

    /// <summary>
    /// 是否保存窗口下方的内容。
    /// </summary>
    public bool? SaveUnder { get; set; }

    /// <summary>
    /// 应该接收的事件掩码。
    /// </summary>
    public EventMask? EventMask { get; set; }

    /// <summary>
    /// 不应该传播的事件掩码。
    /// </summary>
    public EventMask? DoNotPropagateMask { get; set; }

    /// <summary>
    /// 覆盖重定向。
    /// </summary>
    public bool? OverrideRedirect { get; set; }

    /// <summary>
    /// 颜色映射表。
    /// </summary>
    public X11Colormap? Colormap { get; set; }

    /// <summary>
    /// 在窗口上显示的光标。
    /// </summary>
    public X11Cursor? Cursor { get; set; }

    internal WindowAttributeValueMask GetValueMask()
    {
        WindowAttributeValueMask valuemask = 0;

        valuemask |= WindowAttributeValueMask.BackPixmap;
        if (BackgroundPixmap != null)
            valuemask |= WindowAttributeValueMask.BackPixmap;
        if (BackgroundPixel != null)
            valuemask |= WindowAttributeValueMask.BackPixel;
        if (BorderPixmap != null)
            valuemask |= WindowAttributeValueMask.BorderPixmap;
        if (BorderPixel != null)
            valuemask |= WindowAttributeValueMask.BorderPixel;
        if (BitGravity != null)
            valuemask |= WindowAttributeValueMask.BitGravity;
        if (WinGravity != null)
            valuemask |= WindowAttributeValueMask.WinGravity;
        if (BackingStore != null)
            valuemask |= WindowAttributeValueMask.BackingStore;
        if (BackingPlanes != null)
            valuemask |= WindowAttributeValueMask.BackingPlanes;
        if (BackingPixel != null)
            valuemask |= WindowAttributeValueMask.BackingPixel;
        if (SaveUnder != null)
            valuemask |= WindowAttributeValueMask.SaveUnder;
        if (EventMask != null)
            valuemask |= WindowAttributeValueMask.EventMask;
        if (DoNotPropagateMask != null)
            valuemask |= WindowAttributeValueMask.DontPropagate;
        if (OverrideRedirect != null)
            valuemask |= WindowAttributeValueMask.OverrideRedirect;
        if (Colormap != null)
            valuemask |= WindowAttributeValueMask.Colormap;
        if (Cursor != null)
            valuemask |= WindowAttributeValueMask.Cursor;
        return valuemask;
    }

    internal XSetWindowAttributes ToXSetWindowAttributes()
    {
        return new XSetWindowAttributes
        {
            background_pixmap = BackgroundPixmap ?? default,
            background_pixel = BackgroundPixel ?? default,
            border_pixmap = BorderPixmap ?? default,
            border_pixel = BorderPixel ?? default,
            bit_gravity = BitGravity ?? default,
            win_gravity = WinGravity ?? default,
            backing_store = BackingStore ?? default,
            backing_planes = BackingPlanes ?? 0,
            backing_pixel = BackingPixel ?? default,
            save_under = SaveUnder ?? false,
            event_mask = EventMask ?? default,
            do_not_propagate_mask = DoNotPropagateMask ?? default,
            override_redirect = OverrideRedirect ?? false,
            colormap = Colormap ?? default,
            cursor = Cursor ?? default,
        };
    }
}
