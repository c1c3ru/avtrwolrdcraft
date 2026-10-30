namespace Unity.Collections.LowLevel.Unsafe;

[BurstCompatible]
internal struct UnsafeStreamBlockData
{
	internal const int AllocationSize = 4096; //Field offset: 0x0
	internal AllocatorHandle Allocator; //Field offset: 0x0
	internal UnsafeStreamBlock** Blocks; //Field offset: 0x8
	internal int BlockCount; //Field offset: 0x10
	internal UnsafeStreamBlock* Free; //Field offset: 0x18
	internal UnsafeStreamRange* Ranges; //Field offset: 0x20
	internal int RangeCount; //Field offset: 0x28

	internal UnsafeStreamBlock* Allocate(UnsafeStreamBlock* oldBlock, int threadIndex) { }

}

