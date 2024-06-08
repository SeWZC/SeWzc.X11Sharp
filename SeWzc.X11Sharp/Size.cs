using System.Runtime.InteropServices;

namespace SeWzc.X11Sharp;

[StructLayout(LayoutKind.Sequential)]
public struct Size
{
    public uint Width;
    public uint Height;
}
