using Microsoft.CodeAnalysis;

namespace SeWzc.X11Sharp.Analyzer;

[Generator(LanguageNames.CSharp)]
public class IncrementalGenerator : IIncrementalGenerator
{
    /// <inheritdoc />
    public void Initialize(IncrementalGeneratorInitializationContext context)
    {
        context.RegisterSourceOutput(context.CompilationProvider,
            static (context, _) =>
            {
                context.AddSource("X11DisplayXidUsings.g.cs", $$"""
                    global using X11DisplayAtom = SeWzc.X11Sharp.X11DisplayXid<SeWzc.X11Sharp.X11Atom>;
                    global using X11DisplayColormap = SeWzc.X11Sharp.X11DisplayXid<SeWzc.X11Sharp.X11Colormap>;
                    global using X11DisplayCursor = SeWzc.X11Sharp.X11DisplayXid<SeWzc.X11Sharp.X11Cursor>;
                    global using X11DisplayDrawable = SeWzc.X11Sharp.X11DisplayXid<SeWzc.X11Sharp.X11Drawable>;
                    global using X11DisplayFont = SeWzc.X11Sharp.X11DisplayXid<SeWzc.X11Sharp.X11Font>;
                    global using X11DisplayGContext = SeWzc.X11Sharp.X11DisplayXid<SeWzc.X11Sharp.X11GContext>;
                    global using X11DisplayPixmap = SeWzc.X11Sharp.X11DisplayXid<SeWzc.X11Sharp.X11Pixmap>;
                    global using X11DisplayWindow = SeWzc.X11Sharp.X11DisplayXid<SeWzc.X11Sharp.X11Window>;
                    """);
            });
    }
}
