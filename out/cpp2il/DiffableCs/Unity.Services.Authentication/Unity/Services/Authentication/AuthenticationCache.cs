namespace Unity.Services.Authentication;

internal class AuthenticationCache : IAuthenticationCache, ICache
{
	private ICloudProjectId m_CloudProjectId; //Field offset: 0x10
	private IProfile m_Profile; //Field offset: 0x18

	public override string CloudProjectId
	{
		 get { } //Length: 160
	}

	private string OldPrefix
	{
		private get { } //Length: 64
	}

	private string Prefix
	{
		private get { } //Length: 132
	}

	public override string Profile
	{
		 get { } //Length: 164
	}

	public AuthenticationCache(ICloudProjectId cloudProjectId, IProfile profile) { }

	public override void DeleteKey(string key) { }

	public override string get_CloudProjectId() { }

	private string get_OldPrefix() { }

	private string get_Prefix() { }

	public override string get_Profile() { }

	internal string GetKey(string key) { }

	internal string GetOldKey(string key) { }

	[CanBeNull]
	public override string GetString(string key) { }

	public override bool HasKey(string key) { }

	public override void Migrate(string key) { }

	public override void SetString(string key, string value) { }

}

