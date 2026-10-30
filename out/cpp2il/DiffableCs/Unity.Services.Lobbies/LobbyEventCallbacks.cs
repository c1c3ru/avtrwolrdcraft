//Type is in global namespace

public class LobbyEventCallbacks
{
	[CompilerGenerated]
	private Action<ILobbyChanges> LobbyChanged; //Field offset: 0x10
	[CompilerGenerated]
	private Action<List`1<LobbyPlayerJoined>> PlayerJoined; //Field offset: 0x18
	[CompilerGenerated]
	private Action<List`1<Int32>> PlayerLeft; //Field offset: 0x20
	[CompilerGenerated]
	private Action<Dictionary`2<String, ChangedOrRemovedLobbyValue`1<DataObject>>> DataChanged; //Field offset: 0x28
	[CompilerGenerated]
	private Action<Dictionary`2<String, ChangedOrRemovedLobbyValue`1<DataObject>>> DataRemoved; //Field offset: 0x30
	[CompilerGenerated]
	private Action<Dictionary`2<String, ChangedOrRemovedLobbyValue`1<DataObject>>> DataAdded; //Field offset: 0x38
	[CompilerGenerated]
	private Action<Dictionary`2<Int32, Dictionary`2<String, ChangedOrRemovedLobbyValue`1<PlayerDataObject>>>> PlayerDataChanged; //Field offset: 0x40
	[CompilerGenerated]
	private Action<Dictionary`2<Int32, Dictionary`2<String, ChangedOrRemovedLobbyValue`1<PlayerDataObject>>>> PlayerDataRemoved; //Field offset: 0x48
	[CompilerGenerated]
	private Action<Dictionary`2<Int32, Dictionary`2<String, ChangedOrRemovedLobbyValue`1<PlayerDataObject>>>> PlayerDataAdded; //Field offset: 0x50
	[CompilerGenerated]
	private Action LobbyDeleted; //Field offset: 0x58
	[CompilerGenerated]
	private Action KickedFromLobby; //Field offset: 0x60
	[CompilerGenerated]
	private Action<LobbyEventConnectionState> LobbyEventConnectionStateChanged; //Field offset: 0x68

	public event Action<Dictionary`2<String, ChangedOrRemovedLobbyValue`1<DataObject>>> DataAdded
	{
		[CompilerGenerated]
		 add { } //Length: 176
		[CompilerGenerated]
		 remove { } //Length: 176
	}

	public event Action<Dictionary`2<String, ChangedOrRemovedLobbyValue`1<DataObject>>> DataChanged
	{
		[CompilerGenerated]
		 add { } //Length: 176
		[CompilerGenerated]
		 remove { } //Length: 176
	}

	public event Action<Dictionary`2<String, ChangedOrRemovedLobbyValue`1<DataObject>>> DataRemoved
	{
		[CompilerGenerated]
		 add { } //Length: 176
		[CompilerGenerated]
		 remove { } //Length: 176
	}

	public event Action KickedFromLobby
	{
		[CompilerGenerated]
		 add { } //Length: 156
		[CompilerGenerated]
		 remove { } //Length: 156
	}

	public event Action<ILobbyChanges> LobbyChanged
	{
		[CompilerGenerated]
		 add { } //Length: 176
		[CompilerGenerated]
		 remove { } //Length: 176
	}

	public event Action LobbyDeleted
	{
		[CompilerGenerated]
		 add { } //Length: 156
		[CompilerGenerated]
		 remove { } //Length: 156
	}

	public event Action<LobbyEventConnectionState> LobbyEventConnectionStateChanged
	{
		[CompilerGenerated]
		 add { } //Length: 176
		[CompilerGenerated]
		 remove { } //Length: 176
	}

	public event Action<Dictionary`2<Int32, Dictionary`2<String, ChangedOrRemovedLobbyValue`1<PlayerDataObject>>>> PlayerDataAdded
	{
		[CompilerGenerated]
		 add { } //Length: 176
		[CompilerGenerated]
		 remove { } //Length: 176
	}

	public event Action<Dictionary`2<Int32, Dictionary`2<String, ChangedOrRemovedLobbyValue`1<PlayerDataObject>>>> PlayerDataChanged
	{
		[CompilerGenerated]
		 add { } //Length: 176
		[CompilerGenerated]
		 remove { } //Length: 176
	}

	public event Action<Dictionary`2<Int32, Dictionary`2<String, ChangedOrRemovedLobbyValue`1<PlayerDataObject>>>> PlayerDataRemoved
	{
		[CompilerGenerated]
		 add { } //Length: 176
		[CompilerGenerated]
		 remove { } //Length: 176
	}

