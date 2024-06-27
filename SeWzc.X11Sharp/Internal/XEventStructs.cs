﻿using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using SeWzc.X11Sharp.Structs;
using SeWzc.X11Sharp.Xid;

namespace SeWzc.X11Sharp.Internal;

[StructLayout(LayoutKind.Explicit)]
internal struct XEvent
{
    [FieldOffset(0)]
    public int type;
    [FieldOffset(0)]
    public XAnyEvent xany;
    [FieldOffset(0)]
    public XKeyEvent xkey;
    [FieldOffset(0)]
    public XButtonEvent xbutton;
    [FieldOffset(0)]
    public XMotionEvent xmotion;
    [FieldOffset(0)]
    public XCrossingEvent xcrossing;
    [FieldOffset(0)]
    public XFocusChangeEvent xfocus;
    [FieldOffset(0)]
    public XExposeEvent xexpose;
    [FieldOffset(0)]
    public XGraphicsExposeEvent xgraphicsexpose;
    [FieldOffset(0)]
    public XNoExposeEvent xnoexpose;
    [FieldOffset(0)]
    public XVisibilityEvent xvisibility;
    [FieldOffset(0)]
    public XCreateWindowEvent xcreatewindow;
    [FieldOffset(0)]
    public XDestroyWindowEvent xdestroywindow;
    [FieldOffset(0)]
    public XUnmapEvent xunmap;
    [FieldOffset(0)]
    public XMapEvent xmap;
    [FieldOffset(0)]
    public XMapRequestEvent xmaprequest;
    [FieldOffset(0)]
    public XReparentEvent xreparent;
    [FieldOffset(0)]
    public XConfigureEvent xconfigure;
    [FieldOffset(0)]
    public XGravityEvent xgravity;
    [FieldOffset(0)]
    public XResizeRequestEvent xresizerequest;
    [FieldOffset(0)]
    public XConfigureRequestEvent xconfigurerequest;
    [FieldOffset(0)]
    public XCirculateEvent xcirculate;
    [FieldOffset(0)]
    public XCirculateRequestEvent xcirculaterequest;
    [FieldOffset(0)]
    public XPropertyEvent xproperty;
    [FieldOffset(0)]
    public XSelectionClearEvent xselectionclear;
    [FieldOffset(0)]
    public XSelectionRequestEvent xselectionrequest;
    [FieldOffset(0)]
    public XSelectionEvent xselection;
    [FieldOffset(0)]
    public XColormapEvent xcolormap;
    [FieldOffset(0)]
    public XClientMessageEvent xclient;
    [FieldOffset(0)]
    public XMappingEvent xmapping;
    [FieldOffset(0)]
    public XErrorEvent xerror;
    [FieldOffset(0)]
    public XKeymapEvent xkeymap;
    [FieldOffset(0)]
    public XGenericEvent xgeneric;
    [FieldOffset(0)]
    public XGenericEventCookie xcookie;

    [FieldOffset(0)]
    private Pad pad;

    [InlineArray(24)]
    private struct Pad
    {
        private Long _value;
    }
}

[StructLayout(LayoutKind.Sequential)]
internal struct XAnyEvent
{
    public int type;
    public ULong serial;
    public Bool send_event;
    public DisplayPtr display;
    public X11Window window;
}

[StructLayout(LayoutKind.Sequential)]
internal struct XKeyEvent
{
    public int type;
    public ULong serial;
    public Bool send_event;
    public DisplayPtr display;
    public X11Window window;
    public X11Window root;
    public X11Window subwindow;
    public Time time;
    public int x;
    public int y;
    public int x_root;
    public int y_root;
    public uint state;
    public uint keycode;
    public Bool same_screen;
}

[StructLayout(LayoutKind.Sequential)]
internal struct XButtonEvent
{
    public int type;
    public ULong serial;
    public Bool send_event;
    public DisplayPtr display;
    public X11Window window;
    public X11Window root;
    public X11Window subwindow;
    public Time time;
    public int x;
    public int y;
    public int x_root;
    public int y_root;
    public uint state;
    public uint button;
    public Bool same_screen;
}

[StructLayout(LayoutKind.Sequential)]
internal struct XMotionEvent
{
    public int type;
    public ULong serial;
    public Bool send_event;
    public DisplayPtr display;
    public X11Window window;
    public X11Window root;
    public X11Window subwindow;
    public Time time;
    public int x;
    public int y;
    public int x_root;
    public int y_root;
    public uint state;
    public char is_hint;
    public Bool same_screen;
}

