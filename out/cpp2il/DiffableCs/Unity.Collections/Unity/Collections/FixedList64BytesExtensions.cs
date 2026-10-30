namespace Unity.Collections;

[BurstCompatible]
[Extension]
public static class FixedList64BytesExtensions
{

	[BurstCompatible(GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(int), typeof(int)})]
	[Extension]
	public static bool Contains(ref FixedList64Bytes<T>& list, U value) { }

	[BurstCompatible(GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(int), typeof(int)})]
	[Extension]
	public static int IndexOf(ref FixedList64Bytes<T>& list, U value) { }

	[BurstCompatible(GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(int), typeof(int)})]
	[Extension]
	public static bool Remove(ref FixedList64Bytes<T>& list, U value) { }

	[BurstCompatible(GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(int), typeof(int)})]
	[Extension]
	public static bool RemoveSwapBack(ref FixedList64Bytes<T>& list, U value) { }

}

