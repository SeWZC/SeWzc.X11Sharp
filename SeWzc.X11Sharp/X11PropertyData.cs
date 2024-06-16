using SeWzc.X11Sharp.Handles;

namespace SeWzc.X11Sharp;

/// <summary>
/// X11 的属性。
/// </summary>
public abstract record X11PropertyData
{
    /// <summary>
    /// X11 的属性。
    /// </summary>
    /// <param name="PropertyType">属性类型的原子。</param>
    private X11PropertyData(X11Atom PropertyType)
    {
        this.PropertyType = PropertyType;
    }

    /// <summary>
    /// 属性类型的原子。
    /// </summary>
    public X11Atom PropertyType { get; init; }

    /// <summary>
    /// 数据为 byte[] 的 X11 的属性。
    /// </summary>
    /// <param name="PropertyType">属性类型的原子。</param>
    /// <param name="Value">属性的值。</param>
    public record Int8Array(X11Atom PropertyType, byte[] Value) : X11PropertyData(PropertyType);

    /// <summary>
    /// 数据为 short[] 的 X11 的属性。
    /// </summary>
    /// <param name="PropertyType">属性类型的原子。</param>
    /// <param name="Value">属性的值。</param>
    public record Int16Array(X11Atom PropertyType, short[] Value) : X11PropertyData(PropertyType);

    /// <summary>
    /// 数据为 int[] 的 X11 的属性。
    /// </summary>
    /// <param name="PropertyType">属性类型的原子。</param>
    /// <param name="Value">属性的值。</param>
    public record Int32Array(X11Atom PropertyType, int[] Value) : X11PropertyData(PropertyType);
}
