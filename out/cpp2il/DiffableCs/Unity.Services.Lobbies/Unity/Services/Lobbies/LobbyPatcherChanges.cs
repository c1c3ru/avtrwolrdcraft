namespace Unity.Services.Lobbies;

internal class LobbyPatcherChanges : ILobbyChanges
{
	[CompilerGenerated]
	private bool <LobbyDeleted>k__BackingField; //Field offset: 0x10
	[CompilerGenerated]
	private ChangedLobbyValue<String> <Name>k__BackingField; //Field offset: 0x18
	[CompilerGenerated]
	private ChangedLobbyValue<Boolean> <IsPrivate>k__BackingField; //Field offset: 0x28
	[CompilerGenerated]
	private ChangedLobbyValue<Boolean> <IsLocked>k__BackingField; //Field offset: 0x2B
	[CompilerGenerated]
	private ChangedLobbyValue<Boolean> <HasPassword>k__BackingField; //Field offset: 0x2E
	[CompilerGenerated]
	private ChangedLobbyValue<Int32> <AvailableSlots>k__BackingField; //Field offset: 0x34
	[CompilerGenerated]
	private ChangedLobbyValue<Int32> <MaxPlayers>k__BackingField; //Field offset: 0x3C
	[CompilerGenerated]
	private ChangedOrRemovedLobbyValue<Dictionary`2<String, ChangedOrRemovedLobbyValue`1<DataObject>>> <Data>k__BackingField; //Field offset: 0x48
	[CompilerGenerated]
	private ChangedLobbyValue<List`1<Int32>> <PlayerLeft>k__BackingField; //Field offset: 0x58
	[CompilerGenerated]
	private ChangedLobbyValue<List`1<LobbyPlayerJoined>> <PlayerJoined>k__BackingField; //Field offset: 0x68
	[CompilerGenerated]
	private ChangedLobbyValue<Dictionary`2<Int32, LobbyPlayerChanges>> <PlayerData>k__BackingField; //Field offset: 0x78
	[CompilerGenerated]
	private ChangedLobbyValue<String> <HostId>k__BackingField; //Field offset: 0x88
	[CompilerGenerated]
	private ChangedLobbyValue<Int32> <Version>k__BackingField; //Field offset: 0x98
	[CompilerGenerated]
	private ChangedLobbyValue<DateTime> <LastUpdated>k__BackingField; //Field offset: 0xA0

	public private override ChangedLobbyValue<Int32> AvailableSlots
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 8
	}

	public private override ChangedOrRemovedLobbyValue<Dictionary`2<String, ChangedOrRemovedLobbyValue`1<DataObject>>> Data
	{
		[CompilerGenerated]
		 get { } //Length: 12
		[CompilerGenerated]
		private set { } //Length: 16
	}

	public private override ChangedLobbyValue<Boolean> HasPassword
	{
		[CompilerGenerated]
		 get { } //Length: 16
		[CompilerGenerated]
		private set { } //Length: 16
	}

	public private override ChangedLobbyValue<String> HostId
	{
		[CompilerGenerated]
		 get { } //Length: 12
		[CompilerGenerated]
		private set { } //Length: 16
	}

	public private override ChangedLobbyValue<Boolean> IsLocked
	{
		[CompilerGenerated]
		 get { } //Length: 16
		[CompilerGenerated]
		private set { } //Length: 16
	}

	public private override ChangedLobbyValue<Boolean> IsPrivate
	{
		[CompilerGenerated]
		 get { } //Length: 16
		[CompilerGenerated]
		private set { } //Length: 16
	}

	public private override ChangedLobbyValue<DateTime> LastUpdated
	{
		[CompilerGenerated]
		 get { } //Length: 12
		[CompilerGenerated]
		private set { } //Length: 8
	}

	public private override bool LobbyDeleted
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 12
	}

	public private override ChangedLobbyValue<Int32> MaxPlayers
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 8
	}

	public private override ChangedLobbyValue<String> Name
	{
		[CompilerGenerated]
		 get { } //Length: 12
		[CompilerGenerated]
		private set { } //Length: 16
	}

	public private override ChangedLobbyValue<Dictionary`2<Int32, LobbyPlayerChanges>> PlayerData
	{
		[CompilerGenerated]
		 get { } //Length: 12
		[CompilerGenerated]
		private set { } //Length: 16
	}

	public private override ChangedLobbyValue<List`1<LobbyPlayerJoined>> PlayerJoined
	{
		[CompilerGenerated]
		 get { } //Length: 12
		[CompilerGenerated]
		private set { } //Length: 16
	}

	public private override ChangedLobbyValue<List`1<Int32>> PlayerLeft
	{
		[CompilerGenerated]
		 get { } //Length: 12
		[CompilerGenerated]
		private set { } //Length: 16
	}

