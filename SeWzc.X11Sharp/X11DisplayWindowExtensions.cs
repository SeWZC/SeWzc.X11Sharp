using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text;
using SeWzc.X11Sharp.Exceptions;
using SeWzc.X11Sharp.Internal;
using SeWzc.X11Sharp.Structs;

namespace SeWzc.X11Sharp;

/// <summary>
/// X11DisplayWindow 的扩展方法。
/// </summary>
public static class X11DisplayWindowExtensions
{
    /// <summary>
    /// 销毁窗口。
    /// </summary>
    /// <param name="window">要操作的窗口。</param>
    public static void Destroy(this X11DisplayWindow window)
    {
        XLib.XDestroyWindow(window.Display, window).ThrowIfError();
    }

    /// <summary>
    /// 映射窗口。
    /// </summary>
    /// <param name="window">要操作的窗口。</param>
    public static void Map(this X11DisplayWindow window)
    {
        XLib.XMapWindow(window.Display, window).ThrowIfError();
    }

    /// <summary>
    /// 取消映射窗口。
    /// </summary>
    /// <param name="window">要操作的窗口。</param>
    public static void Unmap(this X11DisplayWindow window)
    {
        XLib.XUnmapWindow(window.Display, window).ThrowIfError();
    }

    /// <summary>
    /// 配置窗口。
    /// </summary>
    /// <param name="window">要操作的窗口。</param>
    /// <param name="changes">窗口变化。</param>
    public static void Configure(this X11DisplayWindow window, WindowChanges changes)
    {
        var windowConfigureMask = changes.GetValueMask();
        var windowChanges = changes.ToXWindowChanges();
        XLib.XConfigureWindow(window.Display, window, windowConfigureMask, in windowChanges).ThrowIfError();
    }

    /// <summary>
    /// 移动窗口。
    /// </summary>
    /// <param name="window">要操作的窗口。</param>
    /// <param name="location">窗口左上角在父窗口的位置。</param>
    public static void Move(this X11DisplayWindow window, Point location)
    {
        XLib.XMoveWindow(window.Display, window, location.X, location.Y).ThrowIfError();
    }

    /// <summary>
    /// 重置窗口大小。
    /// </summary>
    /// <param name="window">要操作的窗口。</param>
    /// <param name="size">窗口的大小。</param>
    public static void Resize(this X11DisplayWindow window, Size size)
    {
        XLib.XResizeWindow(window.Display, window, size.Width, size.Height).ThrowIfError();
    }

    /// <summary>
    /// 移动和重置窗口大小。
    /// </summary>
    /// <param name="window">要操作的窗口。</param>
    /// <param name="location">窗口左上角在父窗口的位置。</param>
    /// <param name="size">窗口的大小。</param>
    public static void MoveResize(this X11DisplayWindow window, Point location, Size size)
    {
        XLib.XMoveResizeWindow(window.Display, window, location.X, location.Y, size.Width, size.Height).ThrowIfError();
    }

    /// <summary>
    /// 设置窗口边框宽度。
    /// </summary>
    /// <param name="window">要操作的窗口。</param>
    /// <param name="borderWidth">窗口边框宽度。</param>
    public static void SetBorderWidth(this X11DisplayWindow window, uint borderWidth)
    {
        XLib.XSetWindowBorderWidth(window.Display, window, borderWidth).ThrowIfError();
    }

    /// <summary>
    /// 升起窗口到堆栈顶部。
    /// </summary>
    /// <param name="window">要操作的窗口。</param>
    public static void Raise(this X11DisplayWindow window)
    {
        XLib.XRaiseWindow(window.Display, window).ThrowIfError();
    }

    /// <summary>
    /// 降低窗口到堆栈底部。
    /// </summary>
    /// <param name="window">要操作的窗口。</param>
    public static void Lower(this X11DisplayWindow window)
    {
        XLib.XLowerWindow(window.Display, window).ThrowIfError();
    }

    /// <summary>
    /// 改变窗口的 Attributes。
    /// </summary>
    /// <param name="window">要操作的窗口。</param>
    /// <param name="attributes">新的 Attributes。</param>
    public static void ChangeAttributes(this X11DisplayWindow window, SetWindowAttributes attributes)
    {
        var windowAttributeValueMask = attributes.GetValueMask();
        var setWindowAttributes = attributes.ToXSetWindowAttributes();
        XLib.XChangeWindowAttributes(window.Display, window, windowAttributeValueMask, in setWindowAttributes).ThrowIfError();
    }

    /// <summary>
    /// 设置窗口的背景。
    /// </summary>
    /// <param name="window">要操作的窗口。</param>
    /// <param name="pixel">背景像素。</param>
    public static void SetBackground(this X11DisplayWindow window, Pixel pixel)
    {
        XLib.XSetWindowBackground(window.Display, window, pixel).ThrowIfError();
    }

