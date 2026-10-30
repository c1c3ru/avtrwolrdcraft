namespace Unity.Services.Relay;

internal class InternalRelayService : IRelayServiceSdk
{
	private const string k_CloudEnvironmentKey = "com.unity.services.core.cloud-environment"; //Field offset: 0x0
	private const string k_StagingEnvironment = "staging"; //Field offset: 0x0
	[CompilerGenerated]
	private IRelayAllocationsApiClient <AllocationsApi>k__BackingField; //Field offset: 0x10
	[CompilerGenerated]
	private Configuration <Configuration>k__BackingField; //Field offset: 0x18
	[CompilerGenerated]
	private IAccessToken <AccessToken>k__BackingField; //Field offset: 0x20
	[CompilerGenerated]
	private IQosResults <QosResults>k__BackingField; //Field offset: 0x28

	public override IAccessToken AccessToken
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 8
	}

	public override IRelayAllocationsApiClient AllocationsApi
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 8
	}

	public override Configuration Configuration
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 8
	}

	public override IQosResults QosResults
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 8
	}

	public InternalRelayService(HttpClient httpClient, IProjectConfiguration projectConfiguration = null, IAccessToken accessToken = null, IQosResults qosResults = null) { }

	[CompilerGenerated]
	public override IAccessToken get_AccessToken() { }

	[CompilerGenerated]
	public override IRelayAllocationsApiClient get_AllocationsApi() { }

	[CompilerGenerated]
	public override Configuration get_Configuration() { }

	[CompilerGenerated]
	public override IQosResults get_QosResults() { }

	private string GetHost(IProjectConfiguration projectConfiguration) { }

	[CompilerGenerated]
	public override void set_AccessToken(IAccessToken value) { }

	[CompilerGenerated]
	public override void set_AllocationsApi(IRelayAllocationsApiClient value) { }

	[CompilerGenerated]
	public override void set_Configuration(Configuration value) { }

	[CompilerGenerated]
	public override void set_QosResults(IQosResults value) { }

}

