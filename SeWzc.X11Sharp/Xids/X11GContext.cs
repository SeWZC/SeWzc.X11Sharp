using SeWzc.X11Sharp.Structs;

namespace SeWzc.X11Sharp;

/// <summary>
/// X11 图形上下文。
/// </summary>
/// <remarks>
/// 与 <see cref="X11GC"/> 的区别是，该类是资源 ID 的包装，<see cref="X11GC"/> 用于提供函数调用操作。
/// </remarks>
public readonly partial record struct X11GContext : IXid
{
    /// <summary>
    /// 通过 Id 构造 X11GContext。
    /// </summary>
    /// <param name="Id">图形上下文的 ID。</param>
    public X11GContext(nuint Id)
    {
        this.Id = (ULong)Id;
    }

    /// <summary>
    /// 通过 Id 构造 X11GContext。
    /// </summary>
    /// <param name="Id">图形上下文的 ID。</param>
    public X11GContext(nint Id)
    {
        this.Id = (ULong)Id;
    }

    /// <summary>
    /// 图形上下文的 ID。
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
