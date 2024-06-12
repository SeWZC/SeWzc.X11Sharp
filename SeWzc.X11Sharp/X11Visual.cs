using SeWzc.X11Sharp.Internal;

namespace SeWzc.X11Sharp;

public unsafe class X11Visual
{
    internal readonly XVisual* XVisual;

    internal X11Visual(XVisual* visual)
    {
        XVisual = visual;
    }

    private static WeakReferenceValueDictionary<nint, X11Visual> Cache { get; } = new();

    public static explicit operator IntPtr(X11Visual visual)
    {
        return (IntPtr)visual.XVisual;
    }

    public static explicit operator X11Visual(IntPtr ptr)
    {
        return Cache.GetOrAdd(ptr, static ptr => new X11Visual((XVisual*)ptr));
    }
}
