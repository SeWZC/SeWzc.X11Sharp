using System.Runtime.InteropServices;

namespace SeWzc.X11Sharp.Internal;

internal interface IIntPtrRole<T> where T : unmanaged, IIntPtrRole<T>, IEquatable<T>
{
    nint Value { get; }

    public static virtual implicit operator nint(T xid)
    {
        return xid.Value;
    }

    public static virtual unsafe implicit operator T(nint handle)
    {
        return *(T*)&handle;
    }
}

internal readonly record struct WindowHandle(nint Value) : IIntPtrRole<WindowHandle>;

internal readonly record struct PixmapHandle(nint Value) : IIntPtrRole<PixmapHandle>;

internal readonly record struct ColormapHandle(nint Value) : IIntPtrRole<ColormapHandle>;

internal readonly record struct CursorHandle(nint Value) : IIntPtrRole<CursorHandle>;

internal readonly record struct DisplayPtr(nint Value) : IIntPtrRole<DisplayPtr>
{
    public static implicit operator Display(DisplayPtr ptr)
    {
        return (Display)ptr.Value;
    }

    public static implicit operator DisplayPtr(Display display)
    {
        return new DisplayPtr((IntPtr)display);
    }
}

internal readonly record struct GCPtr(nint Value) : IIntPtrRole<GCPtr>;

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
    public nuint visualid;
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
    public XVisual* root_visual;
    public GCPtr default_gc;
    public ColormapHandle cmap;
    public nint white_pixel;
    public nint black_pixel;
    public int max_maps;
    public int min_maps;
    public int backing_store;
    public bool save_unders;
    public nint root_input_mask;
}

[StructLayout(LayoutKind.Sequential)]
internal struct XPixmapFormatValues
{
    int depth;
    int bits_per_pixel;
    int scanline_pad;
}

[StructLayout(LayoutKind.Sequential)]
internal struct XSetWindowAttributes
{
    public PixmapHandle background_pixmap;
    public nuint background_pixel;
    public PixmapHandle border_pixmap;
    public nuint border_pixel;
    public Gravity bit_gravity;
    public Gravity win_gravity;
    public int backing_store;
    public nuint backing_planes;
    public nuint backing_pixel;
    public bool save_under;
    public long event_mask;
    public long do_not_propagate_mask;
    public bool override_redirect;
    public ColormapHandle colormap;
    public CursorHandle cursor;
}
