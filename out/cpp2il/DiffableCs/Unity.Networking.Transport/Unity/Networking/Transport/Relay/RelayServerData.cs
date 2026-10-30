namespace Unity.Networking.Transport.Relay;

public struct RelayServerData
{
	[CompilerGenerated]
	private sealed class <>c__DisplayClass10_0
	{
		public string connectionType; //Field offset: 0x10

		public <>c__DisplayClass10_0() { }

		internal bool <.ctor>b__0(RelayServerEndpoint ep) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass9_0
	{
		public string connectionType; //Field offset: 0x10

		public <>c__DisplayClass9_0() { }

		internal bool <.ctor>b__0(RelayServerEndpoint ep) { }

	}

	[CompilerGenerated]
	[UnsafeValueType]
	internal struct <HMAC>e__FixedBuffer
	{
		public byte FixedElementField; //Field offset: 0x0

	}

	public NetworkEndPoint Endpoint; //Field offset: 0x0
	public ushort Nonce; //Field offset: 0x18
	public RelayConnectionData ConnectionData; //Field offset: 0x1A
	public RelayConnectionData HostConnectionData; //Field offset: 0x119
	public RelayAllocationId AllocationId; //Field offset: 0x218
	public RelayHMACKey HMACKey; //Field offset: 0x228
	[FixedBuffer(typeof(byte), 32)]
	public <HMAC>e__FixedBuffer HMAC; //Field offset: 0x268
	public readonly byte IsSecure; //Field offset: 0x288

	private RelayServerData(Byte[] allocationId, Byte[] connectionData, Byte[] hostConnectionData, Byte[] key) { }

	public RelayServerData(Allocation allocation, string connectionType) { }

	public RelayServerData(JoinAllocation allocation, string connectionType) { }

	public RelayServerData(string host, ushort port, Byte[] allocationId, Byte[] connectionData, Byte[] hostConnectionData, Byte[] key, bool isSecure) { }

	[Obsolete("Will be removed in Unity Transport 2.0. Use the new constructor introduced in 1.3 instead.", False)]
	public RelayServerData(ref NetworkEndPoint endpoint, ushort nonce, RelayAllocationId allocationId, string connectionData, string hostConnectionData, string key, bool isSecure) { }

	public RelayServerData(ref NetworkEndPoint endpoint, ushort nonce, ref RelayAllocationId allocationId, ref RelayConnectionData connectionData, ref RelayConnectionData hostConnectionData, ref RelayHMACKey key, bool isSecure) { }

	private static void ComputeBindHMAC(Byte* result, ushort nonce, ref RelayConnectionData connectionData, ref RelayHMACKey key) { }

	[Obsolete("Will be removed in Unity Transport 2.0. There shouldn't be any need to call this method.")]
	public void ComputeNewNonce() { }

	private static NetworkEndPoint HostToEndpoint(string host, ushort port) { }

}

