using JetBrains.Annotations;
using SeWzc.X11Sharp.Internal;

namespace SeWzc.X11Sharp;

/// <summary>
/// xlib 的实现。
/// </summary>
public static partial class X11Lib
{
    /// <summary>
    /// 连接到 X 服务器。通过这个方法创建的 Display，在 GC 清理时会自动关闭连接。
    /// </summary>
    /// <param name="displayName">Display 名称。如果为 <see langword="null" />，则默认为 DISPLAY 环境变量。</param>
    /// <returns></returns>
    [MustDisposeResource(true)]
    public static X11Display OpenDisplay(string? displayName = null)
    {
        var display = XLib.XOpenDisplay(displayName);
        if (display == default)
            throw new InvalidOperationException("连接到 X 服务器失败。");
        return new X11Display(display, true);
    }
}
