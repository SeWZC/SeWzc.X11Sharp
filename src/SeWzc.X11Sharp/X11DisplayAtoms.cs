using System.Collections.Concurrent;
using SeWzc.X11Sharp.Internal;

namespace SeWzc.X11Sharp;

/// <summary>
/// Display 中的原子。
/// </summary>
public class X11DisplayAtoms
{
    private readonly X11Display _display;
    private readonly ConcurrentDictionary<string, X11Atom> _atomCache = new();

    internal X11DisplayAtoms(X11Display display)
    {
        _display = display;
    }

    #region 扩展原子

    /// <summary>
    /// UTF8_STRING 原子。
    /// </summary>
    public X11DisplayAtom Utf8String => GetAtom("UTF8_STRING");

    #region Extended Window Manager Hints

    // 基于 Extended Window Manager Hints (EWMH) 的原子。
    // https://specifications.freedesktop.org/wm-spec/1.5/index.html

    #region Root Window Properties

    /// <summary>
    /// _NET_SUPPORTED 原子。
    /// </summary>
    /// <remarks>
    /// _NET_SUPPORTED, ATOM[]/32
    /// </remarks>
    public X11DisplayAtom NetSupported => GetAtom("_NET_SUPPORTED");

    /// <summary>
    /// _NET_CLIENT_LIST 原子。
    /// </summary>
    /// <remarks>
    /// _NET_CLIENT_LIST, WINDOW[]/32
    /// </remarks>
    public X11DisplayAtom NetClientList => GetAtom("_NET_CLIENT_LIST");

    /// <summary>
    /// _NET_CLIENT_LIST_STACKING 原子。
    /// </summary>
    /// <remarks>
    /// _NET_CLIENT_LIST_STACKING, WINDOW[]/32
    /// </remarks>
    public X11DisplayAtom NetClientListStacking => GetAtom("_NET_CLIENT_LIST_STACKING");

    /// <summary>
    /// _NET_NUMBER_OF_DESKTOPS 原子。
    /// </summary>
    /// <remarks>
    /// _NET_NUMBER_OF_DESKTOPS, CARDINAL/32
    /// </remarks>
    public X11DisplayAtom NetNumberOfDesktops => GetAtom("_NET_NUMBER_OF_DESKTOPS");

    /// <summary>
    /// _NET_CURRENT_DESKTOP 原子。
    /// </summary>
    /// <remarks>
    /// _NET_DESKTOP_GEOMETRY width, height, CARDINAL[2]/32
    /// </remarks>
    public X11DisplayAtom NetDesktopGeometry => GetAtom("_NET_DESKTOP_GEOMETRY");

    /// <summary>
    /// _NET_DESKTOP_VIEWPORT 原子。
    /// </summary>
    /// <remarks>
    /// _NET_DESKTOP_VIEWPORT x, y, CARDINAL[][2]/32
    /// </remarks>
    public X11DisplayAtom NetDesktopViewport => GetAtom("_NET_DESKTOP_VIEWPORT");

    /// <summary>
    /// _NET_CURRENT_DESKTOP 原子。
    /// </summary>
    /// <remarks>
    /// _NET_CURRENT_DESKTOP desktop, CARDINAL/32
    /// </remarks>
    public X11DisplayAtom NetCurrentDesktop => GetAtom("_NET_CURRENT_DESKTOP");

    /// <summary>
    /// _NET_DESKTOP_NAMES 原子.
    /// </summary>
    /// <remarks>
    /// _NET_DESKTOP_NAMES, UTF8_STRING[]
    /// </remarks>
    public X11DisplayAtom NetDesktopNames => GetAtom("_NET_DESKTOP_NAMES");

    /// <summary>
    /// _NET_ACTIVE_WINDOW 原子。
    /// </summary>
    /// <remarks>
    /// _NET_ACTIVE_WINDOW, WINDOW/32
    /// </remarks>
    public X11DisplayAtom NetActiveWindow => GetAtom("_NET_ACTIVE_WINDOW");

