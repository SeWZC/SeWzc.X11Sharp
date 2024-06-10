using SeWzc.X11Sharp.Internal;

namespace SeWzc.X11Sharp;

public sealed class Cursor
{
    internal readonly CursorHandle Handle;

    internal Cursor(CursorHandle handle)
    {
        Handle = handle;
    }

    public static explicit operator IntPtr(Cursor cursor)
    {
        return cursor.Handle.Value;
    }

    public static explicit operator Cursor(IntPtr cursor)
    {
        return new Cursor(new CursorHandle(cursor));
    }
}
