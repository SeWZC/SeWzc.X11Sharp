using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using SeWzc.X11Sharp.Handles;
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

    public static virtual implicit operator T(nint handle)
    {
        return Unsafe.BitCast<nint, T>(handle);
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

[StructLayout(LayoutKind.Sequential, Size = sizeof(bool))]
public struct Bool
{
    private int _value;

    public static implicit operator bool(Bool @bool)
    {
        return @bool._value != 0;
    }

    public static implicit operator Bool(bool value)
    {
        return new Bool { _value = value ? 1 : 0 };
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

// ReSharper disable InconsistentNaming
[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
internal unsafe delegate void XConnectionWatchProc(DisplayPtr display, XPointer client_data, int fd, Bool opening, XPointer* watch_data);
// ReSharper restore InconsistentNaming

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
    public X11Window root;
    public int width;
    public int height;
    public int mwidth;
    public int mheight;
    public int ndepths;
    public int* depths;
    public int root_depth;
    public VisualPtr root_visual;
    public GCPtr default_gc;
    public X11Colormap cmap;
    public Pixel white_pixel;
    public Pixel black_pixel;
    public int max_maps;
    public int min_maps;
    public BackingStore backing_store;
    public Bool save_unders;
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
    public X11Window sibling;
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
    public X11Window root;
    public WindowClasses c_class;
    public Gravity bit_gravity;
    public Gravity win_gravity;
    public BackingStore backing_store;
    public nuint backing_planes;
    public Pixel backing_pixel;
    public Bool save_under;
    public X11Colormap colormap;
    public Bool map_installed;
    public MapState map_state;
    public EventMask all_event_masks;
    public EventMask your_event_mask;
    public EventMask do_not_propagate_mask;
    public Bool override_redirect;
    public ScreenPtr screen;

    public static implicit operator WindowAttributes(XWindowAttributes windowAttributes)
    {
        return new WindowAttributes(windowAttributes);
    }
}

[StructLayout(LayoutKind.Sequential)]
internal struct XSetWindowAttributes
{
    public X11Pixmap background_pixmap;
    public Pixel background_pixel;
    public X11Pixmap border_pixmap;
    public Pixel border_pixel;
    public Gravity bit_gravity;
    public Gravity win_gravity;
    public BackingStore backing_store;
    public nuint backing_planes;
    public Pixel backing_pixel;
    public Bool save_under;
    public EventMask event_mask;
    public EventMask do_not_propagate_mask;
    public Bool override_redirect;
    public X11Colormap colormap;
    public X11Cursor cursor;
}

[StructLayout(LayoutKind.Sequential)]
internal struct XGCValues
{
    public GraphicsFunctions function;
    public nuint plane_mask;
    public Pixel foreground;
    public Pixel background;
    public int line_width;
    public LineStyle line_style;
    public CapStyle cap_style;
    public JoinStyle join_style;
    public FillStyle fill_style;
    public FillRule fill_rule;
    public ArcMode arc_mode;
    public X11Pixmap tile;
    public X11Pixmap stipple;
    public int ts_x_origin;
    public int ts_y_origin;
    public X11Font font;
    public int subwindow_mode;
    public Bool graphics_exposures;
    public int clip_x_origin;
    public int clip_y_origin;
    public X11Pixmap clip_mask;
    public int dash_offset;
    public byte dashes;
}
