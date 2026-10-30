namespace Unity.Collections.LowLevel.Unsafe;

[BurstCompatible]
internal struct UnsafeStreamRange
{
	internal UnsafeStreamBlock* Block; //Field offset: 0x0
	internal int OffsetInFirstBlock; //Field offset: 0x8
	internal int ElementCount; //Field offset: 0xC
	internal int LastOffset; //Field offset: 0x10
	internal int NumberOfBlocks; //Field offset: 0x14

}

