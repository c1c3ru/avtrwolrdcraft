namespace Unity.Services.Authentication.PlayerAccounts;

internal interface IBrowserUtils
{

	public bool Bind() { }

	public void Dismiss() { }

	public string GetRedirectUri() { }

	public Task LaunchUrlAsync(string url) { }

}

