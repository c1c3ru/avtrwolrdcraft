namespace Unity.Collections.LowLevel.Unsafe;

[BurstCompile]
internal struct UnsafeHashMapDisposeJob : IJob
{
	[NativeDisableUnsafePtrRestriction]
	public UnsafeHashMapData* Data; //Field offset: 0x0
	public AllocatorHandle Allocator; //Field offset: 0x8

	public override void Execute() { }

}

