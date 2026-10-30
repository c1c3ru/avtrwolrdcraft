namespace Unity.Services.Qos;

internal class InternalQosDiscoveryService
{
	private const int RequestTimeout = 10; //Field offset: 0x0
	private const int NumRetries = 4; //Field offset: 0x0
	[CompilerGenerated]
	private IQosDiscoveryApiClient <QosDiscoveryApi>k__BackingField; //Field offset: 0x10
	[CompilerGenerated]
	private Configuration <Configuration>k__BackingField; //Field offset: 0x18

	public Configuration Configuration
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 8
	}

	public IQosDiscoveryApiClient QosDiscoveryApi
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 8
	}

	internal InternalQosDiscoveryService(string host, HttpClient httpClient, IAccessToken accessToken = null) { }

	[CompilerGenerated]
	public Configuration get_Configuration() { }

	[CompilerGenerated]
	public IQosDiscoveryApiClient get_QosDiscoveryApi() { }

	[CompilerGenerated]
	public void set_Configuration(Configuration value) { }

	[CompilerGenerated]
	public void set_QosDiscoveryApi(IQosDiscoveryApiClient value) { }

}

