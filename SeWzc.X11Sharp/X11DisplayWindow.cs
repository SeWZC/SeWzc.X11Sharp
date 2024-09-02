using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text;
using SeWzc.X11Sharp.Internal;
using SeWzc.X11Sharp.Structs;

namespace SeWzc.X11Sharp;

/// <summary>
/// Display 和 Window 的组合。
/// </summary>
public readonly record struct X11DisplayWindow(X11Display Display, X11Window Window)
    : IDisplayDrawable
{
    X11Drawable IDisplayDrawable.Drawable => Window;

    /// <summary>
    /// 是否是 None 窗口。
    /// </summary>
    public bool IsNone => Window == X11Window.None;

    /// <summary>
    /// 销毁窗口。
    /// </summary>
    public void Destroy()
    {
        _ = XLib.XDestroyWindow(Display.XDisplay, Window);
    }

    /// <summary>
    /// 映射窗口。
    /// </summary>
    public void Map()
    {
        _ = XLib.XMapWindow(Display.XDisplay, Window);
    }

    /// <summary>
    /// 取消映射窗口。
    /// </summary>
    public void Unmap()
    {
        _ = XLib.XUnmapWindow(Display.XDisplay, Window);
    }

    /// <summary>
    /// 配置窗口。
    /// </summary>
    /// <param name="changes">窗口变化。</param>
    public void Configure(WindowChanges changes)
    {
        var windowConfigureMask = changes.GetValueMask();
        var windowChanges = changes.ToXWindowChanges();
        _ = XLib.XConfigureWindow(Display.XDisplay, Window, windowConfigureMask, in windowChanges);
    }

    /// <summary>
    /// 移动窗口。
    /// </summary>
    /// <param name="location">窗口左上角在父窗口的位置。</param>
    public void Move(Point location)
    {
        _ = XLib.XMoveWindow(Display.XDisplay, Window, location.X, location.Y);
    }

    /// <summary>
    /// 重置窗口大小。
    /// </summary>
    /// <param name="size">窗口的大小。</param>
    public void Resize(Size size)
    {
        _ = XLib.XResizeWindow(Display.XDisplay, Window, size.Width, size.Height);
    }

    /// <summary>
    /// 移动和重置窗口大小。
    /// </summary>
    /// <param name="location">窗口左上角在父窗口的位置。</param>
    /// <param name="size">窗口的大小。</param>
    public void MoveResize(Point location, Size size)
    {
        _ = XLib.XMoveResizeWindow(Display.XDisplay, Window, location.X, location.Y, size.Width, size.Height);
    }

    /// <summary>
    /// 设置窗口边框宽度。
    /// </summary>
    /// <param name="borderWidth">窗口边框宽度。</param>
    public void SetBorderWidth(uint borderWidth)
    {
        _ = XLib.XSetWindowBorderWidth(Display.XDisplay, Window, borderWidth);
    }

    /// <summary>
    /// 升起窗口到堆栈顶部。
    /// </summary>
    public void Raise()
    {
        _ = XLib.XRaiseWindow(Display.XDisplay, Window);
    }

    /// <summary>
    /// 降低窗口到堆栈底部。
    /// </summary>
    public void Lower()
    {
        _ = XLib.XLowerWindow(Display.XDisplay, Window);
    }

    /// <summary>
    /// 改变窗口的 Attributes。
    /// </summary>
    /// <param name="attributes">新的 Attributes。</param>
    public void ChangeAttributes(SetWindowAttributes attributes)
    {
        var windowAttributeValueMask = attributes.GetValueMask();
        var setWindowAttributes = attributes.ToXSetWindowAttributes();
        _ = XLib.XChangeWindowAttributes(Display.XDisplay, Window, windowAttributeValueMask, in setWindowAttributes);
    }

    /// <summary>
    /// 设置窗口的背景。
    /// </summary>
    /// <param name="pixel">背景像素。</param>
    public void SetBackground(Pixel pixel)
    {
        _ = XLib.XSetWindowBackground(Display.XDisplay, Window, pixel);
    }

    /// <summary>
    /// 设置窗口的边框。
    /// </summary>
    /// <param name="pixel">边框像素。</param>
    public void SetBorder(Pixel pixel)
    {
        _ = XLib.XSetWindowBorder(Display.XDisplay, Window, pixel);
    }

    /// <summary>
    /// 查询窗口的 Attributes。
    /// </summary>
    /// <returns>如果获取失败，则返回 <see langword="null" />；否则返回窗口的 Attributes。</returns>
    public WindowAttributes? GetAttributes()
    {
        return XLib.XGetWindowAttributes(Display.XDisplay, Window, out var windowAttributes)
            ? new WindowAttributes(windowAttributes)
            : null;
    }

    /// <summary>
    /// 在事件队列中查找该窗口与指定事件掩码的匹配事件，返回并删除找到的事件。
    /// 如果没有匹配的事件，则会清空输出缓冲区并阻塞直到有匹配的事件到来。
    /// </summary>
    /// <param name="eventMask">事件掩码。</param>
    /// <returns>与该窗口和指定事件掩码匹配的事件。</returns>
    public X11Event NextEvent(EventMask eventMask)
    {
        XLib.XWindowEvent(Display.XDisplay, Window, eventMask, out var xEvent);
        return X11Event.FromXEvent(xEvent);
    }

    /// <summary>
    /// 在事件队列中查找该窗口与指定事件掩码的匹配事件，返回并删除找到的事件。
    /// 如果没有匹配的事件，则会立即返回 <see langword="null" />，并清空输出缓冲区。
    /// </summary>
    /// <param name="eventMask">事件掩码。</param>
    /// <returns>与该窗口和指定事件掩码匹配的事件，如果没有匹配的事件则返回 <see langword="null" />。</returns>
    public X11Event? TryGetEvent(EventMask eventMask)
    {
        return XLib.XCheckWindowEvent(Display.XDisplay, Window, eventMask, out var xEvent) ? X11Event.FromXEvent(xEvent) : null;
    }

    /// <summary>
    /// 在事件队列和服务器连接中查找该窗口与指定事件类型的匹配事件，返回并删除找到的事件。
    /// 如果没有匹配的事件，则会立即返回 <see langword="null" />，并清空输出缓冲区。
    /// </summary>
    /// <param name="eventType">事件类型。</param>
    /// <returns>与该窗口和指定事件类型匹配的事件，如果没有匹配的事件则返回 <see langword="null" />。</returns>
    public X11Event? TryGetEvent(EventType eventType)
    {
        return XLib.XCheckTypedWindowEvent(Display.XDisplay, Window, eventType, out var xEvent) ? X11Event.FromXEvent(xEvent) : null;
    }

    /// <summary>
    /// 创建子窗口。
    /// </summary>
    /// <param name="location">窗口左上角在父窗口的位置。</param>
    /// <param name="size">窗口的大小。</param>
    /// <param name="borderWidth">窗口的边框宽度。</param>
    /// <param name="depth">窗口深度。</param>
    /// <param name="windowClass">窗口的类别。</param>
    /// <param name="visual">窗口的 Visual。如果为 null，则从父窗口继承。</param>
    /// <param name="attributes">窗口的 Attributes。如果为 null，则使用默认值。</param>
    /// <returns></returns>
    public X11DisplayWindow CreateSubWindow(Point location,
        Size size, uint borderWidth, int depth,
        WindowClasses windowClass = WindowClasses.CopyFromParent,
        X11Visual? visual = null,
        SetWindowAttributes? attributes = null)
    {
        var valueMask = attributes?.GetValueMask() ?? 0;
        var windowAttributes = attributes?.ToXSetWindowAttributes() ?? default;
        var window = XLib.XCreateWindow(Display, this,
            location.X, location.Y,
            size.Width, size.Height,
            borderWidth,
            depth,
            windowClass,
            visual,
            valueMask,
            in windowAttributes);
        return window.WithDisplay(Display);
    }

    /// <summary>
    /// 创建简单子窗口。从父窗口继承属性。
    /// </summary>
    /// <param name="location">窗口左上角在父窗口的位置。</param>
    /// <param name="size">窗口的大小。</param>
    /// <param name="borderWidth">窗口的边框宽度。</param>
    /// <param name="border">窗口的边框颜色。</param>
    /// <param name="background">窗口的背景颜色。</param>
    /// <returns></returns>
    public X11DisplayWindow CreateSimpleSubWindow(Point location, Size size, uint borderWidth, Pixel border,
        Pixel background)
    {
        var window = XLib.XCreateSimpleWindow(Display, this,
            location.X, location.Y,
            size.Width, size.Height,
            borderWidth,
            border,
            background);
        return window.WithDisplay(Display);
    }

    /// <summary>
    /// 获取指定时间内的运动历史记录。
    /// </summary>
    /// <param name="start">开始时间。</param>
    /// <param name="stop">停止时间。</param>
    /// <returns>指定事件内的运动历史记录。如果服务器不支持运动历史记录，则返回 <see langword="null" />。</returns>
    public unsafe TimeCoord[]? GetMotionHistory(Time start, Time stop)
    {
        var result = XLib.XGetMotionEvents(Display.XDisplay, Window, start, stop, out var count);
        if (result == null)
            return null;

        var timeCoords = new TimeCoord[count];
        for (var i = 0; i < count; i++)
            timeCoords[i] = result[i];

        _ = XLib.XFree(result);
        return timeCoords;
    }

    /// <summary>
    /// 作为可绘制对象使用。
    /// </summary>
    /// <returns>可绘制对象。</returns>
    public X11DisplayDrawable AsDrawable()
    {
        return new X11DisplayDrawable(Display, Window);
    }

    /// <summary>
    /// 将窗口的坐标转换为另一个窗口的坐标。
    /// </summary>
    /// <param name="targetWindow">目标窗口。</param>
    /// <param name="srcPoint">源窗口上坐标。</param>
    /// <returns>转换得到的目标窗口上的坐标。如果两个窗口不在同一个屏幕上，则返回 <see langword="null" />。</returns>
    public Point? TranslateCoordinate(X11Window targetWindow, Point srcPoint)
    {
        return XLib.XTranslateCoordinates(Display.XDisplay, Window, targetWindow, srcPoint.X, srcPoint.Y, out var x, out var y, out _) ? new Point(x, y) : null;
    }

    /// <summary>
    /// 获取窗口的位置。
    /// </summary>
    /// <returns>本质上是获取窗口的左上角坐标点在根窗口上的坐标。</returns>
    public Point GetPosition()
    {
        this.QueryTree(out var root, out _, out _);
        XLib.XTranslateCoordinates(Display.XDisplay, Window, root, 0, 0, out var x, out var y, out _);
        return new Point(x, y);
    }

    /// <summary>
    /// 更改窗口的父窗口。
    /// </summary>
    /// <param name="parent">新的父窗口。</param>
    /// <param name="location">在父窗口中的位置。</param>
    public void SetParent(X11Window parent, Point location = default)
    {
        _ = XLib.XReparentWindow(Display.XDisplay, Window, parent, location.X, location.Y);
    }

    #region 运算符重载

    // 强制转换就不用文档了
#pragma warning disable CS1591
    public static implicit operator X11Window(X11DisplayWindow displayAtom)
    {
        return displayAtom.Window;
    }

    /// <summary>
    /// 强制转换为 X11DisplayDrawable。
    /// </summary>
    public static implicit operator X11DisplayDrawable(X11DisplayWindow value)
    {
        return new X11DisplayDrawable(value.Display, value.Window);
    }

    /// <summary>
    /// 从 X11DisplayDrawable 强制转换为 X11DisplayWindow。需要确保 X11DisplayDrawable.Drawable 是一个窗口。
    /// </summary>
    public static explicit operator X11DisplayWindow(X11DisplayDrawable value)
    {
        return new X11Window(value.Drawable.Id).WithDisplay(value.Display);
    }
#pragma warning restore CS1591

    #endregion

    #region Window Property

    /// <summary>
    /// 获取窗口的属性。
    /// </summary>
    /// <param name="property">属性的原子。</param>
    /// <returns>
    /// 如果不存在该属性，则返回 <see langword="null" />；
    /// 如果获取到属性，则返回 <see cref="PropertyData" />，其中包含属性的类型和值，需要根据类型进行解析。
    /// </returns>
    public unsafe PropertyData? GetProperty(X11Atom property)
    {
        XLib.XGetWindowProperty(Display, Window, property, 0, int.MaxValue, false, new X11Atom(0),
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
                result = new PropertyData.Format8Array(actualTypeReturn.WithDisplay(Display), value);
                break;
            }
            case 16:
            {
                var prop = (short*)propReturn;
                var value = new short[nitemsReturn];
                fixed (void* pValue = value)
                    Unsafe.CopyBlock(pValue, prop, (uint)nitemsReturn * 2);
                result = new PropertyData.Format16Array(actualTypeReturn.WithDisplay(Display), value);
                break;
            }
            case 32:
            {
                var prop = (Long*)propReturn;
                var value = new Long[nitemsReturn];
                fixed (void* pValue = value)
                    Unsafe.CopyBlock(pValue, prop, (uint)((int)nitemsReturn * sizeof(Long)));
                result = new PropertyData.Format32Array(actualTypeReturn.WithDisplay(Display), value);
                break;
            }
            default:
            {
                Debug.Assert(false, "Unexpected actualFormatReturn.");
                break;
            }
        }

        _ = XLib.XFree(propReturn);

        return result;
    }

    /// <summary>
    /// 设置窗口的属性。相当于使用 <see cref="PropertyMode.Replace" /> 模式改变属性。
    /// </summary>
    /// <param name="property">要改变的属性的原子。</param>
    /// <param name="propertyData">属性的数据。</param>
    /// <exception cref="ArgumentException">属性数据类型不符合预期。</exception>
    public void SetProperty(X11Atom property, PropertyData propertyData)
    {
        this.ChangeProperty(property, PropertyMode.Replace, propertyData);
    }

    /// <summary>
    /// 获取窗口的 utf8 类型的属性。
    /// </summary>
    /// <param name="property">属性的原子。</param>
    /// <returns>如果不存在该属性或者属性不是 utf8 类型，则返回 <see langword="null" />；否则返回属性的值。</returns>
    public string? GetUtf8Property(X11Atom property)
    {
        var propertyData = GetProperty(property);
        return propertyData switch
        {
            PropertyData.Format8Array { PropertyType: var type, Value: var value } when type == Display.Atoms.Utf8String.Atom =>
                Encoding.UTF8.GetString(value),
            _ => null,
        };
    }

    /// <summary>
    /// 设置窗口的 utf8 类型的属性。
    /// </summary>
    /// <param name="property">要改变的属性的原子。</param>
    /// <param name="value">属性的值。</param>
    public void SetUtf8Property(X11Atom property, string value)
    {
        var bytes = Encoding.UTF8.GetBytes(value);
        SetProperty(property, new PropertyData.Format8Array(Display.Atoms.Utf8String.Atom.WithDisplay(Display), bytes));
    }

    /// <summary>
    /// 获取窗口的原子数组类型的属性。
    /// </summary>
    /// <param name="property">属性的原子。</param>
    /// <returns>如果不存在该属性或者属性不是原子数组类型，则返回空数组；否则返回属性的值。</returns>
    public X11DisplayAtom[] GetAtomProperty(X11Atom property)
    {
        var propertyData = GetProperty(property);
        switch (propertyData)
        {
            case PropertyData.Format32Array { PropertyType: var type, Value: var value } when type == Display.Atoms.Atom.Atom:
                var result = new X11DisplayAtom[value.Length];
                for (var i = 0; i < value.Length; i++)
                    result[i] = new X11Atom(value[i]).WithDisplay(Display);
                return result;
            default:
                return [];
        }
    }

    /// <summary>
    /// 设置窗口的原子数组类型的属性。
    /// </summary>
    /// <param name="property">要改变的属性的原子。</param>
    /// <param name="value">属性的值。</param>
    public void SetAtomProperty(X11Atom property, X11Atom[] value)
    {
        var valueArray = new Long[value.Length];
        for (var i = 0; i < value.Length; i++)
            valueArray[i] = value[i].Id;

        SetProperty(property, new PropertyData.Format32Array(Display.Atoms.Atom.Atom.WithDisplay(Display), valueArray));
    }

    /// <summary>
    /// 列出窗口的属性。
    /// </summary>
    /// <returns>指定窗口的属性的原子数组。</returns>
    public unsafe X11DisplayAtom[] GetProperties()
    {
        var properties = XLib.XListProperties(Display.XDisplay, Window, out var count);
        var atoms = new X11DisplayAtom[count];
        for (var i = 0; i < count; i++)
            atoms[i] = properties[i].WithDisplay(Display);

        _ = XLib.XFree(properties);
        return atoms;
    }

    #endregion
}
