using System.Runtime.CompilerServices;
using SeWzc.X11Sharp.Internal;

namespace SeWzc.X11Sharp;

/// <summary>
/// X11 窗口。
/// </summary>
public sealed class X11Window : X11Drawable
{
    private X11Window(WindowHandle handle) : base(handle)
    {
    }

    internal new WindowHandle Handle => (WindowHandle)base.Handle;

    internal DrawableHandle DrawableHandle => base.Handle;

    private static WeakReferenceValueDictionary<nint, X11Window> Cache { get; } = new();

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

    public static explicit operator nint(X11Window window)
    {
        return window.Handle.Value;
    }

    public static explicit operator X11Window(nint handle)
    {
        return Cache.GetOrAdd(handle, key => new X11Window(new WindowHandle(key)));
    }
}
