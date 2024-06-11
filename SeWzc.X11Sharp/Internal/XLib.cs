using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;
using SeWzc.X11Sharp.Structs;

// ReSharper disable UnusedMember.Local
// ReSharper disable InconsistentNaming

namespace SeWzc.X11Sharp.Internal;

internal static unsafe partial class XLib
{
    private const string libX11 = "libX11.so.6";
    // ReSharper disable once IdentifierTypo
    // private const string libX11Randr = "libXrandr.so.2";
    // private const string libX11Ext = "libXext.so.6";
    // private const string libXInput = "libXi.so.6";
    // private const string libXCursor = "libXcursor.so.1";

    #region Display Functions

    #region Opening the Display

    // Display *XOpenDisplay(char *display_name);
    [LibraryImport(libX11, StringMarshalling = StringMarshalling.Utf8)]
    public static partial DisplayPtr XOpenDisplay(string? displayName);

    #endregion

    #region Obtaining Information about the Display, Image Formats, or Screens

    #region Display Macros

    // unsigned long XBlackPixel(Display *display, int screen_number);
    [LibraryImport(libX11)]
    public static partial Pixel XWhitePixel(DisplayPtr display, int screen_number);

    // unsigned long XWhitePixel(Display *display, int screen_number);
    [LibraryImport(libX11)]
    public static partial Pixel XBlackPixel(DisplayPtr display, int screen_number);

    // int XConnectionNumber(Display *display);
    [LibraryImport(libX11)]
    public static partial int XConnectionNumber(DisplayPtr display);

    // Colormap XDefaultColormap(Display *display, int screen_number);
    [LibraryImport(libX11)]
    public static partial ColormapHandle XDefaultColormap(DisplayPtr display, int screen_number);

    // int XDefaultDepth(Display *display, int screen_number);
    [LibraryImport(libX11)]
    public static partial int XDefaultDepth(DisplayPtr display, int screen_number);

    // int *XListDepths(Display *display, int screen_number, int *count_return);
    [LibraryImport(libX11)]
    public static partial int* XListDepths(DisplayPtr display, int screen_number, out int count);

    // GC XDefaultGC(Display *display, int screen_number);
    [LibraryImport(libX11)]
    public static partial GCPtr XDefaultGC(DisplayPtr display, int screen_number);

    // Window XDefaultRootWindow(Display *display);
    [LibraryImport(libX11)]
    public static partial WindowHandle XDefaultRootWindow(DisplayPtr display);

    // Screen *XDefaultScreenOfDisplay(Display *display);
    [LibraryImport(libX11)]
    public static partial XScreen* XDefaultScreenOfDisplay(DisplayPtr display);

    // Screen *XScreenOfDisplay(Display *display, int screen_number);
    [LibraryImport(libX11)]
    public static partial XScreen* XScreenOfDisplay(DisplayPtr display, int screen_number);

    // int XDefaultScreen(Display *display);
    [LibraryImport(libX11)]
    public static partial int XDefaultScreen(DisplayPtr display);

    // Visual *XDefaultVisual(Display *display, int screen_number);
    [LibraryImport(libX11)]
    public static partial XVisual* XDefaultVisual(DisplayPtr display, int screen_number);

    // int XDisplayCells(Display *display, int screen_number);
    [LibraryImport(libX11)]
    public static partial int XDisplayCells(DisplayPtr display, int screen_number);

    // int XDisplayPlanes(Display *display, int screen_number);
    [LibraryImport(libX11)]
    public static partial int XDisplayPlanes(DisplayPtr display, int screen_number);

    // char *XDisplayString(Display *display);
    [LibraryImport(libX11, StringMarshalling = StringMarshalling.Custom, StringMarshallingCustomType = typeof(AnsiStringMarshaller))]
    public static partial string? XDisplayString(DisplayPtr display);

    // TODO 暂未使用
    // long XExtendedMaxRequestSize(Display *display);
    [LibraryImport(libX11)]
    public static partial nint XExtendedMaxRequestSize(DisplayPtr display);

    // TODO 暂未使用
    // long XMaxRequestSize(Display *display);
    [LibraryImport(libX11)]
    public static partial nint XMaxRequestSize(DisplayPtr display);

