// See https://aka.ms/new-console-template for more information

using SeWzc.X11Sharp;

Console.WriteLine("Hello, World!");

var display = X11Lib.OpenDisplay();
var rootWindow = display.DefaultRootWindow;
Console.WriteLine($"Display: {display.DisplayString}, Root Window: {rootWindow.Xid}");

var allEventMasks = rootWindow.GetAttributes()!.AllEventMasks;
allEventMasks &= ~(EventMask.ButtonPress | EventMask.SubstructureRedirect);
rootWindow.SelectInput(allEventMasks);

while (true)
{
    var @event = display.NextEvent();
    Console.WriteLine($"{@event.GetType().Name[..^5]} Serial={@event.Serial}, SendEvent={@event.SendEvent}");
    switch (@event)
    {
        case X11Event.ClientMessageEvent clientMessageEvent:
            Console.WriteLine($"Window={clientMessageEvent.Window}, " +
                              $"MessageType={clientMessageEvent.MessageType.WithDisplay(display).GetAtomName()}");
            switch (clientMessageEvent.Data)
            {
                case ClientMessageData.DataFormat32 dataFormat32:
                    Console.WriteLine($"DataFormat32: {string.Join(", ", dataFormat32.Data.Select(x => $"{x:X}"))}");
                    break;
                case ClientMessageData.DataFormat16 dataFormat16:
                    Console.WriteLine($"DataFormat16: {string.Join(", ", dataFormat16.Data)}");
                    break;
                case ClientMessageData.DataFormat8 dataFormat8:
                    Console.WriteLine($"DataFormat8: {string.Join(", ", dataFormat8.Data)}");
                    break;
                default:
                    Console.WriteLine($"Unknown ClientMessageData format: {clientMessageEvent.Data?.GetType().Name}");
                    break;
            }
            break;
        case X11Event.CreateWindowEvent createWindowEvent:
            Console.WriteLine($"indow={createWindowEvent.Window}, " +
                              $"Parent={createWindowEvent.Parent}, " +
                              $"X={createWindowEvent.Bounds.X}, Y={createWindowEvent.Bounds.Y}, " +
                              $"Width={createWindowEvent.Bounds.Width}, Height={createWindowEvent.Bounds.Height}");
            break;
        case X11Event.DestroyWindowEvent destroyWindowEvent:
            Console.WriteLine($"Window={destroyWindowEvent.Window}");
            break;
        case X11Event.MapEvent mapEvent:
            Console.WriteLine($"Window={mapEvent.Window}, " +
                              $"OverrideRedirect={mapEvent.OverrideRedirect}");
            break;
        case X11Event.UnmapEvent unmapEvent:
            Console.WriteLine($"Window={unmapEvent.Window}, " +
                              $"FromConfigure={unmapEvent.FromConfigure}");
            break;
        case X11Event.PropertyEvent propertyEvent:
            Console.WriteLine($"Window={propertyEvent.Window}, " +
                              $"Atom={propertyEvent.Atom.WithDisplay(display).GetAtomName()}, " +
                              $"State={propertyEvent.State}");
            var window = propertyEvent.Window.WithDisplay(display);
            var propertyData = window.GetProperty(propertyEvent.Atom);
            switch (propertyData)
            {
                case PropertyData.Format32Array dataFormat32:
                    if (dataFormat32.PropertyType == display.Atoms.Atom)
                    {
                        Console.WriteLine($"Property Data Atom: {string.Join(", ", dataFormat32.Value.Select(x => $"{new X11Atom(x).WithDisplay(display).GetAtomName()}"))}");
                    }
                    else
                    {
                        Console.WriteLine($"Property Data Format32({dataFormat32.PropertyType.GetAtomName()}): {string.Join(", ", dataFormat32.Value.Select(x => $"{x:X}"))}");
                    }
                    break;
                case PropertyData.Format16Array dataFormat16:
                    Console.WriteLine($"Property Data Format16({dataFormat16.PropertyType.GetAtomName()}): {string.Join(", ", dataFormat16.Value)}");
                    break;
                case PropertyData.Format8Array dataFormat8:
                    if (dataFormat8.PropertyType == display.Atoms.Utf8String)
                    {
                        Console.WriteLine($"Property Data utf8: {window.GetUtf8Property(propertyEvent.Atom)}");
                    }
                    else
                    {
                        Console.WriteLine($"Property Data Format8{dataFormat8.PropertyType.GetAtomName()}): {string.Join(", ", dataFormat8.Value)}");
                    }
                    break;
                default:
                    Console.WriteLine($"Unknown PropertyData format: {propertyData?.GetType().Name}");
                    break;
            }

            break;
    }
    Console.WriteLine();
}
