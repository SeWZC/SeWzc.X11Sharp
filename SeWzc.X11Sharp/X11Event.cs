using System.ComponentModel;
using SeWzc.X11Sharp.Internal;
using SeWzc.X11Sharp.Structs;
using SeWzc.X11Sharp.Xid;

namespace SeWzc.X11Sharp;

/// <summary>
/// X11 中的事件。
/// </summary>
/// <remarks>
/// 其中非 public set 的属性是从 X11 返回的。
/// </remarks>
public abstract record X11Event
{
    private X11Event()
    {
    }

    /// <summary>
    /// 事件序列号。
    /// </summary>
    public uint Serial { get; private set; }

    /// <summary>
    /// 是否是客户端发送的事件。
    /// </summary>
    public bool SendEvent { get; private set; }

    /// <summary>
    /// 事件来源的 Display。
    /// </summary>
    public X11Display? Display { get; private set; }

    /// <summary>
    /// 转换为 XEvent。
    /// </summary>
    /// <returns>事件对应的 XEvent。</returns>
    internal abstract XEvent ToXEvent();

    /// <summary>
    /// 从 XEvent 转换为 X11Event。
    /// </summary>
    /// <param name="xEvent"></param>
    /// <returns></returns>
    /// <exception cref="NotImplementedException"></exception>
    internal static X11Event FromXEvent(XEvent xEvent)
    {
        return xEvent.type switch
        {
            EventType.KeyPress => KeyPressedEvent.FromXEventCore(xEvent.xkey),
            EventType.KeyRelease => KeyReleasedEvent.FromXEventCore(xEvent.xkey),
            EventType.ButtonPress => ButtonPressedEvent.FromXEventCore(xEvent.xbutton),
            EventType.ButtonRelease => ButtonReleasedEvent.FromXEventCore(xEvent.xbutton),
            EventType.MotionNotify => PointerMovedEvent.FromXEventCore(xEvent.xmotion),
            EventType.EnterNotify => EnterWindowEvent.FromXEventCore(xEvent.xcrossing),
            EventType.LeaveNotify => LeaveWindowEvent.FromXEventCore(xEvent.xcrossing),
            EventType.FocusIn => FocusInEvent.FromXEventCore(xEvent.xfocus),
            EventType.FocusOut => FocusOutEvent.FromXEventCore(xEvent.xfocus),
            EventType.KeymapNotify => KeyMapEvent.FromXEventCore(xEvent.xkeymap),
            EventType.Expose => ExposeEvent.FromXEventCore(xEvent.xexpose),
            EventType.GraphicsExpose => GraphicsExposeEvent.FromXEventCore(xEvent.xgraphicsexpose),
            EventType.NoExpose => NoExposeEvent.FromXEventCore(xEvent.xnoexpose),
            EventType.CirculateNotify => CirculateEvent.FromXEventCore(xEvent.xcirculate),
            EventType.ConfigureNotify => ConfigureEvent.FromXEventCore(xEvent.xconfigure),
            EventType.CreateNotify => CreateWindowEvent.FromXEventCore(xEvent.xcreatewindow),
            EventType.DestroyNotify => DestroyWindowEvent.FromXEventCore(xEvent.xdestroywindow),
            EventType.GravityNotify => GravityEvent.FromXEventCore(xEvent.xgravity),
            EventType.MapNotify => MapEvent.FromXEventCore(xEvent.xmap),
            EventType.MappingNotify => MappingEvent.FromXEventCore(xEvent.xmapping),
            EventType.ReparentNotify => ReparentEvent.FromXEventCore(xEvent.xreparent),
            EventType.UnmapNotify => UnmapEvent.FromXEventCore(xEvent.xunmap),
            EventType.VisibilityNotify => VisibilityEvent.FromXEventCore(xEvent.xvisibility),
            EventType.CirculateRequest => CirculateRequestEvent.FromXEventCore(xEvent.xcirculaterequest),
            EventType.ConfigureRequest => ConfigureRequestEvent.FromXEventCore(xEvent.xconfigurerequest),
            EventType.MapRequest => MapRequestEvent.FromXEventCore(xEvent.xmaprequest),
            EventType.ResizeRequest => ResizeRequestEvent.FromXEventCore(xEvent.xresizerequest),
            EventType.ColormapNotify => ColormapEvent.FromXEventCore(xEvent.xcolormap),
            EventType.ClientMessage => ClientMessageEvent.FromXEventCore(xEvent.xclient),
            EventType.PropertyNotify => PropertyEvent.FromXEventCore(xEvent.xproperty),
            EventType.SelectionClear => SelectionClearEvent.FromXEventCore(xEvent.xselectionclear),
            EventType.SelectionRequest => SelectionRequestEvent.FromXEventCore(xEvent.xselectionrequest),
            EventType.SelectionNotify => SelectionNotifyEvent.FromXEventCore(xEvent.xselection),
            _ => new UnknownEvent(),
        };
    }

    /// <summary>
    /// 键盘和指针事件。
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    public abstract record KeyboardPointerEvent : X11Event
    {
        internal KeyboardPointerEvent()
        {
        }

        public X11Window Window { get; set; }

        /// <summary>
        /// 源窗口的根窗口。
        /// </summary>
        public X11Window Root { get; set; }

        /// <summary>
        /// 子窗口。
        /// </summary>
        /// <remarks>
        /// 如果 <see cref="Window" /> 是源窗口的祖先窗口，则这个属性是 <see cref="Window" />
        /// 的子窗口，而且同时是源窗口的祖先窗口或者源窗口本身。否则，这个属性是 None。
        /// </remarks>
        public X11Window SubWindow { get; set; }

        /// <summary>
        /// 事件生成的时间，以毫秒为单位。
        /// </summary>
        public Time Time { get; set; }

        /// <summary>
        /// 相对于 <see cref="Window" /> 的 Y 坐标。如果 <see cref="Window" /> 和 <see cref="Root" />
        /// 不在同一个屏幕上，那么这个坐标是 (0, 0)。
        /// </summary>
        public Point Position { get; set; }

        /// <summary>
        /// <see cref="Position" /> 的 X 坐标。
        /// </summary>
        public int X
        {
            get => Position.X;
            set => Position = Position with { X = value };
        }

        /// <summary>
        /// <see cref="Position" /> 的 Y 坐标。
        /// </summary>
        public int Y
        {
            get => Position.Y;
            set => Position = Position with { Y = value };
        }

        /// <summary>
        /// 相对于 <see cref="Root" /> 的坐标。
        /// </summary>
        public Point RootPosition { get; set; }

        /// <summary>
        /// <see cref="RootPosition" /> 的 X 坐标。
        /// </summary>
        public int XRoot
        {
            get => RootPosition.X;
            set => RootPosition = RootPosition with { X = value };
        }

        /// <summary>
        /// <see cref="RootPosition" /> 的 Y 坐标。
        /// </summary>
        public int YRoot
        {
            get => RootPosition.Y;
            set => RootPosition = RootPosition with { Y = value };
        }

        /// <summary>
        /// 按键或按钮的状态。
        /// </summary>
        public KeyOrButtonMask State { get; set; }

        /// <summary>
        /// <see cref="Window" /> 和 <see cref="Root" /> 是否在同一个屏幕上。
        /// </summary>
        public bool SameScreen { get; set; }
    }

    /// <summary>
    /// 键盘事件。
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    public abstract record KeyEvent : KeyboardPointerEvent
    {
        internal KeyEvent()
        {
        }

        /// <summary>
        /// 按键码。
        /// </summary>
        public uint KeyCode { get; set; }
    }

