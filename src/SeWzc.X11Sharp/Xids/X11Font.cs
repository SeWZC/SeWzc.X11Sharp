using SeWzc.X11Sharp.Structs;

namespace SeWzc.X11Sharp;

/// <summary>
/// X11 字体。
/// </summary>
public readonly partial record struct X11Font : IXid
{
    /// <summary>
    /// 通过 Id 构造 X11Font。
    /// </summary>
    /// <param name="Id">字体的 ID。</param>
    public X11Font(ulong Id)
    {
        this.Id = (ULong)Id;
    }

    /// <summary>
    /// 通过 Id 构造 X11Font。
    /// </summary>
    /// <param name="Id">字体的 ID。</param>
    public X11Font(nint Id)
    {
        this.Id = (ULong)Id;
    }

    /// <summary>
    /// 字体的 ID。
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
