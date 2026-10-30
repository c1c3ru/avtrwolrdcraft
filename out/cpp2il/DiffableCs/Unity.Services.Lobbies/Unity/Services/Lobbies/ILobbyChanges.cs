namespace Unity.Services.Lobbies;

public interface ILobbyChanges
{

	public ChangedLobbyValue<Int32> AvailableSlots
	{
		 get { } //Length: 0
	}

	public ChangedOrRemovedLobbyValue<Dictionary`2<String, ChangedOrRemovedLobbyValue`1<DataObject>>> Data
	{
		 get { } //Length: 0
	}

	public ChangedLobbyValue<Boolean> HasPassword
	{
		 get { } //Length: 0
	}

	public ChangedLobbyValue<String> HostId
	{
		 get { } //Length: 0
	}

	public ChangedLobbyValue<Boolean> IsLocked
	{
		 get { } //Length: 0
	}

	public ChangedLobbyValue<Boolean> IsPrivate
	{
		 get { } //Length: 0
	}

	public ChangedLobbyValue<DateTime> LastUpdated
	{
		 get { } //Length: 0
	}

	public bool LobbyDeleted
	{
		 get { } //Length: 0
	}

	public ChangedLobbyValue<Int32> MaxPlayers
	{
		 get { } //Length: 0
	}

	public ChangedLobbyValue<String> Name
	{
		 get { } //Length: 0
	}

	public ChangedLobbyValue<Dictionary`2<Int32, LobbyPlayerChanges>> PlayerData
	{
		 get { } //Length: 0
	}

	public ChangedLobbyValue<List`1<LobbyPlayerJoined>> PlayerJoined
	{
		 get { } //Length: 0
	}

	public ChangedLobbyValue<List`1<Int32>> PlayerLeft
	{
		 get { } //Length: 0
	}

	public ChangedLobbyValue<Int32> Version
	{
		 get { } //Length: 0
	}

	public void ApplyToLobby(Lobby lobby) { }

	public ChangedLobbyValue<Int32> get_AvailableSlots() { }

	public ChangedOrRemovedLobbyValue<Dictionary`2<String, ChangedOrRemovedLobbyValue`1<DataObject>>> get_Data() { }

	public ChangedLobbyValue<Boolean> get_HasPassword() { }

	public ChangedLobbyValue<String> get_HostId() { }

	public ChangedLobbyValue<Boolean> get_IsLocked() { }

	public ChangedLobbyValue<Boolean> get_IsPrivate() { }

	public ChangedLobbyValue<DateTime> get_LastUpdated() { }

	public bool get_LobbyDeleted() { }

	public ChangedLobbyValue<Int32> get_MaxPlayers() { }

	public ChangedLobbyValue<String> get_Name() { }

	public ChangedLobbyValue<Dictionary`2<Int32, LobbyPlayerChanges>> get_PlayerData() { }

	public ChangedLobbyValue<List`1<LobbyPlayerJoined>> get_PlayerJoined() { }

	public ChangedLobbyValue<List`1<Int32>> get_PlayerLeft() { }

	public ChangedLobbyValue<Int32> get_Version() { }

}

