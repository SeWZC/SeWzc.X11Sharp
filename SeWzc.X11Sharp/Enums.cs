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
    LsbFirst = 0,
    MsbFirst = 1,
}

/// <summary>
/// 事件掩码。
/// </summary>
[Flags]
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

[Flags]
public enum WindowChangeMask : ulong
{
    X = 1 << 0,
    Y = 1 << 1,
    Width = 1 << 2,
    Height = 1 << 3,
    BorderWidth = 1 << 4,
    Sibling = 1 << 5,
    StackMode = 1 << 6,
}

public enum StackMode
{
    Above = 0,
    Below = 1,
    TopIf = 2,
    BottomIf = 3,
    Opposite = 4,
}

public enum CirculationDirection
{
    RaiseLowest = 0,
    LowerHighest = 1,
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

public enum BackingStore : int
{
    NotUseful = 0,
    WhenMapped = 1,
    Always = 2,
}

public enum MapState : int
{
    IsUnmapped = 0,
    IsUnviewable = 1,
    IsViewable = 2,
}

public enum GraphicsFunctions : int
{
    /// <summary>
    /// 0
    /// </summary>
    Clear = 0,

    /// <summary>
    /// src && dst
    /// </summary>
    And = 1,

    /// <summary>
    /// src && !dst
    /// </summary>
    AndReverse = 2,

    /// <summary>
    /// src
    /// </summary>
    Copy = 3,

    /// <summary>
    /// !src && dst
    /// </summary>
    AndInverted = 4,

    /// <summary>
    /// dst
    /// </summary>
    Noop = 5,

    /// <summary>
    /// src ^ dst
    /// </summary>
    Xor = 6,

    /// <summary>
    /// src || dst
    /// </summary>
    Or = 7,

    /// <summary>
    /// !(src || dst)
    /// </summary>
    Nor = 8,

    /// <summary>
    /// !(src ^ dst)
    /// </summary>
    Equiv = 9,

    /// <summary>
    /// !dst
    /// </summary>
    Invert = 10,

    /// <summary>
    /// src || !dst
    /// </summary>
    OrReverse = 11,

    /// <summary>
    /// !src
    /// </summary>
    CopyInverted = 12,

    /// <summary>
    /// !src || dst
    /// </summary>
    OrInverted = 13,

    /// <summary>
    /// !(src && dst)
    /// </summary>
    Nand = 14,

    /// <summary>
    /// 1
    /// </summary>
    Set = 15,
}

public enum PropertyMode : int
{
    Replace = 0,
    Prepend = 1,
    Append = 2,
}

public enum LineStyle : int
{
    Solid = 0,
    OnOffDash = 1,
    DoubleDash = 2,
}

public enum CapStyle : int
{
    NotLast = 0,
    Butt = 1,
    Round = 2,
    Projecting = 3,
}

public enum JoinStyle : int
{
    Miter = 0,
    Round = 1,
    Bevel = 2,
}

public enum FillStyle : int
{
    Solid = 0,
    Tiled = 1,
    Stippled = 2,
    OpaqueStippled = 3,
}

public enum FillRule : int
{
    EvenOdd = 0,
    Winding = 1,
}

public enum SubwindowMode : int
{
    ClipByChildren = 0,
    IncludeInferiors = 1,
}

public enum ArcMode : int
{
    Chord = 0,
    PieSlice = 1,
}
