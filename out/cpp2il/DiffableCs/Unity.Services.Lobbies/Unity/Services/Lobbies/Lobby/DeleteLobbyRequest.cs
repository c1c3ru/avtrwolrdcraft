namespace Unity.Services.Lobbies.Lobby;

[Preserve]
internal class DeleteLobbyRequest : LobbyApiBaseRequest
{
	[CompilerGenerated]
	private readonly string <LobbyId>k__BackingField; //Field offset: 0x10
	[CompilerGenerated]
	private readonly string <ServiceId>k__BackingField; //Field offset: 0x18
	[CompilerGenerated]
	private readonly string <ImpersonatedUserId>k__BackingField; //Field offset: 0x20
	private string PathAndQueryParams; //Field offset: 0x28

	[Preserve]
	public string ImpersonatedUserId
	{
		[CompilerGenerated]
		 get { } //Length: 8
	}

	[Preserve]
	public string LobbyId
	{
		[CompilerGenerated]
		 get { } //Length: 8
	}

	[Preserve]
	public string ServiceId
	{
		[CompilerGenerated]
		 get { } //Length: 8
	}

	[Preserve]
	public DeleteLobbyRequest(string lobbyId, string serviceId = null, string impersonatedUserId = null) { }

	public Byte[] ConstructBody() { }

	public Dictionary<String, String> ConstructHeaders(IAccessToken accessToken, Configuration operationConfiguration = null) { }

	public string ConstructUrl(string requestBasePath) { }

	[CompilerGenerated]
	public string get_ImpersonatedUserId() { }

	[CompilerGenerated]
	public string get_LobbyId() { }

	[CompilerGenerated]
	public string get_ServiceId() { }

}

