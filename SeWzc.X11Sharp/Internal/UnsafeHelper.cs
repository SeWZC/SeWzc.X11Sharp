using System.Runtime.CompilerServices;

namespace SeWzc.X11Sharp.Internal;

internal static unsafe class UnsafeHelper
{
    public static ref T AsRef<T>(T* ptr) where T : unmanaged
    {
        return ref Unsafe.AsRef<T>(ptr);
    }

    public static T* AsPointer<T>(ref T value) where T : unmanaged
    {
        return (T*)Unsafe.AsPointer(ref value);
    }
}
