namespace SeWzc.X11Sharp;

/// <summary>
/// 可绘制的对象接口。
/// </summary>
public interface IDrawable
{
    /// <summary>
    /// 转换为可绘制对象。
    /// </summary>
    /// <returns>可绘制对象。</returns>
    public X11Drawable AsDrawable();
}
