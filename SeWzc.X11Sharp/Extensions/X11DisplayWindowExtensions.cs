using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using System.Text;
using SeWzc.X11Sharp.Handles;
using SeWzc.X11Sharp.Internal;
using SeWzc.X11Sharp.Structs;

namespace SeWzc.X11Sharp.Extensions;

/// <summary>
/// Display 和 Window 的组合。
/// </summary>
public static class X11DisplayWindowExtensions
{
    /// <summary>
    /// 销毁窗口。
    /// </summary>
    /// <param name="displayWindow">Display 和 Window 的组合。</param>
    public static void Destroy(this X11DisplayWith<X11Window> displayWindow)
    {
        _ = XLib.XDestroyWindow(displayWindow.Display.XDisplay, displayWindow.Value);
    }

    /// <summary>
    /// 销毁子窗口。
    /// </summary>
    /// <param name="displayWindow">Display 和 Window 的组合。</param>
    public static void DestroySubwindows(this X11DisplayWith<X11Window> displayWindow)
    {
        _ = XLib.XDestroySubwindows(displayWindow.Display.XDisplay, displayWindow.Value);
    }

    /// <summary>
    /// 映射窗口。
    /// </summary>
    /// <param name="displayWindow">Display 和 Window 的组合。</param>
    public static void Map(this X11DisplayWith<X11Window> displayWindow)
    {
        _ = XLib.XMapWindow(displayWindow.Display.XDisplay, displayWindow.Value);
    }

    /// <summary>
    /// 映射并提升窗口。
    /// </summary>
    /// <param name="displayWindow">Display 和 Window 的组合。</param>
    public static void MapRaised(this X11DisplayWith<X11Window> displayWindow)
    {
        _ = XLib.XMapRaised(displayWindow.Display.XDisplay, displayWindow.Value);
    }

    /// <summary>
    /// 映射子窗口。
    /// </summary>
    /// <param name="displayWindow">Display 和 Window 的组合。</param>
    public static void MapSubwindows(this X11DisplayWith<X11Window> displayWindow)
    {
        _ = XLib.XMapSubwindows(displayWindow.Display.XDisplay, displayWindow.Value);
    }

    /// <summary>
    /// 取消映射窗口。
    /// </summary>
    /// <param name="displayWindow">Display 和 Window 的组合。</param>
    public static void Unmap(this X11DisplayWith<X11Window> displayWindow)
    {
        _ = XLib.XUnmapWindow(displayWindow.Display.XDisplay, displayWindow.Value);
    }

    /// <summary>
    /// 取消映射子窗口。
    /// </summary>
    /// <param name="displayWindow">Display 和 Window 的组合。</param>
    public static void UnmapSubwindows(this X11DisplayWith<X11Window> displayWindow)
    {
        _ = XLib.XUnmapSubwindows(displayWindow.Display.XDisplay, displayWindow.Value);
    }

    /// <summary>
    /// 配置窗口。
    /// </summary>
    /// <param name="displayWindow">Display 和 Window 的组合。</param>
    /// <param name="changes">窗口变化。</param>
    public static void Configure(this X11DisplayWith<X11Window> displayWindow, WindowChanges changes)
    {
        var windowConfigureMask = changes.GetValueMask();
        var windowChanges = changes.ToXWindowChanges();
        _ = XLib.XConfigureWindow(displayWindow.Display.XDisplay, displayWindow.Value, windowConfigureMask, in windowChanges);
    }

    /// <summary>
    /// 移动窗口。
    /// </summary>
    /// <param name="displayWindow">Display 和 Window 的组合。</param>
    /// <param name="location">窗口左上角在父窗口的位置。</param>
    public static void Move(this X11DisplayWith<X11Window> displayWindow, Point location)
    {
        _ = XLib.XMoveWindow(displayWindow.Display.XDisplay, displayWindow.Value, location.X, location.Y);
    }

