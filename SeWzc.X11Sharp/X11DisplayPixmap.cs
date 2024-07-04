namespace SeWzc.X11Sharp;

/// <summary>
/// Display 和 Pixmap 的组合。
/// </summary>
public readonly record struct X11DisplayPixmap(X11Display Display, X11Pixmap Pixmap)
{
    #region 运算符重载

    // 强制转换就不用文档了
#pragma warning disable CS1591
    public static implicit operator X11Pixmap(X11DisplayPixmap displayPixmap)
    {
        return displayPixmap.Pixmap;
    }
#pragma warning restore CS1591

    #endregion
}
