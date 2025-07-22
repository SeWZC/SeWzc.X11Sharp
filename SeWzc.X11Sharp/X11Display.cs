using SeWzc.X11Sharp.Exceptions;
using SeWzc.X11Sharp.Internal;
using SeWzc.X11Sharp.Structs;

namespace SeWzc.X11Sharp;

/// <summary>
/// 与 X 服务器的连接。
/// </summary>
public sealed class X11Display : IDisposable
{
    internal readonly DisplayPtr XDisplay;

    /// <summary>
    /// </summary>
    /// <param name="xDisplay"></param>
    /// <param name="isCreateByOpen">是否由 <see cref="X11Lib.OpenDisplay" /> 创建。</param>
    /// <exception cref="ArgumentNullException"></exception>
    internal X11Display(DisplayPtr xDisplay, bool isCreateByOpen = false)
    {
        if (xDisplay == default)
            throw new ArgumentNullException(nameof(xDisplay));

        XDisplay = xDisplay;
        // 如果是 Open 方法创建的，需要主动释放资源
        // 如果是通过其他方式创建的，不需要主动释放资源
        if (!isCreateByOpen)
            GC.SuppressFinalize(this);
    }

    private static WeakReferenceValueDictionary<nint, X11Display> Cache { get; } = new();

    /// <summary>
    /// 该 Display 相关的原子。
    /// </summary>
    public X11DisplayAtoms Atoms => new(this);

    /// <summary>
    /// 不要自动关闭连接。相当于 <see cref="GC.SuppressFinalize(object)" />。
    /// </summary>
    /// <remarks>
    /// 只有通过 <see cref="X11Lib.OpenDisplay" /> 方法创建的 Display 不希望在 GC 时关闭连接，才需要调用这个方法。
    /// </remarks>
    public void DisableAutoClose()
    {
#pragma warning disable CA1816
        GC.SuppressFinalize(this);
#pragma warning restore CA1816
    }

    #region X11Lib 替代

    /// <summary>
    /// 获取连接编号。
    /// </summary>
    public int ConnectionNumber => XLib.XConnectionNumber(XDisplay);

    /// <summary>
    /// 获取默认的根窗口。
    /// </summary>
    public X11DisplayWindow DefaultRootWindow => XLib.XDefaultRootWindow(XDisplay).WithDisplay(this);

    /// <summary>
    /// 获取默认屏幕。
    /// </summary>
    /// <exception cref="InvalidOperationException">无法获取默认屏幕。</exception>
    public X11Screen DefaultScreen => (X11Screen?)XLib.XDefaultScreenOfDisplay(XDisplay) ?? throw new InvalidOperationException("Default screen is null.");

    /// <summary>
    /// 获取默认屏幕编号。
    /// </summary>
    /// <remarks>This function should be used to retrieve the screen number in applications that will use only a single screen.</remarks>
    public int DefaultScreenNumber => XLib.XDefaultScreen(XDisplay);

    /// <summary>
    /// 获取打开连接时的 Display 名称。
    /// </summary>
    public string? DisplayString => XLib.XDisplayString(XDisplay);

    /// <summary>
    /// 下一个请求的序列号。
    /// </summary>
    public uint NextRequestNumber => (uint)XLib.XNextRequest(XDisplay);

    /// <summary>
    /// 获取 X 协议的版本。
    /// </summary>
    public Version ProtocolVersion => new(XLib.XProtocolVersion(XDisplay), XLib.XProtocolRevision(XDisplay));

    /// <summary>
    /// 获取可用的屏幕数量。
    /// </summary>
    public int ScreenCount => XLib.XScreenCount(XDisplay);

    /// <summary>
    /// 获取 XY 格式中每个扫描线单元或 Z 格式中每个像素值的图像的字节顺序。
    /// </summary>
    public ByteOrder ImageByteOrder => XLib.XImageByteOrder(XDisplay);

    /// <summary>
    /// 获取指定编号的屏幕。
    /// </summary>
    /// <param name="screenNumber">屏幕的编号。</param>
    /// <returns>指定编号的屏幕。</returns>
    public X11Screen? GetScreen(int screenNumber)
    {
        return XLib.XScreenOfDisplay(XDisplay, screenNumber);
    }

    /// <summary>
    /// 获取指定屏幕上的所有深度。
    /// </summary>
    /// <param name="screenNumber">屏幕的编号。</param>
    /// <returns>如果 <paramref name="screenNumber" /> 屏幕无效，则返回 <see langword="null" />；否则返回指定屏幕上的所有深度。</returns>
    public unsafe int[]? GetDepthsOfScreen(int screenNumber)
    {
        var depths = XLib.XListDepths(XDisplay, screenNumber, out var count);
        if (depths == default)
            return null;

        var result = new int[count];
        fixed (int* p = result)
            Buffer.MemoryCopy(depths, p, count * sizeof(int), count * sizeof(int));

        XLib.XFree(depths).ThrowIfError();
        return result;
    }

    /// <summary>
    /// 列出支持的 Z 格式图像的类型。
    /// </summary>
    /// <returns>支持的 Z 格式图像的类型数组。</returns>
    public unsafe X11PixmapFormat[]? GetPixmapFormats()
    {
        var pixmapFormats = XLib.XListPixmapFormats(XDisplay, out var count);
        if (pixmapFormats == default)
            return null;

        var result = new X11PixmapFormat[count];
        for (var i = 0; i < count; i++)
            result[i] = pixmapFormats[i];

        XLib.XFree(pixmapFormats).ThrowIfError();
        return result;
    }

    #endregion

    #region 运算符重载

    /// <summary>
    /// 强制转换为 <see cref="nint" />。
    /// </summary>
    /// <param name="display"></param>
    public static explicit operator nint(X11Display display)
    {
        return display.XDisplay.Value;
    }

    /// <summary>
    /// 将一个 <see cref="nint" /> 转换为 <see cref="X11Display" />。如果 <paramref name="ptr" /> 为 0，则返回 <see langword="null" />。
    /// </summary>
    /// <param name="ptr"></param>
    public static explicit operator X11Display?(nint ptr)
    {
        return ptr is 0 ? null : Cache.GetOrAdd(ptr, static ptr => new X11Display(new DisplayPtr(ptr)));
    }

    #endregion

    #region 处置模式

    private bool _disposed;

    /// <summary>
    /// 关闭连接。和 <see cref="Dispose" /> 等价。
    /// </summary>
    private void Close()
    {
        if (_disposed)
            return;

        _disposed = true;
        Cache.Remove(XDisplay.Value);
        XLib.XCloseDisplay(XDisplay).ThrowIfError();
    }

    /// <summary>
    /// 关闭连接。
    /// </summary>
    public void Dispose()
    {
        Close();
        GC.SuppressFinalize(this);
    }

    // 终结器不需要文档
#pragma warning disable CS1591
    ~X11Display()
    {
        Close();
    }
#pragma warning restore CS1591

    #endregion
}
