namespace SeWzc.X11Sharp.Handles;

public readonly record struct X11Colormap(nint Handle) : IX11HandleWrapper<X11Colormap>
{
    /// <inheritdoc />
    public static X11Colormap None { get; } = new(0);
}
