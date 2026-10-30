namespace Unity.Services.Lobbies;

public struct LobbyPlayerJoined
{
	[CompilerGenerated]
	private readonly int <PlayerIndex>k__BackingField; //Field offset: 0x0
	[CompilerGenerated]
	private readonly Player <Player>k__BackingField; //Field offset: 0x8

	public Player Player
	{
		[CompilerGenerated]
		[IsReadOnly]
		 get { } //Length: 8
	}

	public int PlayerIndex
	{
		[CompilerGenerated]
		[IsReadOnly]
		 get { } //Length: 8
	}

	public LobbyPlayerJoined(int index, Player player) { }

	[CompilerGenerated]
	[IsReadOnly]
	public Player get_Player() { }

	[CompilerGenerated]
	[IsReadOnly]
	public int get_PlayerIndex() { }

}

