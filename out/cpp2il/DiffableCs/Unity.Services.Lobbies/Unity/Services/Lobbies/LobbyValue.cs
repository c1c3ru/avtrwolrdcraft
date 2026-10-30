namespace Unity.Services.Lobbies;

public static class LobbyValue
{

	public static ChangedLobbyValue<T> Added(T value) { }

	public static ChangedOrRemovedLobbyValue<T> ChangeAdded(T value) { }

	public static ChangedLobbyValue<T> Changed(T value) { }

	public static ChangedOrRemovedLobbyValue<T> ChangedNotRemoved(T value) { }

	public static ChangedOrRemovedLobbyValue<T> Removed() { }

}

