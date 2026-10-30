namespace Unity.Services.Authentication.Shared;

internal class ApiConfiguration : IApiConfiguration
{
	public const string ISO8601_DATETIME_FORMAT = "o"; //Field offset: 0x0
	[CompilerGenerated]
	private IDictionary<String, String> <DefaultHeaders>k__BackingField; //Field offset: 0x10
	[CompilerGenerated]
	private int <Timeout>k__BackingField; //Field offset: 0x18
	[CompilerGenerated]
	private string <UserAgent>k__BackingField; //Field offset: 0x20
	[CompilerGenerated]
	private string <Username>k__BackingField; //Field offset: 0x28
	[CompilerGenerated]
	private string <Password>k__BackingField; //Field offset: 0x30
	[CompilerGenerated]
	private string <AccessToken>k__BackingField; //Field offset: 0x38
	private string _basePath; //Field offset: 0x40
	private IDictionary<String, String> _apiKey; //Field offset: 0x48
	private IDictionary<String, String> _apiKeyPrefix; //Field offset: 0x50
	private string _dateTimeFormat; //Field offset: 0x58
	private string _tempFolderPath; //Field offset: 0x60

	public override string AccessToken
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 8
	}

	public override IDictionary<String, String> ApiKey
	{
		 get { } //Length: 8
		 set { } //Length: 92
	}

	public override IDictionary<String, String> ApiKeyPrefix
	{
		 get { } //Length: 8
		 set { } //Length: 92
	}

	public override string BasePath
	{
		 get { } //Length: 8
		 set { } //Length: 8
	}

	public override string DateTimeFormat
	{
		 get { } //Length: 8
		 set { } //Length: 100
	}

	public override IDictionary<String, String> DefaultHeaders
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 8
	}

	public override string Password
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 8
	}

	public override int Timeout
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 8
	}

	public override string UserAgent
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 8
	}

	public override string Username
	{
		[CompilerGenerated]
		 get { } //Length: 8
		[CompilerGenerated]
		 set { } //Length: 8
	}

	public ApiConfiguration(IDictionary<String, String> defaultHeaders, IDictionary<String, String> apiKey, IDictionary<String, String> apiKeyPrefix, string basePath) { }

	public ApiConfiguration() { }

	public void AddApiKey(string key, string value) { }

	public void AddApiKeyPrefix(string key, string value) { }

	[CompilerGenerated]
	public override string get_AccessToken() { }

	public override IDictionary<String, String> get_ApiKey() { }

	public override IDictionary<String, String> get_ApiKeyPrefix() { }

	public override string get_BasePath() { }

	public override string get_DateTimeFormat() { }

	[CompilerGenerated]
	public override IDictionary<String, String> get_DefaultHeaders() { }

	[CompilerGenerated]
	public override string get_Password() { }

	[CompilerGenerated]
	public override int get_Timeout() { }

	[CompilerGenerated]
	public override string get_UserAgent() { }

	[CompilerGenerated]
	public override string get_Username() { }

	public override string GetApiKeyWithPrefix(string apiKeyIdentifier) { }

	[CompilerGenerated]
	public override void set_AccessToken(string value) { }

	public override void set_ApiKey(IDictionary<String, String> value) { }

	public override void set_ApiKeyPrefix(IDictionary<String, String> value) { }

	public override void set_BasePath(string value) { }

	public override void set_DateTimeFormat(string value) { }

	[CompilerGenerated]
	public override void set_DefaultHeaders(IDictionary<String, String> value) { }

	[CompilerGenerated]
	public override void set_Password(string value) { }

	[CompilerGenerated]
	public override void set_Timeout(int value) { }

	[CompilerGenerated]
	public override void set_UserAgent(string value) { }

	[CompilerGenerated]
	public override void set_Username(string value) { }

}

