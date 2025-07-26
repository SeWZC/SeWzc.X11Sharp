using SeWzc.X11Sharp.Exceptions;
using SeWzc.X11Sharp.Internal;
using SeWzc.X11Sharp.Structs;

namespace SeWzc.X11Sharp;

public static partial class X11Lib
{
    /// <summary>
    /// 强制发送 GC 更改。
    /// </summary>
    /// <param name="gc">图形上下文。</param>
    public static void FlushGC(this X11DisplayGC gc)
    {
        XLib.XFlushGC(gc.Display, gc);
    }

    /// <summary>
    /// 在两个具有相同 root 和深度的可绘制对象之间复制区域。
    /// </summary>
    /// <param name="gc">图形上下文。</param>
    /// <param name="src">用于复制的源可绘制对象。</param>
    /// <param name="dst">用于接收复制的目标可绘制对象。</param>
    /// <param name="srcLocation">源位置。</param>
    /// <param name="areaSize">区域大小。</param>
    /// <param name="dstLocation">目标位置。</param>
    public static void CopyArea(this X11DisplayGC gc, X11Drawable src, X11Drawable dst, Point srcLocation, Size areaSize, Point dstLocation)
    {
        XLib.XCopyArea(gc.Display, src, dst, gc, srcLocation.X, srcLocation.Y, areaSize.Width, areaSize.Height, dstLocation.X, dstLocation.Y).ThrowIfError();
    }

    /// <summary>
    /// 在两个具有相同 root 和深度的可绘制对象之间复制指定平面。
    /// </summary>
    /// <param name="gc">图形上下文。</param>
    /// <param name="src">用于复制的源可绘制对象。</param>
    /// <param name="dst">用于接收复制的目标可绘制对象。</param>
    /// <param name="srcLocation">源位置。</param>
    /// <param name="areaSize">区域大小。</param>
    /// <param name="dstLocation">目标位置。</param>
    /// <param name="bitPlane">指定平面，必须只有一个位被设置为 1。</param>
    public static void CopyPlane(this X11DisplayGC gc, X11Drawable src, X11Drawable dst, Point srcLocation, Size areaSize, Point dstLocation,
        uint bitPlane)
    {
        XLib.XCopyPlane(gc.Display, src, dst, gc, srcLocation.X, srcLocation.Y, areaSize.Width, areaSize.Height, dstLocation.X, dstLocation.Y, bitPlane)
            .ThrowIfError();
    }

    /// <summary>
    /// 在可绘制对象上绘制点。
    /// </summary>
    /// <param name="gc">图形上下文。</param>
    /// <param name="drawable">可绘制对象。</param>
    /// <param name="location">点的位置。</param>
    public static void DrawPoint(this X11DisplayGC gc, X11Drawable drawable, X11Point location)
    {
        XLib.XDrawPoint(gc.Display, drawable, gc, location.X, location.Y).ThrowIfError();
    }

    /// <summary>
    /// 在可绘制对象上多个位置绘制点。
    /// </summary>
    /// <param name="gc">图形上下文。</param>
    /// <param name="drawable">可绘制对象。</param>
    /// <param name="points">点的位置。</param>
    /// <param name="mode">坐标模式。每个点是相对于前一个点还是相对于原点。</param>
    public static unsafe void DrawPoints(this X11DisplayGC gc, X11Drawable drawable, X11Point[] points, CoordMode mode)
    {
        fixed (X11Point* p = points)
            XLib.XDrawPoints(gc.Display, drawable, gc, p, points.Length, mode).ThrowIfError();
    }

    /// <summary>
    /// 在可绘制对象上绘制线段。
    /// </summary>
    /// <param name="gc">图形上下文。</param>
    /// <param name="drawable">可绘制对象。</param>
    /// <param name="segment">线段。</param>
    public static void DrawLine(this X11DisplayGC gc, X11Drawable drawable, X11Segment segment)
    {
        XLib.XDrawLine(gc.Display, drawable, gc, segment.Start.X, segment.Start.Y, segment.End.X, segment.End.Y).ThrowIfError();
    }

    /// <summary>
    /// 在可绘制对象上绘制多线段。
    /// </summary>
    /// <param name="gc">图形上下文。</param>
    /// <param name="drawable">可绘制对象。</param>
    /// <param name="segmentPoints">线段的点。</param>
    /// <param name="mode">坐标模式。每个点是相对于前一个点还是相对于原点。</param>
    public static unsafe void DrawLines(this X11DisplayGC gc, X11Drawable drawable, X11Point[] segmentPoints, CoordMode mode)
    {
        fixed (X11Point* p = segmentPoints)
            XLib.XDrawLines(gc.Display, drawable, gc, p, segmentPoints.Length, mode).ThrowIfError();
    }

    /// <summary>
    /// 在可绘制对象上绘制多条线段（不会自动连接每个线段）。
    /// </summary>
    /// <param name="gc">图形上下文。</param>
    /// <param name="drawable">可绘制对象。</param>
    /// <param name="segments">线段。</param>
    public static unsafe void DrawSegments(this X11DisplayGC gc, X11Drawable drawable, X11Segment[] segments)
    {
        fixed (X11Segment* p = segments)
            XLib.XDrawSegments(gc.Display, drawable, gc, p, segments.Length).ThrowIfError();
    }

