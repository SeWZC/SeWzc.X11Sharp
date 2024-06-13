namespace SeWzc.X11Sharp;

internal interface IX11HandleWrapper<TSelf> where TSelf : IX11HandleWrapper<TSelf>, new()
{
    nint Handle { get; init; }
}
