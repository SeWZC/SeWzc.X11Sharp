namespace SeWzc.X11Sharp.Structs;

/// <summary>
/// �޷��������Ĵ�С��
/// </summary>
/// <param name="Width">��ȡ�</param>
/// <param name="Height">�߶ȡ�</param>
public record struct Size(uint Width, uint Height);

/// <summary>
/// �з��������Ĵ�С��
/// </summary>
/// <param name="Width">��ȡ�</param>
/// <param name="Height">�߶ȡ�</param>
public record struct SSize(int Width, int Height);
