using System.Runtime.InteropServices;
using SeWzc.X11Sharp.Structs;

namespace SeWzc.X11Sharp.Internal;

internal interface IIntPtrRole<T> where T : unmanaged, IIntPtrRole<T>, IEquatable<T>
{
    nint Value { get; }

    public static T Zero => default;

    public static virtual implicit operator nint(T xid)
    {
        return xid.Value;
    }

    public static virtual unsafe implicit operator T(nint handle)
    {
        return *(T*)&handle;
    }
}

internal readonly record struct WindowHandle(nint Value) : IIntPtrRole<WindowHandle>
{
    public static explicit operator WindowHandle(DrawableHandle drawableHandle)
    {
        return new WindowHandle(drawableHandle.Value);
    }

    public static implicit operator DrawableHandle(WindowHandle windowHandle)
    {
        return new DrawableHandle(windowHandle.Value);
    }

    public static implicit operator WindowHandle(X11Window value)
    {
        return value.Handle;
    }

    public static implicit operator X11Window(WindowHandle windowHandle)
    {
        return (X11Window)windowHandle.Value;
    }
}

internal readonly record struct PixmapHandle(nint Value) : IIntPtrRole<PixmapHandle>
{
    public static explicit operator PixmapHandle(DrawableHandle drawableHandle)
    {
        return new PixmapHandle(drawableHandle.Value);
    }

    public static implicit operator DrawableHandle(PixmapHandle pixmapHandle)
    {
        return new DrawableHandle(pixmapHandle.Value);
    }

    public static implicit operator PixmapHandle(X11Pixmap value)
    {
        return value.Handle;
    }

    public static implicit operator X11Pixmap(PixmapHandle pixmapHandle)
    {
        return (X11Pixmap)pixmapHandle.Value;
    }
}

internal readonly record struct ColormapHandle(nint Value) : IIntPtrRole<ColormapHandle>
{
    public static implicit operator ColormapHandle(X11ColorMap colormap)
    {
        return colormap.Handle;
    }

    public static implicit operator X11ColorMap(ColormapHandle colormapHandle)
    {
        return (X11ColorMap)colormapHandle.Value;
    }
}

internal readonly record struct CursorHandle(nint Value) : IIntPtrRole<CursorHandle>
{
    public static implicit operator CursorHandle(X11Cursor cursor)
    {
        return cursor.Handle;
    }

    public static implicit operator X11Cursor(CursorHandle cursorHandle)
    {
        return (X11Cursor)cursorHandle.Value;
    }
}

internal readonly record struct DrawableHandle(nint Value) : IIntPtrRole<DrawableHandle>
{
    public static implicit operator DrawableHandle(X11Drawable drawable)
    {
        return drawable.Handle;
    }

    public static implicit operator X11Drawable(DrawableHandle drawableHandle)
    {
        return (X11Drawable)drawableHandle.Value;
    }
}

internal readonly record struct DisplayPtr(nint Value) : IIntPtrRole<DisplayPtr>
{
    public static implicit operator X11Display?(DisplayPtr ptr)
    {
        return (X11Display?)ptr.Value;
    }

    public static implicit operator DisplayPtr(X11Display display)
    {
        return new DisplayPtr((nint)display);
    }
}

internal readonly record struct VisualPtr(nint Value) : IIntPtrRole<VisualPtr>
{
    public static implicit operator X11Visual?(VisualPtr ptr)
    {
        return (X11Visual?)ptr.Value;
    }

    public static implicit operator VisualPtr(X11Visual visual)
    {
        return new VisualPtr((nint)visual);
    }
}

internal readonly record struct ScreenPtr(nint Value) : IIntPtrRole<ScreenPtr>
{
    public static implicit operator X11Screen?(ScreenPtr ptr)
    {
        return (X11Screen?)ptr.Value;
    }

    public static implicit operator ScreenPtr(X11Screen screen)
    {
        return new ScreenPtr((nint)screen);
    }
}

