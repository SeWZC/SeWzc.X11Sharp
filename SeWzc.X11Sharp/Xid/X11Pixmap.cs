using SeWzc.X11Sharp.Structs;

namespace SeWzc.X11Sharp.Xid;

/// <summary>
/// X11 位图。
/// </summary>
public readonly record struct X11Pixmap : IXid
{
    /// <summary>
    /// 通过 Id 构造 X11Pixmap。
    /// </summary>
    /// <param name="Id">图像映射的 ID。</param>
    public X11Pixmap(ulong Id)
    {
        this.Id = (ULong)Id;
    }

    /// <summary>
    /// 通过 Id 构造 X11Pixmap。
    /// </summary>
    /// <param name="Id">图像映射的 ID。</param>
    public X11Pixmap(nint Id)
    {
        this.Id = (ULong)Id;
    }

    /// <summary>
    /// 位图的 ID。
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

    public static implicit operator ULong(X11Pixmap value)
    {
        return value.Id;
    }

    public static implicit operator nuint(X11Pixmap value)
    {
        return value.ToUPtrInt();
    }

    public static implicit operator nint(X11Pixmap value)
    {
        return (nint)value.Id;
    }

#pragma warning restore CS1591

    #endregion
}
