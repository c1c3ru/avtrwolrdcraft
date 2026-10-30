namespace Unity.Services.Lobbies;

internal class InternalLobbyService : ILobbyServiceSdk
{
	[CompilerGenerated]
	private ILobbyApiClient <LobbyApi>k__BackingField; //Field offset: 0x10
	[CompilerGenerated]
	private Configuration <Configuration>k__BackingField; //Field offset: 0x18
	[CompilerGenerated]
	private IWire <Wire>k__BackingField; //Field offset: 0x20
	[CompilerGenerated]
	private readonly IMetrics <Metrics>k__BackingField; //Field offset: 0x28

	public override Configuration Configuration
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 8
	}

	public override ILobbyApiClient LobbyApi
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 8
	}

	public override IMetrics Metrics
	{
		[CompilerGenerated]
		 get { } //Length: 8
	}

	public override IWire Wire
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 8
	}

	public InternalLobbyService(HttpClient httpClient, IAccessToken accessToken = null, IWire subscriptionFactory = null, IMetrics metrics = null) { }

	[CompilerGenerated]
	public override Configuration get_Configuration() { }

	[CompilerGenerated]
	public override ILobbyApiClient get_LobbyApi() { }

	[CompilerGenerated]
	public override IMetrics get_Metrics() { }

	[CompilerGenerated]
	public override IWire get_Wire() { }

	[CompilerGenerated]
	public void set_Configuration(Configuration value) { }

	[CompilerGenerated]
	public void set_LobbyApi(ILobbyApiClient value) { }

	[CompilerGenerated]
	public override void set_Wire(IWire value) { }

}

