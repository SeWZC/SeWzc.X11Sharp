using SeWzc.X11Sharp.Structs;

namespace SeWzc.X11Sharp.Xid;

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
