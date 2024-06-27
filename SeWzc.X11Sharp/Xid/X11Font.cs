using SeWzc.X11Sharp.Structs;

namespace SeWzc.X11Sharp.Xid;

public readonly record struct X11Font
{
    public X11Font(ulong Id)
    {
        this.Id = (ULong)Id;
    }

    public X11Font(nint Id)
    {
        this.Id = (ULong)Id;
    }

    internal ULong Id { get; }

    public static implicit operator ULong(X11Font value)
    {
        return value.Id;
    }

    public static implicit operator nuint(X11Font value)
    {
        return value.Id;
    }

    public static implicit operator nint(X11Font value)
    {
        return (nint)value.Id;
    }
}
