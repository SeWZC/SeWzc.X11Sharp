using JetBrains.Annotations;
using SeWzc.X11Sharp.Structs;

namespace SeWzc.X11Sharp;

public static class Lib
{
    /// <summary>
    /// 连接到 X 服务器。
    /// </summary>
    /// <param name="displayName">显示器名称。如果为 <see langword="null" />，则默认为 DISPLAY 环境变量。</param>
    /// <returns></returns>
    /// <seealso cref="Display.Open" />
    /// <seealso href="https://www.x.org/releases/current/doc/libX11/libX11/libX11.html#XOpenDisplay" />
    [MustDisposeResource]
    public static Display OpenDisplay(string? displayName = null)
    {
        return Display.Open(displayName);
    }
}
