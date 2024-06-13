namespace SeWzc.X11Sharp;

public readonly record struct X11Drawable(nint Handle) : IX11HandleWrapper<X11Drawable>;
