using SeWzc.X11Sharp.Internal;

namespace SeWzc.X11Sharp;

public sealed class X11Atom
{
    private X11Atom(AtomHandle handle)
    {
        Handle = handle;
    }

    internal AtomHandle Handle { get; }

    private static WeakReferenceValueDictionary<nint, X11Atom> Cache { get; } = new();

    public static explicit operator nint(X11Atom atom)
    {
        return atom.Handle.Value;
    }

    public static explicit operator X11Atom(nint handle)
    {
        return Cache.GetOrAdd(handle, static handle => new X11Atom(new AtomHandle(handle)));
    }
}
