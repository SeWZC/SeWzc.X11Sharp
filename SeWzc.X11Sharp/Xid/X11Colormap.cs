using SeWzc.X11Sharp.Structs;

namespace SeWzc.X11Sharp.Xid;

/// <summary>
/// X11 颜色映射表。
/// </summary>
public readonly record struct X11Colormap
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

    /// <summary>
    /// 强制转换为 ULong。
    /// </summary>
    public static implicit operator ULong(X11Colormap value)
    {
        return value.Id;
    }

    /// <summary>
    /// 强制转换为 nuint。
    /// </summary>
    public static implicit operator nuint(X11Colormap value)
    {
        return value.Id;
    }

    /// <summary>
    /// 强制转换为 nint。
    /// </summary>
    public static implicit operator nint(X11Colormap value)
    {
        return (nint)value.Id;
    }
}
