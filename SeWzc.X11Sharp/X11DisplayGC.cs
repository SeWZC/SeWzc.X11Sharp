using SeWzc.X11Sharp.Internal;
using SeWzc.X11Sharp.Structs;

namespace SeWzc.X11Sharp;

/// <summary>
/// Display 和 GC 的组合。
/// </summary>
public readonly record struct X11DisplayGC(X11Display Display, X11GC GC)
{
    /// <summary>
    /// 强制发送 GC 更改。
    /// </summary>
    public void FlushGC()
    {
        XLib.XFlushGC(Display, GC);
    }

    /// <summary>
    /// 设置 GC 的状态。
    /// </summary>
    /// <param name="foreground">前景色。</param>
    /// <param name="background">背景色。</param>
    /// <param name="function">绘图函数。</param>
    /// <param name="planeMask">平面掩码。</param>
    public void SetState(Pixel foreground, Pixel background, GraphicsFunctions function, nuint planeMask)
    {
        _ = XLib.XSetState(Display, GC, foreground, background, function, (ULong)planeMask);
    }

    /// <summary>
    /// 设置前景色。
    /// </summary>
    /// <param name="foreground">前景色。</param>
    public void SetForeground(Pixel foreground)
    {
        _ = XLib.XSetForeground(Display, GC, foreground);
    }

    /// <summary>
    /// 设置背景色。
    /// </summary>
    /// <param name="background">背景色。</param>
    public void SetBackground(Pixel background)
    {
        _ = XLib.XSetBackground(Display, GC, background);
    }

    /// <summary>
    /// 设置绘图函数。
    /// </summary>
    /// <param name="function">绘图函数。</param>
    public void SetFunction(GraphicsFunctions function)
    {
        _ = XLib.XSetFunction(Display, GC, function);
    }

    /// <summary>
    /// 设置平面掩码。
    /// </summary>
    /// <param name="planeMask">平面掩码。</param>
    public void SetPlaneMask(nuint planeMask)
    {
        _ = XLib.XSetPlaneMask(Display, GC, (ULong)planeMask);
    }

    /// <summary>
    /// 设置线条属性。
    /// </summary>
    /// <param name="lineWidth">线宽。</param>
    /// <param name="lineStyle">线型。</param>
    /// <param name="capStyle">端点样式。</param>
    /// <param name="joinStyle">连接样式。</param>
    public void SetLineAttributes(uint lineWidth, LineStyle lineStyle, CapStyle capStyle, JoinStyle joinStyle)
    {
        _ = XLib.XSetLineAttributes(Display, GC, lineWidth, lineStyle, capStyle, joinStyle);
    }

    /// <summary>
    /// 设置虚线。
    /// </summary>
    /// <param name="dashOffset">虚线偏移。</param>
    /// <param name="dashes">虚线。</param>
    public unsafe void SetDashes(int dashOffset, ReadOnlySpan<byte> dashes)
    {
        fixed (byte* ptr = dashes)
            _ = XLib.XSetDashes(Display, GC, dashOffset, ptr, dashes.Length);
    }

    /// <summary>
    /// 设置填充样式。
    /// </summary>
    /// <param name="fillStyle">填充样式。</param>
    public void SetFillStyle(FillStyle fillStyle)
    {
        _ = XLib.XSetFillStyle(Display, GC, fillStyle);
    }

    /// <summary>
    /// 设置填充规则。
    /// </summary>
    /// <param name="fillRule">填充规则。</param>
    public void SetFillRule(FillRule fillRule)
    {
        _ = XLib.XSetFillRule(Display, GC, fillRule);
    }

    /// <summary>
    /// 查询给定类别的最佳大小。
    /// </summary>
    /// <param name="class">指定要查询的类别。</param>
    /// <param name="whichScreen">指定在哪个可绘制对象所属的屏幕上进行查询。这个参数是一个可绘制对象，通常是窗口或者像素图。</param>
    /// <param name="size">指定要查询的大小。</param>
    /// <returns>
    /// 对于 <see cref="QueryBestSizeClass.CursorShape" /> 来说，这个值是指定屏幕上可以完全显示的最大尺寸；
    /// 对于 <see cref="QueryBestSizeClass.TileShape" /> 来说，这个值是可以平铺的最快尺寸；
    /// 对于 <see cref="QueryBestSizeClass.StippleShape" /> 来说，这个值是可以点画的最快尺寸。
    /// </returns>
    public Size? QueryBestSize(QueryBestSizeClass @class, X11Drawable whichScreen, Size size)
    {
        if (!XLib.XQueryBestSize(Display, @class, whichScreen, size.Width, size.Height, out var width, out var height))
            return null;

        return new Size(width, height);
    }

    /// <summary>
    /// 查询平铺的最佳尺寸。
    /// </summary>
    /// <param name="whichScreen">指定在哪个可绘制对象所属的屏幕上进行查询。这个参数是一个可绘制对象，通常是窗口或者像素图。</param>
    /// <param name="size">指定要查询的大小。</param>
    /// <returns>可以平铺的最快尺寸。</returns>
    public Size? QueryBestTil(X11Drawable whichScreen, Size size)
    {
        if (!XLib.XQueryBestTile(Display, whichScreen, size.Width, size.Height, out var w, out var h))
            return null;

        return new Size(w, h);
    }

    /// <summary>
    /// 查询点画的最佳尺寸。
    /// </summary>
    /// <param name="whichScreen">指定在哪个可绘制对象所属的屏幕上进行查询。这个参数是一个可绘制对象，通常是窗口或者像素图。</param>
    /// <param name="size">指定要查询的大小。</param>
    /// <returns>可以点画的最快尺寸。</returns>
    public Size? QueryBestStipple(X11Drawable whichScreen, Size size)
    {
        if (!XLib.XQueryBestStipple(Display, whichScreen, size.Width, size.Height, out var w, out var h))
            return null;

        return new Size(w, h);
    }

    /// <summary>
    /// 设置平铺。
    /// </summary>
    /// <param name="tile">用于平铺的像素图。深度必须与 GC 的深度相同。</param>
    public void SetTile(X11Pixmap tile)
    {
        _ = XLib.XSetTile(Display, GC, tile);
    }

    /// <summary>
    /// 设置点画。
    /// </summary>
    /// <param name="stipple">用于点画的像素图。深度必须为 1。</param>
    public void SetStipple(X11Pixmap stipple)
    {
        _ = XLib.XSetStipple(Display, GC, stipple);
    }

    /// <summary>
    /// 设置平铺和点画的原点。
    /// </summary>
    /// <param name="origin">平铺和点画的原点。</param>
    // ReSharper disable once InconsistentNaming
    public void SetTSOrigin(Point origin)
    {
        _ = XLib.XSetTSOrigin(Display, GC, origin.X, origin.Y);
    }

    /// <summary>
    /// 设置字体。
    /// </summary>
    /// <param name="font">字体。</param>
    public void SetFont(X11Font font)
    {
        _ = XLib.XSetFont(Display, GC, font);
    }

    /// <summary>
    /// 设置剪裁原点。
    /// </summary>
    /// <param name="origin"></param>
    public void SetClipOrigin(Point origin)
    {
        _ = XLib.XSetClipOrigin(Display, GC, origin.X, origin.Y);
    }

    /// <summary>
    /// 设置剪裁掩码。
    /// </summary>
    /// <param name="mask">剪裁掩码。</param>
    public void SetClipMask(X11Pixmap mask)
    {
        _ = XLib.XSetClipMask(Display, GC, mask);
    }

    /// <summary>
    /// 设置剪裁矩形。
    /// </summary>
    public unsafe void SetClipRectangles(Point origin, RectanglesOrdering ordering, ReadOnlySpan<Rectangle> rectangles)
    {
        fixed (Rectangle* ptr = rectangles)
            _ = XLib.XSetClipRectangles(Display, GC, origin.X, origin.Y, ptr, rectangles.Length, ordering);
    }

    /// <summary>
    /// 设置弧线模式。
    /// </summary>
    /// <param name="arcMode">弧线模式。</param>
    public void SetArcMode(ArcMode arcMode)
    {
        _ = XLib.XSetArcMode(Display, GC, arcMode);
    }

    /// <summary>
    /// 设置子窗口模式。
    /// </summary>
    /// <param name="mode">子窗口模式。</param>
    public void SetSubwindowMode(SubwindowMode mode)
    {
        _ = XLib.XSetSubwindowMode(Display, GC, mode);
    }

    /// <summary>
    /// 设置该 GC 是否产生图形曝光事件。
    /// </summary>
    /// <param name="graphicsExposures">该 GC 是否产生图形曝光事件。</param>
    public void SetGraphicsExposures(bool graphicsExposures)
    {
        _ = XLib.XSetGraphicsExposures(Display, GC, graphicsExposures);
    }
}
