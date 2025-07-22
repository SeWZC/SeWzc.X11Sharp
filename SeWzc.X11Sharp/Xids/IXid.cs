namespace SeWzc.X11Sharp;

/// <summary>
/// X11 资源 ID。
/// </summary>
public interface IXid
{
    /// <summary>
    /// 转换为 32 位整数。
    /// </summary>
    /// <returns>32 位整数。</returns>
    int ToInt32();

    /// <summary>
    /// 转换为 32 位无符号整数。
    /// </summary>
    /// <returns>32 位无符号整数。</returns>
    uint ToUInt32();

    /// <summary>
    /// 转换为指针大小的整数。
    /// </summary>
    /// <returns>指针大小的整数。</returns>
    nint ToPtrInt();

    /// <summary>
    /// 转换为无符号指针大小的整数。
    /// </summary>
    /// <returns>无符号指针大小的整数。</returns>
    nuint ToUPtrInt();
}

/// <summary>
/// Xid 扩展方法。
/// </summary>
public static class XidExtensions
{
    /// <summary>
    /// 将 Xid 与 Display 进行组合，以便进行操作。
    /// </summary>
    /// <param name="xid">Xid。</param>
    /// <param name="display">与 X 服务器的连接。</param>
    /// <returns>Display 与 Xid 的组合。</returns>
    public static X11DisplayXid<TXid> WithDisplay<TXid>(this TXid xid, X11Display display)
        where TXid : struct, IXid
    {
        return new X11DisplayXid<TXid>(display, xid);
    }
}
