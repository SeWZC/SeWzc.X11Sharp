namespace SeWzc.X11Sharp;

public readonly record struct X11Cursor(nint Handle) : IX11HandleWrapper<X11Cursor>;
