namespace Unity.Services.Authentication;

internal class AccessTokenComponent : IAccessToken, IServiceComponent, IAccessTokenObserver
{
	[CompilerGenerated]
	private Action<String> AccessTokenChanged; //Field offset: 0x10
	[CompilerGenerated]
	private Nullable<DateTime> <RefreshTime>k__BackingField; //Field offset: 0x18
	[CompilerGenerated]
	private Nullable<DateTime> <ExpiryTime>k__BackingField; //Field offset: 0x28
	private string m_AccessToken; //Field offset: 0x38

	public override event Action<String> AccessTokenChanged
	{
		[CompilerGenerated]
		 add { } //Length: 176
		[CompilerGenerated]
		 remove { } //Length: 176
	}

	public internal override string AccessToken
	{
		 get { } //Length: 8
		internal set { } //Length: 4
	}

	public internal Nullable<DateTime> ExpiryTime
	{
		[CompilerGenerated]
		 get { } //Length: 12
		[CompilerGenerated]
		internal set { } //Length: 8
	}

	public internal Nullable<DateTime> RefreshTime
	{
		[CompilerGenerated]
		 get { } //Length: 12
		[CompilerGenerated]
		internal set { } //Length: 8
	}

	internal AccessTokenComponent() { }

	[CompilerGenerated]
	public override void add_AccessTokenChanged(Action<String> value) { }

	internal void Clear() { }

	public override string get_AccessToken() { }

	[CompilerGenerated]
	public Nullable<DateTime> get_ExpiryTime() { }

	[CompilerGenerated]
	public Nullable<DateTime> get_RefreshTime() { }

	[CompilerGenerated]
	public override void remove_AccessTokenChanged(Action<String> value) { }

	internal void set_AccessToken(string value) { }

	[CompilerGenerated]
	internal void set_ExpiryTime(Nullable<DateTime> value) { }

	[CompilerGenerated]
	internal void set_RefreshTime(Nullable<DateTime> value) { }

	private void SetAccessToken(string accessToken) { }

}

