using System.Runtime.InteropServices;

namespace SeWzc.X11Sharp.Structs;

/// <summary>
/// 时间和坐标。
/// </summary>
[StructLayout(LayoutKind.Sequential)]
public readonly record struct TimeCoord(Time Time, short X, short Y);
