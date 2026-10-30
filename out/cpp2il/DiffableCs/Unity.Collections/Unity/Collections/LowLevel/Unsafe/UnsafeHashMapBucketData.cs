namespace Unity.Collections.LowLevel.Unsafe;

[BurstCompatible]
public struct UnsafeHashMapBucketData
{
	public readonly Byte* values; //Field offset: 0x0
	public readonly Byte* keys; //Field offset: 0x8
	public readonly Byte* next; //Field offset: 0x10
	public readonly Byte* buckets; //Field offset: 0x18
	public readonly int bucketCapacityMask; //Field offset: 0x20

	internal UnsafeHashMapBucketData(Byte* v, Byte* k, Byte* n, Byte* b, int bcm) { }

}

