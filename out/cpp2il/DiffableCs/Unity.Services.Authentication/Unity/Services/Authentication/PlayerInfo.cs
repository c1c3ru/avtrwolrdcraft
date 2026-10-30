namespace Unity.Services.Authentication;

public sealed class PlayerInfo
{
	[CompilerGenerated]
	private sealed class <>c
	{
		public static readonly <>c <>9; //Field offset: 0x0
		public static Predicate<Identity> <>9__33_0; //Field offset: 0x8

		private static <>c() { }

		public <>c() { }

		internal bool <GetOpenIdConnectIdProviders>b__33_0(Identity id) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass34_0
	{
		public string typeId; //Field offset: 0x10

		public <>c__DisplayClass34_0() { }

		internal bool <GetIdentityId>b__0(Identity x) { }

	}

	[CompilerGenerated]
	private sealed class <>c__DisplayClass36_0
	{
		public string typeId; //Field offset: 0x10

		public <>c__DisplayClass36_0() { }

		internal bool <RemoveIdentity>b__0(Identity x) { }

	}

	private const string k_OpenIdConnectPrefix = "oidc-"; //Field offset: 0x0
	private const string k_IdProviderNameRegex = "^oidc-[a-z0-9-_\.]{1,15}$"; //Field offset: 0x0
	[CompilerGenerated]
	private readonly string <Id>k__BackingField; //Field offset: 0x10
	[CompilerGenerated]
	private readonly Nullable<DateTime> <CreatedAt>k__BackingField; //Field offset: 0x18
	[CompilerGenerated]
	private readonly List<Identity> <Identities>k__BackingField; //Field offset: 0x28
	[CompilerGenerated]
	private string <Username>k__BackingField; //Field offset: 0x30
	[CompilerGenerated]
	private Nullable<DateTime> <LastPasswordUpdate>k__BackingField; //Field offset: 0x38

	public Nullable<DateTime> CreatedAt
	{
		[CompilerGenerated]
		 get { } //Length: 12
	}

	public string Id
	{
		[CompilerGenerated]
		 get { } //Length: 8
	}

	public List<Identity> Identities
	{
		[CompilerGenerated]
		 get { } //Length: 8
	}

	[CanBeNull]
	public internal Nullable<DateTime> LastPasswordUpdate
	{
		[CompilerGenerated]
		 get { } //Length: 12
		[CompilerGenerated]
		internal set { } //Length: 8
	}

	[CanBeNull]
	public internal string Username
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		internal set { } //Length: 8
	}

	internal PlayerInfo(User user) { }

	internal PlayerInfo(string playerId, string createdAt, List<ExternalIdentity> externalIdentities, string username, string lastPasswordUpdate) { }

	internal PlayerInfo(PlayerInfoResponse response) { }

	internal PlayerInfo(string playerId) { }

	internal void AddExternalIdentity(ExternalIdentity externalId) { }

	[CompilerGenerated]
	public Nullable<DateTime> get_CreatedAt() { }

	[CompilerGenerated]
	public string get_Id() { }

	[CompilerGenerated]
	public List<Identity> get_Identities() { }

	[CompilerGenerated]
	public Nullable<DateTime> get_LastPasswordUpdate() { }

	[CompilerGenerated]
	public string get_Username() { }

	public string GetAppleGameCenterId() { }

	public string GetAppleId() { }

	public string GetCustomId() { }

	public string GetFacebookId() { }

	public string GetGoogleId() { }

	public string GetGooglePlayGamesId() { }

	internal string GetIdentityId(string typeId) { }

	public string GetOculusId() { }

	public string GetOpenIdConnectId(string idProviderName) { }

	public List<Identity> GetOpenIdConnectIdProviders() { }

	public string GetSteamId() { }

	public string GetUnityId() { }

	internal void RemoveIdentity(string typeId) { }

	[CompilerGenerated]
	internal void set_LastPasswordUpdate(Nullable<DateTime> value) { }

	[CompilerGenerated]
	internal void set_Username(string value) { }

	private bool ValidateOpenIdConnectIdProviderName(string idProviderName) { }

}

