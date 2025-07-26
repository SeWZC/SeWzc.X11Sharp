using SeWzc.X11Sharp.Structs;

namespace SeWzc.X11Sharp;

/// <summary>
/// X11 的属性。
/// </summary>
public abstract record PropertyData
{
    /// <summary>
    /// X11 的属性。
    /// </summary>
    /// <param name="PropertyType">属性类型。</param>
    private PropertyData(X11DisplayAtom PropertyType)
    {
        this.PropertyType = PropertyType;
    }

    /// <summary>
    /// 属性类型的原子。
    /// </summary>
    public X11DisplayAtom PropertyType { get; init; }

    /// <summary>
    /// 数据格式为 8 的 X11 的属性。
    /// </summary>
    /// <param name="PropertyType">属性类型。</param>
    /// <param name="Value">属性的值。</param>
    public record Format8Array(X11DisplayAtom PropertyType, byte[] Value) : PropertyData(PropertyType);

    /// <summary>
    /// 数据格式为 16 的 X11 的属性。
    /// </summary>
    /// <param name="PropertyType">属性类型。</param>
    /// <param name="Value">属性的值。</param>
    public record Format16Array(X11DisplayAtom PropertyType, short[] Value) : PropertyData(PropertyType);

    /// <summary>
    /// 数据格式为 32 的 X11 的属性。
    /// </summary>
    /// <remarks>
    /// 对于 x11，数据格式为 32 的属性值是一个 C 语言中的 long 类型。
    /// </remarks>
    /// <param name="PropertyType">属性类型。</param>
    /// <param name="Value">属性的值。</param>
    public record Format32Array(X11DisplayAtom PropertyType, Long[] Value) : PropertyData(PropertyType);
}
