using System.Runtime.InteropServices;

namespace SeWzc.X11Sharp.Structs;

/// <summary>
/// 用于绘制的矩形。
/// </summary>
/// <param name="Location">左上角坐标。</param>
/// <param name="Size">大小。</param>
[StructLayout(LayoutKind.Sequential)]
public readonly record struct X11Rectangle(X11Point Location, Size Size)
{
    /// <summary>
    /// 创建一个矩形。
    /// </summary>
    /// <param name="x">左上角的 x 坐标。</param>
    /// <param name="y">左上角的 y 坐标。</param>
    /// <param name="width">宽度。</param>
    /// <param name="height">高度。</param>
    public X11Rectangle(short x, short y, ushort width, ushort height) : this(new X11Point(x, y), new Size(width, height))
    {
    }
}
