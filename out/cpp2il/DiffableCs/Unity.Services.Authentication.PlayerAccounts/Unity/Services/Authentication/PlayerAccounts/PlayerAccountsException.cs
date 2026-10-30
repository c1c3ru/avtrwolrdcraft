namespace Unity.Services.Authentication.PlayerAccounts;

public sealed class PlayerAccountsException : RequestFailedException
{

	private PlayerAccountsException(int errorCode, string message, Exception innerException = null) { }

	internal static PlayerAccountsException Create(int errorCode, string message, Exception innerException = null) { }

}

