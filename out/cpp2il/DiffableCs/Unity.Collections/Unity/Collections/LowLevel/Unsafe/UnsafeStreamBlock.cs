namespace Unity.Collections.LowLevel.Unsafe;

[BurstCompatible]
internal struct UnsafeStreamBlock
{
	[CompilerGenerated]
	[UnsafeValueType]
	internal struct <Data>e__FixedBuffer
	{
		public byte FixedElementField; //Field offset: 0x0

	}

	internal UnsafeStreamBlock* Next; //Field offset: 0x0
	[FixedBuffer(typeof(byte), 1)]
	internal <Data>e__FixedBuffer Data; //Field offset: 0x8

}

