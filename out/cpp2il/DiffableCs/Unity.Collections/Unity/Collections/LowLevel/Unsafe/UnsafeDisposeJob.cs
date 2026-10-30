namespace Unity.Collections.LowLevel.Unsafe;

[BurstCompile]
internal struct UnsafeDisposeJob : IJob
{
	[NativeDisableUnsafePtrRestriction]
	public Void* Ptr; //Field offset: 0x0
	public AllocatorHandle Allocator; //Field offset: 0x8

	public override void Execute() { }

}

