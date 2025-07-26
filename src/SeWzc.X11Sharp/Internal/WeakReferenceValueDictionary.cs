namespace SeWzc.X11Sharp.Internal;

/// <summary>
/// 弱引用值字典。如果值被回收，则会自动删除对应的键。
/// </summary>
/// <typeparam name="TKey">键类型。</typeparam>
/// <typeparam name="TValue">值的类型。必须是引用类型。</typeparam>
public class WeakReferenceValueDictionary<TKey, TValue>
    where TKey : notnull
    where TValue : class
{
    private readonly Dictionary<TKey, WeakReference<TValue>> _dictionary = new();

    private readonly object _lock = new();

    /// <summary>
    /// 添加键值对。如果键已存在，则会覆盖原有值。
    /// </summary>
    /// <param name="key">键。</param>
    /// <param name="value">值。</param>
    public void Add(TKey key, TValue value)
    {
        lock (_lock)
            _dictionary[key] = new WeakReference<TValue>(value);
    }

    /// <summary>
    /// 获取值。如果值不存在或已被回收，则返回 <paramref name="defaultValue" />。
    /// </summary>
    /// <param name="key">键。</param>
    /// <param name="defaultValue">默认值。</param>
    /// <returns></returns>
    public TValue? Get(TKey key, TValue? defaultValue = null)
    {
        lock (_lock)
        {
            if (_dictionary.TryGetValue(key, out var weakReference))
            {
                if (weakReference.TryGetTarget(out var value))
                    return value;
                _dictionary.Remove(key);
            }

            return defaultValue;
        }
    }

    /// <summary>
    /// 获取值。如果值不存在或已被回收，则调用 <paramref name="valueFactory" /> 创建新值。
    /// </summary>
    /// <param name="key">键。</param>
    /// <param name="valueFactory">创建新值的方法。</param>
    /// <returns>不存在时返回新值，否则返回已存在的值。</returns>
    public TValue GetOrAdd(TKey key, Func<TKey, TValue> valueFactory)
    {
        lock (_lock)
        {
            if (_dictionary.TryGetValue(key, out var weakReference))
            {
                if (weakReference.TryGetTarget(out var value))
                    return value;
                _dictionary.Remove(key);
            }

            var newValue = valueFactory(key);
            _dictionary[key] = new WeakReference<TValue>(newValue);
            return newValue;
        }
    }

    /// <summary>
    /// 判断是否包含指定键。
    /// </summary>
    /// <param name="key">键。</param>
    /// <returns>是否包含指定键。</returns>
    public bool ContainsKey(TKey key)
    {
        lock (_lock)
        {
            if (_dictionary.TryGetValue(key, out var weakReference))
            {
                if (weakReference.TryGetTarget(out _))
                    return true;
                _dictionary.Remove(key);
            }

            return false;
        }
    }

    /// <summary>
    /// 删除指定键的值。
    /// </summary>
    /// <param name="key">键。</param>
    public void Remove(TKey key)
    {
        lock (_lock)
            _dictionary.Remove(key);
    }
}
