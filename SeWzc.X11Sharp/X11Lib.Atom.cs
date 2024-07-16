using System.Runtime.InteropServices;
using SeWzc.X11Sharp.Internal;

namespace SeWzc.X11Sharp;

public static partial class X11Lib
{
    /// <summary>
    /// 获取 Atom 的名称。
    /// </summary>
    /// <param name="atom">原子。</param>
    /// <returns>Atom 的名称。</returns>
    public static unsafe string? GetAtomName(this X11DisplayAtom atom)
    {
        var atomNamePtr = XLib.XGetAtomName(atom.Display.XDisplay, atom.Atom);
        if (atomNamePtr == null)
            return null;

        var atomName = Marshal.PtrToStringUTF8(new nint(atomNamePtr));
        _ = XLib.XFree(atomNamePtr);
        return atomName;
    }
}
