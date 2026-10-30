namespace Unity.Services.Authentication.PlayerAccounts;

internal interface IJwtDecoder
{

	public T Decode(string token) { }

}

