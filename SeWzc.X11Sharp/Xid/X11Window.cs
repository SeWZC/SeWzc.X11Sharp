﻿using SeWzc.X11Sharp.Structs;

namespace SeWzc.X11Sharp.Xid;

/// <summary>
/// X11 窗口。
/// </summary>
public readonly record struct X11Window : IXid
{
    /// <summary>
    /// 通过 Id 构造 X11Window。
    /// </summary>
    /// <param name="Id"></param>
    public X11Window(ulong Id)
    {
        this.Id = (ULong)Id;
    }

    /// <summary>
    /// 通过 Id 构造 X11Window。
    /// </summary>
    /// <param name="Id"></param>
    public X11Window(nint Id)
    {
        this.Id = (ULong)Id;
    }

    /// <summary>
    /// 窗口的 ID。
    /// </summary>
    internal ULong Id { get; }

    /// <inheritdoc />
    public int ToInt32()
    {
        return (int)Id;
    }

    /// <inheritdoc />
    public uint ToUInt32()
    {
        return (uint)Id;
    }

    /// <inheritdoc />
    public nint ToPtrInt()
    {
        return (nint)Id;
    }

    /// <inheritdoc />
    public nuint ToUPtrInt()
    {
        return Id;
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

    #region 运算符重载

    // 强制转换不需要文档
#pragma warning disable CS1591

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

    /// <summary>
    /// 强制转换为 X11Drawable。
    /// </summary>
    public static implicit operator X11Drawable(X11Window value)
    {
        return new X11Drawable(value.Id);
    }

    /// <summary>
    /// 从 X11Drawable 强制转换为 X11Window。需要确保 X11Drawable 是一个窗口。
    /// </summary>
    public static explicit operator X11Window(X11Drawable value)
    {
        return new X11Window(value.Id);
    }

#pragma warning restore CS1591

    #endregion
}
