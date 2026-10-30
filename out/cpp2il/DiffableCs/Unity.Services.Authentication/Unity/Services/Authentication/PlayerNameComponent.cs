namespace Unity.Services.Authentication;

internal class PlayerNameComponent : IPlayerName
{
	private const string k_CacheKey = "player_name"; //Field offset: 0x0
	private string m_PlayerName; //Field offset: 0x10
	[CompilerGenerated]
	private Action<String> PlayerNameChanged; //Field offset: 0x18
	private readonly IAuthenticationCache m_Cache; //Field offset: 0x20

	public override event Action<String> PlayerNameChanged
	{
		[CompilerGenerated]
		 add { } //Length: 176
		[CompilerGenerated]
		 remove { } //Length: 176
	}

	public internal override string PlayerName
	{
		 get { } //Length: 8
		internal set { } //Length: 4
	}

	internal PlayerNameComponent(IAuthenticationCache cache) { }

	[CompilerGenerated]
	public override void add_PlayerNameChanged(Action<String> value) { }

	internal void Clear() { }

	public override string get_PlayerName() { }

	private string GetPlayerName() { }

	[CompilerGenerated]
	public override void remove_PlayerNameChanged(Action<String> value) { }

	internal void set_PlayerName(string value) { }

	private void SetPlayerName(string playerName) { }

}

