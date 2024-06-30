namespace SeWzc.X11Sharp.Structs;

/// <summary>
/// ���ء�
/// </summary>
public readonly record struct Pixel
{
    internal Pixel(ULong PixelValue)
    {
        this.PixelValue = PixelValue;
    }

    /// <summary>
    /// ͨ������ֵ�������ء�
    /// </summary>
    /// <param name="PixelValue"></param>
    public Pixel(uint PixelValue)
    {
        this.PixelValue = PixelValue;
    }

    internal ULong PixelValue { get; init; }

    #region ���������

    // ǿ��ת���Ͳ����ĵ���
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
