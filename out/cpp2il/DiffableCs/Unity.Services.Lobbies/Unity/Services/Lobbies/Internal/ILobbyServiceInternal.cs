namespace Unity.Services.Lobbies.Internal;

internal interface ILobbyServiceInternal
{

	public Dictionary<String, Lobby> GetLobbyCache() { }

	public Task<Dictionary`2<String, TokenData>> RequestTokensAsync(string lobbyId, TokenTypeOptions[] tokenOptions) { }

}

