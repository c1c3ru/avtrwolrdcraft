namespace Unity.Collections;

[BurstCompatible]
internal struct Memory
{
	[BurstCompatible]
	public struct Array
	{

		[BurstCompatible(GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(int)})]
		internal static void Clear(T* pointer, long count) { }

		[BurstCompatible(GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(int)})]
		internal static void Copy(T* dest, T* src, long count) { }

		[BurstCompatible(GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(int)})]
		internal static void Set(T* pointer, long count, T t = null) { }

	}

	[BurstCompatible]
	public struct Unmanaged
	{
		[BurstCompatible]
		public struct Array
		{

			[BurstCompatible(GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(int)})]
			internal static T* Allocate(long count, AllocatorHandle allocator) { }

			private static Void* CustomResize(Void* oldPointer, long oldCount, long newCount, AllocatorHandle allocator, long size, int align) { }

			[BurstCompatible(GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(int)})]
			internal static void Free(T* pointer, long count, AllocatorHandle allocator) { }

			private static bool IsCustom(AllocatorHandle allocator) { }

			internal static Void* Resize(Void* oldPointer, long oldCount, long newCount, AllocatorHandle allocator, long size, int align) { }

			[BurstCompatible(GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(int)})]
			internal static T* Resize(T* oldPointer, long oldCount, long newCount, AllocatorHandle allocator) { }

		}


		internal static Void* Allocate(long size, int align, AllocatorHandle allocator) { }

		[BurstCompatible(GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(int)})]
		internal static T* Allocate(AllocatorHandle allocator) { }

		internal static void Free(Void* pointer, AllocatorHandle allocator) { }

		[BurstCompatible(GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(int)})]
		internal static void Free(T* pointer, AllocatorHandle allocator) { }

	}

	internal const long k_MaximumRamSizeInBytes = 1099511627776; //Field offset: 0x0

	[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
	internal static void CheckByteCountIsReasonable(long size) { }

}

