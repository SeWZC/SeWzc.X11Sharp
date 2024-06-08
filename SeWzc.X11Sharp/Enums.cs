namespace SeWzc.X11Sharp;

public enum WindowClasses : uint
{
    CopyFromParent = 0,
    InputOutput = 1,
    InputOnly = 2,
}

public enum Gravity : uint
{
    ForgetGravity = 0,
    NorthWestGravity = 1,
    NorthGravity = 2,
    NorthEastGravity = 3,
    WestGravity = 4,
    CenterGravity = 5,
    EastGravity = 6,
    SouthWestGravity = 7,
    SouthGravity = 8,
    SouthEastGravity = 9,
    StaticGravity = 10,
}

[Flags]
public enum WindowAttributeValueMask : ulong
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

public enum Planes
{
    CopyFromParent = 0,
    AllPlanes = 1,
}