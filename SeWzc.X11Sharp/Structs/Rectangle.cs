namespace SeWzc.X11Sharp.Structs;

/// <summary>
/// 矩形。
/// </summary>
/// <param name="Location">左上角坐标。</param>
/// <param name="Size">尺寸。</param>
public struct Rectangle(Point Location, Size Size);