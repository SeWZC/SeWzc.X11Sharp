namespace SeWzc.X11Sharp;

/// <summary>
/// 字节顺序。
/// </summary>
public enum ByteOrder : int
{
    /*
       /* Byte order  used in imageByteOrder and bitmapBitOrder * /
       
       #define LSBFirst 0
       #define MSBFirst 1
     */

    LsbFirst = 0,
    MsbFirst = 1,
}

/// <summary>
/// 事件掩码。
/// </summary>
[Flags]
public enum EventMask : ulong
{
    /*
     /* Input Event Masks. Used as event-mask window attribute and as arguments
          to Grab requests.  Not to be confused with event names.  * /
       
       #define NoEventMask 0L
       #define KeyPressMask (1L<<0)
       #define KeyReleaseMask (1L<<1)
       #define ButtonPressMask (1L<<2)
       #define ButtonReleaseMask (1L<<3)
       #define EnterWindowMask (1L<<4)
       #define LeaveWindowMask (1L<<5)
       #define PointerMotionMask (1L<<6)
       #define PointerMotionHintMask (1L<<7)
       #define Button1MotionMask (1L<<8)
       #define Button2MotionMask (1L<<9)
       #define Button3MotionMask (1L<<10)
       #define Button4MotionMask (1L<<11)
       #define Button5MotionMask (1L<<12)
       #define ButtonMotionMask (1L<<13)
       #define KeymapStateMask (1L<<14)
       #define ExposureMask (1L<<15)
       #define VisibilityChangeMask (1L<<16)
       #define StructureNotifyMask (1L<<17)
       #define ResizeRedirectMask (1L<<18)
       #define SubstructureNotifyMask (1L<<19)
       #define SubstructureRedirectMask (1L<<20)
       #define FocusChangeMask (1L<<21)
       #define PropertyChangeMask (1L<<22)
       #define ColormapChangeMask (1L<<23)
       #define OwnerGrabButtonMask (1L<<24)
     */

    NoEvent = 0,
    KeyPress = 1 << 0,
    KeyRelease = 1 << 1,
    ButtonPress = 1 << 2,
    ButtonRelease = 1 << 3,
    EnterWindow = 1 << 4,
    LeaveWindow = 1 << 5,
    PointerMotion = 1 << 6,
    PointerMotionHint = 1 << 7,
    Button1Motion = 1 << 8,
    Button2Motion = 1 << 9,
    Button3Motion = 1 << 10,
    Button4Motion = 1 << 11,
    Button5Motion = 1 << 12,
    ButtonMotion = 1 << 13,
    KeymapState = 1 << 14,
    Exposure = 1 << 15,
    VisibilityChange = 1 << 16,
    StructureNotify = 1 << 17,
    ResizeRedirect = 1 << 18,
    SubstructureNotify = 1 << 19,
    SubstructureRedirect = 1 << 20,
    FocusChange = 1 << 21,
    PropertyChange = 1 << 22,
    ColormapChange = 1 << 23,
    OwnerGrabButton = 1 << 24,
}

public enum CloseDownMode : int
{
    /*
       /* Used in ChangeCloseDownMode * /
       
       #define DestroyAll 0
       #define RetainPermanent 1
       #define RetainTemporary 2
     */

    DestroyAll = 0,
    RetainPermanent = 1,
    RetainTemporary = 2,
}

[Flags]
public enum WindowChangeMask : ulong
{
    /*
       /* ConfigureWindow structure * /
       
       #define CWX (1<<0)
       #define CWY (1<<1)
       #define CWWidth (1<<2)
       #define CWHeight (1<<3)
       #define CWBorderWidth (1<<4)
       #define CWSibling (1<<5)
       #define CWStackMode (1<<6)
     */

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
    /*
       /* Window stacking method (in configureWindow) * /
       
       #define Above 0
       #define Below 1
       #define TopIf 2
       #define BottomIf 3
       #define Opposite 4
     */

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
    /*
       /* Window classes used by CreateWindow * /
       /* Note that CopyFromParent is already defined as 0 above * /
       
       #define InputOutput 1
       #define InputOnly 2
     */

