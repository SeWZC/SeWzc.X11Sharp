using SeWzc.X11Sharp.Internal;

namespace SeWzc.X11Sharp;

/// <summary>
/// X11 视觉效果。
/// </summary>
public class X11Visual
{
    internal readonly VisualPtr XVisual;

    private X11Visual(VisualPtr visual)
    {
        XVisual = visual;
    }

    private static WeakReferenceValueDictionary<nint, X11Visual> Cache { get; } = new();

    #region 运算符重载

    // 强制转换不需要文档
#pragma warning disable CS1591

    public static explicit operator nint(X11Visual visual)
    {
        return visual.XVisual.Value;
    }

    public static explicit operator X11Visual?(nint ptr)
    {
        return ptr is 0 ? null : Cache.GetOrAdd(ptr, key => new X11Visual(new VisualPtr(key)));
    }

#pragma warning restore CS1591

    #endregion
}
