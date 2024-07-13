using System.Runtime.InteropServices;

namespace SeWzc.X11Sharp.Structs;

/// <summary>
/// 用于绘制的线段。
/// </summary>
/// <param name="Start">起点。</param>
/// <param name="End">终点。</param>
[StructLayout(LayoutKind.Sequential)]
public readonly record struct X11Segment(X11Point Start, X11Point End)
{
    /// <summary>
    /// 创建一个线段。
    /// </summary>
    /// <param name="x1">起点的 x 坐标。</param>
    /// <param name="y1">起点的 y 坐标。</param>
    /// <param name="x2">终点的 x 坐标。</param>
    /// <param name="y2">终点的 y 坐标。</param>
    public X11Segment(short x1, short y1, short x2, short y2) : this(new X11Point(x1, y1), new X11Point(x2, y2))
    {
    }
}