    /// <summary>
    /// _NET_WORKAREA 原子。
    /// </summary>
    /// <remarks>
    /// _NET_WORKAREA, x, y, width, height CARDINAL[][4]/32
    /// </remarks>
    public X11DisplayAtom NetWorkarea => GetAtom("_NET_WORKAREA");

    /// <summary>
    /// _NET_SUPPORTING_WM_CHECK 原子。
    /// </summary>
    /// <remarks>
    /// _NET_SUPPORTING_WM_CHECK, WINDOW/32
    /// </remarks>
    public X11DisplayAtom NetSupportingWmCheck => GetAtom("_NET_SUPPORTING_WM_CHECK");

    /// <summary>
    /// _NET_VIRTUAL_ROOTS 原子。
    /// </summary>
    /// <remarks>
    /// _NET_VIRTUAL_ROOTS, WINDOW[]/32
    /// </remarks>
    public X11DisplayAtom NetVirtualRoots => GetAtom("_NET_VIRTUAL_ROOTS");

    /// <summary>
    /// _NET_DESKTOP_LAYOUT 原子。
    /// </summary>
    /// <remarks>
    /// <code>
    /// _NET_DESKTOP_LAYOUT, orientation, columns, rows, starting_corner CARDINAL[4]/32
    ///
    /// #define _NET_WM_ORIENTATION_HORZ 0
    /// #define _NET_WM_ORIENTATION_VERT 1
    ///
    /// #define _NET_WM_TOPLEFT     0
    /// #define _NET_WM_TOPRIGHT    1
    /// #define _NET_WM_BOTTOMRIGHT 2
    /// #define _NET_WM_BOTTOMLEFT  3
    /// </code>
    /// </remarks>
    public X11DisplayAtom NetDesktopLayout => GetAtom("_NET_DESKTOP_LAYOUT");

    /// <summary>
    /// _NET_SHOWING_DESKTOP 原子。
    /// </summary>
    /// <remarks>
    /// _NET_SHOWING_DESKTOP desktop, CARDINAL/32
    /// </remarks>
    public X11DisplayAtom NetShowingDesktop => GetAtom("_NET_SHOWING_DESKTOP");

    #endregion

    #region Other Root Window Messages

    /// <summary>
    /// _NET_CLOSE_WINDOW 原子。
    /// </summary>
    public X11DisplayAtom NetCloseWindow => GetAtom("_NET_CLOSE_WINDOW");

    /// <summary>
    /// _NET_MOVERESIZE_WINDOW 原子。
    /// </summary>
    public X11DisplayAtom NetMoveresizeWindow => GetAtom("_NET_MOVERESIZE_WINDOW");

    /// <summary>
    /// _NET_WM_MOVERESIZE 原子。
    /// </summary>
    public X11DisplayAtom NetWmMoveresize => GetAtom("_NET_WM_MOVERESIZE");

    /// <summary>
    /// _NET_RESTACK_WINDOW 原子。
    /// </summary>
    public X11DisplayAtom NetRestackWindow => GetAtom("_NET_RESTACK_WINDOW");

    /// <summary>
    /// _NET_REQUEST_FRAME_EXTENTS 原子。
    /// </summary>
    public X11DisplayAtom NetRequestFrameExtents => GetAtom("_NET_REQUEST_FRAME_EXTENTS");

    #endregion

    #region Application Window Properties

    /// <summary>
    /// _NET_WM_NAME 原子。
    /// </summary>
    /// <remarks>
    /// _NET_WM_NAME, UTF8_STRING
    /// </remarks>
    public X11DisplayAtom NetWmName => GetAtom("_NET_WM_NAME");

    /// <summary>
    /// _NET_WM_VISIBLE_NAME 原子。
    /// </summary>
    /// <remarks>
    /// _NET_WM_VISIBLE_NAME, UTF8_STRING
    /// </remarks>
    public X11DisplayAtom NetWmVisibleName => GetAtom("_NET_WM_VISIBLE_NAME");

