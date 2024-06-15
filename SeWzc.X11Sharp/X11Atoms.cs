using SeWzc.X11Sharp.Handles;

namespace SeWzc.X11Sharp;

/// <summary>
/// Xatom.h 中定义的原子。
/// </summary>
public static class X11Atoms
{
    /// <summary>
    /// PRIMARY
    /// </summary>
    public static X11Atom Primary { get; } = new(1);

    /// <summary>
    /// SECONDARY
    /// </summary>
    public static X11Atom Secondary { get; } = new(2);

    /// <summary>
    /// ARC
    /// </summary>
    public static X11Atom Arc { get; } = new(3);

    /// <summary>
    /// ATOM
    /// </summary>
    public static X11Atom Atom { get; } = new(4);

    /// <summary>
    /// BITMAP
    /// </summary>
    public static X11Atom Bitmap { get; } = new(5);

    /// <summary>
    /// CARDINAL
    /// </summary>
    public static X11Atom Cardinal { get; } = new(6);

    /// <summary>
    /// COLORMAP
    /// </summary>
    public static X11Atom Colormap { get; } = new(7);

    /// <summary>
    /// CURSOR
    /// </summary>
    public static X11Atom Cursor { get; } = new(8);

    /// <summary>
    /// CUT_BUFFER0
    /// </summary>
    public static X11Atom CutBuffer0 { get; } = new(9);

    /// <summary>
    /// CUT_BUFFER1
    /// </summary>
    public static X11Atom CutBuffer1 { get; } = new(10);

    /// <summary>
    /// CUT_BUFFER2
    /// </summary>
    public static X11Atom CutBuffer2 { get; } = new(11);

    /// <summary>
    /// CUT_BUFFER3
    /// </summary>
    public static X11Atom CutBuffer3 { get; } = new(12);

    /// <summary>
    /// CUT_BUFFER4
    /// </summary>
    public static X11Atom CutBuffer4 { get; } = new(13);

    /// <summary>
    /// CUT_BUFFER5
    /// </summary>
    public static X11Atom CutBuffer5 { get; } = new(14);

    /// <summary>
    /// CUT_BUFFER6
    /// </summary>
    public static X11Atom CutBuffer6 { get; } = new(15);

    /// <summary>
    /// CUT_BUFFER7
    /// </summary>
    public static X11Atom CutBuffer7 { get; } = new(16);

    /// <summary>
    /// DRAWABLE
    /// </summary>
    public static X11Atom Drawable { get; } = new(17);

    /// <summary>
    /// FONT
    /// </summary>
    public static X11Atom Font { get; } = new(18);

    /// <summary>
    /// INTEGER
    /// </summary>
    public static X11Atom Integer { get; } = new(19);

    /// <summary>
    /// PIXMAP
    /// </summary>
    public static X11Atom Pixmap { get; } = new(20);

    /// <summary>
    /// POINT
    /// </summary>
    public static X11Atom Point { get; } = new(21);

    /// <summary>
    /// RECTANGLE
    /// </summary>
    public static X11Atom Rectangle { get; } = new(22);

    /// <summary>
    /// RESOURCE_MANAGER
    /// </summary>
    public static X11Atom ResourceManager { get; } = new(23);

    /// <summary>
    /// RGB_COLOR_MAP
    /// </summary>
    public static X11Atom RgbColorMap { get; } = new(24);

    /// <summary>
    /// RGB_BEST_MAP
    /// </summary>
    public static X11Atom RgbBestMap { get; } = new(25);

    /// <summary>
    /// RGB_BLUE_MAP
    /// </summary>
    public static X11Atom RgbBlueMap { get; } = new(26);

    /// <summary>
    /// RGB_DEFAULT_MAP
    /// </summary>
    public static X11Atom RgbDefaultMap { get; } = new(27);

    /// <summary>
    /// RGB_GRAY_MAP
    /// </summary>
    public static X11Atom RgbGrayMap { get; } = new(28);

    /// <summary>
    /// RGB_GREEN_MAP
    /// </summary>
    public static X11Atom RgbGreenMap { get; } = new(29);

    /// <summary>
    /// RGB_RED_MAP
    /// </summary>
    public static X11Atom RgbRedMap { get; } = new(30);

    /// <summary>
    /// STRING
    /// </summary>
    public static X11Atom String { get; } = new(31);

    /// <summary>
    /// VISUALID
    /// </summary>
    public static X11Atom Visualid { get; } = new(32);

    /// <summary>
    /// WINDOW
    /// </summary>
    public static X11Atom Window { get; } = new(33);

    /// <summary>
    /// WM_COMMAND
    /// </summary>
    public static X11Atom WmCommand { get; } = new(34);

