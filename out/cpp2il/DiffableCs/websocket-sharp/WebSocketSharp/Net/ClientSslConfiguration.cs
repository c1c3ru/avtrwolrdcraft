namespace WebSocketSharp.Net;

public class ClientSslConfiguration
{
	private bool _checkCertRevocation; //Field offset: 0x10
	private LocalCertificateSelectionCallback _clientCertSelectionCallback; //Field offset: 0x18
	private X509CertificateCollection _clientCerts; //Field offset: 0x20
	private SslProtocols _enabledSslProtocols; //Field offset: 0x28
	private RemoteCertificateValidationCallback _serverCertValidationCallback; //Field offset: 0x30
	private string _targetHost; //Field offset: 0x38

	public bool CheckCertificateRevocation
	{
		 get { } //Length: 8
		 set { } //Length: 12
	}

	public X509CertificateCollection ClientCertificates
	{
		 get { } //Length: 8
		 set { } //Length: 8
	}

	public LocalCertificateSelectionCallback ClientCertificateSelectionCallback
	{
		 get { } //Length: 140
		 set { } //Length: 8
	}

	public SslProtocols EnabledSslProtocols
	{
		 get { } //Length: 8
		 set { } //Length: 8
	}

	public RemoteCertificateValidationCallback ServerCertificateValidationCallback
	{
		 get { } //Length: 140
		 set { } //Length: 8
	}

	public string TargetHost
	{
		 get { } //Length: 8
		 set { } //Length: 180
	}

	public ClientSslConfiguration(string targetHost) { }

	public ClientSslConfiguration(ClientSslConfiguration configuration) { }

	private static X509Certificate defaultSelectClientCertificate(object sender, string targetHost, X509CertificateCollection clientCertificates, X509Certificate serverCertificate, String[] acceptableIssuers) { }

	private static bool defaultValidateServerCertificate(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors) { }

	public bool get_CheckCertificateRevocation() { }

	public X509CertificateCollection get_ClientCertificates() { }

	public LocalCertificateSelectionCallback get_ClientCertificateSelectionCallback() { }

	public SslProtocols get_EnabledSslProtocols() { }

	public RemoteCertificateValidationCallback get_ServerCertificateValidationCallback() { }

	public string get_TargetHost() { }

	public void set_CheckCertificateRevocation(bool value) { }

	public void set_ClientCertificates(X509CertificateCollection value) { }

	public void set_ClientCertificateSelectionCallback(LocalCertificateSelectionCallback value) { }

	public void set_EnabledSslProtocols(SslProtocols value) { }

	public void set_ServerCertificateValidationCallback(RemoteCertificateValidationCallback value) { }

	public void set_TargetHost(string value) { }

}

