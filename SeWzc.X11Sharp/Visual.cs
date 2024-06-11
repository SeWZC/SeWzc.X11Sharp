using SeWzc.X11Sharp.Internal;

namespace SeWzc.X11Sharp;

public unsafe class Visual
{
    internal readonly XVisual* XVisual;

    internal Visual(XVisual* visual)
    {
        XVisual = visual;
    }

    private static WeakReferenceValueDictionary<nint, Visual> Cache { get; } = new();

    public static explicit operator IntPtr(Visual visual)
    {
        return (IntPtr)visual.XVisual;
    }

    public static explicit operator Visual(IntPtr ptr)
    {
        return Cache.GetOrAdd(ptr, static ptr => new Visual((XVisual*)ptr));
    }
}
