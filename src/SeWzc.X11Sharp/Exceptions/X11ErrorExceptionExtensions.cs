namespace SeWzc.X11Sharp.Exceptions;

/// <summary>
/// X11 错误异常扩展方法。
/// </summary>
public static class X11ErrorExceptionExtensions
{
    /// <summary>
    /// 抛出 X11 错误异常，如果错误代码不是 Success。
    /// </summary>
    /// <param name="errorCode"></param>
    /// <returns></returns>
    public static void ThrowIfError(this ErrorCode errorCode)
    {
        if (errorCode == ErrorCode.Success)
            return;

        switch (errorCode)
        {
            case ErrorCode.BadRequest:
                throw new BadRequestException();
            case ErrorCode.BadValue:
                throw new BadValueException();
            case ErrorCode.BadWindow:
                throw new BadWindowException();
            case ErrorCode.BadPixmap:
                throw new BadPixmapException();
            case ErrorCode.BadAtom:
                throw new BadAtomException();
            case ErrorCode.BadCursor:
                throw new BadCursorException();
            case ErrorCode.BadFont:
                throw new BadFontException();
            case ErrorCode.BadMatch:
                throw new BadMatchException();
            case ErrorCode.BadDrawable:
                throw new BadDrawableException();
            case ErrorCode.BadAccess:
                throw new BadAccessException();
            case ErrorCode.BadAlloc:
                throw new BadAllocException();
            case ErrorCode.BadColor:
                throw new BadColorException();
            case ErrorCode.BadGC:
                throw new BadGCException();
            case ErrorCode.BadIDChoice:
                throw new BadIDChoiceException();
            case ErrorCode.BadName:
                throw new BadNameException();
            case ErrorCode.BadLength:
                throw new BadLengthException();
            case ErrorCode.BadImplementation:
                throw new BadImplementationException();
            default:
                throw new X11ErrorException(errorCode);
        }
    }

    /// <summary>
    /// 将错误代码转换为错误文本。
    /// </summary>
    /// <param name="errorCode"></param>
    /// <returns></returns>
    public static string ToErrorText(this ErrorCode errorCode)
    {
        return errorCode switch
        {
            ErrorCode.Success => "Success",
            ErrorCode.BadRequest => "Bad Request",
            ErrorCode.BadValue => "Bad Value",
            ErrorCode.BadWindow => "Bad Window",
            ErrorCode.BadPixmap => "Bad Pixmap",
            ErrorCode.BadAtom => "Bad Atom",
            ErrorCode.BadCursor => "Bad Cursor",
            ErrorCode.BadFont => "Bad Font",
            ErrorCode.BadMatch => "Bad Match",
            ErrorCode.BadDrawable => "Bad Drawable",
            ErrorCode.BadAccess => "Bad Access",
            ErrorCode.BadAlloc => "Bad Alloc",
            ErrorCode.BadColor => "Bad Color",
            ErrorCode.BadGC => "Bad GC",
            ErrorCode.BadIDChoice => "Bad ID Choice",
            ErrorCode.BadName => "Bad Name",
            ErrorCode.BadLength => "Bad Length",
            ErrorCode.BadImplementation => "Bad Implementation",
            _ => "Unknown Error (" + errorCode + ")",
        };
    }
}
