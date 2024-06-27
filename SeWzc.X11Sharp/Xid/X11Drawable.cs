using SeWzc.X11Sharp.Structs;

namespace SeWzc.X11Sharp.Xid;

public readonly record struct X11Drawable
{
    public X11Drawable(ulong Id)
    {
        this.Id = (ULong)Id;
    }

    public X11Drawable(nint Id)
    {
        this.Id = (ULong)Id;
    }

    internal ULong Id { get; }

    public static implicit operator ULong(X11Drawable value)
    {
        return value.Id;
    }

    public static implicit operator nuint(X11Drawable value)
    {
        return value.Id;
    }

    public static implicit operator nint(X11Drawable value)
    {
        return (nint)value.Id;
    }
}
