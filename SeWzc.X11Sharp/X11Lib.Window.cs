using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using SeWzc.X11Sharp.Internal;
using SeWzc.X11Sharp.Structs;

namespace SeWzc.X11Sharp;

public static partial class X11Lib
{
    /// <summary>
    /// 销毁窗口。
    /// </summary>
    /// <param name="window">要操作的窗口。</param>
    /// <seealso cref="X11DisplayWindow.Destroy" />
    public static void DestroyWindow(X11DisplayWindow window)
    {
        _ = XLib.XDestroyWindow(window.Display, window);
    }

    /// <summary>
    /// 销毁子窗口。
    /// </summary>
    /// <param name="window">要操作的窗口。</param>
    public static void DestroySubwindows(this X11DisplayWindow window)
    {
        _ = XLib.XDestroySubwindows(window.Display, window);
    }

    /// <summary>
    /// 映射窗口。
    /// </summary>
    /// <param name="window">要操作的窗口。</param>
    /// <seealso cref="X11DisplayWindow.Map" />
    public static void MapWindow(X11DisplayWindow window)
    {
        _ = XLib.XMapWindow(window.Display, window);
    }

    /// <summary>
    /// 映射并提升窗口。
    /// </summary>
    /// <param name="window">要操作的窗口。</param>
    public static void MapRaised(this X11DisplayWindow window)
    {
        _ = XLib.XMapRaised(window.Display, window);
    }

    /// <summary>
    /// 映射子窗口。
    /// </summary>
    /// <param name="window">要操作的窗口。</param>
    public static void MapSubwindows(this X11DisplayWindow window)
    {
        _ = XLib.XMapSubwindows(window.Display, window);
    }

    /// <summary>
    /// 取消映射窗口。
    /// </summary>
    /// <param name="window">要操作的窗口。</param>
    /// <seealso cref="X11DisplayWindow.Unmap" />
    public static void UnmapWindow(X11DisplayWindow window)
    {
        _ = XLib.XUnmapWindow(window.Display, window);
    }

    /// <summary>
    /// 取消映射子窗口。
    /// </summary>
    /// <param name="window">要操作的窗口。</param>
    public static void UnmapSubwindows(this X11DisplayWindow window)
    {
        _ = XLib.XUnmapSubwindows(window.Display, window);
    }

    /// <summary>
    /// 配置窗口。
    /// </summary>
    /// <param name="window">要操作的窗口。</param>
    /// <param name="changes">窗口变化。</param>
    /// <seealso cref="X11DisplayWindow.Configure" />
    public static void ConfigureWindow(X11DisplayWindow window, WindowChanges changes)
    {
        var windowConfigureMask = changes.GetValueMask();
        var windowChanges = changes.ToXWindowChanges();
        _ = XLib.XConfigureWindow(window.Display, window, windowConfigureMask, in windowChanges);
    }

    /// <summary>
    /// 移动窗口。
    /// </summary>
    /// <param name="window">要操作的窗口。</param>
    /// <param name="location">窗口左上角在父窗口的位置。</param>
    /// <seealso cref="X11DisplayWindow.Move" />
    public static void MoveWindow(X11DisplayWindow window, Point location)
    {
        _ = XLib.XMoveWindow(window.Display, window, location.X, location.Y);
    }

    /// <summary>
    /// 重置窗口大小。
    /// </summary>
    /// <param name="window">要操作的窗口。</param>
    /// <param name="size">窗口的大小。</param>
    /// <seealso cref="X11DisplayWindow.Resize" />
    public static void ResizeWindow(X11DisplayWindow window, Size size)
    {
        _ = XLib.XResizeWindow(window.Display, window, size.Width, size.Height);
    }

