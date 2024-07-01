namespace SeWzc.X11Sharp.Structs;

/// <summary>
/// 尺寸为无符号整数的矩形。
/// </summary>
/// <param name="Location">左上角坐标。</param>
/// <param name="Size">尺寸。</param>
public readonly record struct Rectangle(Point Location, Size Size)
{
    /// <summary>
    /// 创建一个矩形。
    /// </summary>
    /// <param name="x">左上角的 x 坐标。</param>
    /// <param name="y">左上角的 y 坐标。</param>
    /// <param name="width">宽度。</param>
    /// <param name="height">高度。</param>
    public Rectangle(int x, int y, uint width, uint height) : this(new Point(x, y), new Size(width, height))
    {
    }

    /// <summary>
    /// 左上角的 x 坐标。
    /// </summary>
    public int X
    {
        get => Location.X;
        init => Location = new Point(value, Y);
    }

    /// <summary>
    /// 左上角的 y 坐标。
    /// </summary>
    public int Y
    {
        get => Location.Y;
        init => Location = new Point(X, value);
    }

    /// <summary>
    /// 宽度。
    /// </summary>
    public uint Width
    {
        get => Size.Width;
        init => Size = new Size(value, Height);
    }

    /// <summary>
    /// 高度。
    /// </summary>
    public uint Height
    {
        get => Size.Height;
        init => Size = new Size(Width, value);
    }
}

/// <summary>
/// 尺寸为有符号整数的矩形。
/// </summary>
/// <param name="Location">左上角坐标。</param>
/// <param name="Size">尺寸。</param>
public readonly record struct SRectangle(Point Location, SSize Size)
{
    /// <summary>
    /// 创建一个矩形。
    /// </summary>
    /// <param name="x">左上角的 x 坐标。</param>
    /// <param name="y">左上角的 y 坐标。</param>
    /// <param name="width">宽度。</param>
    /// <param name="height">高度。</param>
    public SRectangle(int x, int y, int width, int height) : this(new Point(x, y), new SSize(width, height))
    {
    }

    /// <summary>
    /// 左上角的 x 坐标。
    /// </summary>
    public int X
    {
        get => Location.X;
        init => Location = new Point(value, Y);
    }

    /// <summary>
    /// 左上角的 y 坐标。
    /// </summary>
    public int Y
    {
        get => Location.Y;
        init => Location = new Point(X, value);
    }

    /// <summary>
    /// 宽度。
    /// </summary>
    public int Width
    {
        get => Size.Width;
        init => Size = new SSize(value, Height);
    }

    /// <summary>
    /// 高度。
    /// </summary>
    public int Height
    {
        get => Size.Height;
        init => Size = new SSize(Width, value);
    }
}
