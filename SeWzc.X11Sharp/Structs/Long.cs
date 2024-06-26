using System.ComponentModel;
using System.Runtime.InteropServices;

namespace SeWzc.X11Sharp.Structs;

/// <summary>
/// 与 CLong 类似，但是可以进行更丰富的类型转换。
/// </summary>
/// <param name="Value">内部的 CLong 类型。</param>
[EditorBrowsable(EditorBrowsableState.Advanced)]
public readonly record struct Long(CLong Value)
{
    public Long(nint value) : this(new CLong(value))
    {
    }

    public Long(int value) : this(new CLong(value))
    {
    }

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
}