    /// <summary>
    /// 移动和重置窗口大小。
    /// </summary>
    /// <param name="window">要操作的窗口。</param>
    /// <param name="location">窗口左上角在父窗口的位置。</param>
    /// <param name="size">窗口的大小。</param>
    /// <seealso cref="X11DisplayWindow.MoveResize" />
    public static void MoveResizeWindow(X11DisplayWindow window, Point location, Size size)
    {
        _ = XLib.XMoveResizeWindow(window.Display, window, location.X, location.Y, size.Width, size.Height);
    }

    /// <summary>
    /// 设置窗口边框宽度。
    /// </summary>
    /// <param name="window">要操作的窗口。</param>
    /// <param name="borderWidth">窗口边框宽度。</param>
    /// <seealso cref="X11DisplayWindow.SetBorderWidth" />
    public static void SetWindowBorderWidth(X11DisplayWindow window, uint borderWidth)
    {
        _ = XLib.XSetWindowBorderWidth(window.Display, window, borderWidth);
    }

    /// <summary>
    /// 升起窗口到堆栈顶部。
    /// </summary>
    /// <param name="window">要操作的窗口。</param>
    /// <seealso cref="X11DisplayWindow.Raise" />
    public static void RaiseWindow(X11DisplayWindow window)
    {
        _ = XLib.XRaiseWindow(window.Display, window);
    }

    /// <summary>
    /// 降低窗口到堆栈底部。
    /// </summary>
    /// <param name="window">要操作的窗口。</param>
    /// <seealso cref="X11DisplayWindow.Lower" />
    public static void LowerWindow(X11DisplayWindow window)
    {
        _ = XLib.XLowerWindow(window.Display, window);
    }

    /// <summary>
    /// 改变窗口的 Attributes。
    /// </summary>
    /// <param name="window">要操作的窗口。</param>
    /// <param name="attributes">新的 Attributes。</param>
    /// <seealso cref="X11DisplayWindow.ChangeAttributes" />
    public static void ChangeWindowAttributes(X11DisplayWindow window, SetWindowAttributes attributes)
    {
        var windowAttributeValueMask = attributes.GetValueMask();
        var setWindowAttributes = attributes.ToXSetWindowAttributes();
        _ = XLib.XChangeWindowAttributes(window.Display, window, windowAttributeValueMask, in setWindowAttributes);
    }

    /// <summary>
    /// 设置窗口的背景。
    /// </summary>
    /// <param name="window">要操作的窗口。</param>
    /// <param name="pixel">背景像素。</param>
    /// <seealso cref="X11DisplayWindow.SetBackground" />
    public static void SetWindowBackground(X11DisplayWindow window, Pixel pixel)
    {
        _ = XLib.XSetWindowBackground(window.Display, window, pixel);
    }

    /// <summary>
    /// 设置窗口的边框。
    /// </summary>
    /// <param name="window">要操作的窗口。</param>
    /// <param name="pixel">边框像素。</param>
    /// <seealso cref="X11DisplayWindow.SetBorder" />
    public static void SetWindowBorder(X11DisplayWindow window, Pixel pixel)
    {
        _ = XLib.XSetWindowBorder(window.Display, window, pixel);
    }

    /// <summary>
    /// 查询窗口的根窗口、父窗口和子窗口。
    /// </summary>
    /// <param name="window">要操作的窗口。</param>
    /// <param name="root">根窗口。</param>
    /// <param name="parent">父窗口。</param>
    /// <param name="children">子窗口。</param>
    /// <returns>是否查询成功。</returns>
    public static unsafe bool QueryTree(this X11DisplayWindow window, out X11DisplayWindow root, out X11DisplayWindow parent, out X11DisplayWindow[] children)
    {
        var success = XLib.XQueryTree(window.Display, window, out var rootWindow, out var parentWindow, out var childrenPtr,
            out var childrenCount);
        if (!success)
        {
            root = default;
            parent = default;
            children = [];
            return false;
        }

        root = rootWindow.WithDisplay(window.Display);
        parent = parentWindow.WithDisplay(window.Display);
        children = new X11DisplayWindow[childrenCount];
        for (var i = 0; i < childrenCount; i++)
            children[i] = childrenPtr[i].WithDisplay(window.Display);

        _ = XLib.XFree(childrenPtr);
        return true;
    }

