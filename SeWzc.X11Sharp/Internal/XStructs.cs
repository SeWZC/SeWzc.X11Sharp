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

internal readonly record struct InternalWindow(nint Handle) : IXid<InternalWindow>;

internal readonly record struct InternalPixmap(nint Handle) : IXid<InternalWindow>;

internal readonly record struct InternalColormap(nint Handle) : IXid<InternalWindow>;

internal readonly record struct InternalCursor(nint Handle) : IXid<InternalWindow>;

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
    internal InternalPixmap background_pixmap;
    internal nuint background_pixel;
    internal InternalPixmap border_pixmap;
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
    internal InternalColormap colormap;
    internal InternalCursor cursor;
}
