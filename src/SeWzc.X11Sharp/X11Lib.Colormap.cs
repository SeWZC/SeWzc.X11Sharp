using SeWzc.X11Sharp.Exceptions;
using SeWzc.X11Sharp.Internal;

namespace SeWzc.X11Sharp;

public static partial class X11Lib
{
    /// <summary>
    /// 安装颜色映射表。
    /// </summary>
    /// <param name="colormap">颜色映射表。</param>
    /// <exception cref="ArgumentNullException"></exception>
    /// <exception cref="ArgumentException"></exception>
    /// <exception cref="InvalidOperationException"></exception>
    public static void InstallColormap(this X11DisplayColormap colormap)
    {
        XLib.XInstallColormap(colormap.Display, colormap).ThrowIfError();
    }
}
