namespace SeWzc.X11Sharp.Handles;

public readonly record struct X11Atom(nint Handle) : IX11HandleWrapper<X11Atom>
{
    /// <inheritdoc />
    public static X11Atom None { get; } = new(0);
}
