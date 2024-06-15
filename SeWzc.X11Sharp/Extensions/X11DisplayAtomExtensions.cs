using System.Runtime.InteropServices;
using SeWzc.X11Sharp.Handles;
using SeWzc.X11Sharp.Internal;

namespace SeWzc.X11Sharp.Extensions;

/// <summary>
/// Display 和 Atom 的组合。
/// </summary>
public static class X11DisplayAtomExtensions
{
    /// <summary>
    /// 获取 Atom 的名称。
    /// </summary>
    /// <param name="atom">Display 和 Atom 的组合。</param>
    /// <returns>Atom 的名称。</returns>
    public static unsafe string? GetAtomName(this X11DisplayWith<X11Atom> atom)
    {
        var atomNamePtr = XLib.XGetAtomName(atom.Display.XDisplay, atom.Value);
        if (atomNamePtr == null)
            return null;

        var atomName = Marshal.PtrToStringUTF8(new IntPtr(atomNamePtr));
        XLib.XFree(atomNamePtr);
        return atomName;
    }

    /// <summary>
    /// 获取 Atom 数组中每个 Atom 的名称。
    /// </summary>
    /// <param name="atoms">Display 和 Atom 数组的组合。</param>
    /// <returns>Atom 数组中每个 Atom 的名称。如果对应 Atom 无法获取到名称，则对应位置为 <see langword="null" /> </returns>
    public static unsafe string?[] GetAtomNames(this X11DisplayWith<X11Atom[]> atoms)
    {
        var atomNames = stackalloc byte*[atoms.Value.Length];
        XLib.XGetAtomNames(atoms.Display.XDisplay, atoms.Value, atoms.Value.Length, atomNames);

        var atomNameArray = new string?[atoms.Value.Length];
        for (var i = 0; i < atoms.Value.Length; i++)
        {
            var atomNamePtr = atomNames[i];
            if (atomNamePtr == null)
                continue;

            var atomName = Marshal.PtrToStringUTF8(new IntPtr(atomNamePtr));
            XLib.XFree(atomNamePtr);
            atomNameArray[i] = atomName;
        }

        return atomNameArray;
    }
}
