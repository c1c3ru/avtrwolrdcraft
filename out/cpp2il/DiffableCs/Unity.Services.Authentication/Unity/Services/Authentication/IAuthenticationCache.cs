namespace Unity.Services.Authentication;

internal interface IAuthenticationCache : ICache
{

	public string CloudProjectId
	{
		 get { } //Length: 0
	}

	public string Profile
	{
		 get { } //Length: 0
	}

	public string get_CloudProjectId() { }

	public string get_Profile() { }

	public void Migrate(string key) { }

}

