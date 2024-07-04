using SeWzc.X11Sharp.Structs;

namespace SeWzc.X11Sharp;

/// <summary>
/// X11 光标。
/// </summary>
public readonly record struct X11Cursor : IXid
{
    /// <summary>
    /// 通过 Id 构造 X11Cursor。
    /// </summary>
    /// <param name="Id">光标的 ID。</param>
    public X11Cursor(ulong Id)
    {
        this.Id = (ULong)Id;
    }

    /// <summary>
    /// 通过 Id 构造 X11Cursor。
    /// </summary>
    /// <param name="Id">光标的 ID。</param>
    public X11Cursor(nint Id)
    {
        this.Id = (ULong)Id;
    }

    /// <summary>
    /// 光标的 ID。
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
    /// <returns>Display 与 Cursor 的组合。</returns>
    public X11DisplayCursor WithDisplay(X11Display display)
    {
        return new X11DisplayCursor(display, this);
    }

    #region 运算符重载

    // 强制转换不需要文档
#pragma warning disable CS1591

    public static implicit operator ULong(X11Cursor value)
    {
        return value.Id;
    }

    public static implicit operator nuint(X11Cursor value)
    {
        return value.ToUPtrInt();
    }

    public static implicit operator nint(X11Cursor value)
    {
        return (nint)value.Id;
    }

#pragma warning restore CS1591

    #endregion
}
