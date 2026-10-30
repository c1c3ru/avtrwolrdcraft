namespace Unity.Collections.LowLevel.Unsafe;

[BurstCompatible]
internal struct UnsafeHashMapData
{
	[CompilerGenerated]
	[UnsafeValueType]
	internal struct <firstFreeTLS>e__FixedBuffer
	{
		public int FixedElementField; //Field offset: 0x0

	}

	internal const int IntsPerCacheLine = 16; //Field offset: 0x0
	internal Byte* values; //Field offset: 0x0
	internal Byte* keys; //Field offset: 0x8
	internal Byte* next; //Field offset: 0x10
	internal Byte* buckets; //Field offset: 0x18
	internal int keyCapacity; //Field offset: 0x20
	internal int bucketCapacityMask; //Field offset: 0x24
	internal int allocatedIndexLength; //Field offset: 0x28
	[FixedBuffer(typeof(int), 2048)]
	internal <firstFreeTLS>e__FixedBuffer firstFreeTLS; //Field offset: 0x40

	[BurstCompatible(GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(int), typeof(int)})]
	internal static void AllocateHashMap(int length, int bucketLength, AllocatorHandle label, out UnsafeHashMapData* outBuf) { }

	[BurstCompatible(GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(int), typeof(int)})]
	internal static int CalculateDataSize(int length, int bucketLength, out int keyOffset, out int nextOffset, out int bucketOffset) { }

	[Conditional("ENABLE_UNITY_COLLECTIONS_CHECKS")]
	private static void CheckHashMapReallocateDoesNotShrink(UnsafeHashMapData* data, int newCapacity) { }

	internal static void DeallocateHashMap(UnsafeHashMapData* data, AllocatorHandle allocator) { }

	internal UnsafeHashMapBucketData GetBucketData() { }

	internal static int GetBucketSize(int capacity) { }

	internal static int GetCount(UnsafeHashMapData* data) { }

	[BurstCompatible(GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(int)})]
	internal static void GetKeyArray(UnsafeHashMapData* data, NativeArray<TKey> result) { }

	[BurstCompatible(GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(int), typeof(int)})]
	internal static void GetKeyValueArrays(UnsafeHashMapData* data, NativeKeyValueArrays<TKey, TValue> result) { }

	[BurstCompatible(GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(int)})]
	internal static void GetValueArray(UnsafeHashMapData* data, NativeArray<TValue> result) { }

	internal static int GrowCapacity(int capacity) { }

	internal static bool IsEmpty(UnsafeHashMapData* data) { }

	internal static bool MoveNext(UnsafeHashMapData* data, ref int bucketIndex, ref int nextIndex, out int index) { }

	[BurstCompatible(GenericTypeArguments = new IL2CPP_TYPE_IL2CPP_TYPE_INDEX[] {typeof(int), typeof(int)})]
	internal static void ReallocateHashMap(UnsafeHashMapData* data, int newCapacity, int newBucketCapacity, AllocatorHandle label) { }

}

