namespace Unity.Networking.Transport.Relay;

public struct RelayConnectionData
{
	[CompilerGenerated]
	[UnsafeValueType]
	internal struct <Value>e__FixedBuffer
	{
		public byte FixedElementField; //Field offset: 0x0

	}

	public const int k_Length = 255; //Field offset: 0x0
	[FixedBuffer(typeof(byte), 255)]
	public <Value>e__FixedBuffer Value; //Field offset: 0x0

	public static RelayConnectionData FromByteArray(Byte[] data) { }

	public static RelayConnectionData FromBytePointer(Byte* dataPtr, int length) { }

}