    /// <summary>
    /// _NET_WM_ICON_NAME 原子。
    /// </summary>
    /// <remarks>
    /// _NET_WM_ICON_NAME, UTF8_STRING
    /// </remarks>
    public X11DisplayAtom NetWmIconName => GetAtom("_NET_WM_ICON_NAME");

    /// <summary>
    /// _NET_WM_VISIBLE_ICON_NAME 原子。
    /// </summary>
    /// <remarks>
    /// _NET_WM_VISIBLE_ICON_NAME, UTF8_STRING
    /// </remarks>
    public X11DisplayAtom NetWmVisibleIconName => GetAtom("_NET_WM_VISIBLE_ICON_NAME");

    /// <summary>
    /// _NET_WM_DESKTOP 原子。
    /// </summary>
    /// <remarks>
    /// _NET_WM_DESKTOP desktop, CARDINAL/32
    /// </remarks>
    public X11DisplayAtom NetWmDesktop => GetAtom("_NET_WM_DESKTOP");

    /// <summary>
    /// _NET_WM_WINDOW_TYPE 原子。
    /// </summary>
    /// <remarks>
    /// _NET_WM_WINDOW_TYPE, ATOM[]/32
    /// </remarks>
    public X11DisplayAtom NetWmWindowType => GetAtom("_NET_WM_WINDOW_TYPE");

    #region Window Type Atoms

    /// <summary>
    /// _NET_WM_WINDOW_TYPE_DESKTOP 原子。
    /// </summary>
    public X11DisplayAtom NetWmWindowTypeDesktop => GetAtom("_NET_WM_WINDOW_TYPE_DESKTOP");

    /// <summary>
    /// _NET_WM_WINDOW_TYPE_DOCK 原子。
    /// </summary>
    public X11DisplayAtom NetWmWindowTypeDock => GetAtom("_NET_WM_WINDOW_TYPE_DOCK");

    /// <summary>
    /// _NET_WM_WINDOW_TYPE_TOOLBAR 原子。
    /// </summary>
    public X11DisplayAtom NetWmWindowTypeToolbar => GetAtom("_NET_WM_WINDOW_TYPE_TOOLBAR");

    /// <summary>
    /// _NET_WM_WINDOW_TYPE_MENU 原子。
    /// </summary>
    public X11DisplayAtom NetWmWindowTypeMenu => GetAtom("_NET_WM_WINDOW_TYPE_MENU");

    /// <summary>
    /// _NET_WM_WINDOW_TYPE_UTILITY 原子。
    /// </summary>
    public X11DisplayAtom NetWmWindowTypeUtility => GetAtom("_NET_WM_WINDOW_TYPE_UTILITY");

    /// <summary>
    /// _NET_WM_WINDOW_TYPE_SPLASH 原子。
    /// </summary>
    public X11DisplayAtom NetWmWindowTypeSplash => GetAtom("_NET_WM_WINDOW_TYPE_SPLASH");

    /// <summary>
    /// _NET_WM_WINDOW_TYPE_DIALOG 原子。
    /// </summary>
    public X11DisplayAtom NetWmWindowTypeDialog => GetAtom("_NET_WM_WINDOW_TYPE_DIALOG");

    /// <summary>
    /// _NET_WM_WINDOW_TYPE_DROPDOWN_MENU 原子。
    /// </summary>
    public X11DisplayAtom NetWmWindowTypeDropdownMenu => GetAtom("_NET_WM_WINDOW_TYPE_DROPDOWN_MENU");

    /// <summary>
    /// _NET_WM_WINDOW_TYPE_POPUP_MENU 原子。
    /// </summary>
    public X11DisplayAtom NetWmWindowTypePopupMenu => GetAtom("_NET_WM_WINDOW_TYPE_POPUP_MENU");

    /// <summary>
    /// _NET_WM_WINDOW_TYPE_TOOLTIP 原子。
    /// </summary>
    public X11DisplayAtom NetWmWindowTypeTooltip => GetAtom("_NET_WM_WINDOW_TYPE_TOOLTIP");

