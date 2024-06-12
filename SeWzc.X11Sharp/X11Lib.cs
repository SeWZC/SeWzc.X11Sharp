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

    /// <inheritdoc cref="X11Window.Create" />
    /// <seealso cref="X11Window.Create" />
    public static X11Window CreateWindow(X11Display display, X11Window parent, Point location, Size size, uint borderWidth, int depth,
        WindowClasses windowClass = WindowClasses.CopyFromParent, SetWindowAttributes? attributes = null)
    {
        return X11Window.Create(display, parent, location, size, borderWidth, depth, windowClass, attributes);
    }
}