    /// <summary>
    /// 重置窗口大小。
    /// </summary>
    /// <param name="displayWindow">Display 和 Window 的组合。</param>
    /// <param name="size">窗口的大小。</param>
    public static void Resize(this X11DisplayWith<X11Window> displayWindow, Size size)
    {
        _ = XLib.XResizeWindow(displayWindow.Display.XDisplay, displayWindow.Value, size.Width, size.Height);
    }

    /// <summary>
    /// 移动和重置窗口大小。
    /// </summary>
    /// <param name="displayWindow">Display 和 Window 的组合。</param>
    /// <param name="location">窗口左上角在父窗口的位置。</param>
    /// <param name="size">窗口的大小。</param>
    public static void MoveResize(this X11DisplayWith<X11Window> displayWindow, Point location, Size size)
    {
        _ = XLib.XMoveResizeWindow(displayWindow.Display.XDisplay, displayWindow.Value, location.X, location.Y, size.Width, size.Height);
    }

    /// <summary>
    /// 设置窗口边框宽度。
    /// </summary>
    /// <param name="displayWindow">Display 和 Window 的组合。</param>
    /// <param name="borderWidth">窗口边框宽度。</param>
    public static void SetWindowBorderWidth(this X11DisplayWith<X11Window> displayWindow, uint borderWidth)
    {
        _ = XLib.XSetWindowBorderWidth(displayWindow.Display.XDisplay, displayWindow.Value, borderWidth);
    }

    /// <summary>
    /// 升起窗口到堆栈顶部。
    /// </summary>
    /// <param name="displayWindow">Display 和 Window 的组合。</param>
    public static void Raise(this X11DisplayWith<X11Window> displayWindow)
    {
        _ = XLib.XRaiseWindow(displayWindow.Display.XDisplay, displayWindow.Value);
    }

    /// <summary>
    /// 降低窗口到堆栈底部。
    /// </summary>
    /// <param name="displayWindow">Display 和 Window 的组合。</param>
    public static void Lower(this X11DisplayWith<X11Window> displayWindow)
    {
        _ = XLib.XLowerWindow(displayWindow.Display.XDisplay, displayWindow.Value);
    }

    /// <summary>
    /// 改变窗口的 Attributes。
    /// </summary>
    /// <param name="displayWindow">Display 和 Window 的组合。</param>
    /// <param name="attributes">新的 Attributes。</param>
    public static void ChangeAttributes(this X11DisplayWith<X11Window> displayWindow, SetWindowAttributes attributes)
    {
        var windowAttributeValueMask = attributes.GetValueMask();
        var setWindowAttributes = attributes.ToXSetWindowAttributes();
        _ = XLib.XChangeWindowAttributes(displayWindow.Display.XDisplay, displayWindow.Value, windowAttributeValueMask, in setWindowAttributes);
    }

    /// <summary>
    /// 设置窗口的背景。
    /// </summary>
    /// <param name="displayWindow">Display 和 Window 的组合。</param>
    /// <param name="pixel">背景像素。</param>
    public static void SetBackground(this X11DisplayWith<X11Window> displayWindow, Pixel pixel)
    {
        _ = XLib.XSetWindowBackground(displayWindow.Display.XDisplay, displayWindow.Value, pixel);
    }

    /// <summary>
    /// 设置窗口的边框。
    /// </summary>
    /// <param name="displayWindow">Display 和 Window 的组合。</param>
    /// <param name="pixel">边框像素。</param>
    public static void SetBorder(this X11DisplayWith<X11Window> displayWindow, Pixel pixel)
    {
        _ = XLib.XSetWindowBorder(displayWindow.Display.XDisplay, displayWindow.Value, pixel);
    }