    /// <summary>
    /// _NET_WM_WINDOW_TYPE_NOTIFICATION 原子。
    /// </summary>
    public X11DisplayAtom NetWmWindowTypeNotification => GetAtom("_NET_WM_WINDOW_TYPE_NOTIFICATION");

    /// <summary>
    /// _NET_WM_WINDOW_TYPE_COMBO 原子。
    /// </summary>
    public X11DisplayAtom NetWmWindowTypeCombo => GetAtom("_NET_WM_WINDOW_TYPE_COMBO");

    /// <summary>
    /// _NET_WM_WINDOW_TYPE_DND 原子。
    /// </summary>
    public X11DisplayAtom NetWmWindowTypeDnd => GetAtom("_NET_WM_WINDOW_TYPE_DND");

    /// <summary>
    /// _NET_WM_WINDOW_TYPE_NORMAL 原子。
    /// </summary>
    public X11DisplayAtom NetWmWindowTypeNormal => GetAtom("_NET_WM_WINDOW_TYPE_NORMAL");

    #endregion

    /// <summary>
    /// _NET_WM_STATE 原子。
    /// </summary>
    /// <remarks>
    /// _NET_WM_STATE, ATOM[]/32
    /// </remarks>
    public X11DisplayAtom NetWmState => GetAtom("_NET_WM_STATE");

    #region Window State Atoms

    /// <summary>
    /// _NET_WM_STATE_MODAL 原子。
    /// </summary>
    public X11DisplayAtom NetWmStateModal => GetAtom("_NET_WM_STATE_MODAL");

    /// <summary>
    /// _NET_WM_STATE_STICKY 原子。
    /// </summary>
    public X11DisplayAtom NetWmStateSticky => GetAtom("_NET_WM_STATE_STICKY");

    /// <summary>
    /// _NET_WM_STATE_MAXIMIZED_VERT 原子。
    /// </summary>
    public X11DisplayAtom NetWmStateMaximizedVert => GetAtom("_NET_WM_STATE_MAXIMIZED_VERT");

    /// <summary>
    /// _NET_WM_STATE_MAXIMIZED_HORZ 原子。
    /// </summary>
    public X11DisplayAtom NetWmStateMaximizedHorz => GetAtom("_NET_WM_STATE_MAXIMIZED_HORZ");

    /// <summary>
    /// _NET_WM_STATE_SHADED 原子。
    /// </summary>
    public X11DisplayAtom NetWmStateShaded => GetAtom("_NET_WM_STATE_SHADED");

    /// <summary>
    /// _NET_WM_STATE_SKIP_TASKBAR 原子。
    /// </summary>
    public X11DisplayAtom NetWmStateSkipTaskbar => GetAtom("_NET_WM_STATE_SKIP_TASKBAR");

    /// <summary>
    /// _NET_WM_STATE_SKIP_PAGER 原子。
    /// </summary>
    public X11DisplayAtom NetWmStateSkipPager => GetAtom("_NET_WM_STATE_SKIP_PAGER");

    /// <summary>
    /// _NET_WM_STATE_HIDDEN 原子。
    /// </summary>
    public X11DisplayAtom NetWmStateHidden => GetAtom("_NET_WM_STATE_HIDDEN");

    /// <summary>
    /// _NET_WM_STATE_FULLSCREEN 原子。
    /// </summary>
    public X11DisplayAtom NetWmStateFullscreen => GetAtom("_NET_WM_STATE_FULLSCREEN");

    /// <summary>
    /// _NET_WM_STATE_ABOVE 原子。
    /// </summary>
    public X11DisplayAtom NetWmStateAbove => GetAtom("_NET_WM_STATE_ABOVE");

    /// <summary>
    /// _NET_WM_STATE_BELOW 原子。
    /// </summary>
    public X11DisplayAtom NetWmStateBelow => GetAtom("_NET_WM_STATE_BELOW");

    /// <summary>
    /// _NET_WM_STATE_DEMANDS_ATTENTION 原子。
    /// </summary>
    public X11DisplayAtom NetWmStateDemandsAttention => GetAtom("_NET_WM_STATE_DEMANDS_ATTENTION");

