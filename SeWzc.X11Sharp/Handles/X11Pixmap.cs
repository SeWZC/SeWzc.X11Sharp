namespace SeWzc.X11Sharp.Handles;

public readonly record struct X11Pixmap(nint Handle) : IX11HandleWrapper<X11Pixmap>;
