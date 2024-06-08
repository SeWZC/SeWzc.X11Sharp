using System.Runtime.InteropServices;
using SeWzc.X11Sharp.Structs;

// ReSharper disable UnusedMember.Local
// ReSharper disable InconsistentNaming

namespace SeWzc.X11Sharp.Internal;

internal static unsafe partial class XLib
{
    private const string libX11 = "libX11.so.6";

    // ReSharper disable once IdentifierTypo
    private const string libX11Randr = "libXrandr.so.2";
    private const string libX11Ext = "libXext.so.6";
    private const string libXInput = "libXi.so.6";
    private const string libXCursor = "libXcursor.so.1";

    [LibraryImport(libX11, StringMarshalling = StringMarshalling.Utf8)]
    public static partial DisplayPtr XOpenDisplay(string? displayName);

    [LibraryImport(libX11)]
    public static partial int XCloseDisplay(DisplayPtr display);

    [LibraryImport(libX11)]
    public static partial Pixel XWhitePixel(DisplayPtr display, int screen_number);

    [LibraryImport(libX11)]
    public static partial Pixel XBlackPixel(DisplayPtr display, int screen_number);

    [LibraryImport(libX11)]
    public static partial int XConnectionNumber(DisplayPtr display);

    [LibraryImport(libX11)]
    public static partial ColormapHandle XDefaultColormap(DisplayPtr display, int screen_number);

    [LibraryImport(libX11)]
    public static partial WindowHandle XCreateWindow(DisplayPtr display, WindowHandle parent,
        int x, int y,
        uint width, uint height,
        uint border_width,
        int depth,
        WindowClasses @class,
        XVisual* visual,
        WindowAttributeValueMask valuemask,
        XSetWindowAttributes* attributes);

    [LibraryImport(libX11)]
    public static partial int XDestroyWindow(DisplayPtr display, WindowHandle window);

    [LibraryImport(libX11)]
    public static partial WindowHandle XDefaultRootWindow(DisplayPtr display);
}