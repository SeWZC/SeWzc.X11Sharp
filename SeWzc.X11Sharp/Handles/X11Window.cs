namespace SeWzc.X11Sharp.Handles;

/// <summary>
/// X11 窗口。
/// </summary>
public readonly record struct X11Window(nint Handle) : IX11HandleWrapper<X11Window>;
