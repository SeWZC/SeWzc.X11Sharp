using SeWzc.X11Sharp.Internal;
using SeWzc.X11Sharp.Structs;

namespace SeWzc.X11Sharp;

public static partial class X11Lib
{
    /// <summary>
    /// 获取可绘制对象的矩形内容。
    /// </summary>
    /// <param name="drawable">可绘制对象。</param>
    /// <param name="rectangle">矩形区域。</param>
    /// <param name="planeMask">平面掩码。</param>
    /// <param name="format">图像格式。</param>
    public static unsafe X11Image? GetImage<TDisplayDrawable>(this TDisplayDrawable drawable, Rectangle rectangle, ulong planeMask, ImageFormat format)
        where TDisplayDrawable : struct, IDisplayDrawable
    {
        return X11Image.FromImage(XLib.XGetImage(drawable.Display, drawable.Drawable, rectangle.X, rectangle.Y, rectangle.Width, rectangle.Height, (ULong)planeMask, format));
    }
}
