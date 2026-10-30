namespace Unity.Services.Lobbies;

public interface ILobbyService
{

	public Task<Lobby> CreateLobbyAsync(string lobbyName, int maxPlayers, CreateLobbyOptions options = null) { }

	public Task<Lobby> CreateOrJoinLobbyAsync(string lobbyId, string lobbyName, int maxPlayers, CreateLobbyOptions options = null) { }

	public Task DeleteLobbyAsync(string lobbyId) { }

	public Task<List`1<String>> GetJoinedLobbiesAsync() { }

	public Task<Lobby> GetLobbyAsync(string lobbyId) { }

	public Task<Lobby> JoinLobbyByCodeAsync(string lobbyCode, JoinLobbyByCodeOptions options = null) { }

	public Task<Lobby> JoinLobbyByIdAsync(string lobbyId, JoinLobbyByIdOptions options = null) { }

	public Task<QueryResponse> QueryLobbiesAsync(QueryLobbiesOptions options = null) { }

	public Task<Lobby> QuickJoinLobbyAsync(QuickJoinLobbyOptions options = null) { }

	public Task<Lobby> ReconnectToLobbyAsync(string lobbyId) { }

	public Task RemovePlayerAsync(string lobbyId, string playerId) { }

	public Task SendHeartbeatPingAsync(string lobbyId) { }

	public Task<ILobbyEvents> SubscribeToLobbyEventsAsync(string lobbyId, LobbyEventCallbacks callbacks) { }

	public Task<Lobby> UpdateLobbyAsync(string lobbyId, UpdateLobbyOptions options) { }

	public Task<Lobby> UpdatePlayerAsync(string lobbyId, string playerId, UpdatePlayerOptions options) { }

}