	public private override ChangedLobbyValue<Int32> Version
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		private set { } //Length: 8
	}

	public LobbyPatcherChanges(int version) { }

	public override void ApplyToLobby(Lobby lobby) { }

	public void AvailableSlotsChange(int availableSlots) { }

	public void DataAdded(string key, DataObject dataObject) { }

	public void DataChange(string key, DataObject dataObject) { }

	public void DataRemoveChange(string key) { }

	public void DataRemoveChange() { }

	[CompilerGenerated]
	public override ChangedLobbyValue<Int32> get_AvailableSlots() { }

	[CompilerGenerated]
	public override ChangedOrRemovedLobbyValue<Dictionary`2<String, ChangedOrRemovedLobbyValue`1<DataObject>>> get_Data() { }

	[CompilerGenerated]
	public override ChangedLobbyValue<Boolean> get_HasPassword() { }

	[CompilerGenerated]
	public override ChangedLobbyValue<String> get_HostId() { }

	[CompilerGenerated]
	public override ChangedLobbyValue<Boolean> get_IsLocked() { }

	[CompilerGenerated]
	public override ChangedLobbyValue<Boolean> get_IsPrivate() { }

	[CompilerGenerated]
	public override ChangedLobbyValue<DateTime> get_LastUpdated() { }

	[CompilerGenerated]
	public override bool get_LobbyDeleted() { }

	[CompilerGenerated]
	public override ChangedLobbyValue<Int32> get_MaxPlayers() { }

	[CompilerGenerated]
	public override ChangedLobbyValue<String> get_Name() { }

	[CompilerGenerated]
	public override ChangedLobbyValue<Dictionary`2<Int32, LobbyPlayerChanges>> get_PlayerData() { }

	[CompilerGenerated]
	public override ChangedLobbyValue<List`1<LobbyPlayerJoined>> get_PlayerJoined() { }

	[CompilerGenerated]
	public override ChangedLobbyValue<List`1<Int32>> get_PlayerLeft() { }

	[CompilerGenerated]
	public override ChangedLobbyValue<Int32> get_Version() { }

	public void HasPasswordChange(bool hasPassword) { }

	public void HostChange(string newHostId) { }

	public void IsLockedChange(bool isLocked) { }

	public void IsPrivateChange(bool isPrivate) { }

	public void LastUpdatedChange(DateTime lastUpdated) { }

	public void LobbyDeletedChange() { }

	public void MaxPlayersChange(int maxPlayers) { }

	public void NameChange(string name) { }

	public void PlayerConnectionInfoChange(int index, string connectionInfo) { }

	public void PlayerDataAdded(int index, string key, PlayerDataObject playerDataObject) { }

	public void PlayerDataChange(int index, string key, PlayerDataObject playerDataObject) { }

	public void PlayerDataRemoveChange(int index) { }

	public void PlayerDataRemoveChange(int index, string key) { }

	public void PlayerJoinedChange(int index, Player player) { }

	public void PlayerLastUpdatedChange(int index, DateTime lastUpdated) { }

	public void PlayerLeftChange(int index) { }

	private LobbyPlayerChanges PreparePlayerDataAddition(int index) { }

	private LobbyPlayerChanges PreparePlayerDataChange(int index) { }

	[CompilerGenerated]
	private void set_AvailableSlots(ChangedLobbyValue<Int32> value) { }

	[CompilerGenerated]
	private void set_Data(ChangedOrRemovedLobbyValue<Dictionary`2<String, ChangedOrRemovedLobbyValue`1<DataObject>>> value) { }

	[CompilerGenerated]
	private void set_HasPassword(ChangedLobbyValue<Boolean> value) { }

	[CompilerGenerated]
	private void set_HostId(ChangedLobbyValue<String> value) { }

	[CompilerGenerated]
	private void set_IsLocked(ChangedLobbyValue<Boolean> value) { }

	[CompilerGenerated]
	private void set_IsPrivate(ChangedLobbyValue<Boolean> value) { }

	[CompilerGenerated]
	private void set_LastUpdated(ChangedLobbyValue<DateTime> value) { }

	[CompilerGenerated]
	private void set_LobbyDeleted(bool value) { }

	[CompilerGenerated]
	private void set_MaxPlayers(ChangedLobbyValue<Int32> value) { }

	[CompilerGenerated]
	private void set_Name(ChangedLobbyValue<String> value) { }

	[CompilerGenerated]
	private void set_PlayerData(ChangedLobbyValue<Dictionary`2<Int32, LobbyPlayerChanges>> value) { }

	[CompilerGenerated]
	private void set_PlayerJoined(ChangedLobbyValue<List`1<LobbyPlayerJoined>> value) { }

	[CompilerGenerated]
	private void set_PlayerLeft(ChangedLobbyValue<List`1<Int32>> value) { }

	[CompilerGenerated]
	private void set_Version(ChangedLobbyValue<Int32> value) { }

}

