using System.Runtime.InteropServices;

namespace SeWzc.X11Sharp.Structs;

/// <summary>
/// 用于绘制的圆弧。
/// </summary>
/// <param name="Location">坐标。</param>
/// <param name="Size">大小。</param>
/// <param name="Angle1">起始角度 * 64。</param>
/// <param name="Angle2">终止角度 * 64。</param>
[StructLayout(LayoutKind.Sequential)]
public readonly record struct X11Arc(X11Point Location, Size Size, short Angle1, short Angle2)
{
    /// <summary>
    /// 创建一个圆弧。
    /// </summary>
    /// <param name="x">x 坐标。</param>
    /// <param name="y">y 坐标。</param>
    /// <param name="width">宽度。</param>
    /// <param name="height">高度。</param>
    /// <param name="angle1">起始角度 * 64。</param>
    /// <param name="angle2">终止角度 * 64。</param>
    public X11Arc(short x, short y, ushort width, ushort height, short angle1, short angle2) : this(new X11Point(x, y), new Size(width, height), angle1, angle2)
    {
    }
}
