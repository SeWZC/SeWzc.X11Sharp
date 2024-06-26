using System.ComponentModel;
using System.Runtime.InteropServices;

namespace SeWzc.X11Sharp.Structs;

/// <summary>
/// 与 CULong 类似，但是可以进行更丰富的类型转换。
/// </summary>
/// <param name="Value">内部的 CULong 类型。</param>
[EditorBrowsable(EditorBrowsableState.Advanced)]
public readonly record struct ULong(CULong Value)
{
    public ULong(nuint value) : this(new CULong(value))
    {
    }

    public ULong(uint value) : this(new CULong(value))
    {
    }

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
}
