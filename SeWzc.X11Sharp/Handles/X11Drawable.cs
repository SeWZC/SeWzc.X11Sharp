namespace SeWzc.X11Sharp.Handles;

public readonly record struct X11Drawable(nint Handle) : IX11HandleWrapper<X11Drawable>;