    /// <summary>
    /// 查询窗口的根窗口、父窗口和子窗口。
    /// </summary>
    /// <param name="displayWindow">Display 和 Window 的组合。</param>
    /// <param name="root">根窗口。</param>
    /// <param name="parent">父窗口。</param>
    /// <param name="children">子窗口。</param>
    /// <returns>是否查询成功。</returns>
    public static unsafe bool QueryTree(this X11DisplayWith<X11Window> displayWindow, [NotNullWhen(true)] out X11DisplayWith<X11Window>? root,
        [NotNullWhen(true)] out X11DisplayWith<X11Window>? parent, out X11DisplayWith<X11Window>[] children)
    {
        var success = XLib.XQueryTree(displayWindow.Display.XDisplay, displayWindow.Value, out var rootWindow, out var parentWindow, out var childrenPtr,
            out var childrenCount);
        if (!success)
        {
            root = default;
            parent = default;
            children = [];
            return false;
        }

        root = rootWindow.WithDisplay(displayWindow.Display);
        parent = parentWindow.WithDisplay(displayWindow.Display);
        children = new X11DisplayWith<X11Window>[childrenCount];
        for (var i = 0; i < childrenCount; i++)
            children[i] = childrenPtr[i].WithDisplay(displayWindow.Display);

        XLib.XFree(childrenPtr);
        return true;
    }

    /// <summary>
    /// 查询窗口的 Attributes。
    /// </summary>
    /// <param name="displayWindow">Display 和 Window 的组合。</param>
    /// <returns>如果获取失败，则返回 <see langword="null" />；否则返回窗口的 Attributes。</returns>
    public static WindowAttributes? GetAttributes(this X11DisplayWith<X11Window> displayWindow)
    {
        var success = XLib.XGetWindowAttributes(displayWindow.Display.XDisplay, displayWindow.Value, out var windowAttributes);
        return success ? new WindowAttributes(windowAttributes) : null;
    }

