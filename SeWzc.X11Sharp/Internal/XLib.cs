using System.Runtime.InteropServices;

namespace SeWzc.X11Sharp.Internal;

// ReSharper disable InconsistentNaming
internal static unsafe partial class XLib
{
    private const string libX11 = "libX11.so.6";
    private const string libX11Randr = "libXrandr.so.2";
    private const string libX11Ext = "libXext.so.6";
    private const string libXInput = "libXi.so.6";
    private const string libXCursor = "libXcursor.so.1";

    [LibraryImport(libX11, StringMarshalling = StringMarshalling.Utf8)]
    public static partial DisplayPtr XOpenDisplay(string? displayName);

    [LibraryImport(libX11)]
    public static partial int XCloseDisplay(DisplayPtr display);

    [LibraryImport(libX11)]
    public static partial nuint XWhitePixel(DisplayPtr display, int screen_number);

    [LibraryImport(libX11)]
    public static partial nuint XBlackPixel(DisplayPtr display, int screen_number);

    [LibraryImport(libX11)]
    public static partial InternalWindow XCreateWindow(DisplayPtr display, InternalWindow parent,
        int x, int y,
        uint width, uint height,
        uint border_width,
        int depth,
        WindowClasses @class,
        XVisual* visual,
        WindowAttributeValueMask valuemask,
        XSetWindowAttributes* attributes);

    [LibraryImport(libX11)]
    public static partial int XDestroyWindow(DisplayPtr display, InternalWindow window);
}
