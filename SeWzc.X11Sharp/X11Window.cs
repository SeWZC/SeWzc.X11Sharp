using System.Runtime.CompilerServices;

namespace SeWzc.X11Sharp;

/// <summary>
/// X11 窗口。
/// </summary>
public readonly record struct X11Window(nint Handle) : IX11HandleWrapper<X11Window>
{
    /// <summary>
    /// 与 Display 进行组合，以便进行窗口操作。
    /// </summary>
    /// <param name="display">与 X 服务器的连接。</param>
    /// <returns>Display 与 该窗口的的组合。</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public X11DisplayWindow WithDisplay(X11Display display)
    {
        return new X11DisplayWindow(display, this);
    }
}