    /// <summary>
    /// 按键按下事件。
    /// </summary>
    public sealed record KeyPressedEvent : KeyEvent
    {
        internal override XEvent ToXEvent()
        {
            return new XEvent
            {
                xkey = new XKeyEvent
                {
                    type = EventType.KeyPress,
                    serial = Serial,
                    send_event = SendEvent,
                    display = Display?.XDisplay ?? default,
                    window = Window,
                    root = Root,
                    subwindow = SubWindow,
                    time = Time,
                    x = X,
                    y = Y,
                    x_root = XRoot,
                    y_root = YRoot,
                    state = State,
                    keycode = KeyCode,
                    same_screen = SameScreen,
                },
            };
        }

        internal static KeyPressedEvent FromXEventCore(XKeyEvent xkey)
        {
            if (xkey.type != EventType.KeyPress)
                throw new ArgumentException("不是 KeyPress 事件。", nameof(xkey));

            return new KeyPressedEvent
            {
                Serial = (uint)xkey.serial,
                SendEvent = xkey.send_event,
                Display = xkey.display,
                Window = xkey.window,
                Root = xkey.root,
                SubWindow = xkey.subwindow,
                Time = xkey.time,
                X = xkey.x,
                Y = xkey.y,
                XRoot = xkey.x_root,
                YRoot = xkey.y_root,
                State = xkey.state,
                KeyCode = xkey.keycode,
                SameScreen = xkey.same_screen,
            };
        }
    }

    /// <summary>
    /// 按键释放事件。
    /// </summary>
    public sealed record KeyReleasedEvent : KeyEvent
    {
        internal override XEvent ToXEvent()
        {
            return new XEvent
            {
                xkey = new XKeyEvent
                {
                    type = EventType.KeyRelease,
                    serial = Serial,
                    send_event = SendEvent,
                    display = Display?.XDisplay ?? default,
                    window = Window,
                    root = Root,
                    subwindow = SubWindow,
                    time = Time,
                    x = X,
                    y = Y,
                    x_root = XRoot,
                    y_root = YRoot,
                    state = State,
                    keycode = KeyCode,
                    same_screen = SameScreen,
                },
            };
        }

        internal static KeyReleasedEvent FromXEventCore(XKeyEvent xkey)
        {
            if (xkey.type != EventType.KeyRelease)
                throw new ArgumentException("不是 KeyRelease 事件。", nameof(xkey));

            return new KeyReleasedEvent
            {
                Serial = (uint)xkey.serial,
                SendEvent = xkey.send_event,
                Display = xkey.display,
                Window = xkey.window,
                Root = xkey.root,
                SubWindow = xkey.subwindow,
                Time = xkey.time,
                X = xkey.x,
                Y = xkey.y,
                XRoot = xkey.x_root,
                YRoot = xkey.y_root,
                State = xkey.state,
                KeyCode = xkey.keycode,
                SameScreen = xkey.same_screen,
            };
        }
    }

    /// <summary>
    /// 指针按钮事件。
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    public abstract record ButtonEvent : KeyboardPointerEvent
    {
        internal ButtonEvent()
        {
        }

        /// <summary>
        /// 按钮。
        /// </summary>
        /// <remarks>
        /// 1 表示 Button1，2 表示 Button2，3 表示 Button3，4 表示 Button4，5 表示 Button5。0 表示任意按钮。
        /// </remarks>
        public uint Button { get; set; }
    }

    /// <summary>
    /// 指针按钮按下事件。
    /// </summary>
    public sealed record ButtonPressedEvent : ButtonEvent
    {
        internal override XEvent ToXEvent()
        {
            return new XEvent
            {
                xbutton = new XButtonEvent
                {
                    type = EventType.ButtonPress,
                    serial = Serial,
                    send_event = SendEvent,
                    display = Display?.XDisplay ?? default,
                    window = Window,
                    root = Root,
                    subwindow = SubWindow,
                    time = Time,
                    x = X,
                    y = Y,
                    x_root = XRoot,
                    y_root = YRoot,
                    state = State,
                    button = Button,
                    same_screen = SameScreen,
                },
            };
        }

        internal static ButtonPressedEvent FromXEventCore(XButtonEvent xbutton)
        {
            if (xbutton.type != EventType.ButtonPress)
                throw new ArgumentException("不是 ButtonPress 事件。", nameof(xbutton));

            return new ButtonPressedEvent
            {
                Serial = (uint)xbutton.serial,
                SendEvent = xbutton.send_event,
                Display = xbutton.display,
                Window = xbutton.window,
                Root = xbutton.root,
                SubWindow = xbutton.subwindow,
                Time = xbutton.time,
                X = xbutton.x,
                Y = xbutton.y,
                XRoot = xbutton.x_root,
                YRoot = xbutton.y_root,
                State = xbutton.state,
                Button = xbutton.button,
                SameScreen = xbutton.same_screen,
            };
        }
    }

    /// <summary>
    /// 指针按钮释放事件。
    /// </summary>
    public sealed record ButtonReleasedEvent : ButtonEvent
    {
        internal override XEvent ToXEvent()
        {
            return new XEvent
            {
                xbutton = new XButtonEvent
                {
                    type = EventType.ButtonRelease,
                    serial = Serial,
                    send_event = SendEvent,
                    display = Display?.XDisplay ?? default,
                    window = Window,
                    root = Root,
                    subwindow = SubWindow,
                    time = Time,
                    x = X,
                    y = Y,
                    x_root = XRoot,
                    y_root = YRoot,
                    state = State,
                    button = Button,
                    same_screen = SameScreen,
                },
            };
        }

        internal static ButtonReleasedEvent FromXEventCore(XButtonEvent xbutton)
        {
            if (xbutton.type != EventType.ButtonRelease)
                throw new ArgumentException("不是 ButtonRelease 事件。", nameof(xbutton));

            return new ButtonReleasedEvent
            {
                Serial = (uint)xbutton.serial,
                SendEvent = xbutton.send_event,
                Display = xbutton.display,
                Window = xbutton.window,
                Root = xbutton.root,
                SubWindow = xbutton.subwindow,
                Time = xbutton.time,
                X = xbutton.x,
                Y = xbutton.y,
                XRoot = xbutton.x_root,
                YRoot = xbutton.y_root,
                State = xbutton.state,
                Button = xbutton.button,
                SameScreen = xbutton.same_screen,
            };
        }
    }

    /// <summary>
    /// 移动事件。
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    public abstract record MotionEvent : KeyboardPointerEvent
    {
        internal MotionEvent()
        {
        }

        public bool IsHint { get; set; }
    }

    /// <summary>
    /// 指针移动事件。
    /// </summary>
    public sealed record PointerMovedEvent : MotionEvent
    {
        internal override XEvent ToXEvent()
        {
            return new XEvent
            {
                xmotion = new XMotionEvent
                {
                    type = EventType.MotionNotify,
                    serial = Serial,
                    send_event = SendEvent,
                    display = Display?.XDisplay ?? default,
                    window = Window,
                    root = Root,
                    subwindow = SubWindow,
                    time = Time,
                    x = X,
                    y = Y,
                    x_root = XRoot,
                    y_root = YRoot,
                    state = State,
                    is_hint = (byte)(IsHint ? 1 : 0),
                    same_screen = SameScreen,
                },
            };
        }

