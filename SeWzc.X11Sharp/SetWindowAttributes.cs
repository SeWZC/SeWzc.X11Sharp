using SeWzc.X11Sharp.Internal;
using SeWzc.X11Sharp.Structs;
using SeWzc.X11Sharp.Xid;

namespace SeWzc.X11Sharp;

/// <summary>
/// ���ô������ԡ�
/// </summary>
public sealed class SetWindowAttributes
{
    /// <summary>
    /// ����������λͼ��
    /// </summary>
    public X11Pixmap? BackgroundPixmap { get; set; }
    /// <summary>
    /// �������������ء�
    /// </summary>
    public Pixel? BackgroundPixel { get; set; }
    /// <summary>
    /// �����߿��λͼ��
    /// </summary>
    public X11Pixmap? BorderPixmap { get; set; }
    /// <summary>
    /// �����߿�����ء�
    /// </summary>
    public Pixel? BorderPixel { get; set; }
    /// <summary>
    /// λ��������ʾ���ڴ�С�ı�ʱ�������е����ݱ����봰�ڵ��ĸ�����Ķ��롣
    /// </summary>
    public Gravity? BitGravity { get; set; }
    /// <summary>
    /// ������������ʾ�������ڵĴ�С�ı�ʱ�����ڱ����븸�����ĸ�����Ķ��롣
    /// </summary>
    public Gravity? WinGravity { get; set; }
    /// <summary>
    /// ���ڲ��ɼ�ʱ�Ƿ񱣴������ݡ�������ڲ��ɼ�ʱû�б��������ݣ����ڴ������±�Ϊ�ɼ�ʱ������������Ҫ���»��ơ�
    /// </summary>
    public BackingStore? BackingStore { get; set; }
    /// <summary>
    /// Ҫ�����ƽ�档
    /// </summary>
    public uint? BackingPlanes { get; set; }
    /// <summary>
    /// �������ĳЩλ�õ����ݶ�ʧ��Ӧ����ʲô������䡣
    /// </summary>
    public Pixel? BackingPixel { get; set; }
    /// <summary>
    /// �Ƿ񱣴洰���·������ݡ�
    /// </summary>
    public bool? SaveUnder { get; set; }
    /// <summary>
    /// Ӧ�ý��յ��¼����롣
    /// </summary>
    public EventMask? EventMask { get; set; }
    /// <summary>
    /// ��Ӧ�ô������¼����롣
    /// </summary>
    public EventMask? DoNotPropagateMask { get; set; }
    /// <summary>
    /// �����ض���
    /// </summary>
    public bool? OverrideRedirect { get; set; }
    /// <summary>
    /// ��ɫӳ���
    /// </summary>
    public X11Colormap? Colormap { get; set; }
    /// <summary>
    /// �ڴ�������ʾ�Ĺ�ꡣ
    /// </summary>
    public X11Cursor? Cursor { get; set; }

    internal WindowAttributeValueMask GetValueMask()
    {
        WindowAttributeValueMask valuemask = 0;

        valuemask |= WindowAttributeValueMask.BackPixmap;
        if (BackgroundPixmap != null)
            valuemask |= WindowAttributeValueMask.BackPixmap;
        if (BackgroundPixel != null)
            valuemask |= WindowAttributeValueMask.BackPixel;
        if (BorderPixmap != null)
            valuemask |= WindowAttributeValueMask.BorderPixmap;
        if (BorderPixel != null)
            valuemask |= WindowAttributeValueMask.BorderPixel;
        if (BitGravity != null)
            valuemask |= WindowAttributeValueMask.BitGravity;
        if (WinGravity != null)
            valuemask |= WindowAttributeValueMask.WinGravity;
        if (BackingStore != null)
            valuemask |= WindowAttributeValueMask.BackingStore;
        if (BackingPlanes != null)
            valuemask |= WindowAttributeValueMask.BackingPlanes;
        if (BackingPixel != null)
            valuemask |= WindowAttributeValueMask.BackingPixel;
        if (SaveUnder != null)
            valuemask |= WindowAttributeValueMask.SaveUnder;
        if (EventMask != null)
            valuemask |= WindowAttributeValueMask.EventMask;
        if (DoNotPropagateMask != null)
            valuemask |= WindowAttributeValueMask.DontPropagate;
        if (OverrideRedirect != null)
            valuemask |= WindowAttributeValueMask.OverrideRedirect;
        if (Colormap != null)
            valuemask |= WindowAttributeValueMask.Colormap;
        if (Cursor != null)
            valuemask |= WindowAttributeValueMask.Cursor;
        return valuemask;
    }

    internal XSetWindowAttributes ToXSetWindowAttributes()
    {
        return new XSetWindowAttributes
        {
            background_pixmap = BackgroundPixmap ?? default,
            background_pixel = BackgroundPixel ?? default,
            border_pixmap = BorderPixmap ?? default,
            border_pixel = BorderPixel ?? default,
            bit_gravity = BitGravity ?? default,
            win_gravity = WinGravity ?? default,
            backing_store = BackingStore ?? default,
            backing_planes = BackingPlanes ?? 0,
            backing_pixel = BackingPixel ?? default,
            save_under = SaveUnder ?? false,
            event_mask = EventMask ?? default,
            do_not_propagate_mask = DoNotPropagateMask ?? default,
            override_redirect = OverrideRedirect ?? false,
            colormap = Colormap ?? default,
            cursor = Cursor ?? default,
        };
    }
}
