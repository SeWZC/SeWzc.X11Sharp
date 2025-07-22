namespace SeWzc.X11Sharp;

/// <summary>
/// X11DisplayXid 扩展方法。
/// </summary>
public static class X11DisplayXidExtensions
{
    /// <summary>
    /// 将可绘制的 X11DisplayXid 转换为 X11DisplayDrawable。
    /// </summary>
    /// <param name="displayDrawable"></param>
    /// <typeparam name="TDrawable"></typeparam>
    /// <returns></returns>
    public static X11DisplayDrawable AsDrawable<TDrawable>(this X11DisplayXid<TDrawable> displayDrawable)
        where TDrawable : struct, IXid, IDrawable
    {
        return new X11DisplayDrawable(displayDrawable.Display, displayDrawable.Xid.AsDrawable());
    }
}
