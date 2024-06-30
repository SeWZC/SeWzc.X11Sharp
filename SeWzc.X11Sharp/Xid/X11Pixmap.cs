using SeWzc.X11Sharp.Structs;

namespace SeWzc.X11Sharp.Xid;

/// <summary>
/// X11 位图。
/// </summary>
public readonly record struct X11Pixmap
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

    /// <summary>
    /// 强制转换为 ULong。
    /// </summary>
    public static implicit operator ULong(X11Pixmap value)
    {
        return value.Id;
    }

    /// <summary>
    /// 强制转换为 nuint。
    /// </summary>
    public static implicit operator nuint(X11Pixmap value)
    {
        return value.Id;
    }

    /// <summary>
    /// 强制转换为 nint。
    /// </summary>
    public static implicit operator nint(X11Pixmap value)
    {
        return (nint)value.Id;
    }
}
