using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Text;
using SeWzc.X11Sharp.Internal;
using SeWzc.X11Sharp.Structs;

namespace SeWzc.X11Sharp;

/// <summary>
/// Display 和 Window 的组合。
/// </summary>
public readonly record struct X11DisplayWindow(X11Display Display, X11Window Window)
{
    /// <summary>
    /// 销毁窗口。
    /// </summary>
    public void Destroy()
    {
        _ = XLib.XDestroyWindow(Display.XDisplay, Window);
    }

    /// <summary>
    /// 销毁子窗口。
    /// </summary>
    public void DestroySubwindows()
    {
        _ = XLib.XDestroySubwindows(Display.XDisplay, Window);
    }

    /// <summary>
    /// 映射窗口。
    /// </summary>
    public void Map()
    {
        _ = XLib.XMapWindow(Display.XDisplay, Window);
    }

    /// <summary>
    /// 映射并提升窗口。
    /// </summary>
    public void MapRaised()
    {
        _ = XLib.XMapRaised(Display.XDisplay, Window);
    }

    /// <summary>
    /// 映射子窗口。
    /// </summary>
    public void MapSubwindows()
    {
        _ = XLib.XMapSubwindows(Display.XDisplay, Window);
    }

    /// <summary>
    /// 取消映射窗口。
    /// </summary>
    public void Unmap()
    {
        _ = XLib.XUnmapWindow(Display.XDisplay, Window);
    }

    /// <summary>
    /// 取消映射子窗口。
    /// </summary>
    public void UnmapSubwindows()
    {
        _ = XLib.XUnmapSubwindows(Display.XDisplay, Window);
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
    public void SetWindowBorderWidth(uint borderWidth)
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
    /// 查询窗口的根窗口、父窗口和子窗口。
    /// </summary>
    /// <param name="root">根窗口。</param>
    /// <param name="parent">父窗口。</param>
    /// <param name="children">子窗口。</param>
    /// <returns>是否查询成功。</returns>
    public unsafe bool QueryTree([NotNullWhen(true)] out X11DisplayWindow? root,
        [NotNullWhen(true)] out X11DisplayWindow? parent, out X11DisplayWindow[] children)
    {
        var success = XLib.XQueryTree(Display.XDisplay, Window, out var rootWindow, out var parentWindow, out var childrenPtr,
            out var childrenCount);
        if (!success)
        {
            root = default;
            parent = default;
            children = [];
            return false;
        }

        root = rootWindow.WithDisplay(Display);
        parent = parentWindow.WithDisplay(Display);
        children = new X11DisplayWindow[childrenCount];
        for (var i = 0; i < childrenCount; i++)
            children[i] = childrenPtr[i].WithDisplay(Display);

        XLib.XFree(childrenPtr);
        return true;
    }

    /// <summary>
    /// 查询窗口的 Attributes。
    /// </summary>
    /// <returns>如果获取失败，则返回 <see langword="null" />；否则返回窗口的 Attributes。</returns>
    public WindowAttributes? GetAttributes()
    {
        var success = XLib.XGetWindowAttributes(Display.XDisplay, Window, out var windowAttributes);
        return success ? new WindowAttributes(windowAttributes) : null;
    }

    /// <summary>
    /// 清理窗口的矩形区域。
    /// </summary>
    /// <remarks>
    /// 使用窗口的背景图或背景像素填充矩形区域。
    /// </remarks>
    /// <param name="rectangle">矩形区域。</param>
    /// <param name="exposures">是否发送曝光事件。</param>
    public void ClearArea(Rectangle rectangle, bool exposures)
    {
        _ = XLib.XClearArea(Display.XDisplay, Window, rectangle.X, rectangle.Y, rectangle.Width, rectangle.Height, exposures);
    }

    /// <summary>
    /// 清理整个窗口，但不发送曝光事件。
    /// </summary>
    /// <remarks>
    /// 使用窗口的背景图或背景像素填充整个窗口。
    /// </remarks>
    public void ClearWindow()
    {
        _ = XLib.XClearWindow(Display.XDisplay, Window);
    }

    /// <summary>
    /// 请求 X 服务报告与指定事件掩码关联的事件。
    /// </summary>
    /// <param name="eventMask">事件掩码。</param>
    public void SelectInput(EventMask eventMask)
    {
        _ = XLib.XSelectInput(Display.XDisplay, Window, eventMask);
    }

    /// <summary>
    /// 在事件队列中查找该窗口与指定事件掩码的匹配事件，返回并删除找到的事件。
    /// 如果没有匹配的事件，则会清空输出缓冲区并阻塞直到有匹配的事件到来。
    /// </summary>
    /// <param name="eventMask">事件掩码。</param>
    /// <returns>与该窗口和指定事件掩码匹配的事件。</returns>
    public X11Event WindowEvent(EventMask eventMask)
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
    public X11Event? CheckWindowEvent(EventMask eventMask)
    {
        return XLib.XCheckWindowEvent(Display.XDisplay, Window, eventMask, out var xEvent) ? X11Event.FromXEvent(xEvent) : null;
    }

    /// <summary>
    /// 在事件队列和服务器连接中查找该窗口与指定事件类型的匹配事件，返回并删除找到的事件。
    /// 如果没有匹配的事件，则会立即返回 <see langword="null" />，并清空输出缓冲区。
    /// </summary>
    /// <param name="eventType">事件类型。</param>
    /// <returns>与该窗口和指定事件类型匹配的事件，如果没有匹配的事件则返回 <see langword="null" />。</returns>
    public X11Event? CheckTypedWindowEvent(EventType eventType)
    {
        return XLib.XCheckTypedWindowEvent(Display.XDisplay, Window, eventType, out var xEvent) ? X11Event.FromXEvent(xEvent) : null;
    }

    /// <summary>
    /// 将事件发送到该窗口。
    /// </summary>
    /// <param name="propagate"></param>
    /// <param name="eventMask">事件掩码。</param>
    /// <param name="xEvent">要发送的事件。</param>
    /// <returns>是否能够解析该事件。</returns>
    public bool SendEvent(bool propagate, EventMask eventMask, X11Event xEvent)
    {
        var result = XLib.XSendEvent(Display.XDisplay, Window, propagate, eventMask, xEvent.ToXEvent());
        if (!result)
            Debug.WriteLine("Failed to send event.");
        return result;
    }

    /// <summary>
    /// 获取指定时间内的运动历史记录。
    /// </summary>
    /// <param name="start">开始时间。</param>
    /// <param name="stop">停止时间。</param>
    /// <returns>指定事件内的运动历史记录。如果服务器不支持运动历史记录，则返回 <see langword="null" />。</returns>
    public unsafe TimeCoord[]? GetMotionEvents(Time start, Time stop)
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

        XLib.XFree(propReturn);

        return result;
    }

    /// <summary>
    /// 改变窗口的属性。
    /// </summary>
    /// <param name="property">要改变的属性的原子。</param>
    /// <param name="mode">修改属性的模式。</param>
    /// <param name="propertyData">属性的数据。</param>
    /// <exception cref="ArgumentException">属性数据类型不符合预期。</exception>
    public unsafe void ChangeProperty(X11Atom property, PropertyMode mode, PropertyData propertyData)
    {
        switch (propertyData)
        {
            case PropertyData.Format8Array format8ArrayData:
            {
                var value = format8ArrayData.Value;
                fixed (byte* pValue = value)
                {
                    XLib.XChangeProperty(Display.XDisplay, Window, property, format8ArrayData.PropertyType, 8, mode, pValue,
                        value.Length);
                }

                break;
            }
            case PropertyData.Format16Array format16ArrayData:
            {
                var value = format16ArrayData.Value;
                fixed (short* pValue = value)
                {
                    XLib.XChangeProperty(Display.XDisplay, Window, property, format16ArrayData.PropertyType, 16, mode, pValue,
                        value.Length);
                }

                break;
            }
            case PropertyData.Format32Array format32ArrayData:
            {
                var value = format32ArrayData.Value;
                fixed (Long* pValue = value)
                {
                    XLib.XChangeProperty(Display, Window, property, format32ArrayData.PropertyType, 32, mode, pValue,
                        value.Length);
                }

                break;
            }
            default:
            {
                throw new ArgumentException("Unexpected property data type.", nameof(propertyData));
            }
        }
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
    /// 改变窗口的 utf8 类型的属性。
    /// </summary>
    /// <param name="property">要改变的属性的原子。</param>
    /// <param name="mode">修改属性的模式。</param>
    /// <param name="value">属性的值。</param>
    public void ChangeUtf8Property(X11Atom property, PropertyMode mode, string value)
    {
        var bytes = Encoding.UTF8.GetBytes(value);
        ChangeProperty(property, mode, new PropertyData.Format8Array(Display.Atoms.Utf8String.Atom.WithDisplay(Display), bytes));
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
    /// 改变窗口的原子数组类型的属性。
    /// </summary>
    /// <param name="property">要改变的属性的原子。</param>
    /// <param name="mode">修改属性的模式。</param>
    /// <param name="value">属性的值。</param>
    public void ChangeAtomProperty(X11Atom property, PropertyMode mode, X11Atom[] value)
    {
        var valueArray = new Long[value.Length];
        for (var i = 0; i < value.Length; i++)
            valueArray[i] = value[i].Id;

        ChangeProperty(property, mode, new PropertyData.Format32Array(Display.Atoms.Atom.Atom.WithDisplay(Display), valueArray));
    }

    /// <summary>
    /// 列出窗口的属性。
    /// </summary>
    /// <returns>指定窗口的属性的原子数组。</returns>
    public unsafe X11DisplayAtom[] ListProperties()
    {
        var properties = XLib.XListProperties(Display.XDisplay, Window, out var count);
        var atoms = new X11DisplayAtom[count];
        for (var i = 0; i < count; i++)
            atoms[i] = properties[i].WithDisplay(Display);

        XLib.XFree(properties);
        return atoms;
    }

    /// <summary>
    /// 删除窗口的属性。
    /// </summary>
    /// <param name="property">要删除的属性的原子。</param>
    public void DeleteProperty(X11Atom property)
    {
        XLib.XDeleteProperty(Display.XDisplay, Window, property);
    }

    #endregion
}
