namespace Unity.Networking.Transport.TLS;

internal struct SecureNetworkProtocolData
{
	public UnsafeHashMap<NetworkInterfaceEndPoint, SecureClientState> SecureClients; //Field offset: 0x0
	public FixedString4096Bytes Pem; //Field offset: 0x10
	public FixedString4096Bytes Rsa; //Field offset: 0x1010
	public FixedString4096Bytes RsaKey; //Field offset: 0x2010
	public FixedString32Bytes Hostname; //Field offset: 0x3010
	public uint Protocol; //Field offset: 0x3030
	public uint SSLReadTimeoutMs; //Field offset: 0x3034
	public uint SSLHandshakeTimeoutMax; //Field offset: 0x3038
	public uint SSLHandshakeTimeoutMin; //Field offset: 0x303C
	public uint ClientAuth; //Field offset: 0x3040
	public long LastUpdate; //Field offset: 0x3048
	public long LastHalfOpenPrune; //Field offset: 0x3050

}