    /// <summary>
    /// WM_HINTS
    /// </summary>
    public static X11Atom WmHints { get; } = new(35);

    /// <summary>
    /// WM_CLIENT_MACHINE
    /// </summary>
    public static X11Atom WmClientMachine { get; } = new(36);

    /// <summary>
    /// WM_ICON_NAME
    /// </summary>
    public static X11Atom WmIconName { get; } = new(37);

    /// <summary>
    /// WM_ICON_SIZE
    /// </summary>
    public static X11Atom WmIconSize { get; } = new(38);

    /// <summary>
    /// WM_NAME
    /// </summary>
    public static X11Atom WmName { get; } = new(39);

    /// <summary>
    /// WM_NORMAL_HINTS
    /// </summary>
    public static X11Atom WmNormalHints { get; } = new(40);

    /// <summary>
    /// WM_SIZE_HINTS
    /// </summary>
    public static X11Atom WmSizeHints { get; } = new(41);

    /// <summary>
    /// WM_ZOOM_HINTS
    /// </summary>
    public static X11Atom WmZoomHints { get; } = new(42);

    /// <summary>
    /// MIN_SPACE
    /// </summary>
    public static X11Atom MinSpace { get; } = new(43);

    /// <summary>
    /// NORM_SPACE
    /// </summary>
    public static X11Atom NormSpace { get; } = new(44);

    /// <summary>
    /// MAX_SPACE
    /// </summary>
    public static X11Atom MaxSpace { get; } = new(45);

    /// <summary>
    /// END_SPACE
    /// </summary>
    public static X11Atom EndSpace { get; } = new(46);

    /// <summary>
    /// SUPERSCRIPT_X
    /// </summary>
    public static X11Atom SuperscriptX { get; } = new(47);

    /// <summary>
    /// SUPERSCRIPT_Y
    /// </summary>
    public static X11Atom SuperscriptY { get; } = new(48);

    /// <summary>
    /// SUBSCRIPT_X
    /// </summary>
    public static X11Atom SubscriptX { get; } = new(49);

    /// <summary>
    /// SUBSCRIPT_Y
    /// </summary>
    public static X11Atom SubscriptY { get; } = new(50);

    /// <summary>
    /// UNDERLINE_POSITION
    /// </summary>
    public static X11Atom UnderlinePosition { get; } = new(51);

    /// <summary>
    /// UNDERLINE_THICKNESS
    /// </summary>
    public static X11Atom UnderlineThickness { get; } = new(52);

    /// <summary>
    /// STRIKEOUT_ASCENT
    /// </summary>
    public static X11Atom StrikeoutAscent { get; } = new(53);

    /// <summary>
    /// STRIKEOUT_DESCENT
    /// </summary>
    public static X11Atom StrikeoutDescent { get; } = new(54);

    /// <summary>
    /// ITALIC_ANGLE
    /// </summary>
    public static X11Atom ItalicAngle { get; } = new(55);

    /// <summary>
    /// X_HEIGHT
    /// </summary>
    public static X11Atom XHeight { get; } = new(56);

    /// <summary>
    /// QUAD_WIDTH
    /// </summary>
    public static X11Atom QuadWidth { get; } = new(57);

    /// <summary>
    /// WEIGHT
    /// </summary>
    public static X11Atom Weight { get; } = new(58);

    /// <summary>
    /// POINT_SIZE
    /// </summary>
    public static X11Atom PointSize { get; } = new(59);

    /// <summary>
    /// RESOLUTION
    /// </summary>
    public static X11Atom Resolution { get; } = new(60);

    /// <summary>
    /// COPYRIGHT
    /// </summary>
    public static X11Atom Copyright { get; } = new(61);

    /// <summary>
    /// NOTICE
    /// </summary>
    public static X11Atom Notice { get; } = new(62);

    /// <summary>
    /// FONT_NAME
    /// </summary>
    public static X11Atom FontName { get; } = new(63);

    /// <summary>
    /// FAMILY_NAME
    /// </summary>
    public static X11Atom FamilyName { get; } = new(64);

    /// <summary>
    /// FULL_NAME
    /// </summary>
    public static X11Atom FullName { get; } = new(65);

    /// <summary>
    /// CAP_HEIGHT
    /// </summary>
    public static X11Atom CapHeight { get; } = new(66);

    /// <summary>
    /// WM_CLASS
    /// </summary>
    public static X11Atom WmClass { get; } = new(67);

    /// <summary>
    /// WM_TRANSIENT_FOR
    /// </summary>
    public static X11Atom WmTransientFor { get; } = new(68);

    /// <summary>
    /// LAST_PREDEFINED
    /// </summary>
    public static X11Atom LastPredefined { get; } = new(68);
}
