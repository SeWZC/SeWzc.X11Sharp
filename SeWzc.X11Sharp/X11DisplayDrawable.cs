using SeWzc.X11Sharp.Internal;
using SeWzc.X11Sharp.Structs;

namespace SeWzc.X11Sharp;

/// <summary>
/// Display 和 Drawable 的组合。
/// </summary>
public readonly record struct X11DisplayDrawable(X11Display Display, X11Drawable Drawable)
{
    /// <summary>
    /// 获取可绘制对象的矩形内容。
    /// </summary>
    /// <param name="rectangle">矩形区域。</param>
    /// <param name="planeMask">平面掩码。</param>
    /// <param name="format">图像格式。</param>
    public unsafe X11Image? GetImage(Rectangle rectangle, ulong planeMask, ImageFormat format)
    {
        return X11Image.FromImage(XLib.XGetImage(Display, Drawable, rectangle.X, rectangle.Y, rectangle.Width, rectangle.Height, (ULong)planeMask, format));
    }

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
