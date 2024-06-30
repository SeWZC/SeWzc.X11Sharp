namespace SeWzc.X11Sharp.Structs;

/// <summary>
/// 时间。单位为毫秒。
/// </summary>
/// <param name="Value"></param>
public readonly record struct Time(ULong Value)
{
    public static implicit operator ULong(Time time)
    {
        return time.Value;
    }

    public static explicit operator Time(ULong time)
    {
        return new Time(time);
    }
}
