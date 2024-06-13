using SeWzc.X11Sharp.Internal;

namespace SeWzc.X11Sharp;

public sealed class X11Cursor
{
    private X11Cursor(CursorHandle handle)
    {
        Handle = handle;
    }

    internal CursorHandle Handle { get; }

    private static WeakReferenceValueDictionary<nint, X11Cursor> Cache { get; } = new();

    public static explicit operator nint(X11Cursor x11Cursor)
    {
        return x11Cursor.Handle.Value;
    }

    public static explicit operator X11Cursor(nint handle)
    {
        return Cache.GetOrAdd(handle, static handle => new X11Cursor(new CursorHandle(handle)));
    }
}
