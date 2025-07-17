using SeWzc.X11Sharp.Structs;

namespace SeWzc.X11Sharp;

/// <summary>
/// X11 颜色映射表。
/// </summary>
public readonly partial record struct X11Colormap : IXid
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
}
