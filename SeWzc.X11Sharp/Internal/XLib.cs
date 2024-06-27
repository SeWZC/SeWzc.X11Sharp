using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;
using SeWzc.X11Sharp.Structs;
using SeWzc.X11Sharp.Xid;

// ReSharper disable UnusedMember.Local
// ReSharper disable InconsistentNaming

namespace SeWzc.X11Sharp.Internal;

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

    // TODO 暂未使用
    // unsigned long XNextRequest(Display *display);
    [LibraryImport(libX11)]
    public static partial ULong XNextRequest(DisplayPtr display);

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

    // TODO 暂未使用
    // XPixmapFormatValues *XListPixmapFormats(Display *display, int *count_return);
    [LibraryImport(libX11)]
    public static unsafe partial XPixmapFormatValues* XListPixmapFormats(DisplayPtr display, out int count);

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
    public static partial Bool XAddConnectionWatch(DisplayPtr display, XConnectionWatchProc procedure, XPointer client_data);

    // TODO 暂未使用
    // Status XRemoveConnectionWatch(Display *display, XConnectionWatchProc procedure, XPointer client_data);
    [LibraryImport(libX11)]
    public static partial Bool XRemoveConnectionWatch(DisplayPtr display, XConnectionWatchProc procedure, XPointer client_data);

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

    // TODO 暂未使用
    // Bool XTranslateCoordinates(Display *display, Window src_w, Window dest_w, int src_x, int src_y, int *dest_x_return, int *dest_y_return, Window *child_return);
    [LibraryImport(libX11)]
    public static partial Bool XTranslateCoordinates(DisplayPtr display, X11Window src_w, X11Window dest_w, int src_x, int src_y, out int dest_x_return,
        out int dest_y_return, out X11Window child_return);

    // TODO 暂未使用
    // Bool XQueryPointer(Display *display, Window w, Window *root_return, Window *child_return, int *root_x_return, int *root_y_return, int *win_x_return, int *win_y_return, unsigned int *mask_return);
    [LibraryImport(libX11)]
    public static partial Bool XQueryPointer(DisplayPtr display, X11Window window, out X11Window root_return, out X11Window child_return,
        out int root_x_return, out int root_y_return, out int win_x_return, out int win_y_return, out uint mask_return);

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

    #region Graphics Context Functions

    #region Manipulating Graphics Context/State

    // GC XCreateGC(Display *display, Drawable d, unsigned long valuemask, XGCValues *values);
    [LibraryImport(libX11)]
    public static partial GCPtr XCreateGC(DisplayPtr display, X11Drawable drawable, GCValueMarks valuemask, in XGCValues values);

    // XCopyGC(Display *display, GC src, GC dest, unsigned long valuemask);
    [LibraryImport(libX11)]
    public static partial int XCopyGC(DisplayPtr display, GCPtr src, GCPtr dest, GCValueMarks valuemask);

    // XChangeGC(Display *display, GC gc, unsigned long valuemask, XGCValues *values);
    [LibraryImport(libX11)]
    public static partial int XChangeGC(DisplayPtr display, GCPtr gc, GCValueMarks valuemask, in XGCValues values);

    // Status XGetGCValues(Display *display, GC gc, unsigned long valuemask, XGCValues *values_return);
    [LibraryImport(libX11)]
    public static partial Bool XGetGCValues(DisplayPtr display, GCPtr gc, GCValueMarks valuemask, out XGCValues values_return);

    // XFreeGC(Display *display, GC gc);
    [LibraryImport(libX11)]
    public static partial int XFreeGC(DisplayPtr display, GCPtr gc);

    #endregion

    #endregion
}
