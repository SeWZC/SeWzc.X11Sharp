using SeWzc.X11Sharp.Handles;

namespace SeWzc.X11Sharp;

/// <summary>
/// Display 中的原子。
/// </summary>
public class X11DisplayAtoms
{
    private readonly X11Display _display;

    internal X11DisplayAtoms(X11Display display)
    {
        _display = display;
    }

    #region 扩展原子

    private X11Atom _utf8String;

    /// <summary>
    /// UTF8_STRING 原子。
    /// </summary>
    public X11DisplayAtom Utf8String => GetAtom(ref _utf8String, "UTF8_STRING");

    private X11Atom _netWmName;

    /// <summary>
    /// _NET_WM_NAME 原子。
    /// </summary>
    public X11DisplayAtom NetWmName => GetAtom(ref _netWmName, "_NET_WM_NAME");

    private X11Atom _netWmState;

    /// <summary>
    /// _NET_WM_STATE 原子。
    /// </summary>
    public X11DisplayAtom NetWmState => GetAtom(ref _netWmState, "_NET_WM_STATE");

    private X11DisplayAtom GetAtom(ref X11Atom atom, string atomName)
    {
        if (atom == default)
        {
            var result = _display.InternAtom(atomName);
            atom = result.Value;
            return result;
        }

        return atom.WithDisplay(_display);
    }

    #endregion

    #region 内置原子

    /// <summary>
    /// PRIMARY 原子。
    /// </summary>
    public X11DisplayAtom Primary => X11Atoms.Primary.WithDisplay(_display);

    /// <summary>
    /// SECONDARY 原子。
    /// </summary>
    public X11DisplayAtom Secondary => X11Atoms.Secondary.WithDisplay(_display);

    /// <summary>
    /// ARC 原子。
    /// </summary>
    public X11DisplayAtom Arc => X11Atoms.Arc.WithDisplay(_display);

    /// <summary>
    /// ATOM 原子。
    /// </summary>
    public X11DisplayAtom Atom => X11Atoms.Atom.WithDisplay(_display);

    /// <summary>
    /// BITMAP 原子。
    /// </summary>
    public X11DisplayAtom Bitmap => X11Atoms.Bitmap.WithDisplay(_display);

    /// <summary>
    /// CARDINAL 原子。
    /// </summary>
    public X11DisplayAtom Cardinal => X11Atoms.Cardinal.WithDisplay(_display);

    /// <summary>
    /// COLORMAP 原子。
    /// </summary>
    public X11DisplayAtom Colormap => X11Atoms.Colormap.WithDisplay(_display);

    /// <summary>
    /// CURSOR 原子。
    /// </summary>
    public X11DisplayAtom Cursor => X11Atoms.Cursor.WithDisplay(_display);

    /// <summary>
    /// CUT_BUFFER0 原子。
    /// </summary>
    public X11DisplayAtom CutBuffer0 => X11Atoms.CutBuffer0.WithDisplay(_display);

    /// <summary>
    /// CUT_BUFFER1 原子。
    /// </summary>
    public X11DisplayAtom CutBuffer1 => X11Atoms.CutBuffer1.WithDisplay(_display);

    /// <summary>
    /// CUT_BUFFER2 原子。
    /// </summary>
    public X11DisplayAtom CutBuffer2 => X11Atoms.CutBuffer2.WithDisplay(_display);

    /// <summary>
    /// CUT_BUFFER3 原子。
    /// </summary>
    public X11DisplayAtom CutBuffer3 => X11Atoms.CutBuffer3.WithDisplay(_display);

    /// <summary>
    /// CUT_BUFFER4 原子。
    /// </summary>
    public X11DisplayAtom CutBuffer4 => X11Atoms.CutBuffer4.WithDisplay(_display);

    /// <summary>
    /// CUT_BUFFER5 原子。
    /// </summary>
    public X11DisplayAtom CutBuffer5 => X11Atoms.CutBuffer5.WithDisplay(_display);

    /// <summary>
    /// CUT_BUFFER6 原子。
    /// </summary>
    public X11DisplayAtom CutBuffer6 => X11Atoms.CutBuffer6.WithDisplay(_display);

    /// <summary>
    /// CUT_BUFFER7 原子。
    /// </summary>
    public X11DisplayAtom CutBuffer7 => X11Atoms.CutBuffer7.WithDisplay(_display);

    /// <summary>
    /// DRAWABLE 原子。
    /// </summary>
    public X11DisplayAtom Drawable => X11Atoms.Drawable.WithDisplay(_display);

    /// <summary>
    /// FONT 原子。
    /// </summary>
    public X11DisplayAtom Font => X11Atoms.Font.WithDisplay(_display);

    /// <summary>
    /// INTEGER 原子。
    /// </summary>
    public X11DisplayAtom Integer => X11Atoms.Integer.WithDisplay(_display);

