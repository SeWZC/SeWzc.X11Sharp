using SeWzc.X11Sharp.Internal;
using SeWzc.X11Sharp.Structs;

namespace SeWzc.X11Sharp;

public sealed class WindowAttributes
{
    internal WindowAttributes(XWindowAttributes windowAttributes)
    {
        X = windowAttributes.x;
        Y = windowAttributes.y;
        Width = windowAttributes.width;
        Height = windowAttributes.height;
        BorderWidth = windowAttributes.border_width;
        Depth = windowAttributes.depth;
        Visual = (X11Visual?)windowAttributes.visual ?? throw new ArgumentNullException(nameof(windowAttributes.visual));
        Root = windowAttributes.root;
        WindowClass = windowAttributes.c_class;
        BitGravity = windowAttributes.bit_gravity;
        WinGravity = windowAttributes.win_gravity;
        BackingStore = windowAttributes.backing_store;
        BackingPlanes = windowAttributes.backing_planes;
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

    public int X { get; }
    public int Y { get; }
    public int Width { get; }
    public int Height { get; }
    public int BorderWidth { get; }
    public int Depth { get; }
    public X11Visual Visual { get; }
    public X11Window Root { get; }
    public WindowClasses WindowClass { get; }
    public Gravity BitGravity { get; }
    public Gravity WinGravity { get; }
    public BackingStore BackingStore { get; }
    public nuint BackingPlanes { get; }
    public Pixel BackingPixel { get; }
    public bool SaveUnder { get; }
    public X11ColorMap Colormap { get; }
    public bool MapInstalled { get; }
    public MapState MapState { get; }
    public EventMask AllEventMasks { get; }
    public EventMask YourEventMask { get; }
    public EventMask DoNotPropagateMask { get; }
    public bool OverrideRedirect { get; }
    public X11Screen Screen { get; }
}
