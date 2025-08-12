namespace SeWzc.X11Sharp.Structs;

/// <summary>
/// 像素。
/// </summary>
public readonly record struct Pixel : IFormattable
{
    internal Pixel(ULong PixelValue)
    {
        this.PixelValue = PixelValue;
    }

    /// <summary>
    /// 通过像素值构造像素。
    /// </summary>
    /// <param name="PixelValue"></param>
    public Pixel(uint PixelValue)
    {
        this.PixelValue = PixelValue;
    }

    /// <summary>
    /// 像素值。
    /// </summary>
    public ULong PixelValue { get; init; }

    /// <inheritdoc />
    public override string ToString()
    {
        return $"{PixelValue:X8}";
    }

    /// <inheritdoc />
    public string ToString(string? format, IFormatProvider? formatProvider)
    {
        return PixelValue.ToString(format, formatProvider);
    }

    #region 运算符重载

    // 强制转换就不用文档了
#pragma warning disable CS1591

    public static implicit operator ULong(Pixel pixel)
    {
        return pixel.PixelValue;
    }

    public static implicit operator Pixel(ULong pixelValue)
    {
        return new Pixel(pixelValue);
    }

    public static implicit operator Pixel(uint pixelValue)
    {
        return new Pixel(pixelValue);
    }

    public static implicit operator uint(Pixel pixel)
    {
        return (uint)pixel.PixelValue;
    }

#pragma warning restore CS1591

    #endregion
}