    /// <summary>
    /// 获取窗口的属性。
    /// </summary>
    /// <param name="displayWindow">Display 和 Window 的组合。</param>
    /// <param name="property">属性的原子。</param>
    /// <returns>
    /// 如果不存在该属性，则返回 <see langword="null" />；
    /// 如果获取到属性，则返回 <see cref="X11PropertyData" />，其中包含属性的类型和值，需要根据类型进行解析。
    /// </returns>
    public static unsafe X11PropertyData? GetProperty(this X11DisplayWith<X11Window> displayWindow, X11Atom property)
    {
        XLib.XGetWindowProperty(displayWindow.Display, displayWindow.Value, property, 0, int.MaxValue, false, new X11Atom(0),
            out var actualTypeReturn, out var actualFormatReturn, out var nitemsReturn, out var bytesAfterReturn, out var propReturn);
        if (actualFormatReturn is 0)
            return null;

        Debug.Assert(bytesAfterReturn is 0, "Unexpected bytesAfterReturn.");

        X11PropertyData? result = null;
        switch (actualFormatReturn)
        {
            case 8:
            {
                var prop = (byte*)propReturn;
                var value = new byte[nitemsReturn];
                fixed(void* pValue = value)
                    Unsafe.CopyBlock(pValue, prop, (uint)nitemsReturn);
                result = new X11PropertyData.Format8Array(actualTypeReturn, value);
                break;
            }
            case 16:
            {
                var prop = (short*)propReturn;
                var value = new short[nitemsReturn];
                fixed(void* pValue = value)
                    Unsafe.CopyBlock(pValue, prop, (uint)nitemsReturn * 2);
                result = new X11PropertyData.Format16Array(actualTypeReturn, value);
                break;
            }
            case 32:
            {
                var prop = (nint*)propReturn;
                var value = new nint[nitemsReturn];
                fixed(void* pValue = value)
                    Unsafe.CopyBlock(pValue, prop, (uint)((int)nitemsReturn * sizeof(nint)));
                result = new X11PropertyData.Format32Array(actualTypeReturn, value);
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
    /// 获取窗口的 utf8 类型的属性。
    /// </summary>
    /// <param name="displayWindow">Display 和 Window 的组合。</param>
    /// <param name="property">属性的原子。</param>
    /// <returns>如果不存在该属性或者属性格式不是 8 bit 为单元，则返回 <see langword="null" />；否则返回属性的值使用 utf8 解码的结果。</returns>
    public static string? GetUtf8Property(this X11DisplayWith<X11Window> displayWindow, X11Atom property)
    {
        var propertyData = displayWindow.GetProperty(property);
        if (propertyData is null)
            return null;

        return propertyData switch
        {
            X11PropertyData.Format8Array { Value: var value } => Encoding.UTF8.GetString(value),
            _ => null,
        };
    }

    /// <summary>
    /// 列出窗口的属性。
    /// </summary>
    /// <param name="displayWindow">Display 和 Window 的组合。</param>
    /// <returns>指定窗口的属性的原子数组。</returns>
    public static unsafe X11DisplayWith<X11Atom[]> ListProperties(this X11DisplayWith<X11Window> displayWindow)
    {
        var properties = XLib.XListProperties(displayWindow.Display.XDisplay, displayWindow.Value, out var count);
        var atoms = new X11Atom[count];
        for (var i = 0; i < count; i++)
            atoms[i] = properties[i];

        XLib.XFree(properties);
        return atoms.WithDisplay(displayWindow.Display);
    }

    /// <summary>
    /// 改变窗口的属性。
    /// </summary>
    /// <param name="displayWindow">Display 和 Window 的组合。</param>
    /// <param name="property">要改变的属性的原子。</param>
    /// <param name="propertyData">属性的数据。</param>
    /// <param name="mode">修改属性的模式。</param>
    /// <exception cref="ArgumentException">属性数据类型不符合预期。</exception>
    public static unsafe void ChangeProperty(this X11DisplayWith<X11Window> displayWindow, X11Atom property, X11PropertyData propertyData, PropertyMode mode)
    {
        switch (propertyData)
        {
            case X11PropertyData.Format8Array format8ArrayData:
            {
                var value = format8ArrayData.Value;
                fixed (byte* pValue = value)
                {
                    XLib.XChangeProperty(displayWindow.Display.XDisplay, displayWindow.Value, property, format8ArrayData.PropertyType, 8, mode, pValue,
                        value.Length);
                }

                break;
            }
            case X11PropertyData.Format16Array format16ArrayData:
            {
                var value = format16ArrayData.Value;
                fixed (short* pValue = value)
                {
                    XLib.XChangeProperty(displayWindow.Display.XDisplay, displayWindow.Value, property, format16ArrayData.PropertyType, 16, mode, pValue,
                        value.Length);
                }

                break;
            }
            case X11PropertyData.Format32Array format32ArrayData:
            {
                var value = format32ArrayData.Value;
                fixed (nint* pValue = value)
                {
                    XLib.XChangeProperty(displayWindow.Display, displayWindow.Value, property, format32ArrayData.PropertyType, sizeof(nint) * 8, mode, pValue,
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
    /// 改变窗口的 utf8 类型的属性。
    /// </summary>
    /// <param name="displayWindow">Display 和 Window 的组合。</param>
    /// <param name="property">要改变的属性的原子。</param>
    /// <param name="propertyType">属性的类型的原子。</param>
    /// <param name="value">属性的值。</param>
    /// <param name="mode">修改属性的模式。</param>
    public static void ChangeUtf8Property(this X11DisplayWith<X11Window> displayWindow, X11Atom property, X11Atom propertyType , string value, PropertyMode mode)
    {
        var bytes = Encoding.UTF8.GetBytes(value);
        displayWindow.ChangeProperty(property, new X11PropertyData.Format8Array(propertyType, bytes), mode);
    }

    /// <summary>
    /// 删除窗口的属性。
    /// </summary>
    /// <param name="displayWindow">Display 和 Window 的组合。</param>
    /// <param name="property">要删除的属性的原子。</param>
    public static void DeleteProperty(this X11DisplayWith<X11Window> displayWindow, X11Atom property)
    {
        XLib.XDeleteProperty(displayWindow.Display.XDisplay, displayWindow.Value, property);
    }


}
