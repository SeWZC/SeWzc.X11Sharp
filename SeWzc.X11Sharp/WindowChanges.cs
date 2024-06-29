using SeWzc.X11Sharp.Internal;
using SeWzc.X11Sharp.Xid;

namespace SeWzc.X11Sharp;

public sealed class WindowChanges
{
    public int? X { get; set; }
    public int? Y { get; set; }
    public int? Width { get; set; }
    public int? Height { get; set; }
    public int? BorderWidth { get; set; }
    public X11Window? Sibling { get; set; }
    public StackMode? StackMode { get; set; }

    internal WindowChangeMask GetValueMask()
    {
        WindowChangeMask valuemask = 0;

        if (X != null)
            valuemask |= WindowChangeMask.X;
        if (Y != null)
            valuemask |= WindowChangeMask.Y;
        if (Width != null)
            valuemask |= WindowChangeMask.Width;
        if (Height != null)
            valuemask |= WindowChangeMask.Height;
        if (BorderWidth != null)
            valuemask |= WindowChangeMask.BorderWidth;
        if (Sibling != null)
            valuemask |= WindowChangeMask.Sibling;
        if (StackMode != null)
            valuemask |= WindowChangeMask.StackMode;
        return valuemask;
    }

    internal XWindowChanges ToXWindowChanges()
    {
        return new XWindowChanges
        {
            x = X ?? 0,
            y = Y ?? 0,
            width = Width ?? 0,
            height = Height ?? 0,
            border_width = BorderWidth ?? 0,
            sibling = Sibling ?? default,
            stack_mode = StackMode ?? 0,
        };
    }
}
