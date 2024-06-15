namespace SeWzc.X11Sharp;

public readonly record struct X11DisplayWith<T>(X11Display Display, T Value);
