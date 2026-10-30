namespace Unity.Services.Authentication;

internal interface ICache
{

	public void DeleteKey(string key) { }

	public string GetString(string key) { }

	public bool HasKey(string key) { }

	public void SetString(string key, string value) { }

}

