using SeWzc.X11Sharp.Structs;

namespace SeWzc.X11Sharp.Xid;

public readonly record struct X11Pixmap
{
    public X11Pixmap(ulong Id)
    {
        this.Id = (ULong)Id;
    }

    public X11Pixmap(nint Id)
    {
        this.Id = (ULong)Id;
    }

    internal ULong Id { get; }

    public static implicit operator ULong(X11Pixmap value)
    {
        return value.Id;
    }

    public static implicit operator nuint(X11Pixmap value)
    {
        return value.Id;
    }

    public static implicit operator nint(X11Pixmap value)
    {
        return (nint)value.Id;
    }
}
