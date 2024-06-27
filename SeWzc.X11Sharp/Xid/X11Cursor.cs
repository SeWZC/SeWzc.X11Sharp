using SeWzc.X11Sharp.Structs;

namespace SeWzc.X11Sharp.Xid;

public readonly record struct X11Cursor
{
    public X11Cursor(ulong Id)
    {
        this.Id = (ULong)Id;
    }

    public X11Cursor(nint Id)
    {
        this.Id = (ULong)Id;
    }

    internal ULong Id { get; }

    public static implicit operator ULong(X11Cursor value)
    {
        return value.Id;
    }

    public static implicit operator nuint(X11Cursor value)
    {
        return value.Id;
    }

    public static implicit operator nint(X11Cursor value)
    {
        return (nint)value.Id;
    }
}