    /// <summary>
    /// PIXMAP 原子。
    /// </summary>
    public X11DisplayAtom Pixmap => X11Atoms.Pixmap.WithDisplay(_display);

    /// <summary>
    /// POINT 原子。
    /// </summary>
    public X11DisplayAtom Point => X11Atoms.Point.WithDisplay(_display);

    /// <summary>
    /// RECTANGLE 原子。
    /// </summary>
    public X11DisplayAtom Rectangle => X11Atoms.Rectangle.WithDisplay(_display);

    /// <summary>
    /// RESOURCE_MANAGER 原子。
    /// </summary>
    public X11DisplayAtom ResourceManager => X11Atoms.ResourceManager.WithDisplay(_display);

    /// <summary>
    /// RGB_COLOR_MAP 原子。
    /// </summary>
    public X11DisplayAtom RgbColorMap => X11Atoms.RgbColorMap.WithDisplay(_display);

    /// <summary>
    /// RGB_BEST_MAP 原子。
    /// </summary>
    public X11DisplayAtom RgbBestMap => X11Atoms.RgbBestMap.WithDisplay(_display);

    /// <summary>
    /// RGB_BLUE_MAP 原子。
    /// </summary>
    public X11DisplayAtom RgbBlueMap => X11Atoms.RgbBlueMap.WithDisplay(_display);

    /// <summary>
    /// RGB_DEFAULT_MAP 原子。
    /// </summary>
    public X11DisplayAtom RgbDefaultMap => X11Atoms.RgbDefaultMap.WithDisplay(_display);

    /// <summary>
    /// RGB_GRAY_MAP 原子。
    /// </summary>
    public X11DisplayAtom RgbGrayMap => X11Atoms.RgbGrayMap.WithDisplay(_display);

    /// <summary>
    /// RGB_GREEN_MAP 原子。
    /// </summary>
    public X11DisplayAtom RgbGreenMap => X11Atoms.RgbGreenMap.WithDisplay(_display);

    /// <summary>
    /// RGB_RED_MAP 原子。
    /// </summary>
    public X11DisplayAtom RgbRedMap => X11Atoms.RgbRedMap.WithDisplay(_display);

    /// <summary>
    /// STRING 原子。
    /// </summary>
    public X11DisplayAtom String => X11Atoms.String.WithDisplay(_display);

    /// <summary>
    /// VISUALID 原子。
    /// </summary>
    public X11DisplayAtom Visualid => X11Atoms.Visualid.WithDisplay(_display);

    /// <summary>
    /// WINDOW 原子。
    /// </summary>
    public X11DisplayAtom Window => X11Atoms.Window.WithDisplay(_display);

    /// <summary>
    /// WM_COMMAND 原子。
    /// </summary>
    public X11DisplayAtom WmCommand => X11Atoms.WmCommand.WithDisplay(_display);

    /// <summary>
    /// WM_HINTS 原子。
    /// </summary>
    public X11DisplayAtom WmHints => X11Atoms.WmHints.WithDisplay(_display);

    /// <summary>
    /// WM_CLIENT_MACHINE 原子。
    /// </summary>
    public X11DisplayAtom WmClientMachine => X11Atoms.WmClientMachine.WithDisplay(_display);

    /// <summary>
    /// WM_ICON_NAME 原子。
    /// </summary>
    public X11DisplayAtom WmIconName => X11Atoms.WmIconName.WithDisplay(_display);

    /// <summary>
    /// WM_ICON_SIZE 原子。
    /// </summary>
    public X11DisplayAtom WmIconSize => X11Atoms.WmIconSize.WithDisplay(_display);

    /// <summary>
    /// WM_NAME 原子。
    /// </summary>
    public X11DisplayAtom WmName => X11Atoms.WmName.WithDisplay(_display);

    /// <summary>
    /// WM_NORMAL_HINTS 原子。
    /// </summary>
    public X11DisplayAtom WmNormalHints => X11Atoms.WmNormalHints.WithDisplay(_display);

    /// <summary>
    /// WM_SIZE_HINTS 原子。
    /// </summary>
    public X11DisplayAtom WmSizeHints => X11Atoms.WmSizeHints.WithDisplay(_display);

    /// <summary>
    /// WM_ZOOM_HINTS 原子。
    /// </summary>
    public X11DisplayAtom WmZoomHints => X11Atoms.WmZoomHints.WithDisplay(_display);

    /// <summary>
    /// MIN_SPACE 原子。
    /// </summary>
    public X11DisplayAtom MinSpace => X11Atoms.MinSpace.WithDisplay(_display);

    /// <summary>
    /// NORM_SPACE 原子。
    /// </summary>
    public X11DisplayAtom NormSpace => X11Atoms.NormSpace.WithDisplay(_display);

