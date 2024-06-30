namespace SeWzc.X11Sharp;

// 这些枚举类型定义在 X11 中，文档需要从 X11 协议中找，不然工作量太大了。
#pragma warning disable CS1591

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
    
    /// <summary>
    /// 最低有效字节在最前面。
    /// </summary>
    LsbFirst = 0,

    /// <summary>
    /// 最高有效字节在最前面。
    /// </summary>
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

/// <summary>
/// 事件类型。
/// </summary>
public enum EventType
{
    KeyPress = 2,
    KeyRelease = 3,
    ButtonPress = 4,
    ButtonRelease = 5,
    MotionNotify = 6,
    EnterNotify = 7,
    LeaveNotify = 8,
    FocusIn = 9,
    FocusOut = 10,
    KeymapNotify = 11,
    Expose = 12,
    GraphicsExpose = 13,
    NoExpose = 14,
    VisibilityNotify = 15,
    CreateNotify = 16,
    DestroyNotify = 17,
    UnmapNotify = 18,
    MapNotify = 19,
    MapRequest = 20,
    ReparentNotify = 21,
    ConfigureNotify = 22,
    ConfigureRequest = 23,
    GravityNotify = 24,
    ResizeRequest = 25,
    CirculateNotify = 26,
    CirculateRequest = 27,
    PropertyNotify = 28,
    SelectionClear = 29,
    SelectionRequest = 30,
    SelectionNotify = 31,
    ColormapNotify = 32,
    ClientMessage = 33,
    MappingNotify = 34,
    GenericEvent = 35,
    LastEvent = 36,
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

    /// <summary>
    /// 不备份窗口内容。
    /// </summary>
    NotUseful = 0,
    /// <summary>
    /// 仅在窗口被映射时备份窗口内容。
    /// </summary>
    WhenMapped = 1,
    /// <summary>
    /// 总是备份窗口内容。
    /// </summary>
    Always = 2,
}

/// <summary>
/// 窗口映射状态。
/// </summary>
public enum MapState : int
{
    /*
       /* Used in GetWindowAttributes reply * /
       
       #define IsUnmapped 0
       #define IsUnviewable 1
       #define IsViewable 2
     */

    /// <summary>
    /// 未映射。
    /// </summary>
    IsUnmapped = 0,
    /// <summary>
    /// 已经映射，但不可见。
    /// </summary>
    IsUnviewable = 1,
    /// <summary>
    /// 映射而且可见。
    /// </summary>
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
    /// src &amp;&amp; dst
    /// </summary>
    And = 1,

    /// <summary>
    /// src &amp;&amp; !dst
    /// </summary>
    AndReverse = 2,

    /// <summary>
    /// src
    /// </summary>
    Copy = 3,

    /// <summary>
    /// !src &amp;&amp; dst
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
    /// !(src &amp;&amp; dst)
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

/// <summary>
/// 事件队列数量查询模式。
/// </summary>
public enum EventsQueuedMode
{
    /*
       #define QueuedAlready 0
       #define QueuedAfterReading 1
       #define QueuedAfterFlush 2
     */

    /// <summary>
    /// 返回队列中已经存在的事件。
    /// </summary>
    Already = 0,
    /// <summary>
    /// 如果队列中已经有事件，则返回事件数量；如果队列中没有事件，则尝试从服务器读取事件，再返回事件数量。
    /// </summary>
    AfterReading = 1,
    /// <summary>
    /// 如果队列中已经有事件，则返回事件数量；如果队列中没有事件，则先清空输出缓冲区，然后尝试从服务器读取事件，再返回事件数量。
    /// </summary>
    AfterFlush = 2,
}

public enum ErrorCode
{
    /*
       /*****************************************************************
        * ERROR CODES
        ***************************************************************** /
       
       #define Success 0 /* everything's okay * /
       #define BadRequest 1 /* bad request code * /
       #define BadValue 2 /* int parameter out of range * /
       #define BadWindow 3 /* parameter not a Window * /
       #define BadPixmap 4 /* parameter not a Pixmap * /
       #define BadAtom 5 /* parameter not an Atom * /
       #define BadCursor 6 /* parameter not a Cursor * /
       #define BadFont 7 /* parameter not a Font * /
       #define BadMatch 8 /* parameter mismatch * /
       #define BadDrawable 9 /* parameter not a Pixmap or Window * /
       #define BadAccess 10 /* depending on context:
        - key/button already grabbed
        - attempt to free an illegal
        cmap entry
        - attempt to store into a read-only
        color map entry.
        - attempt to modify the access control
        list from other than the local host.
        * /
       #define BadAlloc 11 /* insufficient resources * /
       #define BadColor 12 /* no such colormap * /
       #define BadGC 13 /* parameter not a GC * /
       #define BadIDChoice 14 /* choice not in range or already used * /
       #define BadName 15 /* font or color name doesn't exist * /
       #define BadLength 16 /* Request length incorrect * /
       #define BadImplementation 17 /* server is defective * /
       
       #define FirstExtensionError 128
       #define LastExtensionError 255
     */

    Success = 0,
    BadRequest = 1,
    BadValue = 2,
    BadWindow = 3,
    BadPixmap = 4,
    BadAtom = 5,
    BadCursor = 6,
    BadFont = 7,
    BadMatch = 8,
    BadDrawable = 9,
    BadAccess = 10,
    BadAlloc = 11,
    BadColor = 12,
    BadGC = 13,
    BadIDChoice = 14,
    BadImage = 15,
    BadLength = 16,
    BadImplementation = 17,
}