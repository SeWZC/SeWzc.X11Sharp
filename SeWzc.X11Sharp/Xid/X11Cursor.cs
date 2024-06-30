using SeWzc.X11Sharp.Structs;

namespace SeWzc.X11Sharp.Xid;

/// <summary>
/// X11 ��ꡣ
/// </summary>
public readonly record struct X11Cursor
{
    /// <summary>
    /// ͨ�� Id ���� X11Cursor��
    /// </summary>
    /// <param name="Id">���� ID��</param>
    public X11Cursor(ulong Id)
    {
        this.Id = (ULong)Id;
    }

    /// <summary>
    /// ͨ�� Id ���� X11Cursor��
    /// </summary>
    /// <param name="Id">���� ID��</param>
    public X11Cursor(nint Id)
    {
        this.Id = (ULong)Id;
    }

    /// <summary>
    /// ���� ID��
    /// </summary>
    internal ULong Id { get; }
    
    /// <summary>
    /// ǿ��ת��Ϊ ULong��
    /// </summary>
    public static implicit operator ULong(X11Cursor value)
    {
        return value.Id;
    }
    
    /// <summary>
    /// ǿ��ת��Ϊ nuint��
    /// </summary>
    public static implicit operator nuint(X11Cursor value)
    {
        return value.Id;
    }
    
    /// <summary>
    /// ǿ��ת��Ϊ nint��
    /// </summary>
    public static implicit operator nint(X11Cursor value)
    {
        return (nint)value.Id;
    }
}
