using System.Runtime.InteropServices;

namespace SeWzc.X11Sharp.Internal;

internal static unsafe partial class XLib
{
    private const string libX11 = "libX11.so.6";
    private const string libX11Randr = "libXrandr.so.2";
    private const string libX11Ext = "libXext.so.6";
    private const string libXInput = "libXi.so.6";
    private const string libXCursor = "libXcursor.so.1";

    [LibraryImport(libX11, StringMarshalling = StringMarshalling.Utf8)]
    public static partial XDisplay* XOpenDisplay(string? displayName);

    [LibraryImport(libX11)]
    public static partial int XCloseDisplay(XDisplay* display);

    // [LibraryImport(libX11)]
    // public static extern IntPtr XCreateWindow(in XDisplay display, IntPtr parent, int x, int y, int width, int height,
    //     int border_width, int depth, int xclass, IntPtr visual, UIntPtr valuemask,
    //     ref XSetWindowAttributes attributes);
}
