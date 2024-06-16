namespace SeWzc.X11Sharp.Internal;

[Flags]
internal enum WindowAttributeValueMask : ulong
{
    BackPixmap = 1 << 0,
    BackPixel = 1 << 1,
    BorderPixmap = 1 << 2,
    BorderPixel = 1 << 3,
    BitGravity = 1 << 4,
    WinGravity = 1 << 5,
    BackingStore = 1 << 6,
    BackingPlanes = 1 << 7,
    BackingPixel = 1 << 8,
    OverrideRedirect = 1 << 9,
    SaveUnder = 1 << 10,
    EventMask = 1 << 11,
    DontPropagate = 1 << 12,
    Colormap = 1 << 13,
    Cursor = 1 << 14,
}

[Flags]
internal enum GCAttributeValueMarks : ulong
{
    Function = 1 << 0,
    PlaneMark = 1 << 1,
    Foreground = 1 << 2,
    Background = 1 << 3,
    LineWidth = 1 << 4,
    LineStyle = 1 << 5,
    CapStyle = 1 << 6,
    JoinStyle = 1 << 7,
    FillStyle = 1 << 8,
    FillRule = 1 << 9,
    Tile = 1 << 10,
    Stipple = 1 << 11,
    TileStipXOrigin = 1 << 12,
    TileStipYOrigin = 1 << 13,
    Font = 1 << 14,
    SubwindowMode = 1 << 15,
    GraphicsExposures = 1 << 16,
    ClipXOrigin = 1 << 17,
    ClipYOrigin = 1 << 18,
    ClipMask = 1 << 19,
    DashOffset = 1 << 20,
    DashList = 1 << 21,
    ArcMode = 1 << 22,
}