        internal static PointerMovedEvent FromXEventCore(XMotionEvent xmotion)
        {
            if (xmotion.type != EventType.MotionNotify)
                throw new ArgumentException("不是 MotionNotify 事件。", nameof(xmotion));

            return new PointerMovedEvent
            {
                Serial = (uint)xmotion.serial,
                SendEvent = xmotion.send_event,
                Display = xmotion.display,
                Window = xmotion.window,
                Root = xmotion.root,
                SubWindow = xmotion.subwindow,
                Time = xmotion.time,
                X = xmotion.x,
                Y = xmotion.y,
                XRoot = xmotion.x_root,
                YRoot = xmotion.y_root,
                State = xmotion.state,
                IsHint = xmotion.is_hint != 0,
                SameScreen = xmotion.same_screen,
            };
        }
    }

    /// <summary>
    /// 指针进入/离开事件。
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    public abstract record CrossingEvent : KeyboardPointerEvent
    {
        internal CrossingEvent()
        {
        }

        /// <summary>
        /// 表示该事件是正常的指针进入/离开事件，还是开始指针捕获或者结束指针捕获而生成的伪移动事件。
        /// </summary>
        public NotifyMode Mode { get; set; }

        public NotifyDetail Detail { get; set; }

        public bool Focus { get; set; }
    }

    /// <summary>
    /// 进入窗口事件。
    /// </summary>
    public sealed record EnterWindowEvent : CrossingEvent
    {
        internal override XEvent ToXEvent()
        {
            return new XEvent
            {
                xcrossing = new XCrossingEvent
                {
                    type = EventType.EnterNotify,
                    serial = Serial,
                    send_event = SendEvent,
                    display = Display?.XDisplay ?? default,
                    window = Window,
                    root = Root,
                    subwindow = SubWindow,
                    time = Time,
                    x = X,
                    y = Y,
                    x_root = XRoot,
                    y_root = YRoot,
                    mode = Mode,
                    detail = Detail,
                    same_screen = SameScreen,
                    focus = Focus,
                    state = State,
                },
            };
        }

        internal static EnterWindowEvent FromXEventCore(XCrossingEvent xcrossing)
        {
            if (xcrossing.type != EventType.EnterNotify)
                throw new ArgumentException("不是 EnterNotify 事件。", nameof(xcrossing));

            return new EnterWindowEvent
            {
                Serial = (uint)xcrossing.serial,
                SendEvent = xcrossing.send_event,
                Display = xcrossing.display,
                Window = xcrossing.window,
                Root = xcrossing.root,
                SubWindow = xcrossing.subwindow,
                Time = xcrossing.time,
                X = xcrossing.x,
                Y = xcrossing.y,
                XRoot = xcrossing.x_root,
                YRoot = xcrossing.y_root,
                Mode = xcrossing.mode,
                Detail = xcrossing.detail,
                SameScreen = xcrossing.same_screen,
                Focus = xcrossing.focus,
                State = xcrossing.state,
            };
        }
    }

    /// <summary>
    /// 离开窗口事件。
    /// </summary>
    public sealed record LeaveWindowEvent : CrossingEvent
    {
        internal override XEvent ToXEvent()
        {
            return new XEvent
            {
                xcrossing = new XCrossingEvent
                {
                    type = EventType.LeaveNotify,
                    serial = Serial,
                    send_event = SendEvent,
                    display = Display?.XDisplay ?? default,
                    window = Window,
                    root = Root,
                    subwindow = SubWindow,
                    time = Time,
                    x = X,
                    y = Y,
                    x_root = XRoot,
                    y_root = YRoot,
                    mode = Mode,
                    detail = Detail,
                    same_screen = SameScreen,
                    focus = Focus,
                    state = State,
                },
            };
        }

        internal static LeaveWindowEvent FromXEventCore(XCrossingEvent xcrossing)
        {
            if (xcrossing.type != EventType.LeaveNotify)
                throw new ArgumentException("不是 LeaveNotify 事件。", nameof(xcrossing));

            return new LeaveWindowEvent
            {
                Serial = (uint)xcrossing.serial,
                SendEvent = xcrossing.send_event,
                Display = xcrossing.display,
                Window = xcrossing.window,
                Root = xcrossing.root,
                SubWindow = xcrossing.subwindow,
                Time = xcrossing.time,
                X = xcrossing.x,
                Y = xcrossing.y,
                XRoot = xcrossing.x_root,
                YRoot = xcrossing.y_root,
                Mode = xcrossing.mode,
                Detail = xcrossing.detail,
                SameScreen = xcrossing.same_screen,
                Focus = xcrossing.focus,
                State = xcrossing.state,
            };
        }
    }

