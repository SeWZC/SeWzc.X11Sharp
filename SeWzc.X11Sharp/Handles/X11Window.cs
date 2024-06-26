namespace SeWzc.X11Sharp.Handles;

/// <summary>
/// X11 窗口。
/// </summary>
public readonly record struct X11Window(nint Handle) : IX11HandleWrapper<X11Window>
{
    /// <inheritdoc />
    public static X11Window None { get; } = new(0);

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
