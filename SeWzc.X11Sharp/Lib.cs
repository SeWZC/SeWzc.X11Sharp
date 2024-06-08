using JetBrains.Annotations;
using SeWzc.X11Sharp.Structs;

namespace SeWzc.X11Sharp;

public static class Lib
{
    /// <inheritdoc cref="Display.Open" />
    /// <seealso cref="Display.Open" />
    [MustDisposeResource]
    public static Display OpenDisplay(string? displayName = null)
    {
        return Display.Open(displayName);
    }

    /// <inheritdoc cref="Window.Create" />
    /// <seealso cref="Window.Create" />
    public static Window CreateWindow(Display display, Window parent, Point location, Size size, uint borderWidth, int depth,
        WindowClasses windowClass = WindowClasses.CopyFromParent, SetWindowAttributes? attributes = null)
    {
        return Window.Create(display, parent, location, size, borderWidth, depth, windowClass, attributes);
    }
}