using SeWzc.X11Sharp.Structs;

namespace SeWzc.X11Sharp;

/// <summary>
/// X11 可绘制对象。
/// </summary>
public readonly record struct X11Drawable : IXid, IDrawable
{
    /// <summary>
    /// 通过 Id 构造 X11Drawable。
    /// </summary>
    /// <param name="Id">可绘制对象的 ID。</param>
    public X11Drawable(ulong Id)
    {
        this.Id = (ULong)Id;
    }

    /// <summary>
    /// 通过 Id 构造 X11Drawable。
    /// </summary>
    /// <param name="Id">可绘制对象的 ID。</param>
    public X11Drawable(nint Id)
    {
        this.Id = (ULong)Id;
    }

    /// <summary>
    /// 可绘制对象的 ID。
    /// </summary>
    internal ULong Id { get; }

    /// <inheritdoc />
    public X11Drawable AsDrawable()
    {
        return this;
    }

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

    public static implicit operator ULong(X11Drawable value)
    {
        return value.Id;
    }

    public static implicit operator nuint(X11Drawable value)
    {
        return value.ToUPtrInt();
    }

    public static implicit operator nint(X11Drawable value)
    {
        return (nint)value.Id;
    }

#pragma warning restore CS1591

    #endregion
}