    CopyFromParent = 0,
    InputOutput = 1,
    InputOnly = 2,
}

public enum Gravity : uint
{
    /*
       /* Bit Gravity * /
       
       #define ForgetGravity 0
       #define NorthWestGravity 1
       #define NorthGravity 2
       #define NorthEastGravity 3
       #define WestGravity 4
       #define CenterGravity 5
       #define EastGravity 6
       #define SouthWestGravity 7
       #define SouthGravity 8
       #define SouthEastGravity 9
       #define StaticGravity 10
     */

    Forget = 0,
    NorthWest = 1,
    North = 2,
    NorthEast = 3,
    West = 4,
    Center = 5,
    East = 6,
    SouthWest = 7,
    South = 8,
    SouthEast = 9,
    Static = 10,
}

public enum BackingStore : int
{
    /*
       /* Used in CreateWindow for backing-store hint * /
       
       #define NotUseful 0
       #define WhenMapped 1
       #define Always 2
     */

    NotUseful = 0,
    WhenMapped = 1,
    Always = 2,
}

public enum MapState : int
{
    /*
       /* Used in GetWindowAttributes reply * /
       
       #define IsUnmapped 0
       #define IsUnviewable 1
       #define IsViewable 2
     */

    IsUnmapped = 0,
    IsUnviewable = 1,
    IsViewable = 2,
}

public enum GraphicsFunctions : int
{
    /*
       /* graphics functions, as in GC.alu * /

       #define GXclear
       #define GXand
       #define GXandReverse
       #define GXcopy
       #define GXandInverted
       #define GXnoop
       #define GXxor
       #define GXor
       #define GXnor
       #define GXequiv
       #define GXinvert
       #define GXorReverse
       #define GXcopyInverted
       #define GXorInverted
       #define GXnand
       #define GXset
     */

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
    /*
       /* Property modes * /
       
       #define PropModeReplace 0
       #define PropModePrepend 1
       #define PropModeAppend 2
     */

    Replace = 0,
    Prepend = 1,
    Append = 2,
}

public enum LineStyle : int
{
    /*
       /* LineStyle * /
       
       #define LineSolid 0
       #define LineOnOffDash 1
       #define LineDoubleDash 2
     */

    Solid = 0,
    OnOffDash = 1,
    DoubleDash = 2,
}

public enum CapStyle : int
{
    /*
       /* capStyle * /
       
       #define CapNotLast 0
       #define CapButt 1
       #define CapRound 2
       #define CapProjecting 3
     */

    NotLast = 0,
    Butt = 1,
    Round = 2,
    Projecting = 3,
}

public enum JoinStyle : int
{
    /*
       /* joinStyle * /
       
       #define JoinMiter 0
       #define JoinRound 1
       #define JoinBevel 2
     */

    Miter = 0,
    Round = 1,
    Bevel = 2,
}

public enum FillStyle : int
{
    /*
       /* fillStyle * /
       
       #define FillSolid 0
       #define FillTiled 1
       #define FillStippled 2
       #define FillOpaqueStippled 3
     */

    Solid = 0,
    Tiled = 1,
    Stippled = 2,
    OpaqueStippled = 3,
}

public enum FillRule : int
{
    /*
       /* fillRule * /
       
       #define EvenOddRule 0
       #define WindingRule 1
     */

    EvenOdd = 0,
    Winding = 1,
}

public enum SubwindowMode : int
{
    /*
       /* subwindow mode * /
       
       #define ClipByChildren 0
       #define IncludeInferiors 1
     */

    ClipByChildren = 0,
    IncludeInferiors = 1,
}

public enum ArcMode : int
{
    /*
       /* Arc modes for PolyFillArc * /
       
       #define ArcChord 0 /* join endpoints of arc * /
       #define ArcPieSlice 1 /* join endpoints to center of arc * /
     */
    Chord = 0,
    PieSlice = 1,
}

