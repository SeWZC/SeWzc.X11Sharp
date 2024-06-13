using SeWzc.X11Sharp.Internal;
using SeWzc.X11Sharp.Structs;

namespace SeWzc.X11Sharp;

public sealed class SetWindowAttributes
{
    public X11Pixmap? BackgroundPixmap { get; set; }
    public Pixel? BackgroundPixel { get; set; }
    public X11Pixmap? BorderPixmap { get; set; }
    public Pixel? BorderPixel { get; set; }
    public Gravity? BitGravity { get; set; }
    public Gravity? WinGravity { get; set; }
    public BackingStore? BackingStore { get; set; }
    public nuint? BackingPlanes { get; set; }
    public Pixel? BackingPixel { get; set; }
    public bool? SaveUnder { get; set; }
    public EventMask? EventMask { get; set; }
    public EventMask? DoNotPropagateMask { get; set; }
    public bool? OverrideRedirect { get; set; }
    public X11Colormap? Colormap { get; set; }
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
            bit_gravity = BitGravity ?? Gravity.ForgetGravity,
            win_gravity = WinGravity ?? Gravity.ForgetGravity,
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
