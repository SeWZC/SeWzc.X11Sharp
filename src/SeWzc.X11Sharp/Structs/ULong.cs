using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace SeWzc.X11Sharp.Structs;

/// <summary>
/// 与 CULong 类似，但是可以进行更丰富的类型转换。
/// </summary>
/// <param name="Value">内部的 CULong 类型。</param>
[EditorBrowsable(EditorBrowsableState.Advanced)]
public readonly record struct ULong(CULong Value) : IComparable<ULong>
{
    /// <summary>
    /// 使用 nuint 构造 ULong。
    /// </summary>
    /// <param name="value"></param>
    public ULong(nuint value) : this(new CULong(value))
    {
    }

    /// <summary>
    /// 使用 uint 构造 ULong。
    /// </summary>
    /// <param name="value"></param>
    public ULong(uint value) : this(new CULong(value))
    {
    }

    /// <inheritdoc />
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public int CompareTo(ULong other)
    {
        return Value.Value.CompareTo(other.Value.Value);
    }

    #region 运算符重载

    // 强制转换就不用文档了
#pragma warning disable CS1591

    public static implicit operator ULong(Long value)
    {
        return new ULong((nuint)value.Value.Value);
    }

    public static implicit operator CULong(ULong value)
    {
        return value.Value;
    }

    public static implicit operator ULong(CULong value)
    {
        return new ULong(value);
    }

    public static implicit operator nuint(ULong value)
    {
        return value.Value.Value;
    }

    public static explicit operator ULong(nuint value)
    {
        return new ULong(value);
    }

    public static explicit operator uint(ULong value)
    {
        return (uint)value.Value.Value;
    }

    public static implicit operator ULong(uint value)
    {
        return new ULong(value);
    }

    public static explicit operator int(ULong value)
    {
        return (int)value.Value.Value;
    }

    public static explicit operator ULong(int value)
    {
        return new ULong((nuint)value);
    }

#pragma warning restore CS1591

    #endregion
}