    // TODO 暂未使用
    // unsigned long XLastKnownRequestProcessed(Display *display);
    [LibraryImport(libX11)]
    public static partial nuint XLastKnownRequestProcessed(DisplayPtr display);

    // TODO 暂未使用
    // unsigned long XNextRequest(Display *display);
    [LibraryImport(libX11)]
    public static partial nuint XNextRequest(DisplayPtr display);

    // int XProtocolVersion(Display *display);
    [LibraryImport(libX11)]
    public static partial int XProtocolVersion(DisplayPtr display);

    // int XProtocolRevision(Display *display);
    [LibraryImport(libX11)]
    public static partial int XProtocolRevision(DisplayPtr display);

    // TODO 暂未使用
    // int XQLength(Display *display);
    [LibraryImport(libX11)]
    public static partial int XQLength(DisplayPtr display);

    // Window XRootWindow(Display *display, int screen_number);
    [LibraryImport(libX11)]
    public static partial WindowHandle XRootWindow(DisplayPtr display, int screen_number);

    // int XScreenCount(Display *display);
    [LibraryImport(libX11)]
    public static partial int XScreenCount(DisplayPtr display);

    // TODO 暂未使用
    // char *XServerVendor(Display *display);
    [LibraryImport(libX11, StringMarshalling = StringMarshalling.Utf8)]
    public static partial string? XServerVendor(DisplayPtr display);

    // TODO 暂未使用
    // int XVendorRelease(Display *display);
    [LibraryImport(libX11)]
    public static partial int XVendorRelease(DisplayPtr display);

    #endregion

    #region Image Format Functions and Macros

    // TODO 暂未使用
    // XPixmapFormatValues *XListPixmapFormats(Display *display, int *count_return);
    [LibraryImport(libX11)]
    public static partial XPixmapFormatValues* XListPixmapFormats(DisplayPtr display, out int count);

    // TODO 暂未使用
    // int XImageByteOrder(Display *display);
    [LibraryImport(libX11)]
    public static partial ByteOrder XImageByteOrder(DisplayPtr display);

    // TODO 暂未使用
    // int XBitmapUnit(Display *display);
    [LibraryImport(libX11)]
    public static partial int XBitmapUnit(DisplayPtr display);

    // TODO 暂未使用
    // int XBitmapBitOrder(Display *display);
    [LibraryImport(libX11)]
    public static partial ByteOrder XBitmapBitOrder(DisplayPtr display);

    // TODO 暂未使用
    // int XBitmapPad(Display *display);
    [LibraryImport(libX11)]
    public static partial int XBitmapPad(DisplayPtr display);

    // TODO 暂未使用
    // int XDisplayHeight(Display *display, int screen_number);
    [LibraryImport(libX11)]
    public static partial int XDisplayHeight(DisplayPtr display, int screen_number);

    // TODO 暂未使用
    // int XDisplayHeightMM(Display *display, int screen_number);
    [LibraryImport(libX11)]
    public static partial int XDisplayHeightMM(DisplayPtr display, int screen_number);

    // TODO 暂未使用
    // int XDisplayWidth(Display *display, int screen_number);
    [LibraryImport(libX11)]
    public static partial int XDisplayWidth(DisplayPtr display, int screen_number);

    // TODO 暂未使用
    // int XDisplayWidthMM(Display *display, int screen_number);
    [LibraryImport(libX11)]
    public static partial int XDisplayWidthMM(DisplayPtr display, int screen_number);

    #endregion

    #region Screen Information Macros

    // unsigned long XBlackPixelOfScreen(Screen *screen);
    [LibraryImport(libX11)]
    public static partial Pixel XBlackPixelOfScreen(XScreen* screen);

    // unsigned long XWhitePixelOfScreen(Screen *screen);
    [LibraryImport(libX11)]
    public static partial Pixel XWhitePixelOfScreen(XScreen* screen);

    // int XCellsOfScreen(Screen *screen);
    [LibraryImport(libX11)]
    public static partial int XCellsOfScreen(XScreen* screen);

    // Colormap XDefaultColormapOfScreen(Screen *screen);
    [LibraryImport(libX11)]
    public static partial ColormapHandle XDefaultColormapOfScreen(XScreen* screen);

