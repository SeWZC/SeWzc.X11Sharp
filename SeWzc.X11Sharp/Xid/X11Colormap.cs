using SeWzc.X11Sharp.Structs;

namespace SeWzc.X11Sharp.Xid;

/// <summary>
/// X11 ��ɫӳ���
/// </summary>
public readonly record struct X11Colormap
{
    /// <summary>
    /// ͨ�� Id ���� X11Colormap��
    /// </summary>
    /// <param name="Id">��ɫӳ���� ID��</param>
    public X11Colormap(ulong Id)
    {
        this.Id = (ULong)Id;
    }

    /// <summary>
    /// ͨ�� Id ���� X11Colormap��
    /// </summary>
    /// <param name="Id">��ɫӳ���� ID��</param>
    public X11Colormap(nint Id)
    {
        this.Id = (ULong)Id;
    }

    /// <summary>
    /// ��ɫӳ���� ID��
    /// </summary>
    internal ULong Id { get; }

    /// <summary>
    /// ǿ��ת��Ϊ ULong��
    /// </summary>
    public static implicit operator ULong(X11Colormap value)
    {
        return value.Id;
    }

    /// <summary>
    /// ǿ��ת��Ϊ nuint��
    /// </summary>
    public static implicit operator nuint(X11Colormap value)
    {
        return value.Id;
    }

    /// <summary>
    /// ǿ��ת��Ϊ nint��
    /// </summary>
    public static implicit operator nint(X11Colormap value)
    {
        return (nint)value.Id;
    }
}
