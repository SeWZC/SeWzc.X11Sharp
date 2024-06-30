using SeWzc.X11Sharp.Structs;

namespace SeWzc.X11Sharp.Xid;

/// <summary>
/// X11 可绘制对象。
/// </summary>
public readonly record struct X11Drawable
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

    /// <summary>
    /// 强制转换为 ULong。
    /// </summary>
    public static implicit operator ULong(X11Drawable value)
    {
        return value.Id;
    }
    
    /// <summary>
    /// 强制转换为 nuint。
    /// </summary>
    public static implicit operator nuint(X11Drawable value)
    {
        return value.Id;
    }
    
    /// <summary>
    /// 强制转换为 nint。
    /// </summary>
    public static implicit operator nint(X11Drawable value)
    {
        return (nint)value.Id;
    }
}