    // int XDefaultDepthOfScreen(Screen *screen);
    [LibraryImport(libX11)]
    public static partial int XDefaultDepthOfScreen(XScreen* screen);

    // GC XDefaultGCOfScreen(Screen *screen);
    [LibraryImport(libX11)]
    public static partial GCPtr XDefaultGCOfScreen(XScreen* screen);

    // Visual *XDefaultVisualOfScreen(Screen *screen);
    [LibraryImport(libX11)]
    public static partial XVisual* XDefaultVisualOfScreen(XScreen* screen);

    // TODO 暂未使用
    // int XDoesBackingStore(Screen *screen);
    [LibraryImport(libX11)]
    public static partial int XDoesBackingStore(XScreen* screen);

    // TODO 暂未使用
    // Bool XDoesSaveUnders(Screen *screen);
    [LibraryImport(libX11)]
    public static partial int XDoesSaveUnders(XScreen* screen);

    // Display *XDisplayOfScreen(Screen *screen);
    [LibraryImport(libX11)]
    public static partial DisplayPtr XDisplayOfScreen(XScreen* screen);

    // long XScreenNumberOfScreen(Screen *screen);
    [LibraryImport(libX11)]
    public static partial nint XScreenNumberOfScreen(XScreen* screen);

    // long XEventMaskOfScreen(Screen *screen);
    [LibraryImport(libX11)]
    public static partial EventMask XEventMaskOfScreen(XScreen* screen);

    // int XWidthOfScreen(Screen *screen);
    [LibraryImport(libX11)]
    public static partial int XWidthOfScreen(XScreen* screen);

    // int XHeightOfScreen(Screen *screen);
    [LibraryImport(libX11)]
    public static partial int XHeightOfScreen(XScreen* screen);

    // int XWidthMMOfScreen(Screen *screen);
    [LibraryImport(libX11)]
    public static partial int XWidthMMOfScreen(XScreen* screen);

    // int XHeightMMOfScreen(Screen *screen);
    [LibraryImport(libX11)]
    public static partial int XHeightMMOfScreen(XScreen* screen);

    // TODO 暂未使用
    // int XMaxCmapsOfScreen(Screen *screen);
    [LibraryImport(libX11)]
    public static partial int XMaxCmapsOfScreen(XScreen* screen);

    // TODO 暂未使用
    // int XMinCmapsOfScreen(Screen *screen);
    [LibraryImport(libX11)]
    public static partial int XMinCmapsOfScreen(XScreen* screen);

    // int XPlanesOfScreen(Screen *screen);
    [LibraryImport(libX11)]
    public static partial int XPlanesOfScreen(XScreen* screen);

    // Window XRootWindowOfScreen(Screen *screen);
    [LibraryImport(libX11)]
    public static partial WindowHandle XRootWindowOfScreen(XScreen* screen);

    #endregion

    #endregion

    #region Generating a NoOperation Protocol Request

    // TODO 暂未使用
    // int XNoOp(Display *display);
    [LibraryImport(libX11)]
    public static partial int XNoOp(DisplayPtr display);

    #endregion

    #region Freeing Client-Created Data

    // XFree(void *data);
    [LibraryImport(libX11)]
    public static partial void XFree(void* data);

    #endregion

    #region Closing the Display

    // XCloseDisplay(Display *display);
    [LibraryImport(libX11)]
    public static partial int XCloseDisplay(DisplayPtr display);

    // XSetCloseDownMode(Display *display, int close_mode);
    [LibraryImport(libX11)]
    public static partial int XSetCloseDownMode(DisplayPtr display, CloseDownMode close_mode);

    #endregion

    #region Using Xlib with Threads

    // TODO 暂未使用
    // Status XInitThreads(void);
    [LibraryImport(libX11)]
    public static partial int XInitThreads();

    // TODO 暂未使用
    // XLockDisplay(Display *display);
    [LibraryImport(libX11)]
    public static partial void XLockDisplay(DisplayPtr display);

    // TODO 暂未使用
    // XUnlockDisplay(Display *display);
    [LibraryImport(libX11)]
    public static partial void XUnlockDisplay(DisplayPtr display);

