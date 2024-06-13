namespace SeWzc.X11Sharp.Structs;

public readonly record struct Pixel(nuint PixelValue)
{
    public static implicit operator nuint(Pixel pixel)
    {
        return pixel.PixelValue;
    }

    public static implicit operator Pixel(nuint pixelValue)
    {
        return new Pixel(pixelValue);
    }
}
