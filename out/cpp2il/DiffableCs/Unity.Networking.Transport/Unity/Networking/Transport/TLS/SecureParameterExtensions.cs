namespace Unity.Networking.Transport.TLS;

[Extension]
public static class SecureParameterExtensions
{

	[Extension]
	public static SecureNetworkProtocolParameter GetSecureParameters(ref NetworkSettings settings) { }

	[Extension]
	public static NetworkSettings WithSecureClientParameters(ref NetworkSettings settings, ref FixedString32Bytes serverName, uint readTimeout = 0, uint handshakeTimeoutMax = 60000, uint handshakeTimeoutMin = 1000) { }

	[Extension]
	public static NetworkSettings WithSecureClientParameters(ref NetworkSettings settings, string serverName) { }

	[Extension]
	public static NetworkSettings WithSecureClientParameters(ref NetworkSettings settings, ref FixedString4096Bytes caCertificate, ref FixedString32Bytes serverName, uint readTimeout = 0, uint handshakeTimeoutMax = 60000, uint handshakeTimeoutMin = 1000) { }

	[Extension]
	public static NetworkSettings WithSecureClientParameters(ref NetworkSettings settings, string caCertificate, string serverName) { }

	[Extension]
	public static NetworkSettings WithSecureClientParameters(ref NetworkSettings settings, ref FixedString4096Bytes certificate, ref FixedString4096Bytes privateKey, ref FixedString4096Bytes caCertificate, ref FixedString32Bytes serverName, uint readTimeout = 0, uint handshakeTimeoutMax = 60000, uint handshakeTimeoutMin = 1000) { }

	[Extension]
	public static NetworkSettings WithSecureClientParameters(ref NetworkSettings settings, string certificate, string privateKey, string caCertificate, string serverName) { }

	[Extension]
	[Obsolete("Use WithSecureClientParameters or WithSecureServerParameters instead.")]
	public static NetworkSettings WithSecureParameters(ref NetworkSettings settings, ref FixedString4096Bytes pem, ref FixedString32Bytes hostname, SecureTransportProtocol protocol = 1, SecureClientAuthPolicy clientAuthenticationPolicy = 1, uint sslReadTimeoutMs = 0, uint sslHandshakeTimeoutMax = 60000, uint sslHandshakeTimeoutMin = 1000) { }

	[Extension]
	[Obsolete("Use WithSecureClientParameters or WithSecureServerParameters instead.")]
	public static NetworkSettings WithSecureParameters(ref NetworkSettings settings, ref FixedString4096Bytes pem, ref FixedString4096Bytes rsa, ref FixedString4096Bytes rsaKey, ref FixedString32Bytes hostname, SecureTransportProtocol protocol = 1, SecureClientAuthPolicy clientAuthenticationPolicy = 1, uint sslReadTimeoutMs = 0, uint sslHandshakeTimeoutMax = 60000, uint sslHandshakeTimeoutMin = 1000) { }

	[Extension]
	public static NetworkSettings WithSecureServerParameters(ref NetworkSettings settings, ref FixedString4096Bytes certificate, ref FixedString4096Bytes privateKey, uint readTimeout = 0, uint handshakeTimeoutMax = 60000, uint handshakeTimeoutMin = 1000) { }

	[Extension]
	public static NetworkSettings WithSecureServerParameters(ref NetworkSettings settings, string certificate, string privateKey) { }

	[Extension]
	public static NetworkSettings WithSecureServerParameters(ref NetworkSettings settings, ref FixedString4096Bytes certificate, ref FixedString4096Bytes privateKey, ref FixedString4096Bytes caCertificate, ref FixedString32Bytes clientName, SecureClientAuthPolicy clientAuthenticationPolicy = 2, uint readTimeout = 0, uint handshakeTimeoutMax = 60000, uint handshakeTimeoutMin = 1000) { }

	[Extension]
	public static NetworkSettings WithSecureServerParameters(ref NetworkSettings settings, string certificate, string privateKey, string caCertificate, string clientName, SecureClientAuthPolicy clientAuthenticationPolicy = 2) { }

}

