namespace SeWzc.X11Sharp;

/// <summary>
/// Display 和可绘制对象的组合的接口。
/// </summary>
public interface IDisplayDrawable
{
    /// <summary>
    /// Display。
    /// </summary>
    public X11Display Display { get; }

    /// <summary>
    /// 可绘制对象。
    /// </summary>
    public X11Drawable Drawable { get; }
}
