using SeWzc.X11Sharp.Internal;

namespace SeWzc.X11Sharp;

public sealed class SetWindowAttributes
{
    // public InternalPixmap BackgroundPixmap {get; set;}
    // public nuint BackgroundPixel {get; set;}
    // public InternalPixmap BorderPixmap {get; set;}
    // public nuint BorderPixel { get; set; }
    public Gravity? BitGravity { get; set; }
    public Gravity? WinGravity { get; set; }
    public int? BackingStore { get; set; }
    public nuint? BackingPlanes { get; set; }
    public nuint? BackingPixel { get; set; }
    public bool? SaveUnder { get; set; }
    public long? EventMask { get; set; }
    public long? DoNotPropagateMask { get; set; }

    public bool? OverrideRedirect { get; set; }
    // public InternalColormap Colormap {get; set;}
    // public InternalCursor Cursor {get; set;}

    internal WindowAttributeValueMask GetValueMask()
    {
        WindowAttributeValueMask valuemask = 0;
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
        return valuemask;
    }

    internal XSetWindowAttributes ToXSetWindowAttributes()
    {
        return new XSetWindowAttributes
        {
            background_pixmap = default,
            background_pixel = 0,
            border_pixmap = default,
            border_pixel = 0,
            bit_gravity = BitGravity ?? Gravity.ForgetGravity,
            win_gravity = WinGravity ?? Gravity.ForgetGravity,
            backing_store = BackingStore ?? 0,
            backing_planes = BackingPlanes ?? 0,
            backing_pixel = BackingPixel ?? 0,
            save_under = SaveUnder ?? false,
            event_mask = EventMask ?? 0,
            do_not_propagate_mask = DoNotPropagateMask ?? 0,
            override_redirect = OverrideRedirect ?? false,
            colormap = default,
            cursor = default,
        };
    }
}
