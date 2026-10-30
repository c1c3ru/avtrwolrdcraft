namespace Unity.Services.Lobbies.Apis.Lobby;

internal interface ILobbyApiClient
{

	public Task<Response`1<Lobby>> BulkUpdateLobbyAsync(BulkUpdateLobbyRequest request, Configuration operationConfiguration = null) { }

	public Task<Response`1<Lobby>> CreateLobbyAsync(CreateLobbyRequest request, Configuration operationConfiguration = null) { }

	public Task<Response`1<Lobby>> CreateOrJoinLobbyAsync(CreateOrJoinLobbyRequest request, Configuration operationConfiguration = null) { }

	public Task<Response> DeleteLobbyAsync(DeleteLobbyRequest request, Configuration operationConfiguration = null) { }

	public Task<Response`1<List`1<String>>> GetHostedLobbiesAsync(GetHostedLobbiesRequest request, Configuration operationConfiguration = null) { }

	public Task<Response`1<List`1<String>>> GetJoinedLobbiesAsync(GetJoinedLobbiesRequest request, Configuration operationConfiguration = null) { }

	public Task<Response`1<Lobby>> GetLobbyAsync(GetLobbyRequest request, Configuration operationConfiguration = null) { }

	public Task<Response> HeartbeatAsync(HeartbeatRequest request, Configuration operationConfiguration = null) { }

	public Task<Response`1<Lobby>> JoinLobbyByCodeAsync(JoinLobbyByCodeRequest request, Configuration operationConfiguration = null) { }

	public Task<Response`1<Lobby>> JoinLobbyByIdAsync(JoinLobbyByIdRequest request, Configuration operationConfiguration = null) { }

	public Task<Response`1<QueryResponse>> QueryLobbiesAsync(QueryLobbiesRequest request, Configuration operationConfiguration = null) { }

	public Task<Response`1<Lobby>> QuickJoinLobbyAsync(QuickJoinLobbyRequest request, Configuration operationConfiguration = null) { }

	public Task<Response`1<Lobby>> ReconnectAsync(ReconnectRequest request, Configuration operationConfiguration = null) { }

	public Task<Response> RemovePlayerAsync(RemovePlayerRequest request, Configuration operationConfiguration = null) { }

	public Task<Response`1<Dictionary`2<String, TokenData>>> RequestTokensAsync(RequestTokensRequest request, Configuration operationConfiguration = null) { }

	public Task<Response`1<Lobby>> UpdateLobbyAsync(UpdateLobbyRequest request, Configuration operationConfiguration = null) { }

	public Task<Response`1<Lobby>> UpdatePlayerAsync(UpdatePlayerRequest request, Configuration operationConfiguration = null) { }

}

