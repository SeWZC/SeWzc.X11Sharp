using SeWzc.X11Sharp.Handles;
using SeWzc.X11Sharp.Internal;

namespace SeWzc.X11Sharp;

public sealed class GCValues
{
    public GraphicsFunctions? Function { get; set; }
    public nuint? PlaneMask { get; set; }
    public nuint? Foreground { get; set; }
    public nuint? Background { get; set; }
    public int? LineWidth { get; set; }
    public LineStyle? LineStyle { get; set; }
    public CapStyle? CapStyle { get; set; }
    public JoinStyle? JoinStyle { get; set; }
    public FillStyle? FillStyle { get; set; }
    public FillRule? FillRule { get; set; }
    public ArcMode? ArcMode { get; set; }
    public X11Pixmap? Tile { get; set; }
    public X11Pixmap? Stipple { get; set; }
    public int? TsXOrigin { get; set; }
    public int? TsYOrigin { get; set; }
    public X11Font? Font { get; set; }
    public SubwindowMode? SubwindowMode { get; set; }
    public bool? GraphicsExposures { get; set; }
    public int? ClipXOrigin { get; set; }
    public int? ClipYOrigin { get; set; }
    public X11Pixmap? ClipMask { get; set; }
    public int? DashOffset { get; set; }
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
            tile = Tile ?? X11Pixmap.None,
            stipple = Stipple ?? X11Pixmap.None,
            ts_x_origin = TsXOrigin ?? 0,
            ts_y_origin = TsYOrigin ?? 0,
            font = Font ?? X11Font.None,
            subwindow_mode = SubwindowMode ?? 0,
            graphics_exposures = GraphicsExposures ?? false,
            clip_x_origin = ClipXOrigin ?? 0,
            clip_y_origin = ClipYOrigin ?? 0,
            clip_mask = ClipMask ?? X11Pixmap.None,
            dash_offset = DashOffset ?? 0,
            dashes = Dashes ?? 0,
        };
    }
}
