namespace SeWzc.X11Sharp.Exceptions;

/// <summary>
/// X11 错误封装的异常。
/// </summary>
/// <seealso href="https://www.x.org/releases/current/doc/libX11/libX11/libX11.html#Using_the_Default_Error_Handlers" />
public class X11ErrorException : Exception
{
    internal X11ErrorException(ErrorCode errorCode)
        : base($"X11 Error: {errorCode.ToErrorText()} (Error Code: {errorCode})")
    {
        ErrorCode = errorCode;
    }

    /// <summary>
    /// X11 错误代码。
    /// </summary>
    public ErrorCode ErrorCode { get; }
}

/// <summary>
/// 表示 X11 错误代码 BadRequest 的异常。
/// </summary>
/// <seealso href="https://www.x.org/releases/current/doc/libX11/libX11/libX11.html#BadRequest" />
public class BadRequestException() : X11ErrorException(ErrorCode.BadRequest);

/// <summary>
/// 表示 X11 错误代码 BadValue 的异常。
/// </summary>
/// <seealso href="https://www.x.org/releases/current/doc/libX11/libX11/libX11.html#BadValue" />
public class BadValueException() : X11ErrorException(ErrorCode.BadValue);

/// <summary>
/// 表示 X11 错误代码 BadWindow 的异常。
/// </summary>
/// <seealso href="https://www.x.org/releases/current/doc/libX11/libX11/libX11.html#BadWindow" />
public class BadWindowException() : X11ErrorException(ErrorCode.BadWindow);

/// <summary>
/// 表示 X11 错误代码 BadPixmap 的异常。
/// </summary>
/// <seealso href="https://www.x.org/releases/current/doc/libX11/libX11/libX11.html#BadPixmap" />
public class BadPixmapException() : X11ErrorException(ErrorCode.BadPixmap);

/// <summary>
/// 表示 X11 错误代码 BadAtom 的异常。
/// </summary>
/// <seealso href="https://www.x.org/releases/current/doc/libX11/libX11/libX11.html#BadAtom" />
public class BadAtomException() : X11ErrorException(ErrorCode.BadAtom);

/// <summary>
/// 表示 X11 错误代码 BadCursor 的异常。
/// </summary>
/// <seealso href="https://www.x.org/releases/current/doc/libX11/libX11/libX11.html#BadCursor" />
public class BadCursorException() : X11ErrorException(ErrorCode.BadCursor);

/// <summary>
/// 表示 X11 错误代码 BadFont 的异常。
/// </summary>
/// <seealso href="https://www.x.org/releases/current/doc/libX11/libX11/libX11.html#BadFont" />
public class BadFontException() : X11ErrorException(ErrorCode.BadFont);

/// <summary>
/// 表示 X11 错误代码 BadMatch 的异常。
/// </summary>
/// <seealso href="https://www.x.org/releases/current/doc/libX11/libX11/libX11.html#BadMatch" />
public class BadMatchException() : X11ErrorException(ErrorCode.BadMatch);

/// <summary>
/// 表示 X11 错误代码 BadDrawable 的异常。
/// </summary>
/// <seealso href="https://www.x.org/releases/current/doc/libX11/libX11/libX11.html#BadDrawable" />
public class BadDrawableException() : X11ErrorException(ErrorCode.BadDrawable);

/// <summary>
/// 表示 X11 错误代码 BadAccess 的异常。
/// </summary>
/// <seealso href="https://www.x.org/releases/current/doc/libX11/libX11/libX11.html#BadAccess" />
public class BadAccessException() : X11ErrorException(ErrorCode.BadAccess);

/// <summary>
/// 表示 X11 错误代码 BadAlloc 的异常。
/// </summary>
/// <seealso href="https://www.x.org/releases/current/doc/libX11/libX11/libX11.html#BadAlloc" />
public class BadAllocException() : X11ErrorException(ErrorCode.BadAlloc);

/// <summary>
/// 表示 X11 错误代码 BadColor 的异常。
/// </summary>
/// <seealso href="https://www.x.org/releases/current/doc/libX11/libX11/libX11.html#BadColor" />
public class BadColorException() : X11ErrorException(ErrorCode.BadColor);

/// <summary>
/// 表示 X11 错误代码 BadGC 的异常。
/// </summary>
/// <seealso href="https://www.x.org/releases/current/doc/libX11/libX11/libX11.html#BadGC" />
public class BadGCException() : X11ErrorException(ErrorCode.BadGC);

/// <summary>
/// 表示 X11 错误代码 BadIDChoice 的异常。
/// </summary>
/// <seealso href="https://www.x.org/releases/current/doc/libX11/libX11/libX11.html#BadIDChoice" />
public class BadIDChoiceException() : X11ErrorException(ErrorCode.BadIDChoice);

/// <summary>
/// 表示 X11 错误代码 BadName 的异常。
/// </summary>
/// <seealso href="https://www.x.org/releases/current/doc/libX11/libX11/libX11.html#BadName" />
public class BadNameException() : X11ErrorException(ErrorCode.BadName);

/// <summary>
/// 表示 X11 错误代码 BadLength 的异常。
/// </summary>
/// <seealso href="https://www.x.org/releases/current/doc/libX11/libX11/libX11.html#BadLength" />
public class BadLengthException() : X11ErrorException(ErrorCode.BadLength);

/// <summary>
/// 表示 X11 错误代码 BadImplementation 的异常。
/// </summary>
/// <seealso href="https://www.x.org/releases/current/doc/libX11/libX11/libX11.html#BadImplementation" />
public class BadImplementationException() : X11ErrorException(ErrorCode.BadImplementation);
