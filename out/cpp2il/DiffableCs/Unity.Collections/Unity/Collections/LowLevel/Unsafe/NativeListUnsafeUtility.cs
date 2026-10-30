namespace Unity.Collections.LowLevel.Unsafe;

[BurstCompatible]
[Extension]
public static class NativeListUnsafeUtility
{

	[BurstCompatible(GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(int)})]
	public static Void* GetInternalListDataPtrUnchecked(ref NativeList<T>& list) { }

	[BurstCompatible(GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(int)})]
	[Extension]
	public static Void* GetUnsafePtr(NativeList<T> list) { }

	[BurstCompatible(GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(int)})]
	[Extension]
	public static Void* GetUnsafeReadOnlyPtr(NativeList<T> list) { }

}

