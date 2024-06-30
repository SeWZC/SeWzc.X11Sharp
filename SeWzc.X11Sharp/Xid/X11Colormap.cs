using SeWzc.X11Sharp.Structs;

namespace SeWzc.X11Sharp.Xid;

/// <summary>
/// X11 颜色映射表。
/// </summary>
public readonly record struct X11Colormap : IXid
{
    /// <summary>
    /// 通过 Id 构造 X11Colormap。
    /// </summary>
    /// <param name="Id">颜色映射表的 ID。</param>
    public X11Colormap(ulong Id)
    {
        this.Id = (ULong)Id;
    }

    /// <summary>
    /// 通过 Id 构造 X11Colormap。
    /// </summary>
    /// <param name="Id">颜色映射表的 ID。</param>
    public X11Colormap(nint Id)
    {
        this.Id = (ULong)Id;
    }

    /// <summary>
    /// 颜色映射表的 ID。
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

    #region 运算符重载

    // 强制转换不需要文档
#pragma warning disable CS1591

    public static implicit operator ULong(X11Colormap value)
    {
        return value.Id;
    }

    public static implicit operator nuint(X11Colormap value)
    {
        return value.ToUPtrInt();
    }

    public static implicit operator nint(X11Colormap value)
    {
        return (nint)value.Id;
    }

#pragma warning restore CS1591

    #endregion
}
