// See https://aka.ms/new-console-template for more information

using System.Text;
using SeWzc.X11Sharp;
using SeWzc.X11Sharp.Exceptions;
using SeWzc.X11Sharp.Structs;

Console.WriteLine("Hello, World!");

var display = X11Lib.OpenDisplay();
X11Lib.SetErrorHandler(static (display, errorEvent) =>
{
    Console.WriteLine(
        $"X11 Error: {errorEvent.ErrorCode.ToErrorText()} (Serial: {errorEvent.Serial}, RequestCode: {errorEvent.RequestCode}, MinorCode: {errorEvent.MinorCode})");
    return 0; // 返回 0 表示继续处理事件
});
var rootWindow = display.DefaultRootWindow;
Console.WriteLine($"Display: {display.DisplayString}, Root Window: {rootWindow.WindowToString()}");

var allEventMasks = rootWindow.GetAttributes()!.AllEventMasks;
allEventMasks &= ~(EventMask.ButtonPress | EventMask.SubstructureRedirect);
rootWindow.SelectInput(allEventMasks);

while (true)
{
    var @event = display.NextEvent();
    Console.WriteLine($"{@event.GetType().Name[..^5]} Serial={@event.Serial}, SendEvent={@event.SendEvent}");

    IReadOnlyList<string> output = @event switch
    {
        X11Event.CirculateEvent circulateEvent =>
        [
            $"Window={circulateEvent.Window.WindowToString(display)}",
            $"Place={circulateEvent.Place}",
        ],
        X11Event.CirculateRequestEvent circulateRequestEvent =>
        [
            $"Window={circulateRequestEvent.Window.WindowToString(display)}",
            $"Place={circulateRequestEvent.Place}",
            $"Parent={circulateRequestEvent.Parent.WindowToString(display)}",
        ],
        X11Event.ClientMessageEvent clientMessageEvent =>
        [
            $"Window={clientMessageEvent.Window.WindowToString(display)}",
            $"MessageType={clientMessageEvent.MessageType.WithDisplay(display).GetAtomName()}",
            $"\n[2mData={clientMessageEvent.Data switch
            {
                ClientMessageData.DataFormat32 dataFormat32 when clientMessageEvent.MessageType == display.Atoms.NetWmState =>
                    $"_NET_WM_STATE: Action={dataFormat32.GetNetWmStateAction()}, Atoms=[{string.Join("", dataFormat32.GetNetWmStateAtoms(display))}]",
                ClientMessageData.DataFormat32 dataFormat32 =>
                    $"DataFormat32: {string.Join("", dataFormat32.Data)}",
                ClientMessageData.DataFormat16 dataFormat16 =>
                    $"DataFormat16: {string.Join("", dataFormat16.Data)}",
                ClientMessageData.DataFormat8 dataFormat8 =>
                    $"DataFormat8: {string.Join("", dataFormat8.Data)}",
                null => "No ClientMessageData",
                _ => "Unknown ClientMessageData format",
            }}",
        ],
        X11Event.CreateWindowEvent createWindowEvent =>
        [
            $"Window={createWindowEvent.Window.WindowToString(display)}",
            $"Parent={createWindowEvent.Parent.WindowToString(display)}",
            $"X={createWindowEvent.Bounds.X}, Y={createWindowEvent.Bounds.Y}",
            $"Width={createWindowEvent.Bounds.Width}, Height={createWindowEvent.Bounds.Height}",
        ],
        X11Event.DestroyWindowEvent destroyWindowEvent =>
        [
            $"Window={destroyWindowEvent.Window.WindowToString(display)}",
        ],
        X11Event.ExposeEvent exposeEvent =>
        [
            $"Window={exposeEvent.Window.WindowToString(display)}",
            $"X={exposeEvent.Area.X}, Y={exposeEvent.Area.Y}",
            $"Width={exposeEvent.Area.Width}, Height={exposeEvent.Area.Height}",
            $"Count={exposeEvent.Count}",
        ],
        X11Event.FocusInEvent focusInEvent =>
        [
            $"Window={focusInEvent.Window.WindowToString(display)}",
            $"Mode={focusInEvent.Mode}",
            $"Detail={focusInEvent.Detail}",
        ],
        X11Event.FocusOutEvent focusOutEvent =>
        [
            $"Window={focusOutEvent.Window.WindowToString(display)}",
            $"Mode={focusOutEvent.Mode}",
            $"Detail={focusOutEvent.Detail}",
        ],
        X11Event.FocusChangeEvent focusChangeEvent =>
        [
            $"Window={focusChangeEvent.Window.WindowToString(display)}",
            $"Mode={focusChangeEvent.Mode}",
            $"Detail={focusChangeEvent.Detail}",
        ],
        X11Event.GraphicsExposeEvent graphicsExposeEvent =>
        [
            $"Drawable={graphicsExposeEvent.Drawable}",
            $"X={graphicsExposeEvent.Area.X}, Y={graphicsExposeEvent.Area.Y}",
            $"Width={graphicsExposeEvent.Area.Width}, Height={graphicsExposeEvent.Area.Height}",
            $"Count={graphicsExposeEvent.Count}",
            $"MajorCode={graphicsExposeEvent.MajorCode}, MinorCode={graphicsExposeEvent.MinorCode}",
        ],
        X11Event.MapEvent mapEvent =>
        [
            $"Window={mapEvent.Window.WindowToString(display)}",
            $"OverrideRedirect={mapEvent.OverrideRedirect}",
        ],
        X11Event.MapRequestEvent mapRequestEvent =>
        [
            $"Window={mapRequestEvent.Window.WindowToString(display)}",
            $"Parent={mapRequestEvent.Parent.WindowToString(display)}",
        ],
        X11Event.UnmapEvent unmapEvent =>
        [
            $"Window={unmapEvent.Window.WindowToString(display)}",
            $"FromConfigure={unmapEvent.FromConfigure}",
        ],
        X11Event.VisibilityEvent visibilityEvent =>
        [
            $"Window={visibilityEvent.Window.WindowToString(display)}",
            $"State={visibilityEvent.State}",
        ],
        X11Event.ConfigureEvent configureEvent =>
        [
            $"Window={configureEvent.Window.WindowToString(display)}",
            $"X={configureEvent.Bounds.X}, Y={configureEvent.Bounds.Y}",
            $"Width={configureEvent.Bounds.Width}, Height={configureEvent.Bounds.Height}",
            $"Above={configureEvent.Above.WindowToString(display)}",
            $"OverrideRedirect={configureEvent.OverrideRedirect}",
        ],
        X11Event.ConfigureRequestEvent configureRequestEvent =>
        [
            $"Window={configureRequestEvent.Window.WindowToString(display)}",
            $"Parent={configureRequestEvent.Parent.WindowToString(display)}",
            ..configureRequestEvent.Changes?.ToMessage() ?? [],
        ],
        X11Event.PropertyEvent propertyEvent =>
        [
            $"Window={propertyEvent.Window.WindowToString(display)}",
            $"Atom={propertyEvent.Atom.WithDisplay(display).GetAtomName()}",
            $"State={propertyEvent.State}",
            $"Time={propertyEvent.Time}",
            $"\e[2m{propertyEvent.Window.WithDisplay(display).GetProperty(propertyEvent.Atom) switch
            {
                PropertyData.Format32Array dataFormat32 when dataFormat32.PropertyType == display.Atoms.Atom =>
                    $"Property Type Atom: {string.Join(", ", dataFormat32.Value.Select(x => new X11Atom(x).WithDisplay(display).GetAtomName()))}",
                PropertyData.Format32Array dataFormat32 =>
                    $"Property Type Format32({dataFormat32.PropertyType.GetAtomName()}): {string.Join(", ", dataFormat32.Value)}",
                PropertyData.Format16Array dataFormat16 =>
                    $"Property Type Format16({dataFormat16.PropertyType.GetAtomName()}): {string.Join(", ", dataFormat16.Value)}",
                PropertyData.Format8Array dataFormat8 when dataFormat8.PropertyType == display.Atoms.Utf8String =>
                    $"Property Type Utf8String: {Encoding.UTF8.GetString(dataFormat8.Value)}",
                PropertyData.Format8Array dataFormat8 =>
                    $"Property Type Format8({dataFormat8.PropertyType.GetAtomName()}): {string.Join(", ", dataFormat8.Value.Select(x => $"{x:X}"))}",
                null => "No PropertyData",
                _ => "Unknown PropertyData format",
            }}\e[0m",
        ],
        X11Event.ReparentEvent reparentEvent =>
        [
            $"Window={reparentEvent.Window.WindowToString(display)}",
            $"Parent={reparentEvent.Parent.WindowToString(display)}",
            $"X={reparentEvent.Position.X}, Y={reparentEvent.Position.Y}",
            $"OverrideRedirect={reparentEvent.OverrideRedirect}",
        ],
        X11Event.ResizeRequestEvent resizeRequestEvent =>
        [
            $"Window={resizeRequestEvent.Window.WindowToString(display)}",
            $"Width={resizeRequestEvent.Width}, Height={resizeRequestEvent.Height}",
        ],
        _ => [],
    };

    Console.WriteLine(string.Join(", ", output));

    Console.WriteLine();
}

