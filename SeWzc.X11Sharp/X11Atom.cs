namespace SeWzc.X11Sharp;

public readonly record struct X11Atom(nint Handle) : IX11HandleWrapper<X11Atom>;

public static class X11Atoms
{
}
