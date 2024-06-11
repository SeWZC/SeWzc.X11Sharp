using SeWzc.X11Sharp.Internal;

namespace SeWzc.X11Sharp;

public sealed class Cursor
{
    internal readonly CursorHandle Handle;

    internal Cursor(CursorHandle handle)
    {
        Handle = handle;
    }

    private static WeakReferenceValueDictionary<nint, Cursor> Cache { get; } = new();

    public static explicit operator nint(Cursor cursor)
    {
        return cursor.Handle.Value;
    }

    public static explicit operator Cursor(nint handle)
    {
        return Cache.GetOrAdd(handle, static handle => new Cursor(new CursorHandle(handle)));
    }
}
