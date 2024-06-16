namespace SeWzc.X11Sharp;

public readonly record struct X11DisplayWith<T>(X11Display Display, T Value)
{
    public static implicit operator T(X11DisplayWith<T> displayWith)
    {
        return displayWith.Value;
    }
}