public enum KeyOrButtonMask : uint
{
    /*
       /* GC components: masks used in CreateGC, CopyGC, ChangeGC, OR'ed into
        GC.stateChanges * /
       
       #define GCFunction (1L<<0)
       #define GCPlaneMask (1L<<1)
       #define GCForeground (1L<<2)
       #define GCBackground (1L<<3)
       #define GCLineWidth (1L<<4)
       #define GCLineStyle (1L<<5)
       #define GCCapStyle (1L<<6)
       #define GCJoinStyle (1L<<7)
       #define GCFillStyle (1L<<8)
       #define GCFillRule (1L<<9)
       #define GCTile (1L<<10)
       #define GCStipple (1L<<11)
       #define GCTileStipXOrigin (1L<<12)
       #define GCTileStipYOrigin (1L<<13)
       #define GCFont (1L<<14)
       #define GCSubwindowMode (1L<<15)
       #define GCGraphicsExposures (1L<<16)
       #define GCClipXOrigin (1L<<17)
       #define GCClipYOrigin (1L<<18)
       #define GCClipMask (1L<<19)
       #define GCDashOffset (1L<<20)
       #define GCDashList (1L<<21)
       #define GCArcMode (1L<<22)
     */

    ShiftMask = 1 << 0,
    LockMask = 1 << 1,
    ControlMask = 1 << 2,
    Mod1Mask = 1 << 3,
    Mod2Mask = 1 << 4,
    Mod3Mask = 1 << 5,
    Mod4Mask = 1 << 6,
    Mod5Mask = 1 << 7,
    Button1Mask = 1 << 8,
    Button2Mask = 1 << 9,
    Button3Mask = 1 << 10,
    Button4Mask = 1 << 11,
    Button5Mask = 1 << 12,
}

public enum NotifyMode
{
    /*
       /* Notify modes * /
       
       #define NotifyNormal 0
       #define NotifyGrab 1
       #define NotifyUngrab 2
       #define NotifyWhileGrabbed 3
     */

    /// <summary>
    /// 正常通知。
    /// </summary>
    NotifyNormal = 0,

    /// <summary>
    /// 激活输入设备捕获时的通知。
    /// </summary>
    NotifyGrab = 1,

    /// <summary>
    /// 释放输入设备捕获时的通知。
    /// </summary>
    NotifyUngrab = 2,

    /// <summary>
    /// 输入设备被捕获过程中的通知。
    /// </summary>
    /// <remarks>某些情况下，即使窗口 A 捕获了输入设备，窗口 B 仍会收到特定的输入事件，</remarks>
    NotifyWhileGrabbed = 3,
}

public enum NotifyDetail
{
    /*
       /* Notify detail * /
       
       #define NotifyAncestor 0
       #define NotifyVirtual 1
       #define NotifyInferior 2
       #define NotifyNonlinear 3
       #define NotifyNonlinearVirtual 4
       #define NotifyPointer 5
       #define NotifyPointerRoot 6
       #define NotifyDetailNone 7
     */

    Ancestor = 0,
    Virtual = 1,
    Inferior = 2,
    Nonlinear = 3,
    NonlinearVirtual = 4,
    Pointer = 5,
    PointerRoot = 6,
    DetailNone = 7,
}

public enum CirculationRequest
{
    /*
       /* Circulation request * /
       
       #define PlaceOnTop 0
       #define PlaceOnBottom 1
     */

    PlaceOnTop = 0,
    PlaceOnBottom = 1,
}

public enum MappingRequest
{
    /*
       #define MappingModifier 0
       #define MappingKeyboard 1
       #define MappingPointer 2
     */

    Modifier = 0,
    Keyboard = 1,
    Pointer = 2,
}

public enum VisibilityNotify
{
    /*
       /* Visibility notify * /
       
       #define VisibilityUnobscured 0
       #define VisibilityPartiallyObscured 1
       #define VisibilityFullyObscured 2
     */

    Unobscured = 0,
    PartiallyObscured = 1,
    FullyObscured = 2,
}

public enum ColorMapNotification
{
    /*
       /* Color Map notification * /
       
       #define ColormapUninstalled 0
       #define ColormapInstalled 1
     */

    Uninstalled = 0,
    Installed = 1,
}

public enum PropertyNotification
{
    /*
       /* Property notification * /
       
       #define PropertyNewValue 0
       #define PropertyDelete 1
     */

    NewValue = 0,
    Delete = 1,
}