    /// <summary>
    /// 查询窗口的 Attributes。
    /// </summary>
    /// <returns>如果获取失败，则返回 <see langword="null" />；否则返回窗口的 Attributes。</returns>
    /// <seealso cref="X11DisplayWindow.GetAttributes" />
    public static WindowAttributes? GetWindowAttributes(X11DisplayWindow window)
    {
        return XLib.XGetWindowAttributes(window.Display, window, out var windowAttributes)
            ? new WindowAttributes(windowAttributes)
            : null;
    }

    /// <summary>
    /// 清理窗口的矩形区域。
    /// </summary>
    /// <remarks>
    /// 使用窗口的背景图或背景像素填充矩形区域。
    /// </remarks>
    /// <param name="window">要操作的窗口。</param>
    /// <param name="rectangle">矩形区域。</param>
    /// <param name="exposures">是否发送曝光事件。</param>
    public static void ClearArea(this X11DisplayWindow window, Rectangle rectangle, bool exposures)
    {
        _ = XLib.XClearArea(window.Display, window, rectangle.X, rectangle.Y, rectangle.Width, rectangle.Height, exposures);
    }

    /// <summary>
    /// 清理整个窗口，但不发送曝光事件。
    /// </summary>
    /// <remarks>
    /// 使用窗口的背景图或背景像素填充整个窗口。
    /// </remarks>
    /// <param name="window">要操作的窗口。</param>
    public static void ClearWindow(this X11DisplayWindow window)
    {
        _ = XLib.XClearWindow(window.Display, window);
    }

    /// <summary>
    /// 请求 X 服务报告与指定事件掩码关联的事件。
    /// </summary>
    /// <param name="window">要操作的窗口。</param>
    /// <param name="eventMask">事件掩码。</param>
    public static void SelectInput(this X11DisplayWindow window, EventMask eventMask)
    {
        _ = XLib.XSelectInput(window.Display, window, eventMask);
    }

    /// <summary>
    /// 在事件队列中查找该窗口与指定事件掩码的匹配事件，返回并删除找到的事件。
    /// 如果没有匹配的事件，则会清空输出缓冲区并阻塞直到有匹配的事件到来。
    /// </summary>
    /// <param name="window">要操作的窗口。</param>
    /// <param name="eventMask">事件掩码。</param>
    /// <returns>与该窗口和指定事件掩码匹配的事件。</returns>
    /// <seealso cref="X11DisplayWindow.NextEvent" />
    public static X11Event WindowEvent(X11DisplayWindow window, EventMask eventMask)
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
    /// <seealso cref="X11DisplayWindow.TryGetEvent(EventMask)" />
    public static X11Event? CheckWindowEvent(X11DisplayWindow window, EventMask eventMask)
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
    /// <seealso cref="X11DisplayWindow.TryGetEvent(EventType)" />
    public static X11Event? CheckTypedWindowEvent(X11DisplayWindow window, EventType eventType)
    {
        return XLib.XCheckTypedWindowEvent(window.Display, window, eventType, out var xEvent) ? X11Event.FromXEvent(xEvent) : null;
    }

    /// <summary>
    /// 将事件发送到该窗口。
    /// </summary>
    /// <param name="window">要操作的窗口。</param>
    /// <param name="propagate"></param>
    /// <param name="eventMask">事件掩码。</param>
    /// <param name="xEvent">要发送的事件。</param>
    /// <returns>是否能够解析该事件。</returns>
    public static bool SendEvent(this X11DisplayWindow window, bool propagate, EventMask eventMask, X11Event xEvent)
    {
        var result = XLib.XSendEvent(window.Display, window, propagate, eventMask, xEvent.ToXEvent());
        if (!result)
            Debug.WriteLine("Failed to send event.");
        return result;
    }

