using SeWzc.X11Sharp.Structs;

namespace SeWzc.X11Sharp.Xid;

public readonly record struct X11Colormap
{
    public X11Colormap(ulong Id)
    {
        this.Id = (ULong)Id;
    }

    public X11Colormap(nint Id)
    {
        this.Id = (ULong)Id;
    }

    internal ULong Id { get; }

    public static implicit operator ULong(X11Colormap value)
    {
        return value.Id;
    }

    public static implicit operator nuint(X11Colormap value)
    {
        return value.Id;
    }

    public static implicit operator nint(X11Colormap value)
    {
        return (nint)value.Id;
    }
}
