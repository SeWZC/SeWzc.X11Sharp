using SeWzc.X11Sharp.Structs;

namespace SeWzc.X11Sharp.Xid;

/// <summary>
/// X11 光标。
/// </summary>
public readonly record struct X11Cursor
{
    /// <summary>
    /// 通过 Id 构造 X11Cursor。
    /// </summary>
    /// <param name="Id">光标的 ID。</param>
    public X11Cursor(ulong Id)
    {
        this.Id = (ULong)Id;
    }

    /// <summary>
    /// 通过 Id 构造 X11Cursor。
    /// </summary>
    /// <param name="Id">光标的 ID。</param>
    public X11Cursor(nint Id)
    {
        this.Id = (ULong)Id;
    }

    /// <summary>
    /// 光标的 ID。
    /// </summary>
    internal ULong Id { get; }
    
    /// <summary>
    /// 强制转换为 ULong。
    /// </summary>
    public static implicit operator ULong(X11Cursor value)
    {
        return value.Id;
    }
    
    /// <summary>
    /// 强制转换为 nuint。
    /// </summary>
    public static implicit operator nuint(X11Cursor value)
    {
        return value.Id;
    }
    
    /// <summary>
    /// 强制转换为 nint。
    /// </summary>
    public static implicit operator nint(X11Cursor value)
    {
        return (nint)value.Id;
    }
}