[StructLayout(LayoutKind.Sequential)]
internal struct XCrossingEvent
{
    public int type;
    public ULong serial;
    public Bool send_event;
    public DisplayPtr display;
    public X11Window window;
    public X11Window root;
    public X11Window subwindow;
    public Time time;
    public int x;
    public int y;
    public int x_root;
    public int y_root;
    public NotifyMode mode;
    public NotifyDetail detail;
    public Bool same_screen;
    public Bool focus;
    public uint state;
}

[StructLayout(LayoutKind.Sequential)]
internal struct XFocusChangeEvent
{
    public int type;
    public ULong serial;
    public Bool send_event;
    public DisplayPtr display;
    public X11Window window;
    public int mode;
    public NotifyDetail detail;
}

[StructLayout(LayoutKind.Sequential)]
internal struct XExposeEvent
{
    public int type;
    public ULong serial;
    public Bool send_event;
    public DisplayPtr display;
    public X11Window window;
    public int x;
    public int y;
    public int width;
    public int height;
    public int count;
}

[StructLayout(LayoutKind.Sequential)]
internal struct XGraphicsExposeEvent
{
    public int type;
    public ULong serial;
    public Bool send_event;
    public DisplayPtr display;
    public X11Window drawable;
    public int x;
    public int y;
    public int width;
    public int height;
    public int count;
    public int major_code;
    public int minor_code;
}

[StructLayout(LayoutKind.Sequential)]
internal struct XNoExposeEvent
{
    public int type;
    public ULong serial;
    public Bool send_event;
    public DisplayPtr display;
    public X11Window drawable;
    public int major_code;
    public int minor_code;
}

[StructLayout(LayoutKind.Sequential)]
internal struct XVisibilityEvent
{
    public int type;
    public ULong serial;
    public Bool send_event;
    public DisplayPtr display;
    public X11Window window;
    public int state;
}

[StructLayout(LayoutKind.Sequential)]
internal struct XCreateWindowEvent
{
    public int type;
    public ULong serial;
    public Bool send_event;
    public DisplayPtr display;
    public X11Window parent;
    public X11Window window;
    public int x;
    public int y;
    public int width;
    public int height;
    public int border_width;
    public Bool override_redirect;
}

[StructLayout(LayoutKind.Sequential)]
internal struct XDestroyWindowEvent
{
    public int type;
    public ULong serial;
    public Bool send_event;
    public DisplayPtr display;
    public X11Window @event;
    public X11Window window;
}

[StructLayout(LayoutKind.Sequential)]
internal struct XUnmapEvent
{
    public int type;
    public ULong serial;
    public Bool send_event;
    public DisplayPtr display;
    public X11Window @event;
    public X11Window window;
    public Bool from_configure;
}

[StructLayout(LayoutKind.Sequential)]
internal struct XMapEvent
{
    public int type;
    public ULong serial;
    public Bool send_event;
    public DisplayPtr display;
    public X11Window @event;
    public X11Window window;
    public Bool override_redirect;
}

[StructLayout(LayoutKind.Sequential)]
internal struct XMapRequestEvent
{
    public int type;
    public ULong serial;
    public Bool send_event;
    public DisplayPtr display;
    public X11Window @event;
    public X11Window window;
}

[StructLayout(LayoutKind.Sequential)]
internal struct XReparentEvent
{
    public int type;
    public ULong serial;
    public Bool send_event;
    public DisplayPtr display;
    public X11Window @event;
    public X11Window window;
    public X11Window parent;
    public int x;
    public int y;
    public Bool override_redirect;
}

[StructLayout(LayoutKind.Sequential)]
internal struct XConfigureEvent
{
    public int type;
    public ULong serial;
    public Bool send_event;
    public DisplayPtr display;
    public X11Window @event;
    public X11Window window;
    public int x;
    public int y;
    public int width;
    public int height;
    public int border_width;
    public X11Window above;
    public Bool override_redirect;
}

[StructLayout(LayoutKind.Sequential)]
internal struct XGravityEvent
{
    public int type;
    public ULong serial;
    public Bool send_event;
    public DisplayPtr display;
    public X11Window @event;
    public X11Window window;
    public int x;
    public int y;
}