    /// <summary>
    /// 在可绘制对象上绘制矩形。
    /// </summary>
    /// <param name="gc">图形上下文。</param>
    /// <param name="drawable">可绘制对象。</param>
    /// <param name="rectangle">矩形。</param>
    public static void DrawRectangle(this X11DisplayGC gc, X11Drawable drawable, X11Rectangle rectangle)
    {
        XLib.XDrawRectangle(gc.Display, drawable, gc, rectangle.Location.X, rectangle.Location.Y, rectangle.Size.Width, rectangle.Size.Height).ThrowIfError();
    }

    /// <summary>
    /// 在可绘制对象上绘制多个矩形。
    /// </summary>
    /// <param name="gc">图形上下文。</param>
    /// <param name="drawable">可绘制对象。</param>
    /// <param name="rectangles">矩形。</param>
    public static unsafe void DrawRectangles(this X11DisplayGC gc, X11Drawable drawable, X11Rectangle[] rectangles)
    {
        fixed (X11Rectangle* p = rectangles)
            XLib.XDrawRectangles(gc.Display, drawable, gc, p, rectangles.Length).ThrowIfError();
    }

    /// <summary>
    /// 在可绘制对象上绘制弧线。
    /// </summary>
    /// <param name="gc">图形上下文。</param>
    /// <param name="drawable">可绘制对象。</param>
    /// <param name="arc">弧线。</param>
    public static void DrawArc(this X11DisplayGC gc, X11Drawable drawable, X11Arc arc)
    {
        XLib.XDrawArc(gc.Display, drawable, gc, arc.Location.X, arc.Location.Y, arc.Size.Width, arc.Size.Height, arc.Angle1, arc.Angle2).ThrowIfError();
    }

    /// <summary>
    /// 在可绘制对象上绘制多个弧线。
    /// </summary>
    /// <param name="gc">图形上下文。</param>
    /// <param name="drawable">可绘制对象。</param>
    /// <param name="arcs">弧线。</param>
    public static unsafe void DrawArcs(this X11DisplayGC gc, X11Drawable drawable, X11Arc[] arcs)
    {
        fixed (X11Arc* p = arcs)
            XLib.XDrawArcs(gc.Display, drawable, gc, p, arcs.Length).ThrowIfError();
    }

    /// <summary>
    /// 在可绘制对象上填充矩形。
    /// </summary>
    /// <param name="gc">图形上下文。</param>
    /// <param name="drawable">可绘制对象。</param>
    /// <param name="rectangle">矩形。</param>
    public static void FillRectangle(this X11DisplayGC gc, X11Drawable drawable, X11Rectangle rectangle)
    {
        XLib.XFillRectangle(gc.Display, drawable, gc, rectangle.Location.X, rectangle.Location.Y, rectangle.Size.Width, rectangle.Size.Height).ThrowIfError();
    }

    /// <summary>
    /// 在可绘制对象上填充多个矩形。
    /// </summary>
    /// <param name="gc">图形上下文。</param>
    /// <param name="drawable">可绘制对象。</param>
    /// <param name="rectangles">矩形。</param>
    public static unsafe void FillRectangles(this X11DisplayGC gc, X11Drawable drawable, X11Rectangle[] rectangles)
    {
        fixed (X11Rectangle* p = rectangles)
            XLib.XFillRectangles(gc.Display, drawable, gc, p, rectangles.Length).ThrowIfError();
    }

    /// <summary>
    /// 在可绘制对象上填充多边形。
    /// </summary>
    /// <param name="gc">图形上下文。</param>
    /// <param name="drawable">可绘制对象。</param>
    /// <param name="points">多边形的点。</param>
    /// <param name="mode">坐标模式。每个点是相对于前一个点还是相对于原点。</param>
    /// <param name="shape">多边形的形状。有助于服务器提高性能。</param>
    public static unsafe void FillPolygon(this X11DisplayGC gc, X11Drawable drawable, X11Point[] points, PolygonShape shape, CoordMode mode)
    {
        fixed (X11Point* p = points)
            XLib.XFillPolygon(gc.Display, drawable, gc, p, points.Length, shape, mode).ThrowIfError();
    }

    /// <summary>
    /// 在可绘制对象上绘制图像。
    /// </summary>
    /// <param name="gc">图形上下文。</param>
    /// <param name="drawable">可绘制对象。</param>
    /// <param name="image">图像。</param>
    /// <param name="srcLocation">源位置。</param>
    /// <param name="dstLocation">目标位置。</param>
    /// <param name="size">图像大小。</param>
    public static unsafe void PutImage(this X11DisplayGC gc, X11Drawable drawable, X11Image image, Point srcLocation, Point dstLocation, Size size)
    {
        XLib.XPutImage(gc.Display, drawable, gc, image.XImage, srcLocation.X, srcLocation.Y, dstLocation.X, dstLocation.Y, size.Width, size.Height)
            .ThrowIfError();
    }
}
