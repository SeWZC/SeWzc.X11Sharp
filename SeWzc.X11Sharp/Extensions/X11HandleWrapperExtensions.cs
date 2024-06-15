using System.Runtime.CompilerServices;
using SeWzc.X11Sharp.Handles;

namespace SeWzc.X11Sharp.Extensions;

public static class X11HandleWrapperExtensions
{
    /// <summary>
    /// 与 Display 进行组合，以便进行操作。
    /// </summary>
    /// <param name="handle">句柄/ID。</param>
    /// <param name="display">与 X 服务器的连接。</param>
    /// <returns>Display 与 Handle 的组合。</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static X11DisplayWith<T> WithDisplay<T>(this T handle, X11Display display) where T : IX11HandleWrapper<T>, new()
    {
        return new X11DisplayWith<T>(display, handle);
    }

    /// <summary>
    /// 与 Display 进行组合，以便进行操作。
    /// </summary>
    /// <param name="handle">句柄/ID 数组。</param>
    /// <param name="display">与 X 服务器的连接。</param>
    /// <returns>Display 与 Handle 数组的组合。</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static X11DisplayWith<T[]> WithDisplay<T>(this T[] handle, X11Display display) where T : IX11HandleWrapper<T>, new()
    {
        return new X11DisplayWith<T[]>(display, handle);
    }

    /// <summary>
    /// 转换为数组。
    /// </summary>
    /// <param name="value">Display 和 Handle 数组的组合。</param>
    /// <typeparam name="TElement">Handle 元素类型。</typeparam>
    /// <typeparam name="TEnumerable">Handle 集合类型。</typeparam>
    /// <returns>Display 和 Handle 组合的数组。</returns>
    public static X11DisplayWith<TElement>[] ToArray<TElement, TEnumerable>(this X11DisplayWith<TEnumerable> value)
        where TElement : IX11HandleWrapper<TElement>, new()
        where TEnumerable : IReadOnlyList<TElement>
    {
        var array = new X11DisplayWith<TElement>[value.Value.Count];
        for (var i = 0; i < value.Value.Count; i++)
            array[i] = new X11DisplayWith<TElement>(value.Display, value.Value[i]);

        return array;
    }

    /// <summary>
    /// 将数组打包。
    /// </summary>
    /// <param name="value">Display 和 Handle 组合的数组。</param>
    /// <typeparam name="TElement">Handle 元素类型。</typeparam>
    /// <returns>Display 和 Handle 数组的组合。</returns>
    public static X11DisplayWith<TElement[]> Package<TElement>(this X11DisplayWith<TElement[]> value)
    {
        return new X11DisplayWith<TElement[]>(value.Display, value.Value);
    }
}
