using SeWzc.X11Sharp.Structs;

namespace SeWzc.X11Sharp.Handles;

public readonly record struct X11Font
{
    public X11Font(ulong Handle)
    {
        this.Handle = (ULong)Handle;
    }

    internal ULong Handle { get; }

    public static implicit operator ULong(X11Font value)
    {
        return value.Handle;
    }

    public static implicit operator nuint(X11Font value)
    {
        return value.Handle;
    }

    public static implicit operator nint(X11Font value)
    {
        return (nint)value.Handle;
    }
}
