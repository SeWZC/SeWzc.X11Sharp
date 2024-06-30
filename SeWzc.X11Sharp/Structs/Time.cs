namespace SeWzc.X11Sharp.Structs;

/// <summary>
/// 时间。单位为毫秒。
/// </summary>
/// <param name="Value">毫秒数。</param>
public readonly record struct Time(ULong Value)
{
    /// <summary>
    /// 强制转换为 ULong。
    /// </summary>
    public static implicit operator ULong(Time time)
    {
        return time.Value;
    }

    /// <summary>
    /// 强制转换为 nuint。
    /// </summary>
    /// <param name="time"></param>
    public static explicit operator Time(ULong time)
    {
        return new Time(time);
    }
}
