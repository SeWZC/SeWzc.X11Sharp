namespace SeWzc.X11Sharp;

public enum Planes
{
    CopyFromParent = 0,
    AllPlanes = 1,
}

/// <summary>
/// 字节顺序。
/// </summary>
public enum ByteOrder : int
{
    LSBFirst = 0,
    MSBFirst = 1,
}

/// <summary>
/// 事件掩码。
/// </summary>
public enum EventMask : ulong
{
    NoEventMask = 0,
    KeyPressMask = 1 << 0,
    KeyReleaseMask = 1 << 1,
    ButtonPressMask = 1 << 2,
    ButtonReleaseMask = 1 << 3,
    EnterWindowMask = 1 << 4,
    LeaveWindowMask = 1 << 5,
    PointerMotionMask = 1 << 6,
    PointerMotionHintMask = 1 << 7,
    Button1MotionMask = 1 << 8,
    Button2MotionMask = 1 << 9,
    Button3MotionMask = 1 << 10,
    Button4MotionMask = 1 << 11,
    Button5MotionMask = 1 << 12,
    ButtonMotionMask = 1 << 13,
    KeymapStateMask = 1 << 14,
    ExposureMask = 1 << 15,
    VisibilityChangeMask = 1 << 16,
    StructureNotifyMask = 1 << 17,
    ResizeRedirectMask = 1 << 18,
    SubstructureNotifyMask = 1 << 19,
    SubstructureRedirectMask = 1 << 20,
    FocusChangeMask = 1 << 21,
    PropertyChangeMask = 1 << 22,
    ColormapChangeMask = 1 << 23,
    OwnerGrabButtonMask = 1 << 24,
}

public enum CloseDownMode : int
{
    DestroyAll = 0,
    RetainPermanent = 1,
    RetainTemporary = 2,
}

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