    /// <summary>
    /// Input 焦点事件。
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Advanced)]
    public abstract record FocusChangeEvent : X11Event
    {
        internal FocusChangeEvent()
        {
        }

        public X11Window Window { get; set; }

        public NotifyMode Mode { get; set; }

        public NotifyDetail Detail { get; set; }
    }

    /// <summary>
    /// 获得焦点事件。
    /// </summary>
    public sealed record FocusInEvent : FocusChangeEvent
    {
        internal override XEvent ToXEvent()
        {
            return new XEvent
            {
                xfocus = new XFocusChangeEvent
                {
                    type = EventType.FocusIn,
                    serial = Serial,
                    send_event = SendEvent,
                    display = Display?.XDisplay ?? default,
                    window = Window,
                    mode = Mode,
                    detail = Detail,
                },
            };
        }

        internal static FocusInEvent FromXEventCore(XFocusChangeEvent xfocus)
        {
            if (xfocus.type != EventType.FocusIn)
                throw new ArgumentException("不是 FocusIn 事件。", nameof(xfocus));

            return new FocusInEvent
            {
                Serial = (uint)xfocus.serial,
                SendEvent = xfocus.send_event,
                Display = xfocus.display,
                Window = xfocus.window,
                Mode = xfocus.mode,
                Detail = xfocus.detail,
            };
        }
    }

    /// <summary>
    /// 失去焦点事件。
    /// </summary>
    public sealed record FocusOutEvent : FocusChangeEvent
    {
        internal override XEvent ToXEvent()
        {
            return new XEvent
            {
                xfocus = new XFocusChangeEvent
                {
                    type = EventType.FocusOut,
                    serial = Serial,
                    send_event = SendEvent,
                    display = Display?.XDisplay ?? default,
                    window = Window,
                    mode = Mode,
                    detail = Detail,
                },
            };
        }

        internal static FocusOutEvent FromXEventCore(XFocusChangeEvent xfocus)
        {
            if (xfocus.type != EventType.FocusOut)
                throw new ArgumentException("不是 FocusOut 事件。", nameof(xfocus));

            return new FocusOutEvent
            {
                Serial = (uint)xfocus.serial,
                SendEvent = xfocus.send_event,
                Display = xfocus.display,
                Window = xfocus.window,
                Mode = xfocus.mode,
                Detail = xfocus.detail,
            };
        }
    }

    /// <summary>
    /// Key 映射状态改变事件。
    /// </summary>
    public sealed record KeyMapEvent : X11Event
    {
        public X11Window Window { get; set; }

        public byte[] KeyVector { get; } = new byte[32];

        internal override XEvent ToXEvent()
        {
            if (KeyVector.Length != 32)
                throw new InvalidOperationException("KeyVector 的长度必须是 32。");

            var keyVector = new XKeymapEvent.KeyVector();
            for (var i = 0; i < 32; i++)
                keyVector[i] = KeyVector[i];

            return new XEvent
            {
                xkeymap = new XKeymapEvent
                {
                    type = EventType.FocusOut,
                    serial = Serial,
                    send_event = SendEvent,
                    display = Display?.XDisplay ?? default,
                    window = Window,
                    key_vector = keyVector,
                },
            };
        }

        internal static KeyMapEvent FromXEventCore(XKeymapEvent xkeymap)
        {
            if (xkeymap.type != EventType.KeymapNotify)
                throw new ArgumentException("不是 KeymapNotify 事件。", nameof(xkeymap));

            var keyMapEvent = new KeyMapEvent
            {
                Serial = (uint)xkeymap.serial,
                SendEvent = xkeymap.send_event,
                Display = xkeymap.display,
            };

            for (var i = 0; i < 32; i++)
                keyMapEvent.KeyVector[i] = xkeymap.key_vector[i];

            return keyMapEvent;
        }
    }

    /// <summary>
    /// 暴露事件。
    /// </summary>
    public sealed record ExposeEvent : X11Event
    {
        public X11Window Window { get; set; }

        public Point Position { get; set; }

        /// <summary>
        /// <see cref="Position" /> 的 X 坐标。
        /// </summary>
        public int X
        {
            get => Position.X;
            set => Position = Position with { X = value };
        }

        /// <summary>
        /// <see cref="Position" /> 的 Y 坐标。
        /// </summary>
        public int Y
        {
            get => Position.Y;
            set => Position = Position with { Y = value };
        }

        public SSize Size { get; set; }

        /// <summary>
        /// <see cref="Size" /> 的宽度。
        /// </summary>
        public int Width
        {
            get => Size.Width;
            set => Size = Size with { Width = value };
        }

        /// <summary>
        /// <see cref="Size" /> 的高度。
        /// </summary>
        public int Height
        {
            get => Size.Height;
            set => Size = Size with { Height = value };
        }

        /// <summary>
        /// 如果大于 0，表示还有 <see cref="Count" /> 个 Expose 事件未处理。
        /// </summary>
        public int Count { get; set; }

        internal override XEvent ToXEvent()
        {
            return new XEvent
            {
                xexpose = new XExposeEvent
                {
                    type = EventType.Expose,
                    serial = Serial,
                    send_event = SendEvent,
                    display = Display?.XDisplay ?? default,
                    window = Window,
                    x = X,
                    y = Y,
                    width = Width,
                    height = Height,
                    count = Count,
                },
            };
        }

        internal static ExposeEvent FromXEventCore(XExposeEvent xexpose)
        {
            return new ExposeEvent
            {
                Serial = (uint)xexpose.serial,
                SendEvent = xexpose.send_event,
                Display = xexpose.display,
                Window = xexpose.window,
                X = xexpose.x,
                Y = xexpose.y,
                Width = xexpose.width,
                Height = xexpose.height,
                Count = xexpose.count,
            };
        }
    }

    /// <summary>
    /// 图像暴露事件。
    /// </summary>
    public sealed record GraphicsExposeEvent : X11Event
    {
        public X11Drawable Drawable { get; set; }

        public Point Position { get; set; }

        /// <summary>
        /// <see cref="Position" /> 的 X 坐标。
        /// </summary>
        public int X
        {
            get => Position.X;
            set => Position = Position with { X = value };
        }

        /// <summary>
        /// <see cref="Position" /> 的 Y 坐标。
        /// </summary>
        public int Y
        {
            get => Position.Y;
            set => Position = Position with { Y = value };
        }

        public SSize Size { get; set; }

        /// <summary>
        /// <see cref="Size" /> 的宽度。
        /// </summary>
        public int Width
        {
            get => Size.Width;
            set => Size = Size with { Width = value };
        }

        /// <summary>
        /// <see cref="Size" /> 的高度。
        /// </summary>
        public int Height
        {
            get => Size.Height;
            set => Size = Size with { Height = value };
        }

        public int Count { get; set; }

        public int MajorCode { get; set; }

        public int MinorCode { get; set; }

        internal override XEvent ToXEvent()
        {
            return new XEvent
            {
                xgraphicsexpose = new XGraphicsExposeEvent
                {
                    type = EventType.GraphicsExpose,
                    serial = Serial,
                    send_event = SendEvent,
                    display = Display?.XDisplay ?? default,
                    drawable = Drawable,
                    x = X,
                    y = Y,
                    width = Width,
                    height = Height,
                    count = Count,
                    major_code = MajorCode,
                    minor_code = MinorCode,
                },
            };
        }

        internal static GraphicsExposeEvent FromXEventCore(XGraphicsExposeEvent xgraphicsexpose)
        {
            if (xgraphicsexpose.type != EventType.GraphicsExpose)
                throw new ArgumentException("不是 GraphicsExpose 事件。", nameof(xgraphicsexpose));

            return new GraphicsExposeEvent
            {
                Serial = (uint)xgraphicsexpose.serial,
                SendEvent = xgraphicsexpose.send_event,
                Display = xgraphicsexpose.display,
                Drawable = xgraphicsexpose.drawable,
                X = xgraphicsexpose.x,
                Y = xgraphicsexpose.y,
                Width = xgraphicsexpose.width,
                Height = xgraphicsexpose.height,
                Count = xgraphicsexpose.count,
                MajorCode = xgraphicsexpose.major_code,
                MinorCode = xgraphicsexpose.minor_code,
            };
        }
    }

    public sealed record NoExposeEvent : X11Event
    {
        public X11Drawable Drawable { get; set; }

        public int MajorCode { get; set; }

        public int MinorCode { get; set; }

        internal override XEvent ToXEvent()
        {
            return new XEvent
            {
                xnoexpose = new XNoExposeEvent
                {
                    type = EventType.NoExpose,
                    serial = Serial,
                    send_event = SendEvent,
                    display = Display?.XDisplay ?? default,
                    drawable = Drawable,
                    major_code = MajorCode,
                    minor_code = MinorCode,
                },
            };
        }

        internal static NoExposeEvent FromXEventCore(XNoExposeEvent xnoexpose)
        {
            if (xnoexpose.type != EventType.NoExpose)
                throw new ArgumentException("不是 NoExpose 事件。", nameof(xnoexpose));

            return new NoExposeEvent
            {
                Serial = (uint)xnoexpose.serial,
                SendEvent = xnoexpose.send_event,
                Display = xnoexpose.display,
                Drawable = xnoexpose.drawable,
                MajorCode = xnoexpose.major_code,
                MinorCode = xnoexpose.minor_code,
            };
        }
    }

    /// <summary>
    /// 窗口循环事件。
    /// </summary>
    public sealed record CirculateEvent : X11Event
    {
        public X11Window Event { get; set; }

        public X11Window Window { get; set; }

        public CirculationRequest Place { get; set; }

        internal override XEvent ToXEvent()
        {
            return new XEvent
            {
                xcirculate = new XCirculateEvent
                {
                    type = EventType.CirculateNotify,
                    serial = Serial,
                    send_event = SendEvent,
                    display = Display?.XDisplay ?? default,
                    @event = Event,
                    window = Window,
                    place = Place,
                },
            };
        }

        internal static CirculateEvent FromXEventCore(XCirculateEvent xcirculate)
        {
            if (xcirculate.type != EventType.CirculateNotify)
                throw new ArgumentException("不是 CirculateNotify 事件。", nameof(xcirculate));

            return new CirculateEvent
            {
                Serial = (uint)xcirculate.serial,
                SendEvent = xcirculate.send_event,
                Display = xcirculate.display,
                Event = xcirculate.@event,
                Window = xcirculate.window,
                Place = xcirculate.place,
            };
        }
    }

    /// <summary>
    /// 配置事件。改变窗口的位置、大小、边框宽度、堆叠顺序等。
    /// </summary>
    public sealed record ConfigureEvent : X11Event
    {
        public X11Window Event { get; set; }

        public X11Window Window { get; set; }

        public Point Position { get; set; }

        /// <summary>
        /// <see cref="Position" /> 的 X 坐标。
        /// </summary>
        public int X
        {
            get => Position.X;
            set => Position = Position with { X = value };
        }

        /// <summary>
        /// <see cref="Position" /> 的 Y 坐标。
        /// </summary>
        public int Y
        {
            get => Position.Y;
            set => Position = Position with { Y = value };
        }

        public SSize Size { get; set; }

        /// <summary>
        /// <see cref="Size" /> 的宽度。
        /// </summary>
        public int Width
        {
            get => Size.Width;
            set => Size = Size with { Width = value };
        }

        /// <summary>
        /// <see cref="Size" /> 的高度。
        /// </summary>
        public int Height
        {
            get => Size.Height;
            set => Size = Size with { Height = value };
        }

        public int BorderWidth { get; set; }

        public X11Window Above { get; set; }

        public bool OverrideRedirect { get; set; }

        internal override XEvent ToXEvent()
        {
            return new XEvent
            {
                xconfigure = new XConfigureEvent
                {
                    type = EventType.ConfigureNotify,
                    serial = Serial,
                    send_event = SendEvent,
                    display = Display?.XDisplay ?? default,
                    @event = Event,
                    window = Window,
                    x = Position.X,
                    y = Position.Y,
                    width = Size.Width,
                    height = Size.Height,
                    border_width = BorderWidth,
                    above = Above,
                    override_redirect = OverrideRedirect,
                },
            };
        }

        internal static ConfigureEvent FromXEventCore(XConfigureEvent xconfigure)
        {
            if (xconfigure.type != EventType.ConfigureNotify)
                throw new ArgumentException("不是 ConfigureNotify 事件。", nameof(xconfigure));

            return new ConfigureEvent
            {
                Serial = (uint)xconfigure.serial,
                SendEvent = xconfigure.send_event,
                Display = xconfigure.display,
                Event = xconfigure.@event,
                Window = xconfigure.window,
                Position = new Point(xconfigure.x, xconfigure.y),
                Size = new SSize(xconfigure.width, xconfigure.height),
                BorderWidth = xconfigure.border_width,
                Above = xconfigure.above,
                OverrideRedirect = xconfigure.override_redirect,
            };
        }
    }

    /// <summary>
    /// 创建窗口事件。
    /// </summary>
    public sealed record CreateWindowEvent : X11Event
    {
        public X11Window Parent { get; set; }

        public X11Window Window { get; set; }

        public Point Position { get; set; }

        /// <summary>
        /// <see cref="Position" /> 的 X 坐标。
        /// </summary>
        public int X
        {
            get => Position.X;
            set => Position = Position with { X = value };
        }

        /// <summary>
        /// <see cref="Position" /> 的 Y 坐标。
        /// </summary>
        public int Y
        {
            get => Position.Y;
            set => Position = Position with { Y = value };
        }

        public SSize Size { get; set; }

        /// <summary>
        /// <see cref="Size" /> 的宽度。
        /// </summary>
        public int Width
        {
            get => Size.Width;
            set => Size = Size with { Width = value };
        }

        /// <summary>
        /// <see cref="Size" /> 的高度。
        /// </summary>
        public int Height
        {
            get => Size.Height;
            set => Size = Size with { Height = value };
        }

        public int BorderWidth { get; set; }

        public bool OverrideRedirect { get; set; }

        internal override XEvent ToXEvent()
        {
            return new XEvent
            {
                xcreatewindow = new XCreateWindowEvent
                {
                    type = EventType.CreateNotify,
                    serial = Serial,
                    send_event = SendEvent,
                    display = Display?.XDisplay ?? default,
                    parent = Parent,
                    window = Window,
                    x = X,
                    y = Y,
                    width = Width,
                    height = Height,
                    border_width = BorderWidth,
                    override_redirect = OverrideRedirect,
                },
            };
        }

        internal static CreateWindowEvent FromXEventCore(XCreateWindowEvent xcreatewindow)
        {
            if (xcreatewindow.type != EventType.CreateNotify)
                throw new ArgumentException("不是 CreateNotify 事件。", nameof(xcreatewindow));

            return new CreateWindowEvent
            {
                Serial = (uint)xcreatewindow.serial,
                SendEvent = xcreatewindow.send_event,
                Display = xcreatewindow.display,
                Parent = xcreatewindow.parent,
                Window = xcreatewindow.window,
                Position = new Point(xcreatewindow.x, xcreatewindow.y),
                Size = new SSize(xcreatewindow.width, xcreatewindow.height),
                BorderWidth = xcreatewindow.border_width,
                OverrideRedirect = xcreatewindow.override_redirect,
            };
        }
    }

    /// <summary>
    /// 销毁窗口事件。
    /// </summary>
    public sealed record DestroyWindowEvent : X11Event
    {
        public X11Window Event { get; set; }

        public X11Window Window { get; set; }

        internal override XEvent ToXEvent()
        {
            return new XEvent
            {
                xdestroywindow = new XDestroyWindowEvent
                {
                    type = EventType.DestroyNotify,
                    serial = Serial,
                    send_event = SendEvent,
                    display = Display?.XDisplay ?? default,
                    @event = Event,
                    window = Window,
                },
            };
        }

        internal static DestroyWindowEvent FromXEventCore(XDestroyWindowEvent xdestroywindow)
        {
            if (xdestroywindow.type != EventType.DestroyNotify)
                throw new ArgumentException("不是 DestroyNotify 事件。", nameof(xdestroywindow));

            return new DestroyWindowEvent
            {
                Serial = (uint)xdestroywindow.serial,
                SendEvent = xdestroywindow.send_event,
                Display = xdestroywindow.display,
                Event = xdestroywindow.@event,
                Window = xdestroywindow.window,
            };
        }
    }

    /// <summary>
    /// 重力事件。
    /// </summary>
    public sealed record GravityEvent : X11Event
    {
        public X11Window Event { get; set; }

        public X11Window Window { get; set; }

        public Point Position { get; set; }

        /// <summary>
        /// <see cref="Position" /> 的 X 坐标。
        /// </summary>
        public int X
        {
            get => Position.X;
            set => Position = Position with { X = value };
        }

        /// <summary>
        /// <see cref="Position" /> 的 Y 坐标。
        /// </summary>
        public int Y
        {
            get => Position.Y;
            set => Position = Position with { Y = value };
        }

        internal override XEvent ToXEvent()
        {
            return new XEvent
            {
                xgravity = new XGravityEvent
                {
                    type = EventType.GravityNotify,
                    serial = Serial,
                    send_event = SendEvent,
                    display = Display?.XDisplay ?? default,
                    @event = Event,
                    window = Window,
                    x = X,
                    y = Y,
                },
            };
        }

        internal static GravityEvent FromXEventCore(XGravityEvent xgravity)
        {
            if (xgravity.type != EventType.GravityNotify)
                throw new ArgumentException("不是 GravityNotify 事件。", nameof(xgravity));

            return new GravityEvent
            {
                Serial = (uint)xgravity.serial,
                SendEvent = xgravity.send_event,
                Display = xgravity.display,
                Event = xgravity.@event,
                Window = xgravity.window,
                Position = new Point(xgravity.x, xgravity.y),
            };
        }
    }

    /// <summary>
    /// 窗口映射事件。
    /// </summary>
    public sealed record MapEvent : X11Event
    {
        public X11Window Event { get; set; }

        public X11Window Window { get; set; }

        public bool OverrideRedirect { get; set; }

        internal override XEvent ToXEvent()
        {
            return new XEvent
            {
                xmap = new XMapEvent
                {
                    type = EventType.MapNotify,
                    serial = Serial,
                    send_event = SendEvent,
                    display = Display?.XDisplay ?? default,
                    @event = Event,
                    window = Window,
                    override_redirect = OverrideRedirect,
                },
            };
        }

        internal static MapEvent FromXEventCore(XMapEvent xmap)
        {
            if (xmap.type != EventType.MapNotify)
                throw new ArgumentException("不是 MapNotify 事件。", nameof(xmap));

            return new MapEvent
            {
                Serial = (uint)xmap.serial,
                SendEvent = xmap.send_event,
                Display = xmap.display,
                Event = xmap.@event,
                Window = xmap.window,
                OverrideRedirect = xmap.override_redirect,
            };
        }
    }

    /// <summary>
    /// 修饰符、键盘按键或按钮映射改变事件。
    /// </summary>
    public sealed record MappingEvent : X11Event
    {
        public MappingRequest Request { get; set; }

        public int FirstKeyCode { get; set; }

        public int Count { get; set; }

        internal override XEvent ToXEvent()
        {
            return new XEvent
            {
                xmapping = new XMappingEvent
                {
                    type = EventType.MappingNotify,
                    serial = Serial,
                    send_event = SendEvent,
                    display = Display?.XDisplay ?? default,
                    request = Request,
                    first_keycode = FirstKeyCode,
                    count = Count,
                },
            };
        }

        internal static MappingEvent FromXEventCore(XMappingEvent xmapping)
        {
            if (xmapping.type != EventType.MappingNotify)
                throw new ArgumentException("不是 MappingNotify 事件。", nameof(xmapping));

            return new MappingEvent
            {
                Serial = (uint)xmapping.serial,
                SendEvent = xmapping.send_event,
                Display = xmapping.display,
                Request = xmapping.request,
                FirstKeyCode = xmapping.first_keycode,
                Count = xmapping.count,
            };
        }
    }

    /// <summary>
    /// 重新设置父窗口事件。
    /// </summary>
    public sealed record ReparentEvent : X11Event
    {
        public X11Window Event { get; set; }

        public X11Window Window { get; set; }

        public X11Window Parent { get; set; }

        public Point Position { get; set; }

        /// <summary>
        /// <see cref="Position" /> 的 X 坐标。
        /// </summary>
        public int X
        {
            get => Position.X;
            set => Position = Position with { X = value };
        }

        /// <summary>
        /// <see cref="Position" /> 的 Y 坐标。
        /// </summary>
        public int Y
        {
            get => Position.Y;
            set => Position = Position with { Y = value };
        }

        public bool OverrideRedirect { get; set; }

        internal override XEvent ToXEvent()
        {
            return new XEvent
            {
                xreparent = new XReparentEvent
                {
                    type = EventType.ReparentNotify,
                    serial = Serial,
                    send_event = SendEvent,
                    display = Display?.XDisplay ?? default,
                    @event = Event,
                    window = Window,
                    parent = Parent,
                    x = X,
                    y = Y,
                    override_redirect = OverrideRedirect,
                },
            };
        }

        internal static ReparentEvent FromXEventCore(XReparentEvent xreparent)
        {
            if (xreparent.type != EventType.ReparentNotify)
                throw new ArgumentException("不是 ReparentNotify 事件。", nameof(xreparent));

            return new ReparentEvent
            {
                Serial = (uint)xreparent.serial,
                SendEvent = xreparent.send_event,
                Display = xreparent.display,
                Event = xreparent.@event,
                Window = xreparent.window,
                Parent = xreparent.parent,
                Position = new Point(xreparent.x, xreparent.y),
                OverrideRedirect = xreparent.override_redirect,
            };
        }
    }

    /// <summary>
    /// 窗口取消映射事件。
    /// </summary>
    public sealed record UnmapEvent : X11Event
    {
        public X11Window Event { get; set; }

        public X11Window Window { get; set; }

        public bool FromConfigure { get; set; }

        internal override XEvent ToXEvent()
        {
            return new XEvent
            {
                xunmap = new XUnmapEvent
                {
                    type = EventType.UnmapNotify,
                    serial = Serial,
                    send_event = SendEvent,
                    display = Display?.XDisplay ?? default,
                    @event = Event,
                    window = Window,
                    from_configure = FromConfigure,
                },
            };
        }

        internal static UnmapEvent FromXEventCore(XUnmapEvent xunmap)
        {
            if (xunmap.type != EventType.UnmapNotify)
                throw new ArgumentException("不是 UnmapNotify 事件。", nameof(xunmap));

            return new UnmapEvent
            {
                Serial = (uint)xunmap.serial,
                SendEvent = xunmap.send_event,
                Display = xunmap.display,
                Event = xunmap.@event,
                Window = xunmap.window,
                FromConfigure = xunmap.from_configure,
            };
        }
    }

    /// <summary>
    /// 可见性事件。
    /// </summary>
    public sealed record VisibilityEvent : X11Event
    {
        public X11Window Window { get; set; }

        public VisibilityNotify State { get; set; }

        internal override XEvent ToXEvent()
        {
            return new XEvent
            {
                xvisibility = new XVisibilityEvent
                {
                    type = EventType.VisibilityNotify,
                    serial = Serial,
                    send_event = SendEvent,
                    display = Display?.XDisplay ?? default,
                    window = Window,
                    state = State,
                },
            };
        }

        internal static VisibilityEvent FromXEventCore(XVisibilityEvent xvisibility)
        {
            if (xvisibility.type != EventType.VisibilityNotify)
                throw new ArgumentException("不是 VisibilityNotify 事件。", nameof(xvisibility));

            return new VisibilityEvent
            {
                Serial = (uint)xvisibility.serial,
                SendEvent = xvisibility.send_event,
                Display = xvisibility.display,
                Window = xvisibility.window,
                State = xvisibility.state,
            };
        }
    }

    /// <summary>
    /// 窗口循环请求事件。
    /// </summary>
    public sealed record CirculateRequestEvent : X11Event
    {
        public X11Window Parent { get; set; }

        public X11Window Window { get; set; }

        public CirculationRequest Place { get; set; }

        internal override XEvent ToXEvent()
        {
            return new XEvent
            {
                xcirculaterequest = new XCirculateRequestEvent
                {
                    type = EventType.CirculateRequest,
                    serial = Serial,
                    send_event = SendEvent,
                    display = Display?.XDisplay ?? default,
                    parent = Parent,
                    window = Window,
                    place = Place,
                },
            };
        }

        internal static CirculateRequestEvent FromXEventCore(XCirculateRequestEvent xcirculaterequest)
        {
            if (xcirculaterequest.type != EventType.CirculateRequest)
                throw new ArgumentException("不是 CirculateRequest 事件。", nameof(xcirculaterequest));

            return new CirculateRequestEvent
            {
                Serial = (uint)xcirculaterequest.serial,
                SendEvent = xcirculaterequest.send_event,
                Display = xcirculaterequest.display,
                Parent = xcirculaterequest.parent,
                Window = xcirculaterequest.window,
                Place = xcirculaterequest.place,
            };
        }
    }

    /// <summary>
    /// 窗口配置请求事件。
    /// </summary>
    public sealed record ConfigureRequestEvent : X11Event
    {
        public X11Window Parent { get; set; }

        public X11Window Window { get; set; }

        /// <summary>
        /// 窗口配置请求参数。
        /// </summary>
        public WindowChanges? Changes { get; set; }

        internal override XEvent ToXEvent()
        {
            return new XEvent
            {
                xconfigurerequest = new XConfigureRequestEvent
                {
                    type = EventType.ConfigureRequest,
                    serial = Serial,
                    send_event = SendEvent,
                    display = Display?.XDisplay ?? default,
                    parent = Parent,
                    window = Window,
                    x = Changes?.X ?? 0,
                    y = Changes?.Y ?? 0,
                    width = Changes?.Width ?? 0,
                    height = Changes?.Height ?? 0,
                    border_width = Changes?.BorderWidth ?? 0,
                    above = Changes?.Sibling ?? default,
                    detail = Changes?.StackMode ?? 0,
                    value_mask = Changes?.GetValueMask() ?? default,
                },
            };
        }

        internal static ConfigureRequestEvent FromXEventCore(XConfigureRequestEvent xconfigurerequest)
        {
            if (xconfigurerequest.type != EventType.ConfigureRequest)
                throw new ArgumentException("不是 ConfigureRequest 事件。", nameof(xconfigurerequest));

            var valueMask = xconfigurerequest.value_mask;
            return new ConfigureRequestEvent
            {
                Serial = (uint)xconfigurerequest.serial,
                SendEvent = xconfigurerequest.send_event,
                Display = xconfigurerequest.display,
                Parent = xconfigurerequest.parent,
                Window = xconfigurerequest.window,
                Changes = new WindowChanges
                {
                    X = (valueMask & WindowChangeMask.X) != 0 ? xconfigurerequest.x : null,
                    Y = (valueMask & WindowChangeMask.Y) != 0 ? xconfigurerequest.y : null,
                    Width = (valueMask & WindowChangeMask.Width) != 0 ? xconfigurerequest.width : null,
                    Height = (valueMask & WindowChangeMask.Height) != 0 ? xconfigurerequest.height : null,
                    BorderWidth = (valueMask & WindowChangeMask.BorderWidth) != 0 ? xconfigurerequest.border_width : null,
                    Sibling = (valueMask & WindowChangeMask.Sibling) != 0 ? xconfigurerequest.above : null,
                    StackMode = (valueMask & WindowChangeMask.StackMode) != 0 ? xconfigurerequest.detail : null,
                },
            };
        }
    }

    /// <summary>
    /// 映射请求事件。
    /// </summary>
    public sealed record MapRequestEvent : X11Event
    {
        public X11Window Parent { get; set; }

        public X11Window Window { get; set; }

        internal override XEvent ToXEvent()
        {
            return new XEvent
            {
                xmaprequest = new XMapRequestEvent
                {
                    type = EventType.MapRequest,
                    serial = Serial,
                    send_event = SendEvent,
                    display = Display?.XDisplay ?? default,
                    parent = Parent,
                    window = Window,
                },
            };
        }

        internal static MapRequestEvent FromXEventCore(XMapRequestEvent xmaprequest)
        {
            if (xmaprequest.type != EventType.MapRequest)
                throw new ArgumentException("不是 MapRequest 事件。", nameof(xmaprequest));

            return new MapRequestEvent
            {
                Serial = (uint)xmaprequest.serial,
                SendEvent = xmaprequest.send_event,
                Display = xmaprequest.display,
                Parent = xmaprequest.parent,
                Window = xmaprequest.window,
            };
        }
    }

    /// <summary>
    /// 重设大小请求事件。
    /// </summary>
    public sealed record ResizeRequestEvent : X11Event
    {
        public X11Window Window { get; set; }

        public SSize Size { get; set; }

        /// <summary>
        /// <see cref="Size" /> 的宽度。
        /// </summary>
        public int Width
        {
            get => Size.Width;
            set => Size = Size with { Width = value };
        }

        /// <summary>
        /// <see cref="Size" /> 的高度。
        /// </summary>
        public int Height
        {
            get => Size.Height;
            set => Size = Size with { Height = value };
        }

        internal override XEvent ToXEvent()
        {
            return new XEvent
            {
                xresizerequest = new XResizeRequestEvent
                {
                    type = EventType.ResizeRequest,
                    serial = Serial,
                    send_event = SendEvent,
                    display = Display?.XDisplay ?? default,
                    window = Window,
                    width = Size.Width,
                    height = Size.Height,
                },
            };
        }

        internal static ResizeRequestEvent FromXEventCore(XResizeRequestEvent xresizerequest)
        {
            if (xresizerequest.type != EventType.ResizeRequest)
                throw new ArgumentException("不是 ResizeRequest 事件。", nameof(xresizerequest));

            return new ResizeRequestEvent
            {
                Serial = (uint)xresizerequest.serial,
                SendEvent = xresizerequest.send_event,
                Display = xresizerequest.display,
                Window = xresizerequest.window,
                Size = new SSize(xresizerequest.width, xresizerequest.height),
            };
        }
    }

    /// <summary>
    /// 颜色图事件。
    /// </summary>
    public sealed record ColormapEvent : X11Event
    {
        public X11Window Window { get; set; }

        public X11Colormap Colormap { get; set; }

        public bool New { get; set; }

        public ColorMapNotification State { get; set; }

        internal override XEvent ToXEvent()
        {
            return new XEvent
            {
                xcolormap = new XColormapEvent
                {
                    type = EventType.ColormapNotify,
                    serial = Serial,
                    send_event = SendEvent,
                    display = Display?.XDisplay ?? default,
                    window = Window,
                    colormap = Colormap,
                    c_new = New,
                    state = State,
                },
            };
        }

        internal static ColormapEvent FromXEventCore(XColormapEvent xcolormap)
        {
            if (xcolormap.type != EventType.ColormapNotify)
                throw new ArgumentException("不是 ColormapNotify 事件。", nameof(xcolormap));

            return new ColormapEvent
            {
                Serial = (uint)xcolormap.serial,
                SendEvent = xcolormap.send_event,
                Display = xcolormap.display,
                Window = xcolormap.window,
                Colormap = xcolormap.colormap,
                New = xcolormap.c_new,
                State = xcolormap.state,
            };
        }
    }

    /// <summary>
    /// 客户端消息事件。
    /// </summary>
    public sealed record ClientMessageEvent : X11Event
    {
        public X11Window Window { get; set; }

        public X11Atom MessageType { get; set; }

        /// <summary>
        /// 客户端消息数据。
        /// </summary>
        public ClientMessageData? Data { get; set; }

        internal override XEvent ToXEvent()
        {
            var data = new XClientMessageEvent.XClientMessageData();
            switch (Data)
            {
                case ClientMessageData.DataFormat8 data8:
                    for (var i = 0; i < 20; i++)
                        data.format8[i] = data8.Data[i];
                    break;
                case ClientMessageData.DataFormat16 data16:
                    for (var i = 0; i < 10; i++)
                        data.format16[i] = data16.Data[i];
                    break;
                case ClientMessageData.DataFormat32 data32:
                    for (var i = 0; i < 5; i++)
                        data.format32[i] = data32.Data[i];
                    break;
                case null:
                    break;
                default:
                    throw new ArgumentException("不支持的数据格式。", nameof(Data));
            }

            return new XEvent
            {
                xclient = new XClientMessageEvent
                {
                    type = EventType.ClientMessage,
                    serial = Serial,
                    send_event = SendEvent,
                    display = Display?.XDisplay ?? default,
                    window = Window,
                    message_type = MessageType,
                    format = Data?.Format ?? 0,
                    data = data,
                },
            };
        }

        internal static ClientMessageEvent FromXEventCore(XClientMessageEvent xclient)
        {
            if (xclient.type != EventType.ClientMessage)
                throw new ArgumentException("不是 ClientMessage 事件。", nameof(xclient));

            ClientMessageData? data;
            switch (xclient.format)
            {
                case 8:
                    var data8 = new ClientMessageData.DataFormat8();
                    for (var i = 0; i < 20; i++)
                        data8.Data[i] = xclient.data.format8[i];
                    data = data8;
                    break;
                case 16:
                    var data16 = new ClientMessageData.DataFormat16();
                    for (var i = 0; i < 10; i++)
                        data16.Data[i] = xclient.data.format16[i];
                    data = data16;
                    break;
                case 32:
                    var data32 = new ClientMessageData.DataFormat32();
                    for (var i = 0; i < 5; i++)
                        data32.Data[i] = xclient.data.format32[i];
                    data = data32;
                    break;
                default:
                    data = null;
                    break;
            }

            return new ClientMessageEvent
            {
                Serial = (uint)xclient.serial,
                SendEvent = xclient.send_event,
                Display = xclient.display,
                Window = xclient.window,
                MessageType = xclient.message_type,
                Data = data,
            };
        }
    }

    /// <summary>
    /// 属性事件。
    /// </summary>
    public sealed record PropertyEvent : X11Event
    {
        public X11Window Window { get; set; }

        public X11Atom Atom { get; set; }

        public Time Time { get; set; }

        public PropertyNotification State { get; set; }

        internal override XEvent ToXEvent()
        {
            return new XEvent
            {
                xproperty = new XPropertyEvent
                {
                    type = EventType.PropertyNotify,
                    serial = Serial,
                    send_event = SendEvent,
                    display = Display?.XDisplay ?? default,
                    window = Window,
                    atom = Atom,
                    time = Time,
                    state = State,
                },
            };
        }

        internal static PropertyEvent FromXEventCore(XPropertyEvent xproperty)
        {
            if (xproperty.type != EventType.PropertyNotify)
                throw new ArgumentException("不是 PropertyNotify 事件。", nameof(xproperty));

            return new PropertyEvent
            {
                Serial = (uint)xproperty.serial,
                SendEvent = xproperty.send_event,
                Display = xproperty.display,
                Window = xproperty.window,
                Atom = xproperty.atom,
                Time = xproperty.time,
                State = xproperty.state,
            };
        }
    }

    public sealed record SelectionClearEvent : X11Event
    {
        public X11Window Window { get; set; }

        public X11Atom Selection { get; set; }

        public Time Time { get; set; }

        internal override XEvent ToXEvent()
        {
            return new XEvent
            {
                xselectionclear = new XSelectionClearEvent
                {
                    type = EventType.SelectionClear,
                    serial = Serial,
                    send_event = SendEvent,
                    display = Display?.XDisplay ?? default,
                    window = Window,
                    selection = Selection,
                    time = Time,
                },
            };
        }

        internal static SelectionClearEvent FromXEventCore(XSelectionClearEvent xselectionclear)
        {
            if (xselectionclear.type != EventType.SelectionClear)
                throw new ArgumentException("不是 SelectionClear 事件。", nameof(xselectionclear));

            return new SelectionClearEvent
            {
                Serial = (uint)xselectionclear.serial,
                SendEvent = xselectionclear.send_event,
                Display = xselectionclear.display,
                Window = xselectionclear.window,
                Selection = xselectionclear.selection,
                Time = xselectionclear.time,
            };
        }
    }

    public sealed record SelectionRequestEvent : X11Event
    {
        public X11Window Owner { get; set; }

        public X11Window Requestor { get; set; }

        public X11Atom Selection { get; set; }

        public X11Atom Target { get; set; }

        public X11Atom Property { get; set; }

        public Time Time { get; set; }

        internal override XEvent ToXEvent()
        {
            return new XEvent
            {
                xselectionrequest = new XSelectionRequestEvent
                {
                    type = EventType.SelectionRequest,
                    serial = Serial,
                    send_event = SendEvent,
                    display = Display?.XDisplay ?? default,
                    owner = Owner,
                    requestor = Requestor,
                    selection = Selection,
                    target = Target,
                    property = Property,
                    time = Time,
                },
            };
        }

        internal static SelectionRequestEvent FromXEventCore(XSelectionRequestEvent xselectionrequest)
        {
            if (xselectionrequest.type != EventType.SelectionRequest)
                throw new ArgumentException("不是 SelectionRequest 事件。", nameof(xselectionrequest));

            return new SelectionRequestEvent
            {
                Serial = (uint)xselectionrequest.serial,
                SendEvent = xselectionrequest.send_event,
                Display = xselectionrequest.display,
                Owner = xselectionrequest.owner,
                Requestor = xselectionrequest.requestor,
                Selection = xselectionrequest.selection,
                Target = xselectionrequest.target,
                Property = xselectionrequest.property,
                Time = xselectionrequest.time,
            };
        }
    }

    public sealed record SelectionNotifyEvent : X11Event
    {
        public X11Window Requestor { get; set; }

        public X11Atom Selection { get; set; }

        public X11Atom Target { get; set; }

        public X11Atom Property { get; set; }

        public Time Time { get; set; }

        internal override XEvent ToXEvent()
        {
            return new XEvent
            {
                xselection = new XSelectionEvent
                {
                    type = EventType.SelectionNotify,
                    serial = Serial,
                    send_event = SendEvent,
                    display = Display?.XDisplay ?? default,
                    requestor = Requestor,
                    selection = Selection,
                    target = Target,
                    property = Property,
                    time = Time,
                },
            };
        }

        internal static SelectionNotifyEvent FromXEventCore(XSelectionEvent xselection)
        {
            if (xselection.type != EventType.SelectionNotify)
                throw new ArgumentException("不是 SelectionNotify 事件。", nameof(xselection));

            return new SelectionNotifyEvent
            {
                Serial = (uint)xselection.serial,
                SendEvent = xselection.send_event,
                Display = xselection.display,
                Requestor = xselection.requestor,
                Selection = xselection.selection,
                Target = xselection.target,
                Property = xselection.property,
                Time = xselection.time,
            };
        }
    }

    public sealed record UnknownEvent : X11Event
    {
        /// <inheritdoc />
        internal override XEvent ToXEvent()
        {
            return new XEvent
            {
                type = 0,
                xany = new XAnyEvent
                {
                    type = 0,
                    serial = Serial,
                    send_event = SendEvent,
                    display = Display?.XDisplay ?? default,
                },
            };
        }

        internal static UnknownEvent FromXEventCore(XAnyEvent xany)
        {
            return new UnknownEvent
            {
                Display = xany.display,
                SendEvent = xany.send_event,
                Serial = (uint)xany.serial,
            };
        }
    }
}

public abstract class ClientMessageData
{
    private ClientMessageData()
    {
    }

    public abstract int Format { get; }

    public class DataFormat8 : ClientMessageData
    {
        /// <inheritdoc />
        public override int Format => 8;

        /// <summary>
        /// 数据内容。长度为 20。
        /// </summary>
        public byte[] Data { get; } = new byte[20];
    }

    public class DataFormat16 : ClientMessageData
    {
        /// <inheritdoc />
        public override int Format => 16;

        /// <summary>
        /// 数据内容。长度为 10。
        /// </summary>
        public short[] Data { get; } = new short[10];
    }

    public class DataFormat32 : ClientMessageData
    {
        /// <inheritdoc />
        public override int Format => 32;

        /// <summary>
        /// 数据内容。长度为 5。
        /// </summary>
        public Long[] Data { get; } = new Long[5];
    }
}
