# SeWzc.X11Sharp

该仓库是一个 X11 (X Window System) 相关内容的 C# 封装。相比于直接使用 P/Invoke 对 xlib 等库进行调用，该仓库提供了更符合 C# 使用习惯（面向对象、强类型）的类型和方法。

目前该仓库还处于起步状态，没有进行充分的测试，如果有问题，欢迎指正。

## 如何开始

首先，这个库只是一个封装，所以你所需要的大部分知识都只能从其他文档中查找。例如：[Xlib - C Language X Interface](https://www.x.org/releases/current/doc/libX11/libX11/libX11.html)。

在 xlib 中，函数往往都以 `X` 进行前缀，例如 `XDefaultRootWindow(Display*)`、 `XMoveWindow(Display *display, Window w, int x, int y)` 等。  
在该仓库中，原函数删除的前缀 `X`，并根据其参数存在作为对应类型的属性或方法。如果函数名和类型名有重复，可能会删除函数中的类型名。例如 `X11Display.DefaultRootWindow`、`X11DisplayWindow.MoveWindow`。

如果还没有打开 Display，你可以通过 `var display = X11Display.Open()` 和 X 服务进行连接；如果当前已经通过其他方式获取了一个 `IntPtr` 类型的 Display，可以通过强制转换 `var display = (X11Display)dispalyPtr` 来转成 `X11Display`。

如果需要获取 root 窗口，在 xlib 中可以使用 `XDefaultRootWindow(Display*)` 函数，在该仓库中可以使用 `X11Display.DefaultRootWindow` 属性。如果需要获取其他窗口，请根据 xlib 中的函数来查找对应的方法。  
如果需要将一个 `IntPtr` 类型的窗口 ID 转换成该仓库中使用的窗口，可以通过 `var window = new X11Window(windowId).WithDisplay(display)` 来生成一个 `X11DisplayWindow`。

如果需要移动一个窗口，在 xlib 中可以使用 `XMoveWindow(Display *display, Window w, int x, int y)` 函数，在该仓库中可以使用 `X11DisplayWindow.Move(Point location)` 方法。