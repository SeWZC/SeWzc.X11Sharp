using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace SeWzc.X11Sharp.Structs;

/// <summary>
/// 与 CLong 类似，但是可以进行更丰富的类型转换。
/// </summary>
/// <param name="Value">内部的 CLong 类型。</param>
[EditorBrowsable(EditorBrowsableState.Advanced)]
public readonly record struct Long(CLong Value) : IComparable<Long>, IFormattable
{
    /// <summary>
    /// 使用 nint 构造 Long。
    /// </summary>
    /// <param name="value"></param>
    public Long(nint value) : this(new CLong(value))
    {
    }

    /// <summary>
    /// 使用 int 构造 Long。
    /// </summary>
    /// <param name="value"></param>
    public Long(int value) : this(new CLong(value))
    {
    }

    /// <inheritdoc />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public int CompareTo(Long other)
    {
        return Value.Value.CompareTo(other.Value.Value);
    }

    /// <inheritdoc />
    public override string ToString()
    {
        return Value.Value.ToString();
    }

    /// <inheritdoc />
    public string ToString([StringSyntax("NumericFormat")] string? format, IFormatProvider? provider = null)
    {
        return Value.Value.ToString(format, provider);
    }

    #region 运算符重载

    // 强制转换就不用文档了
#pragma warning disable CS1591

    public static implicit operator Long(ULong value)
    {
        return new Long((nint)value.Value.Value);
    }

    public static implicit operator CLong(Long value)
    {
        return value.Value;
    }

    public static implicit operator Long(CLong value)
    {
        return new Long(value);
    }

    public static implicit operator nint(Long value)
    {
        return value.Value.Value;
    }

    public static explicit operator Long(nint value)
    {
        return new Long(value);
    }

    public static explicit operator int(Long value)
    {
        return (int)value.Value.Value;
    }

    public static implicit operator Long(int value)
    {
        return new Long(value);
    }

    public static explicit operator uint(Long value)
    {
        return (uint)value.Value.Value;
    }

    public static explicit operator Long(uint value)
    {
        return new Long((nint)value);
    }

#pragma warning restore CS1591

    #endregion
}
