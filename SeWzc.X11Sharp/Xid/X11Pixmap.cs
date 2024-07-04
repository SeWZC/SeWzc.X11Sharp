using SeWzc.X11Sharp.Structs;

namespace SeWzc.X11Sharp.Xid;

/// <summary>
/// X11 λͼ��
/// </summary>
public readonly record struct X11Pixmap
{
    /// <summary>
    /// ͨ�� Id ���� X11Pixmap��
    /// </summary>
    /// <param name="Id">ͼ��ӳ��� ID��</param>
    public X11Pixmap(ulong Id)
    {
        this.Id = (ULong)Id;
    }

    /// <summary>
    /// ͨ�� Id ���� X11Pixmap��
    /// </summary>
    /// <param name="Id">ͼ��ӳ��� ID��</param>
    public X11Pixmap(nint Id)
    {
        this.Id = (ULong)Id;
    }

    /// <summary>
    /// λͼ�� ID��
    /// </summary>
    internal ULong Id { get; }

    /// <summary>
    /// ǿ��ת��Ϊ ULong��
    /// </summary>
    public static implicit operator ULong(X11Pixmap value)
    {
        return value.Id;
    }

    /// <summary>
    /// ǿ��ת��Ϊ nuint��
    /// </summary>
    public static implicit operator nuint(X11Pixmap value)
    {
        return value.Id;
    }

    /// <summary>
    /// ǿ��ת��Ϊ nint��
    /// </summary>
    public static implicit operator nint(X11Pixmap value)
    {
        return (nint)value.Id;
    }
}
