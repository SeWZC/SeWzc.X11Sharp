using System.Runtime.InteropServices;

namespace SeWzc.X11Sharp.Structs;

/// <summary>
/// 表示颜色的结构。
/// </summary>
[StructLayout(LayoutKind.Sequential)]
public readonly struct XColor
{
    /// <summary>
    /// 颜色对应的像素值。
    /// </summary>
    public Pixel Pixel { get; init; }

    /// <summary>
    /// 红色分量的值。
    /// </summary>
    public ushort Red { get; init; }

    /// <summary>
    /// 绿色分量的值。
    /// </summary>
    public ushort Green { get; init; }

    /// <summary>
    /// 蓝色分量的值。
    /// </summary>
    public ushort Blue { get; init; }

    /// <summary>
    /// 哪些分量是有效的。
    /// </summary>
    public byte Flags { get; init; }

    private readonly byte _pad;
}
