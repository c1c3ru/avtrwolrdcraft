namespace UnityWebSocketSharp.Net;

internal class ServerSslConfiguration
{
	private bool _checkCertRevocation; //Field offset: 0x10
	private bool _clientCertRequired; //Field offset: 0x11
	private RemoteCertificateValidationCallback _clientCertValidationCallback; //Field offset: 0x18
	private SslProtocols _enabledSslProtocols; //Field offset: 0x20
	private X509Certificate2 _serverCert; //Field offset: 0x28

	public bool CheckCertificateRevocation
	{
		 get { } //Length: 8
		 set { } //Length: 12
	}

	public bool ClientCertificateRequired
	{
		 get { } //Length: 8
		 set { } //Length: 12
	}

	public RemoteCertificateValidationCallback ClientCertificateValidationCallback
	{
		 get { } //Length: 140
		 set { } //Length: 8
	}

	public SslProtocols EnabledSslProtocols
	{
		 get { } //Length: 8
		 set { } //Length: 8
	}

	public X509Certificate2 ServerCertificate
	{
		 get { } //Length: 8
		 set { } //Length: 8
	}

	public ServerSslConfiguration() { }

	public ServerSslConfiguration(ServerSslConfiguration configuration) { }

	private static bool defaultValidateClientCertificate(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors) { }

	public bool get_CheckCertificateRevocation() { }

	public bool get_ClientCertificateRequired() { }

	public RemoteCertificateValidationCallback get_ClientCertificateValidationCallback() { }

	public SslProtocols get_EnabledSslProtocols() { }

	public X509Certificate2 get_ServerCertificate() { }

	public void set_CheckCertificateRevocation(bool value) { }

	public void set_ClientCertificateRequired(bool value) { }

	public void set_ClientCertificateValidationCallback(RemoteCertificateValidationCallback value) { }

	public void set_EnabledSslProtocols(SslProtocols value) { }

	public void set_ServerCertificate(X509Certificate2 value) { }

}

