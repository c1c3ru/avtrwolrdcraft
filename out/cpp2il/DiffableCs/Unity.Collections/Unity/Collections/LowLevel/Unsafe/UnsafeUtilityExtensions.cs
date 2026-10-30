namespace Unity.Collections.LowLevel.Unsafe;

[BurstCompatible]
public static class UnsafeUtilityExtensions
{

	[BurstCompatible(GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(int)})]
	public static Void* AddressOf(in T value) { }

	[BurstCompatible(GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(int)})]
	public static T AsRef(in T value) { }

	[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
	private static void CheckIndexRange(int index, int capacity) { }

	[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
	private static void CheckMemSwapOverlap(Byte* dst, Byte* src, long size) { }

	internal static void MemSwap(Void* ptr, Void* otherPtr, long size) { }

	[BurstCompatible(GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(int)})]
	public static T ReadArrayElementBoundsChecked(Void* source, int index, int capacity) { }

	[BurstCompatible(GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(int)})]
	public static void WriteArrayElementBoundsChecked(Void* destination, int index, T value, int capacity) { }

}

