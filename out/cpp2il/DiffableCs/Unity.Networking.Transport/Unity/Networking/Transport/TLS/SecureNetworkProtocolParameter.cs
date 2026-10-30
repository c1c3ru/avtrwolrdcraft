namespace Unity.Networking.Transport.TLS;

public struct SecureNetworkProtocolParameter : INetworkParameter
{
	public FixedString4096Bytes Pem; //Field offset: 0x0
	public FixedString4096Bytes Rsa; //Field offset: 0x1000
	public FixedString4096Bytes RsaKey; //Field offset: 0x2000
	public FixedString32Bytes Hostname; //Field offset: 0x3000
	public SecureTransportProtocol Protocol; //Field offset: 0x3020
	public SecureClientAuthPolicy ClientAuthenticationPolicy; //Field offset: 0x3024
	public uint SSLReadTimeoutMs; //Field offset: 0x3028
	public uint SSLHandshakeTimeoutMax; //Field offset: 0x302C
	public uint SSLHandshakeTimeoutMin; //Field offset: 0x3030

	public override bool Validate() { }

}

