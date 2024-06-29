using SeWzc.X11Sharp.Structs;

namespace SeWzc.X11Sharp.Xid;

/// <summary>
/// X11 窗口。
/// </summary>
public readonly record struct X11Window
{
    public X11Window(ulong Id)
    {
        this.Id = (ULong)Id;
    }

    public X11Window(nint Id)
    {
        this.Id = (ULong)Id;
    }

    internal ULong Id { get; }

    public static implicit operator ULong(X11Window value)
    {
        return value.Id;
    }

    public static implicit operator nuint(X11Window value)
    {
        return value.Id;
    }

    public static implicit operator nint(X11Window value)
    {
        return (nint)value.Id;
    }

    public static implicit operator X11Drawable(X11Window value)
    {
        return new X11Drawable(value.Id);
    }

    public static explicit operator X11Window(X11Drawable value)
    {
        return new X11Window(value.Id);
    }

    /// <summary>
    /// 与 Display 进行组合，以便进行操作。
    /// </summary>
    /// <param name="display">与 X 服务器的连接。</param>
    /// <returns>Display 与 Window 的组合。</returns>
    public X11DisplayWindow WithDisplay(X11Display display)
    {
        return new X11DisplayWindow(display, this);
    }
}
