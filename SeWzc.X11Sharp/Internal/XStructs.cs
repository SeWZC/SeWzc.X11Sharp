using System.Runtime.InteropServices;

namespace SeWzc.X11Sharp.Internal;

#region XID

internal interface IXid<T> where T : unmanaged, IXid<T>
{
    nint Handle { get; }

    public static virtual implicit operator nint(T xid)
    {
        return xid.Handle;
    }

    public static virtual unsafe implicit operator T(nint handle)
    {
        return *(T*)&handle;
    }
}

internal readonly record struct WindowHandle(nint Handle) : IXid<WindowHandle>;

internal readonly record struct PixmapHandle(nint Handle) : IXid<WindowHandle>;

internal readonly record struct ColormapHandle(nint Handle) : IXid<WindowHandle>;

internal readonly record struct CursorHandle(nint Handle) : IXid<WindowHandle>;

#endregion

internal readonly record struct DisplayPtr(nint Ptr);

[StructLayout(LayoutKind.Sequential)]
internal readonly struct XVisual
{
    // 暂不实现
}

[StructLayout(LayoutKind.Sequential)]
internal struct XSetWindowAttributes
{
    internal PixmapHandle background_pixmap;
    internal nuint background_pixel;
    internal PixmapHandle border_pixmap;
    internal nuint border_pixel;
    internal Gravity bit_gravity;
    internal Gravity win_gravity;
    internal int backing_store;
    internal nuint backing_planes;
    internal nuint backing_pixel;
    internal bool save_under;
    internal long event_mask;
    internal long do_not_propagate_mask;
    internal bool override_redirect;
    internal ColormapHandle colormap;
    internal CursorHandle cursor;
}
