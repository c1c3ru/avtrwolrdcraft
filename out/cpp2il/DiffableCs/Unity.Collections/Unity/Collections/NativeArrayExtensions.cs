namespace Unity.Collections;

[BurstCompatible]
[Extension]
public static class NativeArrayExtensions
{
	internal struct NativeArrayStaticId
	{
		internal static readonly SharedStatic<Int32> s_staticSafetyId; //Field offset: 0x0

		private static NativeArrayStaticId`1() { }

	}


	[BurstCompatible(GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(int)})]
	[Extension]
	public static bool ArraysEqual(NativeArray<T> array, NativeArray<T> other) { }

	[BurstCompatible(GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(int)})]
	[Extension]
	public static bool ArraysEqual(NativeList<T> array, NativeArray<T> other) { }

	[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
	private static void CheckReinterpretSize(ref NativeArray<T>& array) { }

	[BurstCompatible(GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(int), typeof(int)})]
	[Extension]
	public static bool Contains(NativeArray<T> array, U value) { }

	[BurstCompatible(GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(int), typeof(int)})]
	[Extension]
	public static bool Contains(ReadOnly<T> array, U value) { }

	[BurstCompatible(GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(int), typeof(int)})]
	[Extension]
	public static bool Contains(NativeList<T> list, U value) { }

	[BurstCompatible(GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(int), typeof(int)})]
	public static bool Contains(Void* ptr, int length, U value) { }

	[BurstCompatible(GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(int), typeof(int)})]
	[Extension]
	public static int IndexOf(NativeArray<T> array, U value) { }

	[BurstCompatible(GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(int), typeof(int)})]
	[Extension]
	public static int IndexOf(ReadOnly<T> array, U value) { }

	[BurstCompatible(GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(int), typeof(int)})]
	[Extension]
	public static int IndexOf(NativeList<T> list, U value) { }

	[BurstCompatible(GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(int), typeof(int)})]
	public static int IndexOf(Void* ptr, int length, U value) { }

	[BurstCompatible(GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(int)})]
	[Extension]
	internal static void Initialize(ref NativeArray<T>& array, int length, AllocatorHandle allocator, NativeArrayOptions options = 0) { }

	[BurstCompatible(GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(int), typeof(AllocatorHandle)})]
	[Extension]
	internal static void Initialize(ref NativeArray<T>& array, int length, ref U allocator, NativeArrayOptions options = 1) { }

	[BurstCompatible(GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(int), typeof(int)})]
	[Extension]
	public static NativeArray<U> Reinterpret(NativeArray<T> array) { }

}

