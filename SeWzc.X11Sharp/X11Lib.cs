using JetBrains.Annotations;
using SeWzc.X11Sharp.Structs;

namespace SeWzc.X11Sharp;

public static class X11Lib
{
    /// <inheritdoc cref="X11Display.Open" />
    /// <seealso cref="X11Display.Open" />
    [MustDisposeResource]
    public static X11Display OpenDisplay(string? displayName = null)
    {
        return X11Display.Open(displayName);
    }

    /// <inheritdoc cref="X11Display.CreateWindow" />
    /// <seealso cref="X11Display.CreateWindow" />
    public static X11DisplayWindow CreateWindow(X11Display display, X11Window parent, Point location, Size size, uint borderWidth, int depth,
        WindowClasses windowClass = WindowClasses.CopyFromParent, SetWindowAttributes? attributes = null)
    {
        return display.CreateWindow(parent, location, size, borderWidth, depth, windowClass, attributes);
    }

    /// <inheritdoc cref="X11Display.CreateSimpleWindow" />
    /// <seealso cref="X11Display.CreateSimpleWindow" />
    public static X11DisplayWindow CreateSimpleWindow(X11Display display, X11Window parent, Point location, Size size, uint borderWidth,
        Pixel border, Pixel background)
    {
        return display.CreateSimpleWindow(parent, location, size, borderWidth, border, background);
    }

    public static X11Atom GetAtom(X11Display display, string atomName, bool onlyIfExists = false)
    {
        return display.GetAtom(atomName, onlyIfExists);
    }
}
