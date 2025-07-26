namespace SeWzc.X11Sharp;

/// <summary>
/// Display 和 Xid 的组合。
/// </summary>
/// <param name="Display"></param>
/// <param name="Xid"></param>
/// <typeparam name="TXid"></typeparam>
public readonly record struct X11DisplayXid<TXid>(X11Display Display, TXid Xid)
    where TXid : struct, IXid
{
    /// <summary>
    /// Xid 是否为 None。
    /// </summary>
    public bool IsNone => Xid.ToUPtrInt() == 0;

    #region 运算符重载

    // 强制转换就不用文档了
#pragma warning disable CS1591
    public static implicit operator X11Display(X11DisplayXid<TXid> displayXid)
    {
        return displayXid.Display;
    }

    public static implicit operator TXid(X11DisplayXid<TXid> displayXid)
    {
        return displayXid.Xid;
    }
#pragma warning restore CS1591

    #endregion
}
