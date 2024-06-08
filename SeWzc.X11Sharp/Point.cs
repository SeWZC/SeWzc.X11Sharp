using System.Runtime.InteropServices;

namespace SeWzc.X11Sharp;

[StructLayout(LayoutKind.Sequential)]
public struct Point
{
    public int X;
    public int Y;
}
