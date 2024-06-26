using System.Runtime.InteropServices;
using SeWzc.X11Sharp.Handles;
using SeWzc.X11Sharp.Internal;

namespace SeWzc.X11Sharp;

/// <summary>
/// Display 和 Atom 的组合。
/// </summary>
public readonly record struct X11DisplayAtom(X11Display Display, X11Atom Value)
{
    /// <summary>
    /// 获取 Atom 的名称。
    /// </summary>
    /// <returns>Atom 的名称。</returns>
    public unsafe string? GetAtomName()
    {
        var atomNamePtr = XLib.XGetAtomName(Display.XDisplay, Value);
        if (atomNamePtr == null)
            return null;

        var atomName = Marshal.PtrToStringUTF8(new nint(atomNamePtr));
        XLib.XFree(atomNamePtr);
        return atomName;
    }

    /// <inheritdoc />
    public override string ToString()
    {
        return GetAtomName() ?? "";
    }
}
