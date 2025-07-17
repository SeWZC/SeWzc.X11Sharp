using SeWzc.X11Sharp.Structs;

namespace SeWzc.X11Sharp;

/// <summary>
/// X11 可绘制对象。
/// </summary>
public readonly partial record struct X11Drawable : IXid, IDrawable
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
}
