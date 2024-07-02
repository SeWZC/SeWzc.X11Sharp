using System.Runtime.InteropServices;
using SeWzc.X11Sharp.Internal;

namespace SeWzc.X11Sharp;

/// <summary>
/// Display 和 Atom 的组合。
/// </summary>
public readonly record struct X11DisplayAtom(X11Display Display, X11Atom Atom)
{
    /// <summary>
    /// 获取 Atom 的名称。
    /// </summary>
    /// <returns>Atom 的名称。</returns>
    public unsafe string? GetAtomName()
    {
        var atomNamePtr = XLib.XGetAtomName(Display.XDisplay, Atom);
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

    #region 运算符重载

    // 强制转换就不用文档了
#pragma warning disable CS1591

    public static implicit operator X11Atom(X11DisplayAtom displayAtom)
    {
        return displayAtom.Atom;
    }

#pragma warning restore CS1591

    #endregion
}
