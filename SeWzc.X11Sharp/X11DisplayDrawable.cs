namespace SeWzc.X11Sharp;

/// <summary>
/// Display 和 Drawable 的组合。
/// </summary>
public readonly record struct X11DisplayDrawable(X11Display Display, X11Drawable Drawable)
    : IDisplayDrawable
{
    #region 运算符重载

    // 强制转换就不用文档了
#pragma warning disable CS1591
    public static implicit operator X11Drawable(X11DisplayDrawable displayDrawable)
    {
        return displayDrawable.Drawable;
    }
#pragma warning restore CS1591

    #endregion
}
