using SeWzc.X11Sharp.Structs;

namespace SeWzc.X11Sharp.Handles;

public readonly record struct X11Pixmap
{
    public X11Pixmap(ulong Handle)
    {
        this.Handle = (ULong)Handle;
    }

    internal ULong Handle { get; }

    public static implicit operator ULong(X11Pixmap value)
    {
        return value.Handle;
    }

    public static implicit operator nuint(X11Pixmap value)
    {
        return value.Handle;
    }

    public static implicit operator nint(X11Pixmap value)
    {
        return (nint)value.Handle;
    }
}
