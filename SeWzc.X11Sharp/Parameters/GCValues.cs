using SeWzc.X11Sharp.Internal;

namespace SeWzc.X11Sharp;

/// <summary>
/// 设置图形上下文的值。
/// </summary>
public sealed class GCValues
{
    /// <summary>
    /// 逻辑运算。指定如何将源和目标颜色组合在一起。
    /// </summary>
    public GraphicsFunctions? Function { get; set; }

    /// <summary>
    /// 平面掩码。哪些平面将受到影响。
    /// </summary>
    public uint? PlaneMask { get; set; }

    /// <summary>
    /// 前景色。
    /// </summary>
    public uint? Foreground { get; set; }

    /// <summary>
    /// 背景色。
    /// </summary>
    public uint? Background { get; set; }

    /// <summary>
    /// 线宽。
    /// </summary>
    public int? LineWidth { get; set; }

    /// <summary>
    /// 线型。
    /// </summary>
    public LineStyle? LineStyle { get; set; }

    /// <summary>
    /// 端点样式。
    /// </summary>
    public CapStyle? CapStyle { get; set; }

    /// <summary>
    /// 连接点样式。
    /// </summary>
    public JoinStyle? JoinStyle { get; set; }

    /// <summary>
    /// 填充样式。
    /// </summary>
    public FillStyle? FillStyle { get; set; }

    /// <summary>
    /// 填充规则。
    /// </summary>
    public FillRule? FillRule { get; set; }

    /// <summary>
    /// 弧线模式。
    /// </summary>
    public ArcMode? ArcMode { get; set; }

    /// <summary>
    /// 用于平铺的位图。
    /// </summary>
    public X11Pixmap? Tile { get; set; }

    /// <summary>
    /// 用于点画的位图。
    /// </summary>
    public X11Pixmap? Stipple { get; set; }

    /// <summary>
    /// 平铺位图的原点的 X 坐标。
    /// </summary>
    public int? TsXOrigin { get; set; }

    /// <summary>
    /// 平铺位图的原点的 Y 坐标。
    /// </summary>
    public int? TsYOrigin { get; set; }

    /// <summary>
    /// 字体。
    /// </summary>
    public X11Font? Font { get; set; }

    /// <summary>
    /// 子窗口模式。
    /// </summary>
    public SubwindowMode? SubwindowMode { get; set; }

    /// <summary>
    /// 是否产生 GraphicsExpose 和 NoExpose 事件。
    /// </summary>
    public bool? GraphicsExposures { get; set; }

    /// <summary>
    /// 剪裁区域原点的 X 坐标。
    /// </summary>
    public int? ClipXOrigin { get; set; }

    /// <summary>
    /// 剪裁区域原点的 Y 坐标。
    /// </summary>
    public int? ClipYOrigin { get; set; }

    /// <summary>
    /// 剪裁掩码。
    /// </summary>
    public X11Pixmap? ClipMask { get; set; }

    /// <summary>
    /// 虚线模式的偏移量。
    /// </summary>
    public int? DashOffset { get; set; }

    /// <summary>
    /// 虚线模式的长度。
    /// </summary>
    public byte? Dashes { get; set; }

    internal GCValueMarks GetMarks()
    {
        GCValueMarks marks = 0;
        if (Function is not null)
            marks |= GCValueMarks.Function;
        if (PlaneMask is not null)
            marks |= GCValueMarks.PlaneMask;
        if (Foreground is not null)
            marks |= GCValueMarks.Foreground;
        if (Background is not null)
            marks |= GCValueMarks.Background;
        if (LineWidth is not null)
            marks |= GCValueMarks.LineWidth;
        if (LineStyle is not null)
            marks |= GCValueMarks.LineStyle;
        if (CapStyle is not null)
            marks |= GCValueMarks.CapStyle;
        if (JoinStyle is not null)
            marks |= GCValueMarks.JoinStyle;
        if (FillStyle is not null)
            marks |= GCValueMarks.FillStyle;
        if (FillRule is not null)
            marks |= GCValueMarks.FillRule;
        if (ArcMode is not null)
            marks |= GCValueMarks.ArcMode;
        if (Tile is not null)
            marks |= GCValueMarks.Tile;
        if (Stipple is not null)
            marks |= GCValueMarks.Stipple;
        if (TsXOrigin is not null)
            marks |= GCValueMarks.TileStipXOrigin;
        if (TsYOrigin is not null)
            marks |= GCValueMarks.TileStipYOrigin;
        if (Font is not null)
            marks |= GCValueMarks.Font;
        if (SubwindowMode is not null)
            marks |= GCValueMarks.SubwindowMode;
        if (GraphicsExposures is not null)
            marks |= GCValueMarks.GraphicsExposures;
        if (ClipXOrigin is not null)
            marks |= GCValueMarks.ClipXOrigin;
        if (ClipYOrigin is not null)
            marks |= GCValueMarks.ClipYOrigin;
        if (ClipMask is not null)
            marks |= GCValueMarks.ClipMask;
        if (DashOffset is not null)
            marks |= GCValueMarks.DashOffset;
        if (Dashes is not null)
            marks |= GCValueMarks.DashList;

        return marks;
    }

    internal XGCValues ToXGCValues()
    {
        return new XGCValues
        {
            function = Function ?? 0,
            plane_mask = PlaneMask ?? 0,
            foreground = Foreground ?? 0,
            background = Background ?? 0,
            line_width = LineWidth ?? 0,
            line_style = LineStyle ?? 0,
            cap_style = CapStyle ?? 0,
            join_style = JoinStyle ?? 0,
            fill_style = FillStyle ?? 0,
            fill_rule = FillRule ?? 0,
            arc_mode = ArcMode ?? 0,
            tile = Tile ?? default,
            stipple = Stipple ?? default,
            ts_x_origin = TsXOrigin ?? 0,
            ts_y_origin = TsYOrigin ?? 0,
            font = Font ?? default,
            subwindow_mode = SubwindowMode ?? 0,
            graphics_exposures = GraphicsExposures ?? false,
            clip_x_origin = ClipXOrigin ?? 0,
            clip_y_origin = ClipYOrigin ?? 0,
            clip_mask = ClipMask ?? default,
            dash_offset = DashOffset ?? 0,
            dashes = Dashes ?? 0,
        };
    }
}
