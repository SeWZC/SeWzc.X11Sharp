using System.Runtime.InteropServices;

namespace SeWzc.X11Sharp.Structs;

/// <summary>
/// 用于绘制的点。
/// </summary>
/// <param name="X">X 坐标。</param>
/// <param name="Y">Y 坐标。</param>
[StructLayout(LayoutKind.Sequential)]
public readonly record struct X11Point(short X, short Y);
