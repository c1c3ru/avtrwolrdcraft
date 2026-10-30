namespace Unity.Services.Authentication;

internal class PlayerIdComponent : IPlayerId, IServiceComponent
{
	private const string k_CacheKey = "player_id"; //Field offset: 0x0
	private string m_PlayerId; //Field offset: 0x10
	[CompilerGenerated]
	private Action<String> PlayerIdChanged; //Field offset: 0x18
	private readonly IAuthenticationCache m_Cache; //Field offset: 0x20

	public override event Action<String> PlayerIdChanged
	{
		[CompilerGenerated]
		 add { } //Length: 176
		[CompilerGenerated]
		 remove { } //Length: 176
	}

	public internal override string PlayerId
	{
		 get { } //Length: 8
		internal set { } //Length: 4
	}

	internal PlayerIdComponent(IAuthenticationCache cache) { }

	[CompilerGenerated]
	public override void add_PlayerIdChanged(Action<String> value) { }

	internal void Clear() { }

	public override string get_PlayerId() { }

	private string GetPlayerId() { }

	internal void Refresh() { }

	[CompilerGenerated]
	public override void remove_PlayerIdChanged(Action<String> value) { }

	internal void set_PlayerId(string value) { }

	private void SetPlayerId(string playerId) { }

}

