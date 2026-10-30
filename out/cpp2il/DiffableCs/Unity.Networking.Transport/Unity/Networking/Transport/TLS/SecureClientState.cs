namespace Unity.Networking.Transport.TLS;

internal struct SecureClientState
{
	public unitytls_client* ClientPtr; //Field offset: 0x0
	public unitytls_client_config* ClientConfig; //Field offset: 0x8
	public SessionIdToken ReceiveToken; //Field offset: 0x10
	public long LastHandshakeUpdate; //Field offset: 0x18

}

