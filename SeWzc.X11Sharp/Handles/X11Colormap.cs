using SeWzc.X11Sharp.Structs;

namespace SeWzc.X11Sharp.Handles;

public readonly record struct X11Colormap
{
    public X11Colormap(ulong Handle)
    {
        this.Handle = (ULong)Handle;
    }

    internal ULong Handle { get; }

    public static implicit operator ULong(X11Colormap value)
    {
        return value.Handle;
    }

    public static implicit operator nuint(X11Colormap value)
    {
        return value.Handle;
    }

    public static implicit operator nint(X11Colormap value)
    {
        return (nint)value.Handle;
    }
}
