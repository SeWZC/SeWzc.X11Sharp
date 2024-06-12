using SeWzc.X11Sharp.Internal;

namespace SeWzc.X11Sharp;

public class X11Visual
{
    internal readonly VisualPtr XVisual;

    private X11Visual(VisualPtr visual)
    {
        XVisual = visual;
    }

    private static WeakReferenceValueDictionary<nint, X11Visual> Cache { get; } = new();

    public static explicit operator IntPtr(X11Visual visual)
    {
        return visual.XVisual.Value;
    }

    public static explicit operator X11Visual?(IntPtr ptr)
    {
        return ptr is 0 ? null : Cache.GetOrAdd(ptr, key => new X11Visual(new VisualPtr(key)));
    }
}
