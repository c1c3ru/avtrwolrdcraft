namespace Unity.Networking.Transport;

public struct QueuedSendMessage
{
	[CompilerGenerated]
	[UnsafeValueType]
	internal struct <Data>e__FixedBuffer
	{
		public byte FixedElementField; //Field offset: 0x0

	}

	[FixedBuffer(typeof(byte), 1472)]
	public <Data>e__FixedBuffer Data; //Field offset: 0x0
	public NetworkInterfaceEndPoint Dest; //Field offset: 0x5C0
	public int DataLength; //Field offset: 0x5FC

}

