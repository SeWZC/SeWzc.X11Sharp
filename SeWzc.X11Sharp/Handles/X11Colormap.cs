namespace SeWzc.X11Sharp.Handles;

public readonly record struct X11Colormap(nint Handle) : IX11HandleWrapper<X11Colormap>;