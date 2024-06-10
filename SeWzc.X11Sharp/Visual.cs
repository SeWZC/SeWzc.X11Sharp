using SeWzc.X11Sharp.Internal;

namespace SeWzc.X11Sharp;

public unsafe class Visual
{
    internal readonly XVisual* XVisual;

    internal Visual(XVisual* visual)
    {
        XVisual = visual;
    }

    public static explicit operator Visual(IntPtr visual)
    {
        return new Visual((XVisual*)visual);
    }

    public static explicit operator IntPtr(Visual visual)
    {
        return (IntPtr)visual.XVisual;
    }
}
