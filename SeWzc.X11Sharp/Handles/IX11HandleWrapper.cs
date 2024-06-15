using System.ComponentModel;

namespace SeWzc.X11Sharp.Handles;

[EditorBrowsable(EditorBrowsableState.Never)]
public interface IX11HandleWrapper<TSelf> where TSelf : IX11HandleWrapper<TSelf>, new()
{
    nint Handle { get; init; }

    /// <summary>
    /// 获取一个空的句柄。
    /// </summary>
    public static virtual TSelf None => new() { Handle = 0 };
}