    /// <summary>
    /// _NET_WM_STATE_FOCUSED 原子。
    /// </summary>
    public X11DisplayAtom NetWmStateFocused => GetAtom("_NET_WM_STATE_FOCUSED");

    #endregion

    /// <summary>
    /// _NET_WM_ALLOWED_ACTIONS 原子。
    /// </summary>
    /// <remarks>
    /// _NET_WM_ALLOWED_ACTIONS, ATOM[]/32
    /// </remarks>
    public X11DisplayAtom NetWmAllowedActions => GetAtom("_NET_WM_ALLOWED_ACTIONS");

    #region Allowed Actions Atoms

    /// <summary>
    /// _NET_WM_ACTION_MOVE 原子。
    /// </summary>
    public X11DisplayAtom NetWmActionMove => GetAtom("_NET_WM_ACTION_MOVE");

    /// <summary>
    /// _NET_WM_ACTION_RESIZE 原子。
    /// </summary>
    public X11DisplayAtom NetWmActionResize => GetAtom("_NET_WM_ACTION_RESIZE");

    /// <summary>
    /// _NET_WM_ACTION_MINIMIZE 原子。
    /// </summary>
    public X11DisplayAtom NetWmActionMinimize => GetAtom("_NET_WM_ACTION_MINIMIZE");

    /// <summary>
    /// _NET_WM_ACTION_SHADE 原子。
    /// </summary>
    public X11DisplayAtom NetWmActionShade => GetAtom("_NET_WM_ACTION_SHADE");

    /// <summary>
    /// _NET_WM_ACTION_STICK 原子。
    /// </summary>
    public X11DisplayAtom NetWmActionStick => GetAtom("_NET_WM_ACTION_STICK");

    /// <summary>
    /// _NET_WM_ACTION_MAXIMIZE_HORZ 原子。
    /// </summary>
    public X11DisplayAtom NetWmActionMaximizeHorz => GetAtom("_NET_WM_ACTION_MAXIMIZE_HORZ");

    /// <summary>
    /// _NET_WM_ACTION_MAXIMIZE_VERT 原子。
    /// </summary>
    public X11DisplayAtom NetWmActionMaximizeVert => GetAtom("_NET_WM_ACTION_MAXIMIZE_VERT");

    /// <summary>
    /// _NET_WM_ACTION_FULLSCREEN 原子。
    /// </summary>
    public X11DisplayAtom NetWmActionFullscreen => GetAtom("_NET_WM_ACTION_FULLSCREEN");

    /// <summary>
    /// _NET_WM_ACTION_CHANGE_DESKTOP 原子。
    /// </summary>
    public X11DisplayAtom NetWmActionChangeDesktop => GetAtom("_NET_WM_ACTION_CHANGE_DESKTOP");

    /// <summary>
    /// _NET_WM_ACTION_CLOSE 原子。
    /// </summary>
    public X11DisplayAtom NetWmActionClose => GetAtom("_NET_WM_ACTION_CLOSE");

    /// <summary>
    /// _NET_WM_ACTION_ABOVE 原子。
    /// </summary>
    public X11DisplayAtom NetWmActionAbove => GetAtom("_NET_WM_ACTION_ABOVE");

    /// <summary>
    /// _NET_WM_ACTION_BELOW 原子。
    /// </summary>
    public X11DisplayAtom NetWmActionBelow => GetAtom("_NET_WM_ACTION_BELOW");

    #endregion

    /// <summary>
    /// _NET_WM_STRUT 原子。
    /// </summary>
    /// <remarks>
    /// _NET_WM_STRUT left, right, top, bottom, CARDINAL[4]/32
    /// </remarks>
    public X11DisplayAtom NetWmStrut => GetAtom("_NET_WM_STRUT");

