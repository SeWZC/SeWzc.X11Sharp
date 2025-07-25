using SeWzc.X11Sharp.Structs;

namespace SeWzc.X11Sharp;

/// <summary>
/// X11 像素图。
/// </summary>
public readonly partial record struct X11Pixmap : IXid, IDrawable
{
    /// <summary>
    /// 通过 Id 构造 X11Pixmap。
    /// </summary>
    /// <param name="Id">像素图的 ID。</param>
    public X11Pixmap(ulong Id)
    {
        this.Id = (ULong)Id;
    }

    /// <summary>
    /// 通过 Id 构造 X11Pixmap。
    /// </summary>
    /// <param name="Id">像素图的 ID。</param>
    public X11Pixmap(nint Id)
    {
        this.Id = (ULong)Id;
    }

    /// <summary>
    /// 像素图的 ID。
    /// </summary>
    internal ULong Id { get; }

    /// <inheritdoc />
    public X11Drawable AsDrawable()
    {
        return new X11Drawable(Id);
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

    /// <summary>
    /// 与 Display 进行组合，以便进行操作。
    /// </summary>
    /// <param name="display">与 X 服务器的连接。</param>
    /// <returns>Display 与 Pixmap 的组合。</returns>
    public X11DisplayPixmap WithDisplay(X11Display display)
    {
        return new X11DisplayPixmap(display, this);
    }

    #region 运算符重载

    // 强制转换不需要文档
#pragma warning disable CS1591

    /// <summary>
    /// 强制转换为 X11Drawable。
    /// </summary>
    public static implicit operator X11Drawable(X11Pixmap value)
    {
        return new X11Drawable(value.Id);
    }

    /// <summary>
    /// 从 X11Drawable 强制转换为 X11Pixmap。需要确保 X11Drawable 是一个像素图。
    /// </summary>
    public static explicit operator X11Pixmap(X11Drawable value)
    {
        return new X11Pixmap(value.Id);
    }

#pragma warning restore CS1591

    #endregion
}
