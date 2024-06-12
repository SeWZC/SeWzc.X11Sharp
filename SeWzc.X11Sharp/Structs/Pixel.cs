namespace SeWzc.X11Sharp.Structs;

public readonly record struct Pixel(UIntPtr PixelValue)
{
    public static implicit operator UIntPtr(Pixel pixel)
    {
        return pixel.PixelValue;
    }

    public static implicit operator Pixel(UIntPtr pixelValue)
    {
        return new Pixel(pixelValue);
    }
}