[StructLayout(LayoutKind.Sequential)]
internal struct XResizeRequestEvent
{
    public int type;
    public ULong serial;
    public Bool send_event;
    public DisplayPtr display;
    public X11Window @event;
    public X11Window window;
    public int width;
    public int height;
}

[StructLayout(LayoutKind.Sequential)]
internal struct XConfigureRequestEvent
{
    public int type;
    public ULong serial;
    public Bool send_event;
    public DisplayPtr display;
    public X11Window @event;
    public X11Window window;
    public int x;
    public int y;
    public int width;
    public int height;
    public int border_width;
    public X11Window above;
    public StackMode detail;
    public WindowChangeMask value_mask;
}

[StructLayout(LayoutKind.Sequential)]
internal struct XCirculateEvent
{
    public int type;
    public ULong serial;
    public Bool send_event;
    public DisplayPtr display;
    public X11Window @event;
    public X11Window window;
    public CirculationRequest place;
}

[StructLayout(LayoutKind.Sequential)]
internal struct XCirculateRequestEvent
{
    public int type;
    public ULong serial;
    public Bool send_event;
    public DisplayPtr display;
    public X11Window @event;
    public X11Window window;
    public CirculationRequest place;
}

[StructLayout(LayoutKind.Sequential)]
internal struct XPropertyEvent
{
    public int type;
    public ULong serial;
    public Bool send_event;
    public DisplayPtr display;
    public X11Window @event;
    public X11Window window;
    public X11Atom atom;
    public Time time;
    public int state;
}

[StructLayout(LayoutKind.Sequential)]
internal struct XSelectionClearEvent
{
    public int type;
    public ULong serial;
    public Bool send_event;
    public DisplayPtr display;
    public X11Window @event;
    public X11Atom selection;
    public Time time;
}

[StructLayout(LayoutKind.Sequential)]
internal struct XSelectionRequestEvent
{
    public int type;
    public ULong serial;
    public Bool send_event;
    public DisplayPtr display;
    public X11Window @event;
    public X11Atom selection;
    public X11Atom target;
    public X11Atom property;
    public Time time;
}

[StructLayout(LayoutKind.Sequential)]
internal struct XSelectionEvent
{
    public int type;
    public ULong serial;
    public Bool send_event;
    public DisplayPtr display;
    public X11Window @event;
    public X11Atom selection;
    public X11Atom target;
    public X11Atom property;
    public Time time;
}

[StructLayout(LayoutKind.Sequential)]
internal struct XColormapEvent
{
    public int type;
    public ULong serial;
    public Bool send_event;
    public DisplayPtr display;
    public X11Window @event;
    public X11Colormap colormap;
    public Bool c_new;
    public ColorMapNotification state;
}

[StructLayout(LayoutKind.Sequential)]
internal struct XClientMessageEvent
{
    public int type;
    public ULong serial;
    public Bool send_event;
    public DisplayPtr display;
    public X11Window window;
    public X11Atom message_type;
    public int format;
    public XClientMessageData data;

    [InlineArray(5)]
    public struct XClientMessageData
    {
        public Long _data;
    }
}

[StructLayout(LayoutKind.Sequential)]
internal struct XMappingEvent
{
    public int type;
    public ULong serial;
    public Bool send_event;
    public DisplayPtr display;
    public int request;
    public int first_keycode;
    public int count;
}

[StructLayout(LayoutKind.Sequential)]
internal struct XErrorEvent
{
    public int type;
    public DisplayPtr display;
    public ULong resourceid;
    public ULong serial;
    public byte error_code;
    public byte request_code;
    public byte minor_code;
}

[StructLayout(LayoutKind.Sequential)]
internal struct XKeymapEvent
{
    public int type;
    public ULong serial;
    public Bool send_event;
    public DisplayPtr display;
    public KeyVector key_vector;

    [InlineArray(32)]
    public struct KeyVector
    {
        public byte _value;
    }
}

[StructLayout(LayoutKind.Sequential)]
internal struct XGenericEvent
{
    public int type;
    public ULong serial;
    public Bool send_event;
    public DisplayPtr display;
    public int extension;
    public int evtype;
}

[StructLayout(LayoutKind.Sequential)]
internal struct XGenericEventCookie
{
    public int type;
    public ULong serial;
    public Bool send_event;
    public DisplayPtr display;
    public int extension;
    public int evtype;
    public uint cookie;
    public nint data;
}