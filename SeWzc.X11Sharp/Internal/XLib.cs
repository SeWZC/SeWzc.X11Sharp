using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;
using SeWzc.X11Sharp.Structs;

// ReSharper disable UnusedMember.Local
// ReSharper disable InconsistentNaming

namespace SeWzc.X11Sharp.Internal;

/// <seealso href="https://www.x.org/releases/current/doc/libX11/libX11/libX11.html"/>
internal static partial class XLib
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
    public static partial X11Colormap XDefaultColormap(DisplayPtr display, int screen_number);

    // int XDefaultDepth(Display *display, int screen_number);
    [LibraryImport(libX11)]
    public static partial int XDefaultDepth(DisplayPtr display, int screen_number);

    // int *XListDepths(Display *display, int screen_number, int *count_return);
    [LibraryImport(libX11)]
    public static unsafe partial int* XListDepths(DisplayPtr display, int screen_number, out int count);

    // GC XDefaultGC(Display *display, int screen_number);
    [LibraryImport(libX11)]
    public static partial GCPtr XDefaultGC(DisplayPtr display, int screen_number);

    // Window XDefaultRootWindow(Display *display);
    [LibraryImport(libX11)]
    public static partial X11Window XDefaultRootWindow(DisplayPtr display);

    // Screen *XDefaultScreenOfDisplay(Display *display);
    [LibraryImport(libX11)]
    public static partial ScreenPtr XDefaultScreenOfDisplay(DisplayPtr display);

    // Screen *XScreenOfDisplay(Display *display, int screen_number);
    [LibraryImport(libX11)]
    public static partial ScreenPtr XScreenOfDisplay(DisplayPtr display, int screen_number);

    // int XDefaultScreen(Display *display);
    [LibraryImport(libX11)]
    public static partial int XDefaultScreen(DisplayPtr display);

    // Visual *XDefaultVisual(Display *display, int screen_number);
    [LibraryImport(libX11)]
    public static partial VisualPtr XDefaultVisual(DisplayPtr display, int screen_number);

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
    public static partial Long XExtendedMaxRequestSize(DisplayPtr display);

    // TODO 暂未使用
    // long XMaxRequestSize(Display *display);
    [LibraryImport(libX11)]
    public static partial Long XMaxRequestSize(DisplayPtr display);

    // TODO 暂未使用
    // unsigned long XLastKnownRequestProcessed(Display *display);
    [LibraryImport(libX11)]
    public static partial ULong XLastKnownRequestProcessed(DisplayPtr display);

    // unsigned long XNextRequest(Display *display);
    [LibraryImport(libX11)]
    public static partial ULong XNextRequest(DisplayPtr display);

    // int XProtocolVersion(Display *display);
    [LibraryImport(libX11)]
    public static partial int XProtocolVersion(DisplayPtr display);

    // int XProtocolRevision(Display *display);
    [LibraryImport(libX11)]
    public static partial int XProtocolRevision(DisplayPtr display);

    // int XQLength(Display *display);
    [LibraryImport(libX11)]
    public static partial int XQLength(DisplayPtr display);

    // Window XRootWindow(Display *display, int screen_number);
    [LibraryImport(libX11)]
    public static partial X11Window XRootWindow(DisplayPtr display, int screen_number);

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

    // XPixmapFormatValues *XListPixmapFormats(Display *display, int *count_return);
    [LibraryImport(libX11)]
    public static unsafe partial X11PixmapFormat* XListPixmapFormats(DisplayPtr display, out int count);

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
    public static partial Pixel XBlackPixelOfScreen(ScreenPtr screen);

    // unsigned long XWhitePixelOfScreen(Screen *screen);
    [LibraryImport(libX11)]
    public static partial Pixel XWhitePixelOfScreen(ScreenPtr screen);

    // int XCellsOfScreen(Screen *screen);
    [LibraryImport(libX11)]
    public static partial int XCellsOfScreen(ScreenPtr screen);

    // Colormap XDefaultColormapOfScreen(Screen *screen);
    [LibraryImport(libX11)]
    public static partial X11Colormap XDefaultColormapOfScreen(ScreenPtr screen);

    // int XDefaultDepthOfScreen(Screen *screen);
    [LibraryImport(libX11)]
    public static partial int XDefaultDepthOfScreen(ScreenPtr screen);

    // GC XDefaultGCOfScreen(Screen *screen);
    [LibraryImport(libX11)]
    public static partial GCPtr XDefaultGCOfScreen(ScreenPtr screen);

    // Visual *XDefaultVisualOfScreen(Screen *screen);
    [LibraryImport(libX11)]
    public static partial VisualPtr XDefaultVisualOfScreen(ScreenPtr screen);

    // TODO 暂未使用
    // int XDoesBackingStore(Screen *screen);
    [LibraryImport(libX11)]
    public static partial int XDoesBackingStore(ScreenPtr screen);

    // TODO 暂未使用
    // Bool XDoesSaveUnders(Screen *screen);
    [LibraryImport(libX11)]
    public static partial Bool XDoesSaveUnders(ScreenPtr screen);

    // Display *XDisplayOfScreen(Screen *screen);
    [LibraryImport(libX11)]
    public static partial DisplayPtr XDisplayOfScreen(ScreenPtr screen);

    // long XScreenNumberOfScreen(Screen *screen);
    [LibraryImport(libX11)]
    public static partial Long XScreenNumberOfScreen(ScreenPtr screen);

    // long XEventMaskOfScreen(Screen *screen);
    [LibraryImport(libX11)]
    public static partial EventMask XEventMaskOfScreen(ScreenPtr screen);

    // int XWidthOfScreen(Screen *screen);
    [LibraryImport(libX11)]
    public static partial int XWidthOfScreen(ScreenPtr screen);

    // int XHeightOfScreen(Screen *screen);
    [LibraryImport(libX11)]
    public static partial int XHeightOfScreen(ScreenPtr screen);

    // int XWidthMMOfScreen(Screen *screen);
    [LibraryImport(libX11)]
    public static partial int XWidthMMOfScreen(ScreenPtr screen);

    // int XHeightMMOfScreen(Screen *screen);
    [LibraryImport(libX11)]
    public static partial int XHeightMMOfScreen(ScreenPtr screen);

    // TODO 暂未使用
    // int XMaxCmapsOfScreen(Screen *screen);
    [LibraryImport(libX11)]
    public static partial int XMaxCmapsOfScreen(ScreenPtr screen);

    // TODO 暂未使用
    // int XMinCmapsOfScreen(Screen *screen);
    [LibraryImport(libX11)]
    public static partial int XMinCmapsOfScreen(ScreenPtr screen);

    // int XPlanesOfScreen(Screen *screen);
    [LibraryImport(libX11)]
    public static partial int XPlanesOfScreen(ScreenPtr screen);

    // Window XRootWindowOfScreen(Screen *screen);
    [LibraryImport(libX11)]
    public static partial X11Window XRootWindowOfScreen(ScreenPtr screen);

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
    public static unsafe partial int XFree(void* data);

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
    public static partial Bool XInitThreads();

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
    public static unsafe partial Bool XAddConnectionWatch(DisplayPtr display, XConnectionWatchProc procedure, void* client_data);

    // TODO 暂未使用
    // Status XRemoveConnectionWatch(Display *display, XConnectionWatchProc procedure, XPointer client_data);
    [LibraryImport(libX11)]
    public static unsafe partial Bool XRemoveConnectionWatch(DisplayPtr display, XConnectionWatchProc procedure, void* client_data);

    // TODO 暂未使用
    // void XProcessInternalConnection(Display *display, int fd);
    [LibraryImport(libX11)]
    public static partial void XProcessInternalConnection(DisplayPtr display, int fd);

    // TODO 暂未使用
    // Status XInternalConnectionNumbers(Display *display, int ** fd, int * count_return);
    [LibraryImport(libX11)]
    public static unsafe partial Bool XInternalConnectionNumbers(DisplayPtr display, int** fd, out int count_return);

    #endregion

    #endregion

    #region Window Functions

    #region Visual Types

    // TODO 暂未使用
    // VisualID XVisualIDFromVisual(Visual *visual);
    [LibraryImport(libX11)]
    public static partial XVisualId XVisualIDFromVisual(VisualPtr visual);

    #endregion

    #region Creating Windows

    // Window XCreateWindow(Display *display, Window parent, int x, int y, unsigned int width, unsigned int height, unsigned int border_width, int depth, unsigned int class, Visual *visual, unsigned long valuemask, XSetWindowAttributes *attributes);
    [LibraryImport(libX11)]
    public static partial X11Window XCreateWindow(DisplayPtr display, X11Window parent,
        int x, int y,
        uint width, uint height,
        uint border_width,
        int depth,
        WindowClasses @class,
        VisualPtr visual,
        WindowAttributeValueMask valuemask,
        in XSetWindowAttributes attributes);

    // Window XCreateSimpleWindow(Display *display, Window parent, int x, int y, unsigned int width, unsigned int height, unsigned int border_width, unsigned long border, unsigned long background);
    [LibraryImport(libX11)]
    public static partial X11Window XCreateSimpleWindow(DisplayPtr display, X11Window parent,
        int x, int y,
        uint width, uint height,
        uint border_width,
        Pixel border,
        Pixel background);

    #endregion

    #region Destroying Windows

    // XDestroyWindow(Display *display, Window w);
    [LibraryImport(libX11)]
    public static partial int XDestroyWindow(DisplayPtr display, X11Window window);

    // XDestroySubwindows(Display *display, Window w);
    [LibraryImport(libX11)]
    public static partial int XDestroySubwindows(DisplayPtr display, X11Window window);

    #endregion

    #region Mapping Windows

    // XMapWindow(Display *display, Window w);
    [LibraryImport(libX11)]
    public static partial int XMapWindow(DisplayPtr display, X11Window window);

    // XMapRaised(Display *display, Window w);
    [LibraryImport(libX11)]
    public static partial int XMapRaised(DisplayPtr display, X11Window window);

    // XMapSubwindows(Display *display, Window w);
    [LibraryImport(libX11)]
    public static partial int XMapSubwindows(DisplayPtr display, X11Window window);

    #endregion

    #region Unmapping Windows

    // XUnmapWindow(Display *display, Window w);
    [LibraryImport(libX11)]
    public static partial int XUnmapWindow(DisplayPtr display, X11Window window);

    // XUnmapSubwindows(Display *display, Window w);
    [LibraryImport(libX11)]
    public static partial int XUnmapSubwindows(DisplayPtr display, X11Window window);

    #endregion

    #region Configuring Windows

    // XConfigureWindow(Display *display, Window w, unsigned int value_mask, XWindowChanges *values);
    [LibraryImport(libX11)]
    public static partial int XConfigureWindow(DisplayPtr display, X11Window window, WindowChangeMask value_mask, in XWindowChanges values);

    // XMoveWindow(Display *display, Window w, int x, int y);
    [LibraryImport(libX11)]
    public static partial int XMoveWindow(DisplayPtr display, X11Window window, int x, int y);

    // XResizeWindow(Display *display, Window w, unsigned int width, unsigned int height);
    [LibraryImport(libX11)]
    public static partial int XResizeWindow(DisplayPtr display, X11Window window, uint width, uint height);

    // XMoveResizeWindow(Display *display, Window w, int x, int y, unsigned int width, unsigned int height);
    [LibraryImport(libX11)]
    public static partial int XMoveResizeWindow(DisplayPtr display, X11Window window, int x, int y, uint width, uint height);

    // XSetWindowBorderWidth(Display *display, Window w, unsigned int width);
    [LibraryImport(libX11)]
    public static partial int XSetWindowBorderWidth(DisplayPtr display, X11Window window, uint width);

    #endregion

    #region Changing Window Stacking Order

    // XRaiseWindow(Display *display, Window w);
    [LibraryImport(libX11)]
    public static partial int XRaiseWindow(DisplayPtr display, X11Window window);

    // XLowerWindow(Display *display, Window w);
    [LibraryImport(libX11)]
    public static partial int XLowerWindow(DisplayPtr display, X11Window window);

    // TODO 暂未使用
    // XCirculateSubwindows(Display *display, Window w, int direction);
    [LibraryImport(libX11)]
    public static partial int XCirculateSubwindows(DisplayPtr display, X11Window window, CirculationDirection direction);

    // TODO 暂未使用
    // XCirculateSubwindowsUp(Display *display, Window w);
    [LibraryImport(libX11)]
    public static partial int XCirculateSubwindowsUp(DisplayPtr display, X11Window window);

    // TODO 暂未使用
    // XCirculateSubwindowsDown(Display *display, Window w);
    [LibraryImport(libX11)]
    public static partial int XCirculateSubwindowsDown(DisplayPtr display, X11Window window);

    // TODO 暂未使用
    // XRestackWindows(Display *display, Window windows[], int nwindows);
    [LibraryImport(libX11)]
    public static partial int XRestackWindows(DisplayPtr display, [In] X11Window[] windows, int nwindows);

    #endregion

    #region Changing Window Attributes

    // XChangeWindowAttributes(Display *display, Window w, unsigned long valuemask, XSetWindowAttributes *attributes);
    [LibraryImport(libX11)]
    public static partial int XChangeWindowAttributes(DisplayPtr display, X11Window window, WindowAttributeValueMask valuemask,
        in XSetWindowAttributes attributes);

    // XSetWindowBackground(Display *display, Window w, unsigned long background_pixel);
    [LibraryImport(libX11)]
    public static partial int XSetWindowBackground(DisplayPtr display, X11Window window, Pixel background_pixel);

    // TODO 暂未使用
    // XSetWindowBackgroundPixmap(Display *display, Window w, Pixmap background_pixmap);
    [LibraryImport(libX11)]
    public static partial int XSetWindowBackgroundPixmap(DisplayPtr display, X11Window window, X11Pixmap background_pixmap);

    // XSetWindowBorder(Display *display, Window w, unsigned long border_pixel);
    [LibraryImport(libX11)]
    public static partial int XSetWindowBorder(DisplayPtr display, X11Window window, Pixel border_pixel);

    // TODO 暂未使用
    // XSetWindowBorderPixmap(Display *display, Window w, Pixmap border_pixmap);
    [LibraryImport(libX11)]
    public static partial int XSetWindowBorderPixmap(DisplayPtr display, X11Window window, X11Pixmap border_pixmap);

    // TODO 暂未使用
    // XSetWindowColormap(Display *display, Window w, Colormap colormap);
    [LibraryImport(libX11)]
    public static partial int XSetWindowColormap(DisplayPtr display, X11Window window, X11Colormap colormap);

    // TODO 暂未使用
    // XDefineCursor(Display *display, Window w, Cursor cursor);
    [LibraryImport(libX11)]
    public static partial int XDefineCursor(DisplayPtr display, X11Window window, X11Cursor cursor);

    // TODO 暂未使用
    // XUndefineCursor(Display *display, Window w);
    [LibraryImport(libX11)]
    public static partial int XUndefineCursor(DisplayPtr display, X11Window window);

    #endregion

    #endregion

    #region Window Information Functions

    #region Obtaining Window Information

    // Status XQueryTree(Display *display, Window w, Window *root_return, Window *parent_return, Window **children_return, unsigned int *nchildren_return);
    [LibraryImport(libX11)]
    public static unsafe partial Bool XQueryTree(DisplayPtr display, X11Window window, out X11Window root_return, out X11Window parent_return,
        out X11Window* children_return, out uint nchildren_return);

    // Status XGetWindowAttributes(Display *display, Window w, XWindowAttributes *window_attributes_return);
    [LibraryImport(libX11)]
    public static partial Bool XGetWindowAttributes(DisplayPtr display, X11Window window, out XWindowAttributes window_attributes_return);

    // TODO 暂未使用
    // Status XGetGeometry(Display *display, Drawable d, Window *root_return, int *x_return, int *y_return, unsigned int *width_return, unsigned int *height_return, unsigned int *border_width_return, unsigned int *depth_return);
    [LibraryImport(libX11)]
    public static partial Bool XGetGeometry(DisplayPtr display, X11Drawable drawable, out X11Window root_return, out int x_return, out int y_return,
        out uint width_return, out uint height_return, out uint border_width_return, out uint depth_return);

    #endregion

    #region Translating Screen Coordinates

    // Bool XTranslateCoordinates(Display *display, Window src_w, Window dest_w, int src_x, int src_y, int *dest_x_return, int *dest_y_return, Window *child_return);
    [LibraryImport(libX11)]
    public static partial Bool XTranslateCoordinates(DisplayPtr display, X11Window src_w, X11Window dest_w, int src_x, int src_y, out int dest_x_return,
        out int dest_y_return, out X11Window child_return);

    // Bool XQueryPointer(Display *display, Window w, Window *root_return, Window *child_return, int *root_x_return, int *root_y_return, int *win_x_return, int *win_y_return, unsigned int *mask_return);
    [LibraryImport(libX11)]
    public static partial Bool XQueryPointer(DisplayPtr display, X11Window window, out X11Window root_return, out X11Window child_return,
        out int root_x_return, out int root_y_return, out int win_x_return, out int win_y_return, out KeyOrButtonMask mask_return);

    #endregion

    #region Properties and Atoms

    // Atom XInternAtom(Display *display, char *atom_name, Bool only_if_exists);
    [LibraryImport(libX11, StringMarshalling = StringMarshalling.Utf8)]
    public static partial X11Atom XInternAtom(DisplayPtr display, string atom_name, Bool only_if_exists);

    // TODO 暂未使用
    // Status XInternAtoms(Display *display, char **names, int count, Bool only_if_exists, Atom *atoms_return);
    [LibraryImport(libX11, StringMarshalling = StringMarshalling.Utf8)]
    public static unsafe partial Bool XInternAtoms(DisplayPtr display, [In] string[] names, int count, Bool only_if_exists, [In] [Out] X11Atom[] atoms_return);

    // char *XGetAtomName(Display *display, Atom atom);
    [LibraryImport(libX11)]
    public static unsafe partial byte* XGetAtomName(DisplayPtr display, X11Atom atom);

    // TODO 暂未使用
    // Status XGetAtomNames(Display *display, Atom *atoms, int count, char **names_return);
    [LibraryImport(libX11)]
    public static unsafe partial Bool XGetAtomNames(DisplayPtr display, [In] X11Atom[] atoms, int count, byte** names_return);

    #endregion

    #region Obtaining and Changing Window Properties

    // int XGetWindowProperty(Display *display, Window w, Atom property, long long_offset, long long_length, Bool delete, Atom req_type, Atom *actual_type_return, int *actual_format_return, unsigned long *nitems_return, unsigned long *bytes_after_return, unsigned char **prop_return);
    [LibraryImport(libX11)]
    public static unsafe partial int XGetWindowProperty(DisplayPtr display, X11Window window, X11Atom property, Long long_offset, Long long_length,
        Bool delete, X11Atom req_type, out X11Atom actual_type_return, out int actual_format_return, out ULong nitems_return, out ULong bytes_after_return,
        out void* prop_return);

    // Atom *XListProperties(Display *display, Window w, int *num_prop_return);
    [LibraryImport(libX11)]
    public static unsafe partial X11Atom* XListProperties(DisplayPtr display, X11Window window, out int num_prop_return);

    // XChangeProperty(Display *display, Window w, Atom property, Atom type, int format, int mode, unsignedchar *data, int nelements);
    [LibraryImport(libX11)]
    public static unsafe partial int XChangeProperty(DisplayPtr display, X11Window window, X11Atom property, X11Atom type, int format, PropertyMode mode,
        void* data, int nelements);

    // TODO 暂未使用
    // XRotateWindowProperties(Display *display, Window w, Atom properties[], int num_prop, int npositions);
    [LibraryImport(libX11)]
    public static unsafe partial int XRotateWindowProperties(DisplayPtr display, X11Window window, [In] X11Atom[] properties, int num_prop, int npositions);

    // XDeleteProperty(Display *display, Window w, Atom property);
    [LibraryImport(libX11)]
    public static partial int XDeleteProperty(DisplayPtr display, X11Window window, X11Atom property);

    #endregion

    #region Selections

    // TODO 暂未使用
    // XSetSelectionOwner(Display *display, Atom selection, Window owner, Time time);
    [LibraryImport(libX11)]
    public static partial int XSetSelectionOwner(DisplayPtr display, X11Atom selection, X11Window owner, Time time);

    // TODO 暂未使用
    // Window XGetSelectionOwner(Display *display, Atom selection);
    [LibraryImport(libX11)]
    public static partial X11Window XGetSelectionOwner(DisplayPtr display, X11Atom selection);

    // TODO 暂未使用
    // XConvertSelection(Display *display, Atom selection, Atom target, Atom property, Window requestor, Time time);
    [LibraryImport(libX11)]
    public static partial int XConvertSelection(DisplayPtr display, X11Atom selection, X11Atom target, X11Atom property, X11Window requestor, Time time);

    #endregion

    #endregion

    // TODO Color Management Functions 待补充

    #region Pixmap and Cursor Functions

    #region Creating and Freeing Pixmaps

    // Pixmap XCreatePixmap(Display *display, Drawable d, unsigned int width, unsigned int height, unsigned int depth);
    [LibraryImport(libX11)]
    public static partial X11Pixmap XCreatePixmap(DisplayPtr display, X11Drawable drawable, uint width, uint height, uint depth);

    // XFreePixmap(Display *display, Pixmap pixmap);
    [LibraryImport(libX11)]
    public static partial int XFreePixmap(DisplayPtr display, X11Pixmap pixmap);

    #endregion

    #region Creating, Recoloring, and Freeing Cursors

    // Cursor XCreateFontCursor(Display *display, unsigned int shape);
    [LibraryImport(libX11)]
    public static partial X11Cursor XCreateFontCursor(DisplayPtr display, CursorShape shape);

    // TODO 暂未使用
    // Cursor XCreateGlyphCursor(Display *display, Font source_font, Font mask_font, unsigned int source_char, unsigned int mask_char, XColor *foreground_color, XColor *background_color);
    [LibraryImport(libX11)]
    public static partial X11Cursor XCreateGlyphCursor(DisplayPtr display, X11Font source_font, X11Font mask_font, uint source_char, uint mask_char,
        in XColor foreground_color, in XColor background_color);

    // Cursor XCreatePixmapCursor(Display *display, Pixmap source, Pixmap mask, XColor *foreground_color, XColor *background_color, unsigned int x, unsigned int y);
    [LibraryImport(libX11)]
    public static partial X11Cursor XCreatePixmapCursor(DisplayPtr display, X11Pixmap source, X11Pixmap mask, in XColor foreground_color, in XColor background_color, uint x, uint y);

    // Status XQueryBestCursor(Display *display, Drawable d, unsigned int width, unsigned int height, unsigned int *width_return, unsigned int *height_return);
    [LibraryImport(libX11)]
    public static partial Bool XQueryBestCursor(DisplayPtr display, X11Drawable drawable, uint width, uint height, out uint width_return, out uint height_return);

    // XRecolorCursor(Display *display, Cursor cursor, XColor *foreground_color, XColor *background_color);
    [LibraryImport(libX11)]
    public static partial int XRecolorCursor(DisplayPtr display, X11Cursor cursor, in XColor foreground_color, in XColor background_color);

    // XFreeCursor(Display *display, Cursor cursor);
    [LibraryImport(libX11)]
    public static partial int XFreeCursor(DisplayPtr display, X11Cursor cursor);

    #endregion

    #endregion

    #region Graphics Context Functions

    #region Manipulating Graphics Context/State

    // GC XCreateGC(Display *display, Drawable d, unsigned long valuemask, XGCValues *values);
    [LibraryImport(libX11)]
    public static partial GCPtr XCreateGC(DisplayPtr display, X11Drawable drawable, GCValueMarks valuemask, in XGCValues values);

    // TODO 暂未使用
    // XCopyGC(Display *display, GC src, GC dest, unsigned long valuemask);
    [LibraryImport(libX11)]
    public static partial int XCopyGC(DisplayPtr display, GCPtr src, GCPtr dest, GCValueMarks valuemask);

    // TODO 暂未使用
    // XChangeGC(Display *display, GC gc, unsigned long valuemask, XGCValues *values);
    [LibraryImport(libX11)]
    public static partial int XChangeGC(DisplayPtr display, GCPtr gc, GCValueMarks valuemask, in XGCValues values);

    // TODO 暂未使用
    // Status XGetGCValues(Display *display, GC gc, unsigned long valuemask, XGCValues *values_return);
    [LibraryImport(libX11)]
    public static partial Bool XGetGCValues(DisplayPtr display, GCPtr gc, GCValueMarks valuemask, out XGCValues values_return);

    // TODO 暂未使用
    // XFreeGC(Display *display, GC gc);
    [LibraryImport(libX11)]
    public static partial int XFreeGC(DisplayPtr display, GCPtr gc);

    // GContext XGContextFromGC(GC gc);
    [LibraryImport(libX11)]
    public static partial X11GContext XGContextFromGC(GCPtr gc);

    // void XFlushGC(Display *display, GC gc);
    [LibraryImport(libX11)]
    public static partial void XFlushGC(DisplayPtr display, GCPtr gc);

    #endregion

    #region Using Graphics Context Convenience Routines

    #region Setting the Foreground, Background, Function, or Plane Mask

    // XSetState(Display *display, GC gc, unsigned long foreground, unsigned long background, int function, unsigned long plane_mask);
    [LibraryImport(libX11)]
    public static partial int XSetState(DisplayPtr display, GCPtr gc, Pixel foreground, Pixel background, GraphicsFunctions function, ULong plane_mask);

    // XSetForeground(Display *display, GC gc, unsigned long foreground);
    [LibraryImport(libX11)]
    public static partial int XSetForeground(DisplayPtr display, GCPtr gc, Pixel foreground);

    // XSetBackground(Display *display, GC gc, unsigned long background);
    [LibraryImport(libX11)]
    public static partial int XSetBackground(DisplayPtr display, GCPtr gc, Pixel background);

    // XSetFunction(Display *display, GC gc, int function);
    [LibraryImport(libX11)]
    public static partial int XSetFunction(DisplayPtr display, GCPtr gc, GraphicsFunctions function);

    // XSetPlaneMask(Display *display, GC gc, unsigned long plane_mask);
    [LibraryImport(libX11)]
    public static partial int XSetPlaneMask(DisplayPtr display, GCPtr gc, ULong plane_mask);

    #endregion

    #region Setting the Line Attributes and Dashes

    // XSetLineAttributes(Display *display, GC gc, unsigned int line_width, int line_style, int cap_style, int join_style);
    [LibraryImport(libX11)]
    public static partial int XSetLineAttributes(DisplayPtr display, GCPtr gc, uint line_width, LineStyle line_style, CapStyle cap_style, JoinStyle join_style);

    // XSetDashes(Display *display, GC gc, int dash_offset, char dash_list[], int n);
    [LibraryImport(libX11)]
    public static unsafe partial int XSetDashes(DisplayPtr display, GCPtr gc, int dash_offset, byte* dash_list, int n);

    #endregion

    #region Setting the Fill Style and Fill Rule

    // XSetFillStyle(Display *display, GC gc, int fill_style);
    [LibraryImport(libX11)]
    public static partial int XSetFillStyle(DisplayPtr display, GCPtr gc, FillStyle fill_style);

    // XSetFillRule(Display *display, GC gc, int fill_rule);
    [LibraryImport(libX11)]
    public static partial int XSetFillRule(DisplayPtr display, GCPtr gc, FillRule fill_rule);

    #endregion

    #region Setting the Fill Tile and Stipple

    // Status XQueryBestSize(Display *display, int class, Drawable which_screen, unsigned int width, unsigned int height, unsigned int *width_return, unsigned int *height_return);
    [LibraryImport(libX11)]
    public static partial Bool XQueryBestSize(DisplayPtr display, QueryBestSizeClass @class, X11Drawable which_screen, uint width, uint height, out uint width_return, out uint height_return);

    // Status XQueryBestTile(Display *display, Drawable which_screen, unsigned int width, unsigned int height, unsigned int *width_return, unsigned int *height_return);
    [LibraryImport(libX11)]
    public static partial Bool XQueryBestTile(DisplayPtr display, X11Drawable which_screen, uint width, uint height, out uint width_return, out uint height_return);

    // Status XQueryBestStipple(Display *display, Drawable which_screen, unsigned int width, unsigned int height, unsigned int *width_return, unsigned int *height_return);
    [LibraryImport(libX11)]
    public static partial Bool XQueryBestStipple(DisplayPtr display, X11Drawable which_screen, uint width, uint height, out uint width_return, out uint height_return);

    // XSetTile(Display *display, GC gc, Pixmap tile);
    [LibraryImport(libX11)]
    public static partial int XSetTile(DisplayPtr display, GCPtr gc, X11Pixmap tile);

    // XSetStipple(Display *display, GC gc, Pixmap stipple);
    [LibraryImport(libX11)]
    public static partial int XSetStipple(DisplayPtr display, GCPtr gc, X11Pixmap stipple);

    // XSetTSOrigin(Display *display, GC gc, int ts_x_origin, int ts_y_origin);
    [LibraryImport(libX11)]
    public static partial int XSetTSOrigin(DisplayPtr display, GCPtr gc, int ts_x_origin, int ts_y_origin);

    #endregion

    #region Setting the Current Font

    // XSetFont(Display *display, GC gc, Font font);
    [LibraryImport(libX11)]
    public static partial int XSetFont(DisplayPtr display, GCPtr gc, X11Font font);

    #endregion

    #region Setting the Clip Region

    // XSetClipOrigin(Display *display, GC gc, int clip_x_origin, int clip_y_origin);
    [LibraryImport(libX11)]
    public static partial int XSetClipOrigin(DisplayPtr display, GCPtr gc, int clip_x_origin, int clip_y_origin);

    // XSetClipMask(Display *display, GC gc, Pixmap pixmap);
    [LibraryImport(libX11)]
    public static partial int XSetClipMask(DisplayPtr display, GCPtr gc, X11Pixmap pixmap);

    // XSetClipRectangles(Display *display, GC gc, int clip_x_origin, int clip_y_origin, XRectangle rectangles[], int n, int ordering);
    [LibraryImport(libX11)]
    public static unsafe partial int XSetClipRectangles(DisplayPtr display, GCPtr gc, int clip_x_origin, int clip_y_origin, Rectangle* rectangles, int n, RectanglesOrdering ordering);

    #endregion

    #region Setting the Arc Mode, Subwindow Mode, and Graphics Exposure

    // XSetArcMode(Display *display, GC gc, int arc_mode);
    [LibraryImport(libX11)]
    public static partial int XSetArcMode(DisplayPtr display, GCPtr gc, ArcMode arc_mode);

    // XSetSubwindowMode(Display *display, GC gc, int subwindow_mode);
    [LibraryImport(libX11)]
    public static partial int XSetSubwindowMode(DisplayPtr display, GCPtr gc, SubwindowMode subwindow_mode);

    // XSetGraphicsExposures(Display *display, GC gc, Bool graphics_exposures);
    [LibraryImport(libX11)]
    public static partial int XSetGraphicsExposures(DisplayPtr display, GCPtr gc, Bool graphics_exposures);

    #endregion

    #endregion

    #endregion

    #region Graphics Functions

    #region Clearing Areas

    // XClearArea(Display *display, Window w, int x, int y, unsigned int width, unsigned int height, Bool exposures);
    [LibraryImport(libX11)]
    public static partial int XClearArea(DisplayPtr display, X11Window window, int x, int y, uint width, uint height, Bool exposures);

    // XClearWindow(Display *display, Window w);
    [LibraryImport(libX11)]
    public static partial int XClearWindow(DisplayPtr display, X11Window window);

    #endregion

    #region Copying Areas

    // XCopyArea(Display *display, Drawable src, Drawable dest, GC gc, int src_x, int src_y, unsigned int width, unsigned int height, int dest_x, int dest_y);
    [LibraryImport(libX11)]
    public static partial int XCopyArea(DisplayPtr display, X11Drawable src, X11Drawable dest, GCPtr gc, int src_x, int src_y, uint width, uint height, int dest_x, int dest_y);

    // XCopyPlane(Display *display, Drawable src, Drawable dest, GC gc, int src_x, int src_y, unsigned int width, unsigned int height, int dest_x, int dest_y, unsigned long plane);
    [LibraryImport(libX11)]
    public static partial int XCopyPlane(DisplayPtr display, X11Drawable src, X11Drawable dest, GCPtr gc, int src_x, int src_y, uint width, uint height, int dest_x, int dest_y, ULong plane);

    #endregion

    #region Drawing Points, Lines, Rectangles, and Arcs

    #region Drawing Single and Multiple Points

    // XDrawPoint(Display *display, Drawable d, GC gc, int x, int y);
    [LibraryImport(libX11)]
    public static partial int XDrawPoint(DisplayPtr display, X11Drawable drawable, GCPtr gc, int x, int y);

    // XDrawPoints(Display *display, Drawable d, GC gc, XPoint *points, int npoints, int mode);
    [LibraryImport(libX11)]
    public static unsafe partial int XDrawPoints(DisplayPtr display, X11Drawable drawable, GCPtr gc, X11Point* points, int npoints, CoordMode mode);

    #endregion

    #region Drawing Single and Multiple Lines

    // XDrawLine(Display *display, Drawable d, GC gc, int x1, int y1, int x2, int y2);
    [LibraryImport(libX11)]
    public static partial int XDrawLine(DisplayPtr display, X11Drawable drawable, GCPtr gc, int x1, int y1, int x2, int y2);

    // XDrawLines(Display *display, Drawable d, GC gc, XPoint *points, int npoints, int mode);
    [LibraryImport(libX11)]
    public static unsafe partial int XDrawLines(DisplayPtr display, X11Drawable drawable, GCPtr gc, X11Point* points, int npoints, CoordMode mode);

    // XDrawSegments(Display *display, Drawable d, GC gc, XSegment *segments, int nsegments);
    [LibraryImport(libX11)]
    public static unsafe partial int XDrawSegments(DisplayPtr display, X11Drawable drawable, GCPtr gc, X11Segment* segments, int nsegments);

    #endregion

    #region Drawing Single and Multiple Rectangles

    // XDrawRectangle(Display *display, Drawable d, GC gc, int x, int y, unsigned int width, unsigned int height);
    [LibraryImport(libX11)]
    public static partial int XDrawRectangle(DisplayPtr display, X11Drawable drawable, GCPtr gc, int x, int y, uint width, uint height);

    // XDrawRectangles(Display *display, Drawable d, GC gc, XRectangle rectangles[], int nrectangles);
    [LibraryImport(libX11)]
    public static unsafe partial int XDrawRectangles(DisplayPtr display, X11Drawable drawable, GCPtr gc, X11Rectangle* rectangles, int nrectangles);

    #endregion

    #region Drawing Single and Multiple Arcs

    // XDrawArc(Display *display, Drawable d, GC gc, int x, int y, unsigned int width, unsigned int height, int angle1, int angle2);
    [LibraryImport(libX11)]
    public static partial int XDrawArc(DisplayPtr display, X11Drawable drawable, GCPtr gc, int x, int y, uint width, uint height, int angle1, int angle2);

    // XDrawArcs(Display *display, Drawable d, GC gc, XArc *arcs, int narcs);
    [LibraryImport(libX11)]
    public static unsafe partial int XDrawArcs(DisplayPtr display, X11Drawable drawable, GCPtr gc, X11Arc* arcs, int narcs);

    #endregion

    #endregion

    #region Filling Areas

    #region Filling Single and Multiple Rectangles

    // XFillRectangle(Display *display, Drawable d, GC gc, int x, int y, unsigned int width, unsigned int height);
    [LibraryImport(libX11)]
    public static partial int XFillRectangle(DisplayPtr display, X11Drawable drawable, GCPtr gc, int x, int y, uint width, uint height);

    // XFillRectangles(Display *display, Drawable d, GC gc, XRectangle *rectangles, int nrectangles);
    [LibraryImport(libX11)]
    public static unsafe partial int XFillRectangles(DisplayPtr display, X11Drawable drawable, GCPtr gc, X11Rectangle* rectangles, int nrectangles);

    #endregion

    #region Filling a Single Polygon

    // XFillPolygon(Display *display, Drawable d, GC gc, XPoint *points, int npoints, int shape, int mode);
    [LibraryImport(libX11)]
    public static unsafe partial int XFillPolygon(DisplayPtr display, X11Drawable drawable, GCPtr gc, X11Point* points, int npoints, PolygonShape shape, CoordMode mode);

    #endregion

    #region Filling Single and Multiple Arcs

    // TODO 暂未使用
    // XFillArc(Display *display, Drawable d, GC gc, int x, int y, unsigned int width, unsigned int height, int angle1, int angle2);
    [LibraryImport(libX11)]
    public static partial int XFillArc(DisplayPtr display, X11Drawable drawable, GCPtr gc, int x, int y, uint width, uint height, int angle1, int angle2);

    // TODO 暂未使用
    // XFillArcs(Display *display, Drawable d, GC gc, XArc *arcs, int narcs);
    [LibraryImport(libX11)]
    public static unsafe partial int XFillArcs(DisplayPtr display, X11Drawable drawable, GCPtr gc, X11Arc* arcs, int narcs);

    #endregion

    #endregion

    #region Font Metrics

    #region Loading and Freeing Fonts

    // TODO 待补充

    #endregion

    #region Obtaining and Freeing Font Names and Information

    // TODO 待补充

    #endregion

    #region Computing Character String Sizes

    // TODO 待补充

    #endregion

    #region Computing Logical Extents

    // TODO 待补充

    #endregion

    #region Querying Character String Sizes

    // TODO 待补充

    #endregion

    #endregion

    #region Drawing Text

    #region Drawing Complex Text

    // TODO 待补充

    #endregion

    #region Drawing Text Characters

    // TODO 待补充

    #endregion

    #region Drawing Image Text Characters

    // TODO 待补充

    #endregion

    #endregion

    #region Transferring Images between Client and Server

    // Status XInitImage(XImage *image);
    [LibraryImport(libX11)]
    public static unsafe partial Bool XInitImage(XImage* image);

    // XPutImage(Display *display, Drawable d, GC gc, XImage *image, int src_x, int src_y, int dest_x, int dest_y, unsigned int width, unsigned int height);
    [LibraryImport(libX11)]
    public static unsafe partial int XPutImage(DisplayPtr display, X11Drawable drawable, GCPtr gc, XImage* image, int src_x, int src_y, int dest_x, int dest_y, uint width, uint height);

    // XImage *XGetImage(Display *display, Drawable d, int x, int y, unsigned int width, unsigned int height, unsigned long plane_mask, int format);
    [LibraryImport(libX11)]
    public static unsafe partial XImage* XGetImage(DisplayPtr display, X11Drawable drawable, int x, int y, uint width, uint height, ULong plane_mask, ImageFormat format);

    // TODO 暂未使用
    // XImage *XGetSubImage(Display *display, Drawable d, int x, int y, unsigned int width, unsigned int height, unsigned long plane_mask, int format, XImage *dest_image, int dest_x, int dest_y);
    [LibraryImport(libX11)]
    public static unsafe partial XImage* XGetSubImage(DisplayPtr display, X11Drawable drawable, int x, int y, uint width, uint height, ULong plane_mask, ImageFormat format, XImage* dest_image, int dest_x, int dest_y);

    #endregion

    #endregion

    #region Window and Session Manager Functions

    #region Changing the Parent of a Window

    // XReparentWindow(Display *display, Window w, Window parent, int x, int y);
    [LibraryImport(libX11)]
    public static partial int XReparentWindow(DisplayPtr display, X11Window window, X11Window parent, int x, int y);

    #endregion

    #region Controlling the Lifetime of a Window

    // XChangeSaveSet(Display *display, Window w, int change_mode);
    [LibraryImport(libX11)]
    public static partial int XChangeSaveSet(DisplayPtr display, X11Window window, SetMode change_mode);

    // XAddToSaveSet(Display *display, Window w);
    [LibraryImport(libX11)]
    public static partial int XAddToSaveSet(DisplayPtr display, X11Window window);

    // XRemoveFromSaveSet(Display *display, Window w);
    [LibraryImport(libX11)]
    public static partial int XRemoveFromSaveSet(DisplayPtr display, X11Window window);

    #endregion

    #region Managing Installed Colormaps

    // XInstallColormap(Display *display, Colormap colormap);
    [LibraryImport(libX11)]
    public static partial int XInstallColormap(DisplayPtr display, X11Colormap colormap);

    // TODO 暂未使用
    // XUninstallColormap(Display *display, Colormap colormap);
    [LibraryImport(libX11)]
    public static partial int XUninstallColormap(DisplayPtr display, X11Colormap colormap);

    // TODO 暂未使用
    // Colormap *XListInstalledColormaps(Display *display, Window w, int *num_return);
    [LibraryImport(libX11)]
    public static unsafe partial X11Colormap* XListInstalledColormaps(DisplayPtr display, X11Window window, out int num_return);

    #endregion

    #region Setting and Retrieving the Font Search Path

    // TODO 暂未使用
    // XSetFontPath(Display *display, char **directories, int ndirs);
    [LibraryImport(libX11, StringMarshalling = StringMarshalling.Utf8)]
    public static partial int XSetFontPath(DisplayPtr display, [In] string[] directories, int ndirs);

    // TODO 暂未使用
    // char **XGetFontPath(Display *display, int *npaths_return);
    [LibraryImport(libX11)]
    public static unsafe partial byte** XGetFontPath(DisplayPtr display, out int npaths_return);

    // TODO 暂未使用
    // XFreeFontPath(char **list);
    [LibraryImport(libX11)]
    public static unsafe partial void XFreeFontPath(byte** list);

    #endregion

    #region Grabbing the Server

    // TODO 暂未使用
    // XGrabServer(Display *display);
    [LibraryImport(libX11)]
    public static partial int XGrabServer(DisplayPtr display);

    #endregion

    #endregion

    #region Event Handling Functions

    #region Selecting Events

    // XSelectInput(Display *display, Window w, long event_mask);
    [LibraryImport(libX11)]
    public static partial int XSelectInput(DisplayPtr display, X11Window window, EventMask event_mask);

    #endregion

    #region Handling the Output Buffer

    // XFlush(Display *display);
    [LibraryImport(libX11)]
    public static partial int XFlush(DisplayPtr display);

    // XSync(Display *display, Bool discard);
    [LibraryImport(libX11)]
    public static partial int XSync(DisplayPtr display, Bool discard);

    #endregion

    #region Event Queue Management

    // int XEventsQueued(Display *display, int mode);
    [LibraryImport(libX11)]
    public static partial int XEventsQueued(DisplayPtr display, EventsQueuedMode mode);

    // int XPending(Display *display);
    [LibraryImport(libX11)]
    public static partial int XPending(DisplayPtr display);

    #endregion

    #region Manipulating the Event Queue

    // XNextEvent(Display *display, XEvent *event_return);
    [LibraryImport(libX11)]
    public static partial int XNextEvent(DisplayPtr display, out XEvent event_return);

    // XPeekEvent(Display *display, XEvent *event_return);
    [LibraryImport(libX11)]
    public static partial int XPeekEvent(DisplayPtr display, out XEvent event_return);

    #endregion

    #region Selecting Events Using a Predicate Procedure

    // TODO 暂未使用
    // XIfEvent(Display *display, XEvent *event_return, Bool (*predicate)(), XPointer arg);
    [LibraryImport(libX11)]
    public static unsafe partial int XIfEvent(DisplayPtr display, out XEvent event_return, XEventPredicate predicate, void* arg);

    // TODO 暂未使用
    // Bool XCheckIfEvent(Display *display, XEvent *event_return, Bool (*predicate)(), XPointer arg);
    [LibraryImport(libX11)]
    public static unsafe partial Bool XCheckIfEvent(DisplayPtr display, out XEvent event_return, XEventPredicate predicate, void* arg);

    // TODO 暂未使用
    // XPeekIfEvent(Display *display, XEvent *event_return, Bool (*predicate)(), XPointer arg);
    [LibraryImport(libX11)]
    public static unsafe partial int XPeekIfEvent(DisplayPtr display, out XEvent event_return, XEventPredicate predicate, void* arg);

    #endregion

    #region Selecting Events Using a Window or Event Mask

    // XWindowEvent(Display *display, Window w, long event_mask, XEvent *event_return);
    [LibraryImport(libX11)]
    public static partial int XWindowEvent(DisplayPtr display, X11Window window, EventMask event_mask, out XEvent event_return);

    // Bool XCheckWindowEvent(Display *display, Window w, long event_mask, XEvent *event_return);
    [LibraryImport(libX11)]
    public static partial Bool XCheckWindowEvent(DisplayPtr display, X11Window window, EventMask event_mask, out XEvent event_return);

    // XMaskEvent(Display *display, long event_mask, XEvent *event_return);
    [LibraryImport(libX11)]
    public static partial int XMaskEvent(DisplayPtr display, EventMask event_mask, out XEvent event_return);

    // Bool XCheckMaskEvent(Display *display, long event_mask, XEvent *event_return);
    [LibraryImport(libX11)]
    public static partial Bool XCheckMaskEvent(DisplayPtr display, EventMask event_mask, out XEvent event_return);

    // Bool XCheckTypedEvent(Display *display, int event_type, XEvent *event_return);
    [LibraryImport(libX11)]
    public static partial Bool XCheckTypedEvent(DisplayPtr display, EventType event_type, out XEvent event_return);

    // Bool XCheckTypedWindowEvent(Display *display, Window w, int event_type, XEvent *event_return);
    [LibraryImport(libX11)]
    public static partial Bool XCheckTypedWindowEvent(DisplayPtr display, X11Window window, EventType event_type, out XEvent event_return);

    #endregion

    #region Putting an Event Back into the Queue

    // XPutBackEvent(Display *display, XEvent *event);
    [LibraryImport(libX11)]
    public static partial int XPutBackEvent(DisplayPtr display, in XEvent @event);

    #endregion

    #region Sending Events to Other Applications

    // Status XSendEvent(Display *display, Window w, Bool propagate, long event_mask, XEvent *event_send);
    [LibraryImport(libX11)]
    public static partial Bool XSendEvent(DisplayPtr display, X11Window window, Bool propagate, EventMask event_mask, in XEvent event_send);

    #endregion

    #region Getting Pointer Motion History

    // XTimeCoord *XGetMotionEvents(Display *display, Window w, Time start, Time stop, int *nevents_return);
    [LibraryImport(libX11)]
    public static unsafe partial TimeCoord* XGetMotionEvents(DisplayPtr display, X11Window window, Time start, Time stop, out int nevents_return);

    #endregion

    #region Handling Protocol Errors

    // TODO 暂未使用
    // int(Display *display, int (*procedure)());
    [LibraryImport(libX11)]
    public static unsafe partial delegate*<DisplayPtr, int> XSetAfterFunction(DisplayPtr display, delegate*<DisplayPtr, int> procedure);

    // TODO 暂未使用
    // int(Display *display, Bool onoff);
    [LibraryImport(libX11)]
    public static unsafe partial delegate*<DisplayPtr, int> XSynchronize(DisplayPtr display, Bool onoff);

    #endregion

    #region Using the Default Error Handlers

    // TODO 暂未使用
    // int *XSetErrorHandler(int *handler);
    [LibraryImport(libX11)]
    public static unsafe partial delegate*<DisplayPtr, XErrorEvent*, int> XSetErrorHandler(delegate*<DisplayPtr, XErrorEvent*, int> handler);

    // TODO 暂未使用
    // XGetErrorText(Display *display, int code, char *buffer_return, int length);
    [LibraryImport(libX11, StringMarshalling = StringMarshalling.Utf8)]
    public static unsafe partial int XGetErrorText(DisplayPtr display, int code, byte* buffer_return, int length);

    // TODO 暂未使用
    // XGetErrorDatabaseText(Display *display, char *name, char *message, char *default_string, char *buffer_return, int length);
    [LibraryImport(libX11, StringMarshalling = StringMarshalling.Utf8)]
    public static unsafe partial int XGetErrorDatabaseText(DisplayPtr display, string name, string message, string default_string, byte* buffer_return,
        int length);

    // TODO 暂未使用
    // char *XDisplayName(char *string);
    [LibraryImport(libX11, StringMarshalling = StringMarshalling.Utf8)]
    public static unsafe partial byte* XDisplayName(string @string);

    // TODO 暂未使用
    // int(int(*handler)(Display *));
    [LibraryImport(libX11)]
    public static unsafe partial delegate*<DisplayPtr, int> XSetIOErrorHandler(delegate*<DisplayPtr, int> handler);

    #endregion

    #endregion

    // 下面是单独实现的一些函数，因为有些函数比较需要用到

    // XSetInputFocus(Display *display, Window focus, int revert_to, Time time);
    [LibraryImport(libX11)]
    public static partial int XSetInputFocus(DisplayPtr display, X11Window focus, FocusRevert revert_to, Time time);

    // XGetInputFocus(Display *display, Window *focus_return, int *revert_to_return);
    [LibraryImport(libX11)]
    public static partial int XGetInputFocus(DisplayPtr display, out X11Window focus_return, out FocusRevert revert_to_return);
}