    /// <summary>
    /// 获取指定时间内的运动历史记录。
    /// </summary>
    /// <param name="window">要操作的窗口。</param>
    /// <param name="start">开始时间。</param>
    /// <param name="stop">停止时间。</param>
    /// <returns>指定事件内的运动历史记录。如果服务器不支持运动历史记录，则返回 <see langword="null" />。</returns>
    /// <seealso cref="X11DisplayWindow.GetMotionHistory" />
    public static unsafe TimeCoord[]? GetMotionEvents(X11DisplayWindow window, Time start, Time stop)
    {
        var result = XLib.XGetMotionEvents(window.Display, window, start, stop, out var count);
        if (result == null)
            return null;

        var timeCoords = new TimeCoord[count];
        for (var i = 0; i < count; i++)
            timeCoords[i] = result[i];

        _ = XLib.XFree(result);
        return timeCoords;
    }

    /// <summary>
    /// 获取窗口的属性。
    /// </summary>
    /// <param name="window">要操作的窗口。</param>
    /// <param name="property">属性的原子。</param>
    /// <returns>
    /// 如果不存在该属性，则返回 <see langword="null" />；
    /// 如果获取到属性，则返回 <see cref="PropertyData" />，其中包含属性的类型和值，需要根据类型进行解析。
    /// </returns>
    /// <seealso cref="X11DisplayWindow.GetProperty" />
    public static unsafe PropertyData? GetWindowProperty(X11DisplayWindow window, X11Atom property)
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

        _ = XLib.XFree(propReturn);

        return result;
    }

    /// <summary>
    /// 改变窗口的属性。
    /// </summary>
    /// <param name="window">要操作的窗口。</param>
    /// <param name="property">要改变的属性的原子。</param>
    /// <param name="mode">修改属性的模式。</param>
    /// <param name="propertyData">属性的数据。</param>
    /// <exception cref="ArgumentException">属性数据类型不符合预期。</exception>
    public static unsafe void ChangeProperty(this X11DisplayWindow window, X11Atom property, PropertyMode mode, PropertyData propertyData)
    {
        switch (propertyData)
        {
            case PropertyData.Format8Array format8ArrayData:
            {
                var value = format8ArrayData.Value;
                fixed (byte* pValue = value)
                {
                    _ = XLib.XChangeProperty(window.Display, window, property, format8ArrayData.PropertyType, 8, mode, pValue,
                        value.Length);
                }

                break;
            }
            case PropertyData.Format16Array format16ArrayData:
            {
                var value = format16ArrayData.Value;
                fixed (short* pValue = value)
                {
                    _ = XLib.XChangeProperty(window.Display, window, property, format16ArrayData.PropertyType, 16, mode, pValue,
                        value.Length);
                }

                break;
            }
            case PropertyData.Format32Array format32ArrayData:
            {
                var value = format32ArrayData.Value;
                fixed (Long* pValue = value)
                {
                    _ = XLib.XChangeProperty(window.Display, window, property, format32ArrayData.PropertyType, 32, mode, pValue,
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
    /// 列出窗口的属性。
    /// </summary>
    /// <returns>指定窗口的属性的原子数组。</returns>
    /// <seealso cref="X11DisplayWindow.GetProperties" />
    public static unsafe X11DisplayAtom[] ListProperties(X11DisplayWindow window)
    {
        var properties = XLib.XListProperties(window.Display, window, out var count);
        var atoms = new X11DisplayAtom[count];
        for (var i = 0; i < count; i++)
            atoms[i] = properties[i].WithDisplay(window.Display);

        _ = XLib.XFree(properties);
        return atoms;
    }

    /// <summary>
    /// 删除窗口的属性。
    /// </summary>
    /// <param name="window">要操作的窗口。</param>
    /// <param name="property">要删除的属性的原子。</param>
    public static void DeleteProperty(this X11DisplayWindow window, X11Atom property)
    {
        _ = XLib.XDeleteProperty(window.Display, window, property);
    }
}
