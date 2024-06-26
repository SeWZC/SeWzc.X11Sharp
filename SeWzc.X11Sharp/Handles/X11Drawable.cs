using SeWzc.X11Sharp.Structs;

namespace SeWzc.X11Sharp.Handles;

public readonly record struct X11Drawable
{
    public X11Drawable(ulong Handle)
    {
        this.Handle = (ULong)Handle;
    }

    internal ULong Handle { get; }

    public static implicit operator ULong(X11Drawable value)
    {
        return value.Handle;
    }

    public static implicit operator nuint(X11Drawable value)
    {
        return value.Handle;
    }

    public static implicit operator nint(X11Drawable value)
    {
        return (nint)value.Handle;
    }
}
