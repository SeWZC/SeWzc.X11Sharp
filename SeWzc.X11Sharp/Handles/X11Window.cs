﻿using SeWzc.X11Sharp.Structs;

namespace SeWzc.X11Sharp.Handles;

/// <summary>
/// X11 窗口。
/// </summary>
public readonly record struct X11Window
{
    public X11Window(ulong Handle)
    {
        this.Handle = (ULong)Handle;
    }

    internal ULong Handle { get; }

    public static implicit operator ULong(X11Window value)
    {
        return value.Handle;
    }

    public static implicit operator nuint(X11Window value)
    {
        return value.Handle;
    }

    public static implicit operator nint(X11Window value)
    {
        return (nint)value.Handle;
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