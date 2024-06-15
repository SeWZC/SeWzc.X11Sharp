namespace SeWzc.X11Sharp.Handles;

public readonly record struct X11Cursor(nint Handle) : IX11HandleWrapper<X11Cursor>;