    /// <summary>
    /// _NET_WM_STRUT_PARTIAL 原子。
    /// </summary>
    /// <remarks>
    /// _NET_WM_STRUT_PARTIAL left, right, top, bottom, left_start_y, left_end_y,
    /// right_start_y, right_end_y, top_start_x, top_end_x, bottom_start_x, bottom_end_x,
    /// CARDINAL[12]/32
    /// </remarks>
    public X11DisplayAtom NetWmStrutPartial => GetAtom("_NET_WM_STRUT_PARTIAL");

    /// <summary>
    /// _NET_WM_ICON_GEOMETRY 原子。
    /// </summary>
    /// <remarks>
    /// _NET_WM_ICON_GEOMETRY x, y, width, height, CARDINAL[4]/32
    /// </remarks>
    public X11DisplayAtom NetWmIconGeometry => GetAtom("_NET_WM_ICON_GEOMETRY");

    /// <summary>
    /// _NET_WM_ICON 原子。
    /// </summary>
    /// <remarks>
    /// _NET_WM_ICON, CARDINAL[][2+n]/32
    /// </remarks>
    public X11DisplayAtom NetWmIcon => GetAtom("_NET_WM_ICON");

    /// <summary>
    /// _NET_WM_PID 原子。
    /// </summary>
    /// <remarks>
    /// _NET_WM_PID, CARDINAL/32
    /// </remarks>
    public X11DisplayAtom NetWmPid => GetAtom("_NET_WM_PID");

    /// <summary>
    /// _NET_WM_HANDLED_ICONS 原子。
    /// </summary>
    /// <remarks>
    /// _NET_WM_HANDLED_ICONS, CARDINAL/32
    /// </remarks>
    public X11DisplayAtom NetWmHandledIcons => GetAtom("_NET_WM_HANDLED_ICONS");

    /// <summary>
    /// _NET_WM_USER_TIME 原子。
    /// </summary>
    /// <remarks>
    /// _NET_WM_USER_TIME, CARDINAL/32
    /// </remarks>
    public X11DisplayAtom NetWmUserTime => GetAtom("_NET_WM_USER_TIME");

    /// <summary>
    /// _NET_WM_USER_TIME_WINDOW 原子。
    /// </summary>
    /// <remarks>
    /// _NET_WM_USER_TIME_WINDOW, WINDOW/32
    /// </remarks>
    public X11DisplayAtom NetWmUserTimeWindow => GetAtom("_NET_WM_USER_TIME_WINDOW");

    /// <summary>
    /// _NET_FRAME_EXTENTS 原子。
    /// </summary>
    /// <remarks>
    /// _NET_FRAME_EXTENTS, left, right, top, bottom, CARDINAL[4]/32
    /// </remarks>
    public X11DisplayAtom NetFrameExtents => GetAtom("_NET_FRAME_EXTENTS");

    /// <summary>
    /// _NET_WM_OPAQUE_REGION 原子。
    /// </summary>
    /// <remarks>
    /// _NET_WM_OPAQUE_REGION, CARDINAL[][4]/32
    /// </remarks>
    public X11DisplayAtom NetWmOpaqueRegion => GetAtom("_NET_WM_OPAQUE_REGION");

    /// <summary>
    /// _NET_WM_BYPASS_COMPOSITOR 原子。
    /// </summary>
    /// <remarks>
    /// _NET_WM_BYPASS_COMPOSITOR, CARDINAL/32
    /// </remarks>
    public X11DisplayAtom NetWmBypassCompositor => GetAtom("_NET_WM_BYPASS_COMPOSITOR");

    /// <summary>
    /// _NET_WM_WINDOW_OPACITY 原子。
    /// </summary>
    /// <remarks>
    /// _NET_WM_WINDOW_OPACITY, CARDINAL/32
    /// </remarks>
    public X11DisplayAtom NetWmWindowOpacity => GetAtom("_NET_WM_WINDOW_OPACITY");

    #endregion

    #endregion

    private X11DisplayAtom GetAtom(string atomName)
    {
        var x11Atom = _atomCache.GetOrAdd(atomName, static (name, display) => XLib.XInternAtom(display, name, false), _display);
        return x11Atom.WithDisplay(_display);
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
