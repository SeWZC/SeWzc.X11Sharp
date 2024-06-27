using SeWzc.X11Sharp.Structs;

namespace SeWzc.X11Sharp.Xid;

public readonly record struct X11Atom
{
    public X11Atom(nuint Id)
    {
        this.Id = (ULong)Id;
    }

    public X11Atom(nint Id)
    {
        this.Id = (ULong)Id;
    }

    internal ULong Id { get; }

    public static implicit operator ULong(X11Atom value)
    {
        return value.Id;
    }

    public static implicit operator nuint(X11Atom value)
    {
        return value.Id;
    }

    public static implicit operator nint(X11Atom value)
    {
        return (nint)value.Id;
    }

    /// <summary>
    /// 与 Display 进行组合，以便进行操作。
    /// </summary>
    /// <param name="display">与 X 服务器的连接。</param>
    /// <returns>Display 与 Atom 的组合。</returns>
    public X11DisplayAtom WithDisplay(X11Display display)
    {
        return new X11DisplayAtom(display, this);
    }
}