internal readonly record struct GCPtr(nint Value) : IIntPtrRole<GCPtr>
{
    public static implicit operator X11GC?(GCPtr ptr)
    {
        return (X11GC?)ptr.Value;
    }

    public static implicit operator GCPtr(X11GC gc)
    {
        return new GCPtr((nint)gc);
    }
}

internal readonly record struct AtomHandle(nint Value) : IIntPtrRole<AtomHandle>
{
    public static implicit operator X11Atom(AtomHandle atomHandle)
    {
        return (X11Atom)atomHandle.Value;
    }

    public static implicit operator AtomHandle(X11Atom atom)
    {
        return new AtomHandle((nint)atom);
    }
}

internal unsafe struct XPointer(byte* value)
{
    public byte* Value = value;
}

[StructLayout(LayoutKind.Sequential)]
internal unsafe struct XExtData
{
    public int number;
    public XExtData* next;
    public delegate*<int> free_private;
    public XPointer private_data;
}

internal unsafe delegate void XConnectionWatchProc(DisplayPtr display, XPointer client_data, int fd, bool opening, XPointer* watch_data);

internal readonly record struct XVisualId(nuint Value);

[StructLayout(LayoutKind.Sequential)]
internal unsafe struct XVisual
{
    public XExtData* ext_data;
    public XVisualId visualid;
    public int c_class; // TODO 待确定类型
    public nuint red_mask;
    public nuint green_mask;
    public nuint blue_mask;
    public int bits_per_rgb;
    public int map_entries;
}

[StructLayout(LayoutKind.Sequential)]
internal unsafe struct XScreen
{
    public XExtData* ext_data;
    public DisplayPtr display;
    public WindowHandle root;
    public int width;
    public int height;
    public int mwidth;
    public int mheight;
    public int ndepths;
    public int* depths;
    public int root_depth;
    public VisualPtr root_visual;
    public GCPtr default_gc;
    public ColormapHandle cmap;
    public Pixel white_pixel;
    public Pixel black_pixel;
    public int max_maps;
    public int min_maps;
    public BackingStore backing_store;
    public bool save_unders;
    public nint root_input_mask;
}

[StructLayout(LayoutKind.Sequential)]
internal struct XPixmapFormatValues
{
    public int depth;
    public int bits_per_pixel;
    public int scanline_pad;
}

[StructLayout(LayoutKind.Sequential)]
internal struct XWindowChanges
{
    public int x;
    public int y;
    public int width;
    public int height;
    public int border_width;
    public WindowHandle sibling;
    public StackMode stack_mode;
}

[StructLayout(LayoutKind.Sequential)]
internal struct XWindowAttributes
{
    public int x;
    public int y;
    public int width;
    public int height;
    public int border_width;
    public int depth;
    public VisualPtr visual;
    public WindowHandle root;
    public WindowClasses c_class;
    public Gravity bit_gravity;
    public Gravity win_gravity;
    public BackingStore backing_store;
    public nuint backing_planes;
    public Pixel backing_pixel;
    public bool save_under;
    public ColormapHandle colormap;
    public bool map_installed;
    public MapState map_state;
    public EventMask all_event_masks;
    public EventMask your_event_mask;
    public EventMask do_not_propagate_mask;
    public bool override_redirect;
    public ScreenPtr screen;

    public static implicit operator WindowAttributes(XWindowAttributes windowAttributes)
    {
        return new WindowAttributes(windowAttributes);
    }
}

[StructLayout(LayoutKind.Sequential)]
internal struct XSetWindowAttributes
{
    public PixmapHandle background_pixmap;
    public Pixel background_pixel;
    public PixmapHandle border_pixmap;
    public Pixel border_pixel;
    public Gravity bit_gravity;
    public Gravity win_gravity;
    public BackingStore backing_store;
    public nuint backing_planes;
    public Pixel backing_pixel;
    public bool save_under;
    public EventMask event_mask;
    public EventMask do_not_propagate_mask;
    public bool override_redirect;
    public ColormapHandle colormap;
    public CursorHandle cursor;
}
