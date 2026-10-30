namespace Unity.Services.Lobbies;

public class LobbyPlayerChanges
{
	[CompilerGenerated]
	private readonly int <PlayerIndex>k__BackingField; //Field offset: 0x10
	[CompilerGenerated]
	private ChangedLobbyValue<String> <ConnectionInfoChanged>k__BackingField; //Field offset: 0x18
	[CompilerGenerated]
	private ChangedLobbyValue<DateTime> <LastUpdatedChanged>k__BackingField; //Field offset: 0x28
	[CompilerGenerated]
	private ChangedOrRemovedLobbyValue<Dictionary`2<String, ChangedOrRemovedLobbyValue`1<PlayerDataObject>>> <ChangedData>k__BackingField; //Field offset: 0x38

	public internal ChangedOrRemovedLobbyValue<Dictionary`2<String, ChangedOrRemovedLobbyValue`1<PlayerDataObject>>> ChangedData
	{
		[CompilerGenerated]
		 get { } //Length: 12
		[CompilerGenerated]
		internal set { } //Length: 16
	}

	public internal ChangedLobbyValue<String> ConnectionInfoChanged
	{
		[CompilerGenerated]
		 get { } //Length: 12
		[CompilerGenerated]
		internal set { } //Length: 16
	}

	public internal ChangedLobbyValue<DateTime> LastUpdatedChanged
	{
		[CompilerGenerated]
		 get { } //Length: 12
		[CompilerGenerated]
		internal set { } //Length: 8
	}

	public int PlayerIndex
	{
		[CompilerGenerated]
		 get { } //Length: 8
	}

	public LobbyPlayerChanges(int index) { }

	[CompilerGenerated]
	public ChangedOrRemovedLobbyValue<Dictionary`2<String, ChangedOrRemovedLobbyValue`1<PlayerDataObject>>> get_ChangedData() { }

	[CompilerGenerated]
	public ChangedLobbyValue<String> get_ConnectionInfoChanged() { }

	[CompilerGenerated]
	public ChangedLobbyValue<DateTime> get_LastUpdatedChanged() { }

	[CompilerGenerated]
	public int get_PlayerIndex() { }

	[CompilerGenerated]
	internal void set_ChangedData(ChangedOrRemovedLobbyValue<Dictionary`2<String, ChangedOrRemovedLobbyValue`1<PlayerDataObject>>> value) { }

	[CompilerGenerated]
	internal void set_ConnectionInfoChanged(ChangedLobbyValue<String> value) { }

	[CompilerGenerated]
	internal void set_LastUpdatedChanged(ChangedLobbyValue<DateTime> value) { }

}