    /// <summary>
    /// 设置窗口的边框。
    /// </summary>
    /// <param name="window">要操作的窗口。</param>
    /// <param name="pixel">边框像素。</param>
    public static void SetBorder(this X11DisplayWindow window, Pixel pixel)
    {
        XLib.XSetWindowBorder(window.Display, window, pixel).ThrowIfError();
    }

    /// <summary>
    /// 查询窗口的 Attributes。
    /// </summary>
    /// <param name="window">要操作的窗口。</param>
    /// <returns>如果获取失败，则返回 <see langword="null" />；否则返回窗口的 Attributes。</returns>
    public static WindowAttributes? GetAttributes(this X11DisplayWindow window)
    {
        return XLib.XGetWindowAttributes(window.Display, window, out var windowAttributes)
            ? new WindowAttributes(windowAttributes)
            : null;
    }

    /// <summary>
    /// 在事件队列中查找该窗口与指定事件掩码的匹配事件，返回并删除找到的事件。
    /// 如果没有匹配的事件，则会清空输出缓冲区并阻塞直到有匹配的事件到来。
    /// </summary>
    /// <param name="window">要操作的窗口。</param>
    /// <param name="eventMask">事件掩码。</param>
    /// <returns>与该窗口和指定事件掩码匹配的事件。</returns>
    public static X11Event NextEvent(this X11DisplayWindow window, EventMask eventMask)
    {
        XLib.XWindowEvent(window.Display, window, eventMask, out var xEvent);
        return X11Event.FromXEvent(xEvent);
    }

    /// <summary>
    /// 在事件队列中查找该窗口与指定事件掩码的匹配事件，返回并删除找到的事件。
    /// 如果没有匹配的事件，则会立即返回 <see langword="null" />，并清空输出缓冲区。
    /// </summary>
    /// <param name="window">要操作的窗口。</param>
    /// <param name="eventMask">事件掩码。</param>
    /// <returns>与该窗口和指定事件掩码匹配的事件，如果没有匹配的事件则返回 <see langword="null" />。</returns>
    public static X11Event? TryGetEvent(this X11DisplayWindow window, EventMask eventMask)
    {
        return XLib.XCheckWindowEvent(window.Display, window, eventMask, out var xEvent) ? X11Event.FromXEvent(xEvent) : null;
    }

    /// <summary>
    /// 在事件队列和服务器连接中查找该窗口与指定事件类型的匹配事件，返回并删除找到的事件。
    /// 如果没有匹配的事件，则会立即返回 <see langword="null" />，并清空输出缓冲区。
    /// </summary>
    /// <param name="window">要操作的窗口。</param>
    /// <param name="eventType">事件类型。</param>
    /// <returns>与该窗口和指定事件类型匹配的事件，如果没有匹配的事件则返回 <see langword="null" />。</returns>
    public static X11Event? TryGetEvent(this X11DisplayWindow window, EventType eventType)
    {
        return XLib.XCheckTypedWindowEvent(window.Display, window, eventType, out var xEvent) ? X11Event.FromXEvent(xEvent) : null;
    }

    /// <summary>
    /// 创建子窗口。
    /// </summary>
    /// <param name="window">要操作的窗口。</param>
    /// <param name="location">窗口左上角在父窗口的位置。</param>
    /// <param name="size">窗口的大小。</param>
    /// <param name="borderWidth">窗口的边框宽度。</param>
    /// <param name="depth">窗口深度。</param>
    /// <param name="windowClass">窗口的类别。</param>
    /// <param name="visual">窗口的 Visual。如果为 null，则从父窗口继承。</param>
    /// <param name="attributes">窗口的 Attributes。如果为 null，则使用默认值。</param>
    /// <returns></returns>
    public static X11DisplayWindow CreateSubWindow(
        this X11DisplayWindow window,
        Point location,
        Size size, uint borderWidth, int depth,
        WindowClasses windowClass = WindowClasses.CopyFromParent,
        X11Visual? visual = null,
        SetWindowAttributes? attributes = null)
    {
        var valueMask = attributes?.GetValueMask() ?? 0;
        var windowAttributes = attributes?.ToXSetWindowAttributes() ?? default;
        return XLib.XCreateWindow(window.Display, window,
                location.X, location.Y,
                size.Width, size.Height,
                borderWidth,
                depth,
                windowClass,
                visual,
                valueMask,
                in windowAttributes)
            .WithDisplay(window.Display);
    }

