namespace SeWzc.X11Sharp.Structs;

/// <summary>
/// 无符号整数的大小。
/// </summary>
/// <param name="Width">宽度。</param>
/// <param name="Height">高度。</param>
public record struct Size(uint Width, uint Height);

/// <summary>
/// 有符号整数的大小。
/// </summary>
/// <param name="Width">宽度。</param>
/// <param name="Height">高度。</param>
public record struct SSize(int Width, int Height);
