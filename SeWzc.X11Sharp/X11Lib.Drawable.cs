using SeWzc.X11Sharp.Internal;
using SeWzc.X11Sharp.Structs;

namespace SeWzc.X11Sharp;

public static partial class X11Lib
{
    /// <summary>
    /// 查询最佳光标大小。
    /// </summary>
    /// <param name="drawable">可绘制对象。</param>
    /// <param name="size">希望的大小。</param>
    /// <returns></returns>
    public static Size? QueryBestCursor<TDrawable>(this X11DisplayXid<TDrawable> drawable, Size size)
        where TDrawable : struct, IXid, IDrawable
    {
        return XLib.XQueryBestCursor(drawable.Display, drawable.Xid.AsDrawable(), size.Width, size.Height, out var bw, out var bh)
            ? new Size(bw, bh)
            : null;
    }

    /// <summary>
    /// 创建图形上下文。
    /// </summary>
    /// <param name="drawable">可绘制对象。</param>
    /// <param name="values">设置的值。</param>
    /// <returns>具有指定值的图形上下文。</returns>
    public static X11GC? CreateGC<TDrawable>(this X11DisplayXid<TDrawable> drawable, GCValues values)
        where TDrawable : struct, IXid, IDrawable
    {
        var gcValues = values.ToXGCValues();
        var valueMarks = values.GetMarks();
        return XLib.XCreateGC(drawable.Display, drawable.Xid.AsDrawable(), valueMarks, in gcValues);
    }

    /// <summary>
    /// 获取可绘制对象的矩形内容。
    /// </summary>
    /// <param name="drawable">可绘制对象。</param>
    /// <param name="rectangle">矩形区域。</param>
    /// <param name="planeMask">平面掩码。</param>
    /// <param name="format">图像格式。</param>
    public static unsafe X11Image? GetImage<TDrawable>(this X11DisplayXid<TDrawable> drawable, Rectangle rectangle, ulong planeMask, ImageFormat format)
        where TDrawable : struct, IXid, IDrawable
    {
        return X11Image.FromImage(XLib.XGetImage(drawable.Display, drawable.Xid.AsDrawable(), rectangle.X, rectangle.Y, rectangle.Width, rectangle.Height,
            (ULong)planeMask, format));
    }
}
