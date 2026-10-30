namespace Unity.Services.Authentication.PlayerAccounts;

internal class UnityPlayerAccountSettings : ScriptableObject
{
	[Flags]
	internal enum SupportedScopesEnum
	{
		OpenId = 1,
		Email = 2,
		OfflineAccess = 4,
	}

	private const string k_DeepLinkUriScheme = "unitydl"; //Field offset: 0x0
	private const string k_DeepLinkUriHostPrefix = "com.unityplayeraccounts."; //Field offset: 0x0
	private static readonly Dictionary<SupportedScopesEnum, String> k_SupportedScopesDictionary; //Field offset: 0x0
	[HideInInspector]
	[SerializeField]
	[Tooltip("Unity Player Account Client ID.")]
	internal string clientId; //Field offset: 0x18
	[HideInInspector]
	[SerializeField]
	internal int scopeMask; //Field offset: 0x20
	[HideInInspector]
	[SerializeField]
	[Tooltip("Override the default redirect uri")]
	internal bool useCustomDeepLinkUri; //Field offset: 0x24
	[HideInInspector]
	[SerializeField]
	[Tooltip("Custom Deep Link URI Scheme")]
	internal string customScheme; //Field offset: 0x28
	[HideInInspector]
	[SerializeField]
	[Tooltip("Custom Deep Link URI Host Prefix")]
	internal string customHost; //Field offset: 0x30

	public string ClientId
	{
		 get { } //Length: 60
		 set { } //Length: 48
	}

	public string DeepLinkUriHostPrefix
	{
		 get { } //Length: 84
	}

	public string DeepLinkUriScheme
	{
		 get { } //Length: 84
	}

	public string Scope
	{
		 get { } //Length: 488
	}

	public SupportedScopesEnum ScopeFlags
	{
		 get { } //Length: 8
		 set { } //Length: 8
	}

	public bool UseCustomUri
	{
		 get { } //Length: 8
	}

	private static UnityPlayerAccountSettings() { }

	public UnityPlayerAccountSettings() { }

	public string get_ClientId() { }

	public string get_DeepLinkUriHostPrefix() { }

	public string get_DeepLinkUriScheme() { }

	public string get_Scope() { }

	public SupportedScopesEnum get_ScopeFlags() { }

	public bool get_UseCustomUri() { }

	public static UnityPlayerAccountSettings Load() { }

	public void set_ClientId(string value) { }

	public void set_ScopeFlags(SupportedScopesEnum value) { }

}

