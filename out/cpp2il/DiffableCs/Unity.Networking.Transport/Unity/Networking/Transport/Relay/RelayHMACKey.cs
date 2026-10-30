namespace Unity.Networking.Transport.Relay;

public struct RelayHMACKey
{
	[CompilerGenerated]
	[UnsafeValueType]
	internal struct <Value>e__FixedBuffer
	{
		public byte FixedElementField; //Field offset: 0x0

	}

	public const int k_Length = 64; //Field offset: 0x0
	[FixedBuffer(typeof(byte), 64)]
	public <Value>e__FixedBuffer Value; //Field offset: 0x0

	public static RelayHMACKey FromByteArray(Byte[] data) { }

	public static RelayHMACKey FromBytePointer(Byte* data, int length) { }

}