    /// <summary>
    /// 创建简单子窗口。从父窗口继承属性。
    /// </summary>
    /// <param name="window">要操作的窗口。</param>
    /// <param name="location">窗口左上角在父窗口的位置。</param>
    /// <param name="size">窗口的大小。</param>
    /// <param name="borderWidth">窗口的边框宽度。</param>
    /// <param name="border">窗口的边框颜色。</param>
    /// <param name="background">窗口的背景颜色。</param>
    /// <returns></returns>
    public static X11DisplayWindow CreateSimpleSubWindow(this X11DisplayWindow window, Point location, Size size, uint borderWidth, Pixel border,
        Pixel background)
    {
        return XLib.XCreateSimpleWindow(window.Display, window,
            location.X, location.Y,
            size.Width, size.Height,
            borderWidth,
            border,
            background).WithDisplay(window.Display);
    }

    /// <summary>
    /// 获取指定时间内的运动历史记录。
    /// </summary>
    /// <param name="window">要操作的窗口。</param>
    /// <param name="start">开始时间。</param>
    /// <param name="stop">停止时间。</param>
    /// <returns>指定事件内的运动历史记录。如果服务器不支持运动历史记录，则返回 <see langword="null" />。</returns>
    public static unsafe TimeCoord[]? GetMotionHistory(this X11DisplayWindow window, Time start, Time stop)
    {
        var result = XLib.XGetMotionEvents(window.Display, window, start, stop, out var count);
        if (result == null)
            return null;

        var timeCoords = new TimeCoord[count];
        for (var i = 0; i < count; i++)
            timeCoords[i] = result[i];

        XLib.XFree(result).ThrowIfError();
        return timeCoords;
    }

    /// <summary>
    /// 将窗口的坐标转换为另一个窗口的坐标。
    /// </summary>
    /// <param name="window">要操作的窗口。</param>
    /// <param name="targetWindow">目标窗口。</param>
    /// <param name="srcPoint">源窗口上坐标。</param>
    /// <returns>转换得到的目标窗口上的坐标。如果两个窗口不在同一个屏幕上，则返回 <see langword="null" />。</returns>
    public static Point? TranslateCoordinate(this X11DisplayWindow window, X11Window targetWindow, Point srcPoint)
    {
        return XLib.XTranslateCoordinates(window.Display, window, targetWindow, srcPoint.X, srcPoint.Y, out var x, out var y, out _) ? new Point(x, y) : null;
    }

    /// <summary>
    /// 获取窗口的位置。
    /// </summary>
    /// <param name="window">要操作的窗口。</param>
    /// <returns>本质上是获取窗口的左上角坐标点在根窗口上的坐标。</returns>
    public static Point GetPosition(this X11DisplayWindow window)
    {
        window.QueryTree(out var root, out _, out _);
        XLib.XTranslateCoordinates(window.Display, window, root, 0, 0, out var x, out var y, out _);
        return new Point(x, y);
    }

    /// <summary>
    /// 更改窗口的父窗口。
    /// </summary>
    /// <param name="window">要操作的窗口。</param>
    /// <param name="parent">新的父窗口。</param>
    /// <param name="location">在父窗口中的位置。</param>
    public static void SetParent(this X11DisplayWindow window, X11Window parent, Point location = default)
    {
        XLib.XReparentWindow(window.Display, window, parent, location.X, location.Y).ThrowIfError();
    }

    #region Window Property

    /// <summary>
    /// 获取窗口的属性。
    /// </summary>
    /// <param name="window">要操作的窗口。</param>
    /// <param name="property">属性的原子。</param>
    /// <returns>
    /// 如果不存在该属性，则返回 <see langword="null" />；
    /// 如果获取到属性，则返回 <see cref="PropertyData" />，其中包含属性的类型和值，需要根据类型进行解析。
    /// </returns>
    public static unsafe PropertyData? GetProperty(this X11DisplayWindow window, X11Atom property)
    {
        XLib.XGetWindowProperty(window.Display, window, property, 0, int.MaxValue, false, new X11Atom(0),
            out var actualTypeReturn, out var actualFormatReturn, out var nitemsReturn, out var bytesAfterReturn, out var propReturn);
        if (actualFormatReturn is 0)
            return null;

        Debug.Assert(bytesAfterReturn == 0, "Unexpected bytesAfterReturn.");

        PropertyData? result = null;
        switch (actualFormatReturn)
        {
            case 8:
            {
                var prop = (byte*)propReturn;
                var value = new byte[nitemsReturn];
                fixed (void* pValue = value)
                    Unsafe.CopyBlock(pValue, prop, (uint)nitemsReturn);
                result = new PropertyData.Format8Array(actualTypeReturn.WithDisplay(window.Display), value);
                break;
            }
            case 16:
            {
                var prop = (short*)propReturn;
                var value = new short[nitemsReturn];
                fixed (void* pValue = value)
                    Unsafe.CopyBlock(pValue, prop, (uint)nitemsReturn * 2);
                result = new PropertyData.Format16Array(actualTypeReturn.WithDisplay(window.Display), value);
                break;
            }
            case 32:
            {
                var prop = (Long*)propReturn;
                var value = new Long[nitemsReturn];
                fixed (void* pValue = value)
                    Unsafe.CopyBlock(pValue, prop, (uint)((int)nitemsReturn * sizeof(Long)));
                result = new PropertyData.Format32Array(actualTypeReturn.WithDisplay(window.Display), value);
                break;
            }
            default:
            {
                Debug.Assert(false, "Unexpected actualFormatReturn.");
                break;
            }
        }

        XLib.XFree(propReturn).ThrowIfError();

        return result;
    }

