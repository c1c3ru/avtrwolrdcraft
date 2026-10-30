namespace Unity.Services.Authentication;

internal interface IAuthenticationExceptionHandler
{

	public RequestFailedException BuildClientInvalidProfileException() { }

	public RequestFailedException BuildClientInvalidStateException(AuthenticationState state) { }

	public RequestFailedException BuildClientSessionTokenNotExistsException() { }

	public RequestFailedException BuildClientUnlinkExternalIdNotFoundException() { }

	public RequestFailedException BuildInvalidCredentialsException() { }

	public RequestFailedException BuildInvalidIdProviderNameException() { }

	public RequestFailedException BuildInvalidPlayerNameException() { }

	public RequestFailedException BuildUnknownException(string error) { }

	public RequestFailedException ConvertException(WebRequestException exception) { }

	public RequestFailedException ConvertException(ApiException exception) { }

}

