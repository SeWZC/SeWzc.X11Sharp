using SeWzc.X11Sharp.Internal;

namespace SeWzc.X11Sharp;

/// <summary>
/// 配置窗口时的设置。
/// </summary>
public sealed class WindowChanges
{
    /// <summary>
    /// 窗口的 X 坐标。
    /// </summary>
    public int? X { get; set; }

    /// <summary>
    /// 窗口的 Y 坐标。
    /// </summary>
    public int? Y { get; set; }

    /// <summary>
    /// 窗口的宽度。
    /// </summary>
    public int? Width { get; set; }

    /// <summary>
    /// 窗口的高度。
    /// </summary>
    public int? Height { get; set; }

    /// <summary>
    /// 边框的宽度。
    /// </summary>
    public int? BorderWidth { get; set; }

    /// <summary>
    /// 指定堆叠模式中使用的兄弟窗口。如果没有指定，则使用所有的兄弟窗口。
    /// </summary>
    public X11Window? Sibling { get; set; }

    /// <summary>
    /// 堆叠模式。
    /// </summary>
    public StackMode? StackMode { get; set; }

    internal WindowChangeMask GetValueMask()
    {
        WindowChangeMask valuemask = 0;

        if (X != null)
            valuemask |= WindowChangeMask.X;
        if (Y != null)
            valuemask |= WindowChangeMask.Y;
        if (Width != null)
            valuemask |= WindowChangeMask.Width;
        if (Height != null)
            valuemask |= WindowChangeMask.Height;
        if (BorderWidth != null)
            valuemask |= WindowChangeMask.BorderWidth;
        if (Sibling != null)
            valuemask |= WindowChangeMask.Sibling;
        if (StackMode != null)
            valuemask |= WindowChangeMask.StackMode;
        return valuemask;
    }

    internal XWindowChanges ToXWindowChanges()
    {
        return new XWindowChanges
        {
            x = X ?? 0,
            y = Y ?? 0,
            width = Width ?? 0,
            height = Height ?? 0,
            border_width = BorderWidth ?? 0,
            sibling = Sibling ?? default,
            stack_mode = StackMode ?? 0,
        };
    }
}
