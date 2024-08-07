﻿namespace SeWzc.X11Sharp;

/// <summary>
/// Display 和 Atom 的组合。
/// </summary>
public readonly record struct X11DisplayAtom(X11Display Display, X11Atom Atom)
{
    /// <summary>
    /// 名称。
    /// </summary>
    public string? Name => this.GetAtomName();

    /// <inheritdoc />
    public override string ToString()
    {
        return Name ?? "";
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
