namespace Unity.Collections.LowLevel.Unsafe;

[BurstCompatible]
[Extension]
public static class NativeReferenceUnsafeUtility
{

	[BurstCompatible(GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(int)})]
	[Extension]
	public static Void* GetUnsafePtr(NativeReference<T> reference) { }

	[BurstCompatible(GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(int)})]
	[Extension]
	public static Void* GetUnsafePtrWithoutChecks(NativeReference<T> reference) { }

	[BurstCompatible(GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(int)})]
	[Extension]
	public static Void* GetUnsafeReadOnlyPtr(NativeReference<T> reference) { }

}