file static class Extensions
{
    public static string WindowToString(this X11DisplayWindow window)
    {
        return $"Window(Id={window.Xid}, " +
               $"Name={window.GetUtf8Property(window.Display.Atoms.NetWmName)}, " +
               $"Geometry={(window.GetAttributes()?.Bounds is { } bounds ? BoundsToString(bounds) : "null")})";

        string BoundsToString(SRectangle attributesBounds)
        {
            return $"{attributesBounds.X},{attributesBounds.Y},{attributesBounds.Width}x{attributesBounds.Height}";
        }
    }

    public static string WindowToString(this X11Window window, X11Display display)
    {
        return window.WithDisplay(display).WindowToString();
    }

    public static IReadOnlyList<string> ToMessage(this WindowChanges changes)
    {
        var messages = new List<string>();
        if (changes.X != null)
            messages.Add($"X={changes.X}");
        if (changes.Y != null)
            messages.Add($"Y={changes.Y}");
        if (changes.Width != null)
            messages.Add($"Width={changes.Width}");
        if (changes.Height != null)
            messages.Add($"Height={changes.Height}");
        if (changes.BorderWidth != null)
            messages.Add($"BorderWidth={changes.BorderWidth}");
        if (changes.Sibling != null)
            messages.Add($"Sibling={changes.Sibling}");
        if (changes.StackMode != null)
            messages.Add($"StackMode={changes.StackMode}");
        return messages;
    }

    public static string GetNetWmStateAction(this ClientMessageData.DataFormat32 dataFormat32)
    {
        return (int)dataFormat32.Data[0] switch
        {
            0 => "Remove",
            1 => "Add",
            2 => "Toggle",
            _ => $"Unknown({dataFormat32.Data[0]})",
        };
    }

    public static IEnumerable<string?> GetNetWmStateAtoms(this ClientMessageData.DataFormat32 dataFormat32, X11Display display)
    {
        return ((IEnumerable<nint>) [dataFormat32.Data[1], dataFormat32.Data[2]])
            .Where(static x => x != 0)
            .Select(x => new X11Atom(x).WithDisplay(display).GetAtomName());
    }
}