    /// <summary>
    /// 设置窗口的属性。相当于使用 <see cref="PropertyMode.Replace" /> 模式改变属性。
    /// </summary>
    /// <param name="window">要操作的窗口。</param>
    /// <param name="property">要改变的属性的原子。</param>
    /// <param name="propertyData">属性的数据。</param>
    /// <exception cref="ArgumentException">属性数据类型不符合预期。</exception>
    public static void SetProperty(this X11DisplayWindow window, X11Atom property, PropertyData propertyData)
    {
        window.ChangeProperty(property, PropertyMode.Replace, propertyData);
    }

    /// <summary>
    /// 获取窗口的 utf8 类型的属性。
    /// </summary>
    /// <param name="window">要操作的窗口。</param>
    /// <param name="property">属性的原子。</param>
    /// <returns>如果不存在该属性或者属性不是 utf8 类型，则返回 <see langword="null" />；否则返回属性的值。</returns>
    public static string? GetUtf8Property(this X11DisplayWindow window, X11Atom property)
    {
        var propertyData = window.GetProperty(property);
        return propertyData switch
        {
            PropertyData.Format8Array { PropertyType: var type, Value: var value } when type == window.Display.Atoms.Utf8String =>
                Encoding.UTF8.GetString(value),
            _ => null,
        };
    }

    /// <summary>
    /// 设置窗口的 utf8 类型的属性。
    /// </summary>
    /// <param name="window">要操作的窗口。</param>
    /// <param name="property">要改变的属性的原子。</param>
    /// <param name="value">属性的值。</param>
    public static void SetUtf8Property(this X11DisplayWindow window, X11Atom property, string value)
    {
        var bytes = Encoding.UTF8.GetBytes(value);
        window.SetProperty(property, new PropertyData.Format8Array(window.Display.Atoms.Utf8String, bytes));
    }

    /// <summary>
    /// 获取窗口的原子数组类型的属性。
    /// </summary>
    /// <param name="window">要操作的窗口。</param>
    /// <param name="property">属性的原子。</param>
    /// <returns>如果不存在该属性或者属性不是原子数组类型，则返回空数组；否则返回属性的值。</returns>
    public static X11DisplayAtom[] GetAtomProperty(this X11DisplayWindow window, X11Atom property)
    {
        var propertyData = window.GetProperty(property);
        switch (propertyData)
        {
            case PropertyData.Format32Array { PropertyType: var type, Value: var value } when type == window.Display.Atoms.Atom:
                var result = new X11DisplayAtom[value.Length];
                for (var i = 0; i < value.Length; i++)
                    result[i] = new X11Atom(value[i]).WithDisplay(window.Display);
                return result;
            default:
                return [];
        }
    }

    /// <summary>
    /// 设置窗口的原子数组类型的属性。
    /// </summary>
    /// <param name="window">要操作的窗口。</param>
    /// <param name="property">要改变的属性的原子。</param>
    /// <param name="value">属性的值。</param>
    public static void SetAtomProperty(this X11DisplayWindow window, X11Atom property, X11Atom[] value)
    {
        var valueArray = new Long[value.Length];
        for (var i = 0; i < value.Length; i++)
            valueArray[i] = value[i].Id;

        window.SetProperty(property, new PropertyData.Format32Array(window.Display.Atoms.Atom, valueArray));
    }

    /// <summary>
    /// 列出窗口的属性。
    /// </summary>
    /// <param name="window">要操作的窗口。</param>
    /// <returns>指定窗口的属性的原子数组。</returns>
    public static unsafe X11DisplayAtom[] GetProperties(this X11DisplayWindow window)
    {
        var properties = XLib.XListProperties(window.Display, window, out var count);
        var atoms = new X11DisplayAtom[count];
        for (var i = 0; i < count; i++)
            atoms[i] = properties[i].WithDisplay(window.Display);

        XLib.XFree(properties).ThrowIfError();
        return atoms;
    }

    #endregion
}
