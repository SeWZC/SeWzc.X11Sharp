namespace SeWzc.X11Sharp.Handles;

public readonly record struct X11Font(IntPtr Handle) : IX11HandleWrapper<X11Font>;
