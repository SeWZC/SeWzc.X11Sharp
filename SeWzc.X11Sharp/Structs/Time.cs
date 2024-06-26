namespace SeWzc.X11Sharp.Structs;

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
