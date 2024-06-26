namespace SeWzc.X11Sharp.Structs;

public readonly record struct Pixel
{
    internal Pixel(ULong PixelValue)
    {
        this.PixelValue = PixelValue;
    }

    public static implicit operator ULong(Pixel pixel)
    {
        return pixel.PixelValue;
    }

    public static explicit operator Pixel(ULong pixelValue)
    {
        return new Pixel(pixelValue);
    }

    public static implicit operator Pixel(uint pixelValue)
    {
        return new Pixel(pixelValue);
    }

    public static explicit operator uint(Pixel pixel)
    {
        return (uint)pixel.PixelValue;
    }

    internal ULong PixelValue { get; init; }
}