    #endregion

    #region Using Internal Connections

    // TODO 暂未使用
    // Status XAddConnectionWatch(Display *display, XConnectionWatchProc procedure, XPointer client_data);
    [LibraryImport(libX11)]
    public static partial int XAddConnectionWatch(DisplayPtr display, XConnectionWatchProc procedure, XPointer client_data);

    // TODO 暂未使用
    // Status XRemoveConnectionWatch(Display *display, XConnectionWatchProc procedure, XPointer client_data);
    [LibraryImport(libX11)]
    public static partial int XRemoveConnectionWatch(DisplayPtr display, XConnectionWatchProc procedure, XPointer client_data);

    // TODO 暂未使用
    // void XProcessInternalConnection(Display *display, int fd);
    [LibraryImport(libX11)]
    public static partial void XProcessInternalConnection(DisplayPtr display, int fd);

    // TODO 暂未使用
    // Status XInternalConnectionNumbers(Display *display, int ** fd, int * count_return);
    [LibraryImport(libX11)]
    public static partial int XInternalConnectionNumbers(DisplayPtr display, int** fd, out int count_return);

    #endregion

    #endregion

    #region Window Functions

    #region Visual Types

    // TODO 暂未使用
    // VisualID XVisualIDFromVisual(Visual *visual);
    [LibraryImport(libX11)]
    public static partial XVisualId XVisualIDFromVisual(XVisual* visual);

    #endregion

    #region Creating Windows

    // Window XCreateWindow(Display *display, Window parent, int x, int y, unsigned int width, unsigned int height, unsigned int border_width, int depth, unsigned int class, Visual *visual, unsigned long valuemask, XSetWindowAttributes *attributes);
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

    // TODO 暂未使用
    // Window XCreateSimpleWindow(Display *display, Window parent, int x, int y, unsigned int width, unsigned int height, unsigned int border_width, unsigned long border, unsigned long background);
    [LibraryImport(libX11)]
    public static partial WindowHandle XCreateSimpleWindow(DisplayPtr display, WindowHandle parent,
        int x, int y,
        uint width, uint height,
        uint border_width,
        Pixel border,
        Pixel background);

    #endregion

    #region Destroying Windows

    // XDestroyWindow(Display *display, Window w);
    [LibraryImport(libX11)]
    public static partial int XDestroyWindow(DisplayPtr display, WindowHandle window);

    // XDestroySubwindows(Display *display, Window w);
    [LibraryImport(libX11)]
    public static partial int XDestroySubwindows(DisplayPtr display, WindowHandle window);

    #endregion

    #region Mapping Windows

    // XMapWindow(Display *display, Window w);
    [LibraryImport(libX11)]
    public static partial int XMapWindow(DisplayPtr display, WindowHandle window);

    // XMapRaised(Display *display, Window w);
    [LibraryImport(libX11)]
    public static partial int XMapRaised(DisplayPtr display, WindowHandle window);

    // XMapSubwindows(Display *display, Window w);
    [LibraryImport(libX11)]
    public static partial int XMapSubwindows(DisplayPtr display, WindowHandle window);

    #endregion

    #region Unmapping Windows

    // XUnmapWindow(Display *display, Window w);
    [LibraryImport(libX11)]
    public static partial int XUnmapWindow(DisplayPtr display, WindowHandle window);

    // XUnmapSubwindows(Display *display, Window w);
    [LibraryImport(libX11)]
    public static partial int XUnmapSubwindows(DisplayPtr display, WindowHandle window);

    #endregion

    #region Configuring Windows

    // XConfigureWindow(Display *display, Window w, unsigned int value_mask, XWindowChanges *values);
    [LibraryImport(libX11)]
    public static partial int XConfigureWindow(DisplayPtr display, WindowHandle window, WindowChangeMask value_mask, XWindowChanges* values);

    // XMoveWindow(Display *display, Window w, int x, int y);
    [LibraryImport(libX11)]
    public static partial int XMoveWindow(DisplayPtr display, WindowHandle window, int x, int y);

