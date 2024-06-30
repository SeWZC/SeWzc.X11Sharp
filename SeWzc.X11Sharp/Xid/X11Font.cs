using SeWzc.X11Sharp.Structs;

namespace SeWzc.X11Sharp.Xid;

/// <summary>
/// X11 字体。
/// </summary>
public readonly record struct X11Font
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

    /// <summary>
    /// 强制转换为 ULong。
    /// </summary>
    public static implicit operator ULong(X11Font value)
    {
        return value.Id;
    }

    /// <summary>
    /// 强制转换为 nuint。
    /// </summary>
    public static implicit operator nuint(X11Font value)
    {
        return value.Id;
    }

    /// <summary>
    /// 强制转换为 nint。
    /// </summary>
    public static implicit operator nint(X11Font value)
    {
        return (nint)value.Id;
    }
}
