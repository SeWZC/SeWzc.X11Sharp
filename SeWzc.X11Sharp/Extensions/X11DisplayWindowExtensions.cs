using System.Diagnostics.CodeAnalysis;
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
}
