using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using SeWzc.X11Sharp.Internal;

namespace SeWzc.X11Sharp.Structs;

/// <summary>
/// 与 X 服务器的连接。
/// </summary>
public readonly unsafe ref struct Display
{
    private readonly ref XDisplay _display;

    private Display(ref XDisplay display)
    {
        _display = display;
    }

    /// <summary>
    /// 连接到 X 服务器。
    /// </summary>
    /// <param name="displayName">显示器名称。如果为 <see langword="null" />，则默认为 DISPLAY 环境变量。</param>
    /// <returns></returns>
    [MustDisposeResource]
    public static Display Open(string? displayName = null)
    {
        return new Display(ref Unsafe.AsRef<XDisplay>(XLib.XOpenDisplay(displayName)));
    }

    /// <summary>
    /// 关闭连接。和 <see cref="Dispose" /> 等价。
    /// </summary>
    public void Close()
    {
        _ = XLib.XCloseDisplay(_display);
    }

    /// <summary>
    /// 关闭连接。和 <see cref="Close" /> 等价。
    /// </summary>
    public void Dispose()
    {
        _ = XLib.XCloseDisplay(_display);
    }

    public static explicit operator IntPtr(Display display)
    {
        return new IntPtr(Unsafe.AsPointer(ref display._display));
    }

    public static explicit operator Display(IntPtr display)
    {
        return new Display(ref Unsafe.AsRef<XDisplay>(display.ToPointer()));
    }
}
