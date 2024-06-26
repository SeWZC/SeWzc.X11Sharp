using SeWzc.X11Sharp.Structs;

namespace SeWzc.X11Sharp.Handles;

public readonly record struct X11Cursor
{
    public X11Cursor(ulong Handle)
    {
        this.Handle = (ULong)Handle;
    }

    internal ULong Handle { get; }

    public static implicit operator ULong(X11Cursor value)
    {
        return value.Handle;
    }

    public static implicit operator nuint(X11Cursor value)
    {
        return value.Handle;
    }

    public static implicit operator nint(X11Cursor value)
    {
        return (nint)value.Handle;
    }
}