    /// <summary>
    /// MAX_SPACE 原子。
    /// </summary>
    public X11DisplayAtom MaxSpace => X11Atoms.MaxSpace.WithDisplay(_display);

    /// <summary>
    /// END_SPACE 原子。
    /// </summary>
    public X11DisplayAtom EndSpace => X11Atoms.EndSpace.WithDisplay(_display);

    /// <summary>
    /// SUPERSCRIPT_X 原子。
    /// </summary>
    public X11DisplayAtom SuperscriptX => X11Atoms.SuperscriptX.WithDisplay(_display);

    /// <summary>
    /// SUPERSCRIPT_Y 原子。
    /// </summary>
    public X11DisplayAtom SuperscriptY => X11Atoms.SuperscriptY.WithDisplay(_display);

    /// <summary>
    /// SUBSCRIPT_X 原子。
    /// </summary>
    public X11DisplayAtom SubscriptX => X11Atoms.SubscriptX.WithDisplay(_display);

    /// <summary>
    /// SUBSCRIPT_Y 原子。
    /// </summary>
    public X11DisplayAtom SubscriptY => X11Atoms.SubscriptY.WithDisplay(_display);

    /// <summary>
    /// UNDERLINE_POSITION 原子。
    /// </summary>
    public X11DisplayAtom UnderlinePosition => X11Atoms.UnderlinePosition.WithDisplay(_display);

    /// <summary>
    /// UNDERLINE_THICKNESS 原子。
    /// </summary>
    public X11DisplayAtom UnderlineThickness => X11Atoms.UnderlineThickness.WithDisplay(_display);

    /// <summary>
    /// STRIKEOUT_ASCENT 原子。
    /// </summary>
    public X11DisplayAtom StrikeoutAscent => X11Atoms.StrikeoutAscent.WithDisplay(_display);

    /// <summary>
    /// STRIKEOUT_DESCENT 原子。
    /// </summary>
    public X11DisplayAtom StrikeoutDescent => X11Atoms.StrikeoutDescent.WithDisplay(_display);

    /// <summary>
    /// ITALIC_ANGLE 原子。
    /// </summary>
    public X11DisplayAtom ItalicAngle => X11Atoms.ItalicAngle.WithDisplay(_display);

    /// <summary>
    /// X_HEIGHT 原子。
    /// </summary>
    public X11DisplayAtom XHeight => X11Atoms.XHeight.WithDisplay(_display);

    /// <summary>
    /// QUAD_WIDTH 原子。
    /// </summary>
    public X11DisplayAtom QuadWidth => X11Atoms.QuadWidth.WithDisplay(_display);

    /// <summary>
    /// WEIGHT 原子。
    /// </summary>
    public X11DisplayAtom Weight => X11Atoms.Weight.WithDisplay(_display);

    /// <summary>
    /// POINT_SIZE 原子。
    /// </summary>
    public X11DisplayAtom PointSize => X11Atoms.PointSize.WithDisplay(_display);

    /// <summary>
    /// RESOLUTION 原子。
    /// </summary>
    public X11DisplayAtom Resolution => X11Atoms.Resolution.WithDisplay(_display);

    /// <summary>
    /// COPYRIGHT 原子。
    /// </summary>
    public X11DisplayAtom Copyright => X11Atoms.Copyright.WithDisplay(_display);

    /// <summary>
    /// NOTICE 原子。
    /// </summary>
    public X11DisplayAtom Notice => X11Atoms.Notice.WithDisplay(_display);

    /// <summary>
    /// FONT_NAME 原子。
    /// </summary>
    public X11DisplayAtom FontName => X11Atoms.FontName.WithDisplay(_display);

    /// <summary>
    /// FAMILY_NAME 原子。
    /// </summary>
    public X11DisplayAtom FamilyName => X11Atoms.FamilyName.WithDisplay(_display);

    /// <summary>
    /// FULL_NAME 原子。
    /// </summary>
    public X11DisplayAtom FullName => X11Atoms.FullName.WithDisplay(_display);

    /// <summary>
    /// CAP_HEIGHT 原子。
    /// </summary>
    public X11DisplayAtom CapHeight => X11Atoms.CapHeight.WithDisplay(_display);

    /// <summary>
    /// WM_CLASS 原子。
    /// </summary>
    public X11DisplayAtom WmClass => X11Atoms.WmClass.WithDisplay(_display);

    /// <summary>
    /// WM_TRANSIENT_FOR 原子。
    /// </summary>
    public X11DisplayAtom WmTransientFor => X11Atoms.WmTransientFor.WithDisplay(_display);

    /// <summary>
    /// LastPredefined 原子。
    /// </summary>
    public X11DisplayAtom LastPredefined => X11Atoms.LastPredefined.WithDisplay(_display);

    #endregion
}