    // XResizeWindow(Display *display, Window w, unsigned int width, unsigned int height);
    [LibraryImport(libX11)]
    public static partial int XResizeWindow(DisplayPtr display, WindowHandle window, uint width, uint height);

    // XMoveResizeWindow(Display *display, Window w, int x, int y, unsigned int width, unsigned int height);
    [LibraryImport(libX11)]
    public static partial int XMoveResizeWindow(DisplayPtr display, WindowHandle window, int x, int y, uint width, uint height);
    
    // XSetWindowBorderWidth(Display *display, Window w, unsigned int width);
    [LibraryImport(libX11)]
    public static partial int XSetWindowBorderWidth(DisplayPtr display, WindowHandle window, uint width);

    #endregion

    #region Changing Window Stacking Order

    // XRaiseWindow(Display *display, Window w);
    [LibraryImport(libX11)]
    public static partial int XRaiseWindow(DisplayPtr display, WindowHandle window);

    // XLowerWindow(Display *display, Window w);
    [LibraryImport(libX11)]
    public static partial int XLowerWindow(DisplayPtr display, WindowHandle window);

    // TODO 暂未使用
    // XCirculateSubwindows(Display *display, Window w, int direction);
    [LibraryImport(libX11)]
    public static partial int XCirculateSubwindows(DisplayPtr display, WindowHandle window, CirculationDirection direction);

    // TODO 暂未使用
    // XCirculateSubwindowsUp(Display *display, Window w);
    [LibraryImport(libX11)]
    public static partial int XCirculateSubwindowsUp(DisplayPtr display, WindowHandle window);

    // TODO 暂未使用
    // XCirculateSubwindowsDown(Display *display, Window w);
    [LibraryImport(libX11)]
    public static partial int XCirculateSubwindowsDown(DisplayPtr display, WindowHandle window);

    // TODO 暂未使用
    // XRestackWindows(Display *display, Window windows[], int nwindows);
    [LibraryImport(libX11)]
    public static partial int XRestackWindows(DisplayPtr display, WindowHandle[] windows, int nwindows);

    #endregion

    #region Changing Window Attributes

    // XChangeWindowAttributes(Display *display, Window w, unsigned long valuemask, XSetWindowAttributes *attributes);
    [LibraryImport(libX11)]
    public static partial int XChangeWindowAttributes(DisplayPtr display, WindowHandle window, WindowAttributeValueMask valuemask, XSetWindowAttributes* attributes);

    // XSetWindowBackground(Display *display, Window w, unsigned long background_pixel);
    [LibraryImport(libX11)]
    public static partial int XSetWindowBackground(DisplayPtr display, WindowHandle window, Pixel background_pixel);

    // TODO 暂未使用
    // XSetWindowBackgroundPixmap(Display *display, Window w, Pixmap background_pixmap);
    [LibraryImport(libX11)]
    public static partial int XSetWindowBackgroundPixmap(DisplayPtr display, WindowHandle window, PixmapHandle background_pixmap);

    // XSetWindowBorder(Display *display, Window w, unsigned long border_pixel);
    [LibraryImport(libX11)]
    public static partial int XSetWindowBorder(DisplayPtr display, WindowHandle window, Pixel border_pixel);

    // TODO 暂未使用
    // XSetWindowBorderPixmap(Display *display, Window w, Pixmap border_pixmap);
    [LibraryImport(libX11)]
    public static partial int XSetWindowBorderPixmap(DisplayPtr display, WindowHandle window, PixmapHandle border_pixmap);

    // TODO 暂未使用
    // XSetWindowColormap(Display *display, Window w, Colormap colormap);
    [LibraryImport(libX11)]
    public static partial int XSetWindowColormap(DisplayPtr display, WindowHandle window, ColormapHandle colormap);

    // TODO 暂未使用
    // XDefineCursor(Display *display, Window w, Cursor cursor);
    [LibraryImport(libX11)]
    public static partial int XDefineCursor(DisplayPtr display, WindowHandle window, CursorHandle cursor);

    // TODO 暂未使用
    // XUndefineCursor(Display *display, Window w);
    [LibraryImport(libX11)]
    public static partial int XUndefineCursor(DisplayPtr display, WindowHandle window);

    #endregion

    #endregion
}
