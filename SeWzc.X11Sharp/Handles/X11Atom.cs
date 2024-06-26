namespace SeWzc.X11Sharp.Handles;

public readonly record struct X11Atom(nint Handle) : IX11HandleWrapper<X11Atom>
{
    /// <inheritdoc />
    public static X11Atom None { get; } = new(0);

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
