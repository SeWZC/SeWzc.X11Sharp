namespace SeWzc.X11Sharp.Structs;

/// <summary>
/// 时间。单位为毫秒。
/// </summary>
/// <param name="Value">毫秒数。</param>
public readonly record struct Time(ULong Value)
{
    /// <summary>
    /// 表示当前时间。注意，这里只是 x11 定义的特殊值，实际里面的值并不是当前时间。
    /// </summary>
    public static Time CurrentTime => new(0u);

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
