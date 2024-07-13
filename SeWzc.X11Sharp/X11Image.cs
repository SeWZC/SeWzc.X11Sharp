using System.Runtime.InteropServices;
using SeWzc.X11Sharp.Internal;
using SeWzc.X11Sharp.Structs;

namespace SeWzc.X11Sharp;

/// <summary>
/// X11 中的图像对象。
/// </summary>
public sealed unsafe class X11Image
{
    /// <summary>
    /// 图像指针。
    /// </summary>
    internal readonly XImage* XImage;

    internal X11Image(XImage* image)
    {
        XImage = image;
    }

    /// <summary>
    /// 图像大小。
    /// </summary>
    public SSize Size => new(XImage->width, XImage->height);

    /// <summary>
    /// 图像在 X 方向上的偏移（以像素为单位）。
    /// </summary>
    public int XOffset => XImage->xoffset;

    /// <summary>
    /// 图像格式。(XYBitmap, XYPixmap, ZPixmap)
    /// </summary>
    public ImageFormat Format => XImage->format;

    /// <summary>
    /// 数据的字节顺序，可以是 LSBFirst 或 MSBFirst。
    /// </summary>
    public ByteOrder ByteOrder => XImage->byte_order;

    /// <summary>
    /// 每个扫描行的寻址单位大小，可以是 8、16 或 32。
    /// </summary>
    public int BitmapUnit => XImage->bitmap_unit;

    /// <summary>
    /// 位图的位顺序，可以是 LSBFirst 或 MSBFirst。
    /// </summary>
    public ByteOrder BitmapBitOrder => XImage->bitmap_bit_order;

    /// <summary>
    /// 每行扫描线的填充位数。
    /// </summary>
    public int BitmapPad => XImage->bitmap_pad;

    /// <summary>
    /// 颜色深度。
    /// </summary>
    public int Depth => XImage->depth;

    /// <summary>
    /// 每行的字节数。
    /// </summary>
    public int BytesPerLine => XImage->bytes_per_line;

    /// <summary>
    /// 每个像素的位数。
    /// </summary>
    public int BitsPerPixel => XImage->bits_per_pixel;

    /// <summary>
    /// 红色掩码。
    /// </summary>
    public uint RedMask => (uint)XImage->red_mask;

    /// <summary>
    /// 绿色掩码。
    /// </summary>
    public uint GreenMask => (uint)XImage->green_mask;

    /// <summary>
    /// 蓝色掩码。
    /// </summary>
    public uint BlueMask => (uint)XImage->blue_mask;

    /// <summary>
    /// 创建一个 X11Image 对象。
    /// </summary>
    /// <param name="size">图像大小。</param>
    /// <param name="xOffset">图像在 X 方向上的偏移（以像素为单位）。</param>
    /// <param name="format">图像格式。</param>
    /// <param name="data">图像数据。</param>
    /// <param name="byteOrder">数据的字节顺序。</param>
    /// <param name="bitmapUnit">每个扫描行的寻址单位大小。</param>
    /// <param name="bitmapBitOrder">位图的位顺序。</param>
    /// <param name="bitmapPad">每行扫描线的填充位数。</param>
    /// <param name="depth">颜色深度。</param>
    /// <param name="bytesPerLine">每行的字节数。</param>
    /// <param name="bitsPerPixel">每个像素的位数。</param>
    /// <param name="redMask">红色掩码。</param>
    /// <param name="greenMask">绿色掩码。</param>
    /// <param name="blueMask">蓝色掩码。</param>
    /// <returns>如果参数无法创建图像，则返回 null；否则返回创建的图像。</returns>
    public static X11Image? CreateImage(SSize size, int xOffset, ImageFormat format, byte* data, ByteOrder byteOrder, int bitmapUnit, ByteOrder bitmapBitOrder,
        int bitmapPad, int depth, int bytesPerLine, int bitsPerPixel, uint redMask, uint greenMask, uint blueMask)
    {
        var image = (XImage*)Marshal.AllocHGlobal(sizeof(XImage));
        image->width = size.Width;
        image->height = size.Height;
        image->xoffset = xOffset;
        image->format = format;
        image->data = data;
        image->byte_order = byteOrder;
        image->bitmap_unit = bitmapUnit;
        image->bitmap_bit_order = bitmapBitOrder;
        image->bitmap_pad = bitmapPad;
        image->depth = depth;
        image->bytes_per_line = bytesPerLine;
        image->bits_per_pixel = bitsPerPixel;
        image->red_mask = redMask;
        image->green_mask = greenMask;
        image->blue_mask = blueMask;

        if (XLib.XInitImage(image))
            return new X11Image(image);
        Marshal.FreeHGlobal((IntPtr)image);
        return null;
    }

    internal static X11Image? FromImage(XImage* image)
    {
        return image == null ? null : new X11Image(image);
    }

    #region 运算符重载

    /// <summary>
    /// 从 XImage 指针转换为 X11Image 对象。
    /// </summary>
    /// <param name="ptr">XImage 指针。</param>
    /// <returns></returns>
    public static explicit operator X11Image?(void* ptr)
    {
        return ptr == null ? null : new X11Image((XImage*)ptr);
    }

    /// <summary>
    /// 获取 XImage 指针。
    /// </summary>
    /// <param name="image"></param>
    /// <returns></returns>
    public static explicit operator void*(X11Image image)
    {
        return image.XImage;
    }

    #endregion
}