	public event Action<List`1<LobbyPlayerJoined>> PlayerJoined
	{
		[CompilerGenerated]
		 add { } //Length: 176
		[CompilerGenerated]
		 remove { } //Length: 176
	}

	public event Action<List`1<Int32>> PlayerLeft
	{
		[CompilerGenerated]
		 add { } //Length: 176
		[CompilerGenerated]
		 remove { } //Length: 176
	}

	public LobbyEventCallbacks() { }

	[CompilerGenerated]
	public void add_DataAdded(Action<Dictionary`2<String, ChangedOrRemovedLobbyValue`1<DataObject>>> value) { }

	[CompilerGenerated]
	public void add_DataChanged(Action<Dictionary`2<String, ChangedOrRemovedLobbyValue`1<DataObject>>> value) { }

	[CompilerGenerated]
	public void add_DataRemoved(Action<Dictionary`2<String, ChangedOrRemovedLobbyValue`1<DataObject>>> value) { }

	[CompilerGenerated]
	public void add_KickedFromLobby(Action value) { }

	[CompilerGenerated]
	public void add_LobbyChanged(Action<ILobbyChanges> value) { }

	[CompilerGenerated]
	public void add_LobbyDeleted(Action value) { }

	[CompilerGenerated]
	public void add_LobbyEventConnectionStateChanged(Action<LobbyEventConnectionState> value) { }

	[CompilerGenerated]
	public void add_PlayerDataAdded(Action<Dictionary`2<Int32, Dictionary`2<String, ChangedOrRemovedLobbyValue`1<PlayerDataObject>>>> value) { }

	[CompilerGenerated]
	public void add_PlayerDataChanged(Action<Dictionary`2<Int32, Dictionary`2<String, ChangedOrRemovedLobbyValue`1<PlayerDataObject>>>> value) { }

	[CompilerGenerated]
	public void add_PlayerDataRemoved(Action<Dictionary`2<Int32, Dictionary`2<String, ChangedOrRemovedLobbyValue`1<PlayerDataObject>>>> value) { }

	[CompilerGenerated]
	public void add_PlayerJoined(Action<List`1<LobbyPlayerJoined>> value) { }

	[CompilerGenerated]
	public void add_PlayerLeft(Action<List`1<Int32>> value) { }

	internal void InvokeKickedFromLobby() { }

	internal void InvokeLobbyChanged(ILobbyChanges changes) { }

	internal void InvokeLobbyEventConnectionStateChanged(LobbyEventConnectionState state) { }

	[CompilerGenerated]
	public void remove_DataAdded(Action<Dictionary`2<String, ChangedOrRemovedLobbyValue`1<DataObject>>> value) { }

	[CompilerGenerated]
	public void remove_DataChanged(Action<Dictionary`2<String, ChangedOrRemovedLobbyValue`1<DataObject>>> value) { }

	[CompilerGenerated]
	public void remove_DataRemoved(Action<Dictionary`2<String, ChangedOrRemovedLobbyValue`1<DataObject>>> value) { }

	[CompilerGenerated]
	public void remove_KickedFromLobby(Action value) { }

	[CompilerGenerated]
	public void remove_LobbyChanged(Action<ILobbyChanges> value) { }

	[CompilerGenerated]
	public void remove_LobbyDeleted(Action value) { }

	[CompilerGenerated]
	public void remove_LobbyEventConnectionStateChanged(Action<LobbyEventConnectionState> value) { }

	[CompilerGenerated]
	public void remove_PlayerDataAdded(Action<Dictionary`2<Int32, Dictionary`2<String, ChangedOrRemovedLobbyValue`1<PlayerDataObject>>>> value) { }

	[CompilerGenerated]
	public void remove_PlayerDataChanged(Action<Dictionary`2<Int32, Dictionary`2<String, ChangedOrRemovedLobbyValue`1<PlayerDataObject>>>> value) { }

	[CompilerGenerated]
	public void remove_PlayerDataRemoved(Action<Dictionary`2<Int32, Dictionary`2<String, ChangedOrRemovedLobbyValue`1<PlayerDataObject>>>> value) { }

	[CompilerGenerated]
	public void remove_PlayerJoined(Action<List`1<LobbyPlayerJoined>> value) { }

	[CompilerGenerated]
	public void remove_PlayerLeft(Action<List`1<Int32>> value) { }

}

