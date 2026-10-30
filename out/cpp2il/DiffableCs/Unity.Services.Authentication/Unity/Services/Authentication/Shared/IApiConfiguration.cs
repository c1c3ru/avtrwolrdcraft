namespace Unity.Services.Authentication.Shared;

internal interface IApiConfiguration
{

	public string AccessToken
	{
		 get { } //Length: 0
		 set { } //Length: 0
	}

	public IDictionary<String, String> ApiKey
	{
		 get { } //Length: 0
		 set { } //Length: 0
	}

	public IDictionary<String, String> ApiKeyPrefix
	{
		 get { } //Length: 0
		 set { } //Length: 0
	}

	public string BasePath
	{
		 get { } //Length: 0
		 set { } //Length: 0
	}

	public string DateTimeFormat
	{
		 get { } //Length: 0
		 set { } //Length: 0
	}

	public IDictionary<String, String> DefaultHeaders
	{
		 get { } //Length: 0
		 set { } //Length: 0
	}

	public string Password
	{
		 get { } //Length: 0
		 set { } //Length: 0
	}

	public int Timeout
	{
		 get { } //Length: 0
		 set { } //Length: 0
	}

	public string UserAgent
	{
		 get { } //Length: 0
		 set { } //Length: 0
	}

	public string Username
	{
		 get { } //Length: 0
		 set { } //Length: 0
	}

	public string get_AccessToken() { }

	public IDictionary<String, String> get_ApiKey() { }

	public IDictionary<String, String> get_ApiKeyPrefix() { }

	public string get_BasePath() { }

	public string get_DateTimeFormat() { }

	public IDictionary<String, String> get_DefaultHeaders() { }

	public string get_Password() { }

	public int get_Timeout() { }

	public string get_UserAgent() { }

	public string get_Username() { }

	public string GetApiKeyWithPrefix(string apiKeyIdentifier) { }

	public void set_AccessToken(string value) { }

	public void set_ApiKey(IDictionary<String, String> value) { }

	public void set_ApiKeyPrefix(IDictionary<String, String> value) { }

	public void set_BasePath(string value) { }

	public void set_DateTimeFormat(string value) { }

	public void set_DefaultHeaders(IDictionary<String, String> value) { }

	public void set_Password(string value) { }

	public void set_Timeout(int value) { }

	public void set_UserAgent(string value) { }

	public void set_Username(string value) { }

}

