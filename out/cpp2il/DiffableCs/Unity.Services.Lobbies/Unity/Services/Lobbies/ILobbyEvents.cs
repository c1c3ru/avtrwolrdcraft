namespace Unity.Services.Lobbies;

public interface ILobbyEvents
{

	public LobbyEventCallbacks Callbacks
	{
		 get { } //Length: 0
	}

	public LobbyEventCallbacks get_Callbacks() { }

	public Task SubscribeAsync() { }

	public Task UnsubscribeAsync() { }

}

