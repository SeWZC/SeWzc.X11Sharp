using System.Runtime.InteropServices;

namespace SeWzc.X11Sharp.Structs;

/// <summary>
/// X11 的 Pixmap 格式。
/// </summary>
/// <param name="Depth">颜色深度。</param>
/// <param name="BitsPerPixel">每个像素的位数。</param>
/// <param name="ScanlinePad">扫描线的填充数。</param>
[StructLayout(LayoutKind.Sequential)]
public readonly record struct X11PixmapFormat(int Depth, int BitsPerPixel, int ScanlinePad);